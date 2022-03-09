using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionPlatform : MonoBehaviour
{
    //All locations that the companion can become a platform at
    public List<EmptyPlatform> allEmptyPlats = new List<EmptyPlatform>();
    //The current closest to the player location from above 
    private Transform curEmptyPlat;
    private int curPlatNum;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] temp = GameObject.FindGameObjectsWithTag("EmptyPlatform");
        for (int i = 0; i < temp.Length; i++)
        {
            allEmptyPlats.Add(temp[i].GetComponent<EmptyPlatform>());
            allEmptyPlats[i].index = i;
            allEmptyPlats[i].companion = this;
        }
    }

    public void MakePlatform()
    {
        GameObject plat = curEmptyPlat.gameObject;
        plat.GetComponent<BoxCollider2D>().enabled = true;
        foreach (EmptyPlatform platform in allEmptyPlats)
        {
            if (platform.index != curPlatNum)
                platform.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    public void SetCurrentPlat(int index)
    {
        curPlatNum = index;
        curEmptyPlat = allEmptyPlats[index].transform;
    }

    public IEnumerator WaitToDisable()
    {
        yield return new WaitForSeconds(0.75f);
        allEmptyPlats[curPlatNum].GetComponent<BoxCollider2D>().enabled = false;
        FindObjectOfType<PlayerCompanion>().goToPlat = false;
        FindObjectOfType<PlayerCompanion>().platformTarget = null;
        print("disabled");
        if (curPlatNum != -1)
        {
            curPlatNum = -1;
        }
    }
}
