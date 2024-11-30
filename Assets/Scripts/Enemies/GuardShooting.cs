using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    private GameObject player;
    [SerializeField] private ParticleSystem bloodParticles;

    private ParticleSystem _bloodParticlesInstance;

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

    private void SpawnBloodParticles(Vector3 direction)
    {
        Vector3 impactDirection = (transform.position - direction).normalized;

        Quaternion spawnRotation = Quaternion.LookRotation(impactDirection);

        _bloodParticlesInstance = Instantiate(bloodParticles, transform.position, spawnRotation);
    }

    public void WaitAndSpawnBloodParticles(Vector2 direction)
    {
        //TODO: Fix Spawn rotation
        SpawnBloodParticles(direction);
        //TODO: Add Death animation
        Destroy(gameObject, 0.1f);
    }
}