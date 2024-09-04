using UnityEngine;

public class Turtle : MonoBehaviour
{
    protected new Rigidbody2D rigidbody;
    [SerializeField] public bool isMovementToRight = true;
    [SerializeField] protected float velocityFactor = 100;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = new Vector2(velocityFactor*(isMovementToRight?1:-1), rigidbody.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        // rigidbody.velocity = new Vector2(velocityFactor*(isMovementToRight?1:-1), rigidbody.velocity.y);
    }
}
