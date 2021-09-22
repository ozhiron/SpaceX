using UnityEngine;

public class Bullet : MonoBehaviour
{
    float timer;
    
    //void Update() => transform.Translate(Vector2.up * 25 * Time.deltaTime);

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 2) Destroy(gameObject);
    }
}
