using UnityEngine;

public class FoodController : MonoBehaviour
{
    public GameObject ship;

    private int dir;
    private float speed = 1f;

    private void Awake() => dir = Random.Range(0, 4);

    private void Start() => ship.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));

    private void Update() => transform.Translate(Vector2.up * speed * Time.deltaTime);
}