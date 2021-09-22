using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotingPlayer : MonoBehaviour
{
    public GameObject player;

    void Update() => player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
}
