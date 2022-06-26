using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//Created by Maxkcy 6-5-22
public class PlayerMove : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] [Range(2, 8)] private float movementSpeed = 2; 
    
    Rigidbody2D rb;
    private Vector2 _moveDir;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void OnMove(InputValue val) {
        _moveDir = val.Get<Vector2>();                                                   // Debug.Log("<color=green>MoveShoot:</color> " +  $"Move X:{_moveDir.x}, Move Y: {_moveDir.y}");
        _moveDir.Normalize();
    }



    private void Move() {
        rb.velocity = _moveDir * movementSpeed;
    }
}
