using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefillOxygen : MonoBehaviour
{
    public int tankLevel = 15;

    public GameObject SpawnOnPickUp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.oxygen += tankLevel;
            //AudioSource PAud = collision.gameObject.GetComponent<AudioSource>();
            //if (PAud != null)
            {

            }
            if (SpawnOnPickUp != null)
            {
                Instantiate(SpawnOnPickUp, transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }
    }
}
