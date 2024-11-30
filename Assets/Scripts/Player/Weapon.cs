using System;
using UnityEngine;

namespace Player
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private GameObject[] bulletPrefabs;
        [SerializeField] private float bulletSpeed;
        [SerializeField] private Transform firePoint;
        [SerializeField] private float fireCooldown;
        private float _fireTimer;

        public void Update()
        {
            _fireTimer -= Time.deltaTime;
        }

        public void Fire()
        {
            if (_fireTimer <= 0)
            {
                _fireTimer = fireCooldown;
                GameObject bullet = bulletPrefabs[FindProjectile()];
                bullet.transform.position = firePoint.position;
                bullet.GetComponent<Bullet>().Activate();
                bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
            }
        }

        private int FindProjectile()
        {
            for (var i = 0; i < bulletPrefabs.Length; i++)
                if (!bulletPrefabs[i].activeInHierarchy)
                    return i;
            return 0;
        }
    }
}
