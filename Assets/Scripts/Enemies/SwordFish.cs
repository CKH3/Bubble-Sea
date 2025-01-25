using UnityEngine;

public class SwordFish : MonoBehaviour
{
    public float Speed = 1f;
    private int direction = 1;

    [SerializeField]
    private float DashTime = 3f;
    [SerializeField]
    private float DashSpeed = 3f;
    [SerializeField]
    private float currentTime = 0f;
    [SerializeField]
    bool isDashing = false;
    [SerializeField]
    private float currentSpeed;

    private void Start()
    {
        currentSpeed = Speed;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        

        if (!isDashing)
        {
            if (currentTime >= DashTime)
            {
                currentSpeed = DashSpeed;
                currentTime = 0f;
                isDashing = true;
                Debug.Log("isDashing");
            }
        }
        else
        {
            if (currentTime >= DashTime)
            {
                currentSpeed = Speed;
                currentTime = 0f;
                isDashing = false;
                Debug.Log("NotDashing");
            }
        }
    }

    void FixedUpdate()
    {
        float move = currentSpeed * Time.deltaTime;
        transform.Translate(Vector2.left * currentSpeed * direction);
    }

    void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            direction *= -1;
            Vector3 newScale = transform.localScale;
            newScale.x *= -1;
            transform.localScale = newScale;
        }
    }
}