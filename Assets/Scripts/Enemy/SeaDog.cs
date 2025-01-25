using UnityEngine;

// Enemy
// AOE damage to simulate sound wave attack
// The sound wave is a circle collider
public class SeaDog : MonoBehaviour
{
    public GameObject soundWavePrefab;

    public float soundWaveLifetime = 2.0f;
    
    private float nextSoundWaveTime;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSoundWaveTime)
        {
            GameObject soundWave = Instantiate(soundWavePrefab, transform.position, Quaternion.identity);
            Destroy(soundWave, soundWaveLifetime);
            nextSoundWaveTime = Time.time + soundWaveLifetime;
        }
    }
}
