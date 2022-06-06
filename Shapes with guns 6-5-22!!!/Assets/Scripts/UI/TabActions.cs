using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TabActions : MonoBehaviour // created by maxkcy 6-5-22
{
    RectTransform inventory;
    private bool _isTabOpen;
    float openPos = 0f, closedPos = -100f;

    private void Awake() {
        inventory = transform.parent.GetComponent<RectTransform>();
        // check playerprefs if tab is open or closed
        // set inventory position and isTabOpen. ... but for now
        Debug.Log("<color=blue>UI TabActions: inventory.position.y: </color>" + inventory.position.y);
        if (inventory.position.y == openPos)
        {
            _isTabOpen = true;
        }
        else
        {
            _isTabOpen = false;
        }
    }

    
    public void OnTabClicked() {
        if (_isTabOpen)
        {
            inventory.DOAnchorPosY(closedPos, 1.5f);
            _isTabOpen = false;
        }
        else
        {
            inventory.DOAnchorPosY(openPos, 1.5f);
            _isTabOpen = true;
        }
    }
}
