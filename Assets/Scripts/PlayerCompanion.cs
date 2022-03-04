using UnityEngine;
using System.Collections;

public class PlayerCompanion : MonoBehaviour
{
    public float speed;
    public Transform target;
    public Transform platformTarget;
    private float OrigSp;
    public bool goToPlat;
    public static bool shouldGoToPlat;

    private void Start()
    {

    }

    private void Update()
    {
        if (goToPlat && !platformTarget.Equals(null))
            transform.position = Vector2.MoveTowards(transform.position, platformTarget.position, speed + Time.deltaTime);
        else if(Mathf.Abs(Vector2.Distance(transform.position, target.position)) > 0)
           transform.position = Vector2.MoveTowards(transform.position, target.position, speed + Time.deltaTime);
    }
}