using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Oxygen oxygenManager;

    public float bubble_radius = 0.5f;
    public Vector3 checkpointPosition = Vector3.zero;

    public float oxygen = 100.0f;
    public float max_oxygen = 100.0f;
    public float oxygen_loss_rate = 1.0f;
    public float oxygen_gain_amount = 20.0f;
    

    public int score = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        oxygenManager = GetComponent<Oxygen>();
        oxygenManager.setMaxOxygen((int)max_oxygen);
    }

    public void LoseOxygen(float amount)
    {
        oxygen -= amount;
        if (oxygen < 0)
        {
            oxygen = 0;
        }
        oxygenManager.setOxygen((int)oxygen);
    }


    public void GainOxygen(float amount)
    {
        oxygen += amount;
        if (oxygen > max_oxygen)
        {
            oxygen = max_oxygen;
        }
        oxygenManager.setOxygen((int)oxygen);
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

    public void Respawn()
    {
        transform.position = checkpointPosition;
        oxygen = max_oxygen;
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

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Checkpoint"))
        {
            checkpointPosition = other.transform.position;
            other.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        }
    }
    

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Oxygen"))
        {
            GainOxygen(oxygen_gain_amount);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            Respawn();
        }
    }
    
}
