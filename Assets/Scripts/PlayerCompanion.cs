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

    [SerializeField] public Transform[] Positions;
    [SerializeField] float objectSpeed;

    int nextPosIndex;
    Transform nextPos;
    // Start is called before the first frame update
    void Start()
    {
        nextPos = Positions[0];
    }

    private void Update()
    {
        MoveGameObject();
        if (goToPlat && !platformTarget.Equals(null))
            transform.position = Vector2.MoveTowards(transform.position, platformTarget.position, speed + Time.deltaTime);
        else if (Mathf.Abs(Vector2.Distance(transform.position, target.position)) > 0)
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed + Time.deltaTime);
    }

    void MoveGameObject()
    {
        if (target.position == nextPos.position)
        {
            nextPosIndex++;

            if (nextPosIndex >= Positions.Length)
            {
                nextPosIndex = 0;
            }
            nextPos = Positions[nextPosIndex];
        }
        else
        {
            target.position = Vector3.MoveTowards(target.position, nextPos.position, objectSpeed * Time.deltaTime);
        }
    }
}