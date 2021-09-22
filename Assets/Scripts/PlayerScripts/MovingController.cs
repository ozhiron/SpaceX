using UnityEngine;

public class MovingController : MonoBehaviour
{
    [Header("Particle")]
    public GameObject wEffect;

    [Header("Movement")]
    public Rigidbody2D rb;
    public float speed;

    [Header("Camera for rotate")]
    public Camera cam;

    private Vector2 mousePos;

    [System.Obsolete]
    void Update()
    {
        if (GameManger.instance.isDead)
            rb.velocity = new Vector2(0, 0);

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Move();
    }

    void FixedUpdate()
    {
        if (GameManger.instance.isDead == false)
        {
            LookForward(mousePos);
        }
    }

    [System.Obsolete]
    private void Move()
    {
        if (GameManger.instance.isDead == false)
        {
            if (Input.GetKey(KeyCode.W))
                rb.AddRelativeForce(new Vector2(0, speed));
            if (Input.GetKeyDown(KeyCode.W))
                wEffect.GetComponent<ParticleSystem>().startLifetime = 1.72f;
            if (Input.GetKeyUp(KeyCode.W))
                wEffect.GetComponent<ParticleSystem>().startLifetime = 0f;
        }
    }

    private void LookForward(Vector2 mousePos)
    {
        Vector2 dir = mousePos - rb.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
