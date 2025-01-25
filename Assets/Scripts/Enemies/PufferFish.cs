using UnityEngine;

public class PufferFish : MonoBehaviour
{
    public GameObject player;
    private float distance;

    private void Update()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);
        Debug.Log(distance);
    }
}
