using UnityEngine;

public class Oxygen : MonoBehaviour
{
    // keep moving up and down
    private float oxygenSpeed = 3.0f;
    private float oxygenAmplitude = 1.0f;
    private float oxygenOffset = 0.0f;

    void Update()
    {
        oxygenOffset += oxygenSpeed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, transform.position.y + Mathf.Sin(oxygenOffset) * oxygenAmplitude * Time.deltaTime, transform.position.z);
    }
}
