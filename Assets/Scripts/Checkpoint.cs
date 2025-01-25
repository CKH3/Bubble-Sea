using UnityEngine;
using UnityEngine.UI;

public class Checkpoint : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private Sprite flagClosed;

    [SerializeField]
    private Sprite flagOpen;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetFlagClosed()
    {
        spriteRenderer.sprite = flagClosed;
    }

    public void SetFlagOpen()
    {
        spriteRenderer.sprite = flagOpen;   
    }

}
