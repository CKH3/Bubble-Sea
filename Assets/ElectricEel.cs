using UnityEngine;

// Enemy
// Go diagonally between top right and bottom left
public class ElectricEel : MonoBehaviour
{
    private float speed = 1.0f;
    private float amplitudeX = 3.0f;
    private float amplitudeY = 3.0f;
    private float offsetX = 0.0f;
    private float offsetY = 0.0f;
    private bool movingUp = true;

    private void Update()
    {
        offsetX += speed * Time.deltaTime;
        offsetY += speed * Time.deltaTime;
        float newX = Mathf.Sin(offsetX) * amplitudeX;
        float newY = Mathf.Sin(offsetY) * amplitudeY;
        bool newMovingUp = newY > transform.position.y;

        if (newMovingUp != movingUp)
        {
            movingUp = newMovingUp;
            transform.Rotate(0f, 180f, 0f);
        }

        transform.position = new Vector3(transform.position.x + newX * Time.deltaTime, transform.position.y + newY * Time.deltaTime, transform.position.z);
    }

}
