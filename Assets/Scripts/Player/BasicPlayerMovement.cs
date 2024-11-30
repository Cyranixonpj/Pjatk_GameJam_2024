using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Player
{
    public class BasicPlayerMovement : MonoBehaviour
    {

        [SerializeField]private float speed;
        [SerializeField]private Weapon weapon;
        private float _speedX, _speedY, _xInput, _yInput;
        Rigidbody2D _rigidbody;
        
        private Vector2 _moveDirection, _mousePosition;
        private Camera _camera;

        void Awake()
        {
            _camera = Camera.main;
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            //TODO:Check if moving diagonally makes u move faster
            _xInput = Input.GetAxisRaw("Horizontal");
            _yInput = Input.GetAxisRaw("Vertical");
            _moveDirection = new Vector2(_xInput, _yInput).normalized;
            if (_camera) _mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);

            //Fire Bullet
            if (Input.GetButtonDown("Fire1")) weapon.Fire();
        }

        private void FixedUpdate()
        {
            _speedX = _xInput * speed;
            _speedY = _yInput * speed;
            _rigidbody.velocity = new Vector2(_speedX, _speedY);
            Vector2 aimDirection = _mousePosition - _rigidbody.position;
            float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
            _rigidbody.rotation = aimAngle;
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.CompareTag("APAP"))
            {
                PlayerHealth playerHealth = GetComponent<PlayerHealth>();
                playerHealth.Heal(20);
                Destroy(collider.gameObject);
            }
        }
    }
}
