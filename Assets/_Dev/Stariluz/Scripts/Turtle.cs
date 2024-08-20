using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : MonoBehaviour
{
    protected new Rigidbody2D rigidbody;
    [SerializeField] protected bool isRightMovement = true;
    [SerializeField] private float _velocityFactor = 100;

    [SerializeField]
    protected float velocityFactor
    {
        get
        {
            return _velocityFactor;
        }
        set
        {
            _velocityFactor = value;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        // rigidbody.velocity = new Vector2(velocityFactor, rigidbody.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.velocity = new Vector2(velocityFactor*(isRightMovement?1:-1), rigidbody.velocity.y);
    }
}
