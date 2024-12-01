using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    private GameObject player;
    private Rigidbody2D rb;
    public float force;
    private Animator _animator;

    private float timer;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        
        Vector3 direction = (player.transform.position - transform.position).normalized;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        
        float rot = Mathf.Atan2(-direction.y,-direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,rot+180);

        _animator = GetComponent<Animator>();
        
        
    }
    
    void Update()
    {
        timer += Time.deltaTime;
        if (timer>10)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // TODO playerHealth zabieranie życia playerowi 
            // other.gameObject.GetComponent<playerHealth>()
            GameObject policeCanvas = other.gameObject.GetComponent<CanvasHolder>().policeCanvas;
            _animator.SetTrigger("Hit");
            rb.velocity = Vector2.zero;
            Destroy(gameObject,0.5f);
            policeCanvas.GetComponent<PoliceCanvas>().Show();
            Destroy(other.gameObject);
            
        }
    }
    
    
}
