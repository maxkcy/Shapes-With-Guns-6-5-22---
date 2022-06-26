using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuActions : MonoBehaviour
{
    public void OnPlayButtClick()
    {
        SceneManager.LoadScene("Template Scene");
    }
}
