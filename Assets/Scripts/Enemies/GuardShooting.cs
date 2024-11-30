using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    private GameObject player;

    [SerializeField] private ParticleSystem bloodParticles;
    private AudioManager _audioManager;

    private ParticleSystem _bloodParticlesInstance;


    private float timer;


    private void Awake()
    {
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (player != null)
        {
            float distance = Vector2.Distance(transform.position, player.transform.position);
            if (distance < 5)
            {
                timer += Time.deltaTime;

                if (timer > 1)
                {
                    timer = 0;

                    _audioManager.PlaySFX(_audioManager.EnemyShoot);
                    Shoot();
                }
            }
        }

        // Debug.Log(distance);
    }

    void Shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}