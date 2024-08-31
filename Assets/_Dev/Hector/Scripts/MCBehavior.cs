using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MCBehavior : MonoBehaviour
{
    public UnityEvent playerDeath;
    [SerializeField] private float moveSpeed = 2.2f;
    [SerializeField] private float rotationSpeed = 0.8f;
    private bool allowControl = true;

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


    // Función encargada de manejar los inputs del jugador. Es decir, qué teclas/botones está presionando.
    private void InputHandler()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, 0, -rotationSpeed);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, 0, rotationSpeed);
        }
    }
}
