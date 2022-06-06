using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//Created by Maxkcy 6-5-22
public class MoveShoot : MonoBehaviour
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
    }

    void OnFire() {
        Debug.Log("<color=green>MoveShoot:</color> Fired a bullet");
    }

    private void Move() {
        rb.velocity = new Vector2(_moveDir.x * movementSpeed, _moveDir.y * movementSpeed);
    }
}
