using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSpawn : MonoBehaviour
{
    public Color[] ColorArray;
    public HashSet<Color> GunColorHash;
    public Color SkinColor;
    public Color GunColor;
    SpriteRenderer sr;
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        SetColors();
    }
    void SetColors()
    {
        ColorArray = new Color[]{  Color.red, Color.green, Color.blue, Color.yellow, Color.white, Color.magenta, Color.black, Color.cyan };
        SkinColor = (Color)ColorArray.GetValue(Random.Range((int)0, (int)ColorArray.Length));
        sr.color = SkinColor;
        do
        {
            GunColor = (Color)ColorArray.GetValue(Random.Range((int)0, (int)ColorArray.Length));
        }
        while (GunColor.Equals(SkinColor));
        Transform child = transform.Find("Gun");
        child.GetComponent<SpriteRenderer>().color = GunColor;
    }
}
