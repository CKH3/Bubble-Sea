using UnityEngine;

// Enemy
// Go up and down
public class HumanFish : MonoBehaviour
{
    private float speed = 1.0f;
    private float amplitude = 3.0f;
    private float offset = 0.0f;
    private bool movingUp = true;

    private void Update()
    {
        offset += speed * Time.deltaTime;
        float newY = Mathf.Sin(offset) * amplitude;
        bool newMovingUp = newY > transform.position.y;

        if (newMovingUp != movingUp)
        {
            movingUp = newMovingUp;
            transform.Rotate(180f, 0f, 0f);
        }

        transform.position = new Vector3(transform.position.x, transform.position.y + newY * Time.deltaTime, transform.position.z);
    }
}
