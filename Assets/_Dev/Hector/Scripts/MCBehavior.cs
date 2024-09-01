using System;
using Stariluz.GameControl;
using UnityEngine;
using UnityEngine.Events;

public class MCBehavior : MonoBehaviour
{
    public UnityEvent playerDeath;
    [SerializeField] private float moveSpeed = 2.2f;
    [SerializeField] private float maxVelocity = 4f;
    [SerializeField] private float decelerationFactor = 1f;
    // [SerializeField] private float rotationSpeed = 0.8f;
    private bool allowControl = true;

    [SerializeField] protected string inputHorizontalAxis = "Horizontal";
    [SerializeField] protected string inputVerticalAxis = "Vertical";
    [SerializeField] protected JoysticController joysticController;
    protected Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (allowControl)
        {
            Vector2 movement = GetPCMovement();
            if (movement.magnitude != 0)
            {
                rb.AddForce(moveSpeed * Time.deltaTime * movement.normalized, ForceMode2D.Impulse);
                float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg - 90;
                rb.MoveRotation(angle);
            }
            else if (rb.velocity.magnitude > 0.1)
            {
                rb.AddForce(decelerationFactor * Time.deltaTime * -rb.velocity, ForceMode2D.Impulse);
            }
            else
            {
                rb.velocity = Vector2.zero;
            }

            if (rb.velocity.magnitude > maxVelocity)
            {
                rb.velocity = rb.velocity.normalized * maxVelocity;
            }
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
        rb.velocity = Vector2.zero;
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
