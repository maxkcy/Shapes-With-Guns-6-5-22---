using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 6-11-22
public class Gun : MonoBehaviour
{
    public GunState GunState;
    [SerializeField] private GameObject _bullet;
    SpriteRenderer sr;


    void Awake()
    {
        OnAwake();
    }
    void OnFire()
    {
        Fire();
    }

    public void Fire()
    {
        if (GunState != GunState.Armed) return;
        GameObject clone = Instantiate(_bullet, (Vector2)transform.position
             + (Vector2)transform.up, Quaternion.identity);
        clone.GetComponent<Bullet>().Init(sr.color, (Vector2)transform.up, transform.parent.gameObject);
    }

    public void OnAwake()
    {
        if (transform.parent.CompareTag("Player"))
        {
            GunState = GunState.Armed;
        }
        else if (transform.parent.CompareTag("NPC"))
        {
            GunState = GunState.WithEnemy;
        }
        sr = GetComponent<SpriteRenderer>();
    }

    public void NPCFire()
    {
        if (GunState != GunState.WithEnemy) return;
        GameObject clone = Instantiate(_bullet, (Vector2)transform.position
             + (Vector2)transform.up, Quaternion.identity);
        clone.GetComponent<Bullet>().Init(sr.color, (Vector2)transform.up, transform.parent.gameObject);
    }

}
