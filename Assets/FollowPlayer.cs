using UnityEngine;

// Follow player in y-axis
public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - player.position;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, player.position.y + offset.y, transform.position.z);
    }
}
