using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    [SerializeField]
    private Animator playerAnimator;
    [SerializeField]
    private Animator playerIconAnimator;

    
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

        if (oxygen <= 40)
        {
            playerAnimator.SetBool("isLowOxygen", true);
            playerIconAnimator.SetBool("isLowOxygen", true);
        }
        else
        {
            playerAnimator.SetBool("isLowOxygen", false);
            playerIconAnimator.SetBool("isLowOxygen", false);
        }

        // if (transform.position.y < -121)
        // {
        //     Debug.Log("WinWinWIn");
        //     SceneManager.LoadSceneAsync("WinScene");
        // }
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
        else if (other.gameObject.CompareTag("FinishLine"))
        {
            SceneManager.LoadSceneAsync("WinScene");
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
