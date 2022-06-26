using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI NumOfNPCstxt;
    [SerializeField] Transform NPCContainer;
    public int ChildCount;
    void Start()
    {
        UpdateNumOfNPCs();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateNumOfNPCs()
    {
        ChildCount = NPCContainer.childCount;
        NumOfNPCstxt.text = $"NPC Shapes remaining: {ChildCount}";
        if ( ChildCount <= 0 )
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
