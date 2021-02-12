using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    bool zoneEnter;
    public float camX;
    public float playerX;
    public float camY;
    public float playerY;
    public GameObject cam;
    public GameObject player;


    private void FixedUpdate()
    {
        if (zoneEnter == true && Input.GetKeyDown(KeyCode.E))
        {
            cam.transform.Translate(camX, camY, 0);
            player.transform.Translate(playerX, playerY, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            zoneEnter = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            zoneEnter = false;
        }
    }
}
