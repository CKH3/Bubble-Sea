using UnityEngine;

public class Sunfish : MonoBehaviour
{
    public float speed = 1.0f;
    public GameObject target;

    private Vector3 zAxis = new Vector3(0, 0, 1);

    void FixedUpdate()
    {
        transform.RotateAround(target.transform.position, zAxis, speed * Time.deltaTime);
    }
}
