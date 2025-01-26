using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private ScoreUI scoreManager;
    private OxygenUI oxygenManager;

    public float bubble_radius = 0.5f;
    public Vector3 checkpointPosition = Vector3.zero;

    public float oxygen = 100.0f;
    public float max_oxygen = 100.0f;
    public float oxygen_loss_rate = 5.0f;
    public float oxygen_gain_amount = 100.0f;
    

    public int score = 0;

    private Animator animator;

    
    // Start is called before the first frame update
    void Start()
    {
        oxygenManager = GetComponent<OxygenUI>();
        scoreManager = GetComponent<ScoreUI>();
        animator = GetComponent<Animator>();

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
        scoreManager.SetScore(score);
    }

    public void Respawn()
    {
        transform.position = checkpointPosition;
    }

    public void GameOver()
    {
        Debug.Log("Game Over!");
        // animator.SetTrigger("Gameover");
        SceneController.instance.LoadScene("GameoverScene");
    }

    public void Win()
    {
        Debug.Log("You Win!");
    }

    public void Update()
    {
        LoseOxygen(oxygen_loss_rate * Time.deltaTime);

        if (oxygen <= 0)
        {
            GameOver();
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Checkpoint"))
        {
            checkpointPosition = other.transform.position;
            other.gameObject.GetComponent<Checkpoint>().SetFlagOpen();
        }
        else if (other.gameObject.CompareTag("Pearl"))
        {
            AddScore(1);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            Respawn();
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
