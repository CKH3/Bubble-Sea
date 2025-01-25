using Unity.VisualScripting;
using UnityEngine;

public class PooDestroy : MonoBehaviour
{
    public float currentTime;
    public float DestroyTime = 3f;

    private void Update()
    {
        currentTime += Time.deltaTime;

        if(currentTime >= DestroyTime)
        {
            Destroy(this.gameObject);
        }
    }
}
