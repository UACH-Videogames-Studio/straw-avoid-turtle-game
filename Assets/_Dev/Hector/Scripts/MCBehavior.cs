using System;
using Stariluz.GameControl;
using UnityEngine;
using UnityEngine.Events;

public class MCBehavior : MonoBehaviour
{
    public UnityEvent playerDeath;
    [SerializeField] private float moveSpeed = 2.2f;
    [SerializeField] private float maxVelocity = 4f;
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
            Vector2 movement = GetPCMovement();
            if (movement.magnitude != 0)
            {
                rb.AddForce(moveSpeed * Time.deltaTime * movement.normalized, ForceMode2D.Impulse);

                float currentAngle = rb.rotation;
                float targetAngle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg - 90;

                float smoothedAngle = Mathf.LerpAngle(
                    currentAngle,
                    targetAngle,
                    maxRotationSpeed * Time.deltaTime / Mathf.Abs(Mathf.DeltaAngle(currentAngle, targetAngle))
                    );
                rb.MoveRotation(smoothedAngle);
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
        // Se supone que este código que sigue es para cuando el jugador gana
        else
        {
            isInvincible = true;
            /* float moveTime = 1.0f;
            Vector3 startPosition = transform.position;
            Vector3 targetPosition = new Vector3(startPosition.x, (gameManager.amountOfScreensForGameEnd * 9f) + 4.5f, startPosition.z);
            float elapsedTime = 0f;

            float endRotationTime = 1.0f;

            float currentZAngle = transform.eulerAngles.z;
            float targetAngle = Mathf.Abs(currentZAngle - 0) <= Mathf.Abs(currentZAngle - 180) ? 0f : 180f;

            if (elapsedTime < moveTime)
            {
                elapsedTime += Time.deltaTime;
                float t = elapsedTime / moveTime;

                transform.position = Vector3.Lerp(startPosition, targetPosition, t);
                float t2 = Mathf.Clamp01(elapsedTime / rotationTime);

                // Smoothly interpolate rotation
                float newAngle = Mathf.LerpAngle(transform.eulerAngles.z, targetAngle, t2);
                transform.rotation = Quaternion.Euler(0f, 0f, newAngle);
            }
            else
            {
                // Ensure the GameObject reaches the exact target position
                transform.position = targetPosition;
                this.enabled = false; // Disable the script after movement
            } */
            /* float startAngle = transform.eulerAngles.z;
            targetAngle = Mathf.Abs(startAngle - 0) <= Mathf.Abs(startAngle - 180) ? 0f : 180f;

            if (elapsedTime < rotationTime)
            {
                elapsedTime += Time.deltaTime;
                float t = elapsedTime / rotationTime;

                // Linearly interpolate rotation
                float newAngle = Mathf.Lerp(startAngle, targetAngle, t);
                transform.rotation = Quaternion.Euler(0f, 0f, newAngle);
            }
            else
            {
                // Ensure the rotation is exactly at the target angle at the end
                transform.rotation = Quaternion.Euler(0f, 0f, targetAngle);
                this.enabled = false; // Disable the script after rotation
            } */
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
        float movementX = Input.GetAxisRaw(inputHorizontalAxis);
        float movementY = Input.GetAxisRaw(inputVerticalAxis);
        Vector2 movement = new Vector2(movementX, movementY);

        return movement;
    }

    public Vector2 GetMobileMovement()
    {
        return joysticController.movement;
    }
}
