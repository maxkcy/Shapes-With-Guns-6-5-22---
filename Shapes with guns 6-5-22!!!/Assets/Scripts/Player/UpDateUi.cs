using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpDateUi : MonoBehaviour
{
    Health health;
    [SerializeField] public Slider Slider;
    [SerializeField] float offset;
    private void Start()
    {
        health = GetComponent<Health>();
        Slider.value = health.Healthy;
        offset = Slider.transform.GetComponent<RectTransform>().position.y - transform.position.y;
    }

    private void Update()
    {
        Slider.transform.position = new Vector2(transform.position.x, transform.position.y + offset);
    }
}
