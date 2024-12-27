using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    private Rigidbody2D _rigidbody;
    private Vector2 _movementInput;

    public bool dialogue = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (!dialogue)
        {
            _rigidbody.velocity = _movementInput * _speed;
        }
    }

    public void Move(InputAction.CallbackContext context)
    { 
        _movementInput = context.ReadValue<Vector2>();
    }
}
