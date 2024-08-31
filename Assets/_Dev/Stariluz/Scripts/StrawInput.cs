using System;
using UnityEngine;

public class StrawInput : MonoBehaviour
{
    public delegate void OnStartMovementEvent(Vector2 direction);
    public delegate void OnStopMovementEvent();
    public OnStartMovementEvent onStartMovement;
    public OnStopMovementEvent onStopMovement;

    protected bool isMovementActive=false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float y = Input.GetAxis("vertical");
        float x = Input.GetAxis("horizontal");
        if (x != 0 || y != 0)
        {
            Vector2 direction = new Vector2(x, y);
            direction.Normalize();
            isMovementActive=true;
            onStartMovement?.Invoke(direction);
        }else if(isMovementActive){
            isMovementActive=false;
            onStopMovement?.Invoke();
        }
    }
}
