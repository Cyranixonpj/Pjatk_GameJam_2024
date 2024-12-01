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
        private Rigidbody2D _rigidbody;
        private Animator _animator;
        
        private Vector2 _moveDirection, _mousePosition;
        private Camera _camera;
        

        private Vector2 _lastMoveDirection;

        void Awake()
        {
            _camera = Camera.main;
            _rigidbody = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
        }

        void Update()
        {
            //TODO:Check if moving diagonally makes u move faster
            _xInput = Input.GetAxisRaw("Horizontal");
            _yInput = Input.GetAxisRaw("Vertical");
            if ((_xInput == 0 && _yInput == 0) && _moveDirection.x != 0 || _moveDirection.y != 0)
            {
                _lastMoveDirection = _moveDirection;
            }
            Animate();

            //Fire Bullet
            if (Input.GetButtonDown("Fire1") && _moveDirection.magnitude > 0.1) weapon.Fire();
        }

        private void FixedUpdate()
        {
            _speedX = _xInput * speed;
            _speedY = _yInput * speed;
            Move();
            Vector2 aimDirection = new Vector2(_xInput, _yInput) - _rigidbody.position;

            _moveDirection = new Vector2(_speedX, _speedY).normalized;
        }

        private void Move()
        {
            _rigidbody.velocity = new Vector2(_speedX, _speedY);
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

        private void Animate()
        {
            _animator.SetFloat("AnimMoveX", _moveDirection.x);
            _animator.SetFloat("AnimMoveY", _moveDirection.y);
            _animator.SetFloat("AnimMoveMagnitude", _moveDirection.magnitude);
            _animator.SetFloat("AnimLastMoveX", _lastMoveDirection.x);
            _animator.SetFloat("AnimLastMoveY", _lastMoveDirection.y);
        }
    }
}
