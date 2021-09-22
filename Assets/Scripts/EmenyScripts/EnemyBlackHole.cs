using UnityEngine;

public class EnemyBlackHole : MonoBehaviour
{
    public Animator animator;
    public float HP = 5;

    private void Start() => animator = GetComponent<Animator>();

    private void Update()
    {
        if (HP <= 0)
        {
            animator.SetBool("IsDead", true);
            GetComponent<CircleCollider2D>().enabled = false;
            Destroy(gameObject, 2);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BlackHole"))
            Destroy(gameObject);

        if (collision.gameObject.CompareTag("Player"))
            collision.gameObject.GetComponent<PlayerController>().HP -= Random.Range(19, 24);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            HP--;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
        }
    }
}
