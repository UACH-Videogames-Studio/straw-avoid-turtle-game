using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private bool shouldContinueMoving = true;
    
    void Update()
    {
        if (shouldContinueMoving)
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);  
    }
}
