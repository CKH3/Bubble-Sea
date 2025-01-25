using UnityEngine;

// Let player control the bubble movement using arrow keys to move left, right, up, and down
public class PlayerController : MonoBehaviour
{

    private const float BUBBLE_RADIUS = 0.5f;

    private float xRange;
    private float yRange;

    public float speed = 10.0f;
    public float acceleration = 8.0f;
    public float deceleration = 8.0f;
    public float maxSpeed = 10.0f;

    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        xRange = Camera.main.aspect * Camera.main.orthographicSize - BUBBLE_RADIUS;
        yRange = Camera.main.orthographicSize - BUBBLE_RADIUS;
    }

    // Update is called once per frame
    void Update()
    {
        // Get input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate target velocity
        Vector3 targetVelocity = new Vector3(horizontalInput, verticalInput, 0) * speed;

        // Accelerate or decelerate to target velocity
        if (targetVelocity.magnitude > 0)
        {
            velocity = Vector3.MoveTowards(velocity, targetVelocity, acceleration * Time.deltaTime);
        }
        else
        {
            velocity = Vector3.MoveTowards(velocity, Vector3.zero, deceleration * Time.deltaTime);
        }

        // Clamp velocity to max speed
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        // Move the bubble
        transform.Translate(velocity * Time.deltaTime);

        // Keep the bubble within the screen
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
            // keep y velocity and set x velocity to 0
            velocity = new Vector3(0, velocity.y, 0);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
            // keep y velocity and set x velocity to 0  
            velocity = new Vector3(0, velocity.y, 0);
        }
        if (transform.position.y < -yRange)
        {
            transform.position = new Vector3(transform.position.x, -yRange, transform.position.z);
            // keep x velocity and set y velocity to 0
            velocity = new Vector3(velocity.x, 0, 0);
        }
        if (transform.position.y > yRange)
        {
            transform.position = new Vector3(transform.position.x, yRange, transform.position.z);
            // keep x velocity and set y velocity to 0
            velocity = new Vector3(velocity.x, 0, 0);
        
        }
    }
}
