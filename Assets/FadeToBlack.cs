using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FadeToBlack : MonoBehaviour
{
    [SerializeField]
    private Image fadeImage;
    [SerializeField]
    private float duration = 1.5f;


    private Image endingImage;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject endingPanel;

    // Change the alpha of the image to 1
    public void FadeOut()
    {
        // fadeImage.DOFade(1, duration);
        fadeImage.DOFade(1, duration).OnComplete(() => ShowEnding());
    }

    public void FadeIn()
    {
        fadeImage.DOFade(0, duration).onComplete += () => player.SetActive(false);
    }

    public void ShowEnding()
    {
        endingPanel.SetActive(true);
        FadeIn();
    }
    
}
