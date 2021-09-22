using UnityEngine;

public class TargetForMiniMap : MonoBehaviour
{
    public Transform target;
    
    void Update() => transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
}
