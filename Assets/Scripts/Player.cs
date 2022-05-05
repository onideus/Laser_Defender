using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    
    private Vector2 _rawInput;
    
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 delta = _rawInput * (moveSpeed * Time.deltaTime);
        transform.position += delta;
    }

    private void OnMove(InputValue value)
    {
        _rawInput = value.Get<Vector2>();
        Debug.Log(_rawInput);
    }
}
