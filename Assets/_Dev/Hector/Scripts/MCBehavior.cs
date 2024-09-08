using System;
using Stariluz.GameControl;
using UnityEngine;
using UnityEngine.Events;

public class MCBehavior : MonoBehaviour
{
    public UnityEvent playerDeath;
    [SerializeField] private float moveSpeed = 2.2f;
    [SerializeField] private float maxVelocity = 4f;
    [SerializeField] private float rotationSpeed = 3f;
    [SerializeField] private float maxRotationSpeed = 30f;
    [SerializeField] private float decelerationFactor = 1f;
    // [SerializeField] private float rotationSpeed = 0.8f;
    private bool allowControl = true;

    [SerializeField] protected string inputHorizontalAxis = "Horizontal";
    [SerializeField] protected string inputVerticalAxis = "Vertical";
    [SerializeField] protected JoysticController joysticController;
    [SerializeField] protected GameManager gameManager;
    protected Rigidbody2D rb;
    public float rotationTime = 0.5f;
    protected bool isInvincible = false;
    /* private float targetAngle;
    private float elapsedTime = 0f; */



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (allowControl)
        {
            Vector2 input = GetPCMovement();

            transform.Translate(input.y * Vector2.up * moveSpeed * Time.deltaTime);
            transform.Rotate(0, 0, -Math.Sign(input.x) * rotationSpeed);
        }
        // Se supone que este código que sigue es para cuando el jugador gana
        else
        {
            isInvincible = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Killzone") && !isInvincible)
        {
            Destroy(gameObject);
            playerDeath.Invoke();
            Debug.Log("TE PERDISTE EN EL OCEANO");
        }
        if (other.gameObject.CompareTag("Enemy") && !isInvincible)
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

        Vector2 movement = Vector2.zero;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            movement.y = 1;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            movement.y = -1;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            movement.x = -1;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            movement.x = 1;
        }
        return movement;
    }

    public Vector2 GetMobileMovement()
    {
        return joysticController.movement;
    }
}
