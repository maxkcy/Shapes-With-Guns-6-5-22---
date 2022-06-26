using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCmovement : MonoBehaviour // 6-11-22
{
    [SerializeField] float MovementSpeed = 5f;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("ChangeToRandDir", 0f, Random.Range(.3f, 10f));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Wall"))
        {
            Debug.Log("I the NPC, collided with a wall");
            ChangeToRandDir();
        }
    }
    void ChangeToRandDir()
    {
        Vector2 dir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        dir.Normalize();
        rb.velocity = dir * MovementSpeed;
    }
}
