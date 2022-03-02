using UnityEngine;
using System.Collections;

public class PlayerCompanion : MonoBehaviour
{
    public float speed;
    public Transform target;
    private float OrigSp;

    private void Start()
    {

    }

    private void Update()
    {
        if(Mathf.Abs(Vector2.Distance(transform.position, target.position)) > 0)
           transform.position = Vector2.MoveTowards(transform.position, target.position, speed + Time.deltaTime);
    }
}