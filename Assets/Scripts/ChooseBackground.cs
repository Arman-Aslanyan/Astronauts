using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseBackground : MonoBehaviour
{
    Image spr;
    public Sprite[] backgrounds;

    // Start is called before the first frame update
    void Start()
    {
        spr = GetComponent<Image>();
        int rand = Mathf.RoundToInt(Random.Range(0, 1.05f));
        print("working");
        spr.sprite = backgrounds[rand];
    }
}
