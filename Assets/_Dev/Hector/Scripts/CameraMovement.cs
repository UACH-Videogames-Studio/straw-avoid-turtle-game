using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    
    void Update()
    {
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);  
    }
}
