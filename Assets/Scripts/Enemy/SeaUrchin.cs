using UnityEngine;

// Enemy
// Instantiates spines in 8 directions
public class SeaUrchin : MonoBehaviour
{
    public GameObject spinePrefab;
    public float spineSpeed = 5.0f;
    public float spineRate = 1.0f;
    public float spineLifetime = 2.0f;

    private float nextSpineTime;

    void Update()
    {
        if (Time.time > nextSpineTime)
        {
            for (int i = 0; i < 8; i++)
            {
                float angle = i * 45;
                Vector3 direction = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0);
                GameObject spine = Instantiate(spinePrefab, transform.position, Quaternion.LookRotation(Vector3.forward, direction));
                spine.GetComponent<Rigidbody2D>().linearVelocity = direction * spineSpeed;
                Destroy(spine, spineLifetime);
            }
            nextSpineTime = Time.time + spineRate;
        }
    }
}
