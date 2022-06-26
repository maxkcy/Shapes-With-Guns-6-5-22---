using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 5f;
    GameObject parentDNDamage;
    Rigidbody2D rb;
    float time;
    SpriteRenderer sr;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.smoothDeltaTime;
        if (time > 5f)
        {
            Destroy(gameObject);
        }
    }

    public void Init(Color color, Vector2 upDir, GameObject parentDNDamage)
    {
        sr.color = color;
        rb.velocity = bulletSpeed * upDir;
        this.parentDNDamage = parentDNDamage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("NPC") || collision.collider.CompareTag("Player"))
        {
            if (collision.transform.GetComponent<OnSpawn>().SkinColor.Equals(sr.color))
            {
                if (collision.gameObject != parentDNDamage)
                {
                    collision.transform.GetComponent<Health>().TakeDamage();
                    Destroy(gameObject);
                }
            }
        }
    }
}
