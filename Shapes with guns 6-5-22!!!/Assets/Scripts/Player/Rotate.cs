using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Rotate : MonoBehaviour
{
    [SerializeField] float _rotSpd = 135f;
    float rot;
    Vector2 _mPos;
    Camera cam;
    Rigidbody2D rb;
    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.SetRotation(rb.rotation + -rot * _rotSpd * Time.deltaTime);
    }
    private void OnRotate(InputValue val)
    {
        rot = val.Get<float>();
    }


/*    private void RotateToMouse()
    {
        Vector2 dir = (_mPos - (Vector2)transform.position).normalized;
        float deltaZAngle = Quaternion.FromToRotation(transform.up, dir).eulerAngles.z;
        transform.Rotate(new Vector3(0, 0, deltaZAngle));
    }*/
}
