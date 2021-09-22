using UnityEngine;

public class Ships : MonoBehaviour
{
    public GameObject brokenShips;
    
    private float deathTimer;


    void Update()
    {
        deathTimer += Time.deltaTime;

        if (deathTimer >= 45)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BlackHole"))
        {
            Instantiate(brokenShips, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
