using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GuardShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    private GameObject player;

    [SerializeField] private ParticleSystem bloodSystem;
    private AudioManager _audioManager;

    private ParticleSystem _bloodParticlesInstance;
    private Animator _animator;


    private float timer;


    private void Awake()
    {
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        _animator = GetComponent<Animator>();
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
                    
                    SetGuardDirection();
                    
                    Shoot();
                }
            }
        }
    }

    void Shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
    
    private void SetGuardDirection()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;

        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            
            if (direction.x > 0)
            {
                _animator.SetTrigger("Right"); 
            }
            else
            {
                _animator.SetTrigger("Left"); 
            }
        }
        else
        {
            
            if (direction.y > 0)
            {
                _animator.SetTrigger("Up"); 
            }
            else
            {
                _animator.SetTrigger("Down"); 
            }
        }
    }
    
    public void SpawnBlood()
    {
        Debug.Log("Spawn Blood");
        bloodSystem = Instantiate(bloodSystem, transform.position, Quaternion.identity);
    }
}