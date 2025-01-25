using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI scoreText;

    public void SetScore(int score)
    {
        scoreText.text = "Score: " + score;
    }
}
