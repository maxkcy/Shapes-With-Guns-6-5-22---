using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
// created by maxkcy 6-6-22
public class Gun : MonoBehaviour
{
    public GunState GunState;

    void Awake() {
        if (transform.parent.CompareTag("Player"))
        {
            GunState = GunState.Armed;
        }
        else if (transform.parent.CompareTag("Enemy"))
        {
            GunState = GunState.WithEnemy;
        }
    }



    void OnFire()
    {
        Debug.Log("<color=green>MoveShoot:</color> Fired a bullet");
        // check if gunstate is armed
    }

    void Update() {

    }
}
