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

    [SerializeReference]
    protected MCInput movementInput = new();

    void Update()
    {
        if (allowControl)
        {
            InputHandler();
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


    // Función encargada de conectar el input con el movimiento
    private void InputHandler()
    {
        Vector2 movement = movementInput.GetBehaviourValue();
        transform.Translate(movement.y * Vector2.up * moveSpeed * Time.deltaTime);
        transform.Rotate(0, 0, -Math.Sign(movement.x) * rotationSpeed);
    }


    protected class MCInput : MultiplatformBehaviour<Vector2>
    {
        [SerializeField] protected string inputHorizontalAxis = "Horizontal";
        [SerializeField] protected string inputVerticalAxis = "Vertical";
        [SerializeField] protected JoysticController joysticController;

        public override Vector2 PCBehaviour()
        {
            float movementX = Input.GetAxis(inputHorizontalAxis);
            float movementY = Input.GetAxis(inputVerticalAxis);
            Vector2 movement = new Vector2(movementX, movementY);


            return movement;
        }

        public override Vector2 TouchMobileBehaviour()
        {
            return joysticController.movement;
        }
    }

}
