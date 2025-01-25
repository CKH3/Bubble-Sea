using Unity.VisualScripting;
using UnityEngine;

public class Dolphin : MonoBehaviour
{
    public float Speed = 1f;
    private int direction = 1;

    // Update is called once per frame
    void Update()
    {
        float move = Speed * Time.deltaTime;
        transform.Translate(Vector2.left * Speed * direction);
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
