using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTargeting : MonoBehaviour
{
    Transform _target = null;
    Color _gunColor;
    Gun _gun;
    bool _canShoot;
    void Start()
    {
        _canShoot = true;
        _gunColor = GetComponent<OnSpawn>().GunColor;
        _gun = GetComponentInChildren<Gun>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_target != null) LookAndShoot(ref _target);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("NPC") || collision.CompareTag("Player")) 
        {
            if (collision.transform.GetComponent<OnSpawn>().SkinColor.Equals(_gunColor))
            {
                _target = collision.transform;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_target != null)
        {
            if (_target.Equals(collision.transform))
            {
                _target = null;
            }
        }
    }

    private void LookAndShoot(ref Transform _target)
    {
        Vector2 dir = _target.position - transform.position;
        transform.up = dir;
        if (_canShoot)
        {
            _gun.NPCFire();
            _canShoot = false;
            StartCoroutine(ResetCanShoot());
        }


        IEnumerator ResetCanShoot()
        {
            yield return new WaitForSeconds(.3f);
            _canShoot = true;
        }
    }



}
