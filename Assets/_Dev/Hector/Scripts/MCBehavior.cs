using System;
using Stariluz.GameControl;
using UnityEngine;
using UnityEngine.Events;

public class MCBehavior : MonoBehaviour
{
    public UnityEvent playerDeath;
    [SerializeField] private float moveSpeed = 2.2f;
    [SerializeField] private float rotationSpeed = 0.8f;
    private bool allowControl = true;

    [SerializeField] protected string inputHorizontalAxis = "Horizontal";
    [SerializeField] protected string inputVerticalAxis = "Vertical";
    [SerializeField] protected JoysticController joysticController;
    
    void Update()
    {
        if (allowControl)
        {
            Vector2 movement = GetPCMovement();
            transform.Translate(movement.y * Vector2.up * moveSpeed * Time.deltaTime);
            transform.Rotate(0, 0, -Math.Sign(movement.x) * rotationSpeed);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Killzone"))
        {
            Destroy(gameObject);
            playerDeath.Invoke();
            Debug.Log("TE PERDISTE EN EL OCEANO");
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            playerDeath.Invoke();
            Debug.Log("TE MATO UNA TORTUGA. Y TU A ELLA.");
        }
    }


    public void SetAllowControl(bool value)
    {
        allowControl = value;
    }

    public Vector2 GetPCMovement()
    {
        float movementX = Input.GetAxisRaw(inputHorizontalAxis);
        float movementY = Input.GetAxisRaw(inputVerticalAxis);
        Vector2 movement = new Vector2(movementX, movementY);


        return movement;
    }

    public Vector2 GetTouchMovement()
    {
        return joysticController.movement;
    }
}
