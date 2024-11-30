using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    private GameObject player;

    private float timer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);
        // Debug.Log(distance);
        
        if (distance < 5)
        {
            timer += Time.deltaTime;

            if (timer > 1)
            {
                timer = 0;
                shoot();
            }
        }
    }


    void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}