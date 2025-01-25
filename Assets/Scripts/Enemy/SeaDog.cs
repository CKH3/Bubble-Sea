using UnityEngine;

// Enemy
// AOE damage to simulate sound wave attack
// The sound wave is a circle collider
public class SeaDog : MonoBehaviour
{
    private Animator animator;

    public GameObject soundWavePrefab;

    public float soundWaveLifetime = 2.0f;
    
    private float nextSoundWaveTime;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Time.time > nextSoundWaveTime)
        {
            animator.SetTrigger("Swipe");
            nextSoundWaveTime = Time.time + soundWaveLifetime;
        }
    }

    // Method to spawn the sound wave
    public void SpawnSoundWave()
    {
        GameObject soundWave = Instantiate(soundWavePrefab, transform.position, Quaternion.identity);
        Destroy(soundWave, soundWaveLifetime);
    }
}
