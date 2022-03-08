using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Oxygen : MonoBehaviour
{
    public int _Oxygen = 80;
    public Slider slider;

    public float time;
    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = _Oxygen;
        slider.value = _Oxygen;
    }

    // Update is called once per frame
    void Update()
    {
        if(time >= 1f)
        {
            _Oxygen--;
            SetOxygen();
            time = 0;
        }
        else
        {
            time += Time.deltaTime;
        }
    }
    public void SetOxygen()
    {
        slider.value -= 1;
    }
}
