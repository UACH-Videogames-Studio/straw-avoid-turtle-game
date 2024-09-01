using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtlesSpawner : MonoBehaviour
{
    public bool isMovementToRight = false;
    void Start()
    {
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log((other, other.CompareTag("Enemy")));
            Destroy(other.gameObject);
        }
    }
}
