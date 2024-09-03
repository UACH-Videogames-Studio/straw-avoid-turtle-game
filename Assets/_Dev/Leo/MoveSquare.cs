using UnityEngine;

public class MoveSquare : MonoBehaviour
{
    [SerializeField] float movementSpeed = 1;
    void Update()
    {
        transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
    }
}