using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float bubble_radius = 0.5f;

    public float oxygen = 100.0f;
    public float max_oxygen = 100.0f;
    public float oxygen_loss_rate = 1.0f;
    public float oxygen_gain_amount = 20.0f;
    

    public int score = 0;
    
    public void LoseOxygen(float amount)
    {
        oxygen -= amount;
        if (oxygen < 0)
        {
            oxygen = 0;
        }
    }


    public void GainOxygen(float amount)
    {
        oxygen += amount;
        if (oxygen > max_oxygen)
        {
            oxygen = max_oxygen;
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
    }

    public void Reset()
    {
        oxygen = max_oxygen;
        score = 0;
    }

    public void GameOver()
    {
        Debug.Log("Game Over!");
    }

    public void Win()
    {
        Debug.Log("You Win!");
    }

    public void Update()
    {
        LoseOxygen(oxygen_loss_rate * Time.deltaTime);
    }

    // public void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.CompareTag("Oxygen"))
    //     {
    //         GainOxygen(oxygen_gain_amount);
    //         Destroy(other.gameObject);
    //     }
    //     else if (other.CompareTag("Enemy"))
    //     {
    //         GameOver();
    //         Destroy(gameObject);
    //         Time.timeScale = 0;
    //     }
    // }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Oxygen"))
        {
            GainOxygen(oxygen_gain_amount);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            GameOver();
            Destroy(gameObject);
            Time.timeScale = 0;
        }
    }
    
}
