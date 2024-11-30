using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float projectileDamage;
        [SerializeField] private float lifeTime;
        private float _lifeTimer;
        [SerializeField] private string layerName;
        
        private CapsuleCollider2D _capsuleCollider2D;
        private bool _hit;
        private void Awake()
        {
            _capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        }

        private void Update()
        {
            _lifeTimer -= Time.deltaTime;
            if (_lifeTimer <= 0)
            {
                Deactivate();
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            _hit = true;
            _capsuleCollider2D.enabled = false;
            if (other.gameObject.layer == LayerMask.NameToLayer(layerName) && other.isTrigger)
            {
                //TODO: Deal dmg
            }

            Deactivate();
        }

        private void Deactivate()
        {
            gameObject.SetActive(false);
        }

        public void Activate()
        {
            gameObject.SetActive(true);
            _lifeTimer = lifeTime;
            _hit = false;
            _capsuleCollider2D.enabled = true;
        }
    }
}
