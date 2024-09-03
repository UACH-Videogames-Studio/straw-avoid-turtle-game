using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    private bool shouldContinueMoving = true;
    private bool isMovementStopSequenceActive = false;
    protected float movementStopDuration = 9f;
    protected float elapsedTime = 0f;
    
    void Update()
    {
        if (shouldContinueMoving)
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);  

        // Función para que la cámara se detenga pasada una pantalla (la final)
        if (isMovementStopSequenceActive)
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime >= movementStopDuration)
            {
                SetShouldContinueMovement(false);
                elapsedTime = 0f;

                // LEO AQUÍ ES DONDE PONES EL CÓDIGO
            }
        }
    }

    public void SetShouldContinueMovement(bool value)
    {
        shouldContinueMoving = value;
    }

    public void SetMovementStopSequence(bool value)
    {
        isMovementStopSequenceActive = value;
    }
}
