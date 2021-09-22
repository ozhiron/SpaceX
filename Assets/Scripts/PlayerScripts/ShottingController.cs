using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShottingController : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnPos;

    private GameManger gm;
    private float shootForce = 25;

    void Start()
    {
        gm = GameManger.instance;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && GameManger.instance.isDead == false)
            Shoot();

    }

    private void Shoot()
    {
        
        gm.shootSource.clip = gm.shootClip;
        gm.shootSource.Play();

        GameObject newBullet = Instantiate(bullet, spawnPos.position, spawnPos.rotation);
        Rigidbody2D rbBullet = newBullet.GetComponent<Rigidbody2D>();
        rbBullet.AddForce(spawnPos.up * shootForce, ForceMode2D.Impulse);
    }
}
