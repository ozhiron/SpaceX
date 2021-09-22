using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.15f;

    Vector3 velocity = Vector3.zero;

    void FixedUpdate()
    {
        Vector3 targerPos = target.position;

        targerPos.z = transform.position.z;

        transform.position = Vector3.SmoothDamp(transform.position, targerPos, ref velocity, smoothTime);
    }
}
