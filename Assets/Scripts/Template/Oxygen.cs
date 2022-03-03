using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oxygen : MonoBehaviour
{
    public float _Oxygen = 80;

    private float time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(time >= 1f)
        {
            _Oxygen--;
            time = 0;
        }
        else
        {
            time += Time.deltaTime;
        }
    }
}
