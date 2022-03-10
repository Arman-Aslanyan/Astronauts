using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefillOxygen : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Oxygen tank = other.GetComponent<Oxygen>();
            tank.time = 0;
            tank.slider.value = tank.slider.maxValue;
            tank._Oxygen = (int)tank.slider.maxValue;
        }
    }
}
