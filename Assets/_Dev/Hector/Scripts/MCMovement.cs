using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2.2f;
    [SerializeField] private float rotationSpeed = 0.8f;

    void Update()
    {
        InputHandler();
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

    void OnTriggerEnter2D(Collider2D other) 
    {
        // Código de muerte
        Debug.Log("FIN DEL JUEGO");
    }
}
