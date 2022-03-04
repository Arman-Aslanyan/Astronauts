using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyPlatform : MonoBehaviour
{
    public int index;
    public CompanionPlatform companion;
    private PlayerCompanion star;
    private Transform player;
    private int num;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
        star = companion.GetComponent<PlayerCompanion>();
        GetComponent<BoxCollider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(Vector2.Distance(transform.position, player.position)) <= 5)
        {
            num++;
            if (num == 1)
            {
                PlayerHasCameInReach();
            }
        }
        else if (!PlayerCompanion.shouldGoToPlat)
        {
            star.goToPlat = false;
            star.platformTarget = null;
            //PlayerCompanion.shouldGoToPlat = false;
        }
    }

    public void PlayerHasCameInReach()
    {
        companion.SetCurrentPlat(index);
        companion.MakePlatform();
        star.platformTarget = transform;
        star.goToPlat = true;
        PlayerCompanion.shouldGoToPlat = true;
        num = 0;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        StartCoroutine(companion.WaitToDisable());
    }
}
