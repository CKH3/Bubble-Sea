using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Seabird : MonoBehaviour
{
    public float Speed = 1f;
private int direction = 1;

public Rigidbody2D pooPrefab;
public float pooSpeed;
public float pooCD = 2f;
public float pooTimer = 0f;



// Update is called once per frame
void Update()
{
    float move = Speed * Time.deltaTime;
    transform.Translate(Vector2.left * Speed * direction);

    pooTimer += Time.deltaTime;
    if (pooTimer >= pooCD)
    {
        poo();
    }
}

void OnCollisionEnter2D(UnityEngine.Collision2D collision)
{
    if (collision.gameObject.CompareTag("Obstacle"))
    {
        direction *= -1;
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }
}
private void poo()
{
    Rigidbody2D star = Instantiate(pooPrefab, new Vector2(transform.position.x, transform.position.y), transform.rotation) as Rigidbody2D;

    star.GetComponent<Rigidbody2D>().AddForce(transform.up * pooSpeed);
    pooTimer = 0f;
}
}
