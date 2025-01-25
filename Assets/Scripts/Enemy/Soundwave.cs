using UnityEngine;

public class Soundwave : MonoBehaviour
{
    private float soundWaveRadius = 0;
    private float soundWaveExpansionSpeed = 3.0f;

    void Update()
    {
        soundWaveRadius += soundWaveExpansionSpeed * Time.deltaTime;
        transform.localScale = new Vector3(soundWaveRadius, soundWaveRadius, 1);
    }
    
}
