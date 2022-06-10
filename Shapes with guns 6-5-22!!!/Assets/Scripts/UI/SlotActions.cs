using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotActions : MonoBehaviour
{
    public Gun slotGun;
    GunDrag playersGunDrag;
    Color slotColor;
    Color ogColor;
    SpriteRenderer gunSr;
    Image image;
    void Start()
    {
        playersGunDrag = FindObjectOfType<GunDrag>();
        image = GetComponent<Image>();
        ogColor = image.color;
    }

    void Update()
    {
        
    }

    public void OnSlotClicked()
    {
        if ((playersGunDrag.Gun?.GunState == GunState.GettingDragged)
            && slotGun == null)
        {
            Debug.Log(playersGunDrag.Gun?.GunState + "I'm adding a gun to the slot");
            slotGun = playersGunDrag.Gun;
            playersGunDrag.Gun.GunState = GunState.InSlot;
            gunSr = slotGun.GetComponent<SpriteRenderer>();
            slotColor = gunSr.color;
            image.color = slotColor;
            slotGun.gameObject.SetActive(false);
            
        }
        else if (playersGunDrag.Gun == null && slotGun != null)
        {
            slotGun.gameObject.SetActive(true);
            playersGunDrag.Gun = slotGun;
            playersGunDrag.Gun.GunState = GunState.GettingDragged;
            slotGun = null;
            Debug.Log("I removed a gun from the slot");
            image.color = ogColor;
            
        }
        else
        {
            Debug.Log("why clicked me man?");
        }

    }
}
