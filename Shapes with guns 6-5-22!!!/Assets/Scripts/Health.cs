using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    Gun gun;
    [SerializeField] public int Healthy = 10;
    UpDateUi upDateUi;
    GameObject parent;
    LevelManager lvlMan;
    private void Start()
    {
        gun = GetComponentInChildren<Gun>();
        upDateUi = GetComponent<UpDateUi>();
        parent = transform.parent.gameObject;
        lvlMan = FindObjectOfType<LevelManager>();
    }
    public void TakeDamage()
    {
        Healthy -= 1;
        if (upDateUi != null)
        {
            upDateUi.Slider.value = Healthy;
        }
        if (Healthy <= 0)
        {
            gun.transform.parent = null;
            gun.GunState = GunState.OnGround;
            if (transform.CompareTag("Player"))
            {
                Debug.Log("<color=green>Health Player:</color> ok i should be sent back to menu in 5 secs now");
                BackToMenu();
            }
            Destroy(gameObject);
            Destroy(parent);
            lvlMan.UpdateNumOfNPCs();
        }
        void BackToMenu()
        {
            Debug.Log("<color=green>Health Player:</color> Coroutine... hold on now");
            SceneManager.LoadScene("Menu");
        }

    }
   
}
