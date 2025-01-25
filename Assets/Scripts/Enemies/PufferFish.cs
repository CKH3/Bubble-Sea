using UnityEngine;

public class PufferFish : MonoBehaviour
{
    public GameObject player;
    public float destroyDistance;
    private float distance;
    private Animator anim;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);
        Debug.Log(distance);

        if (distance <= destroyDistance)
        {
            anim.SetTrigger("Alert");
        }

    }

    public void DestroyFish()
    {
        Destroy(gameObject);
    }
}
