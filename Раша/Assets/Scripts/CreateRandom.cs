using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRandom : MonoBehaviour
{
    int choose;
    public float camY;
    public float playerY;
    public float camX;
    public float playerX;
    public bool boy;
    public bool girl;
    public GameObject cam;
    public GameObject player;

    void Start()
    {
        choose = Random.Range(0, 2);

        if (choose == 0)
        {
            boy = true;
            cam.transform.Translate(camX, camY, 0);
            player.transform.Translate(playerX, playerY, 0);
        }

        else if (choose == 1)
        {
            girl = true;
            cam.transform.Translate(0, 0, 0);
            player.transform.Translate(0, 0, 0);
        }
    }

    void Update()
    {
        
    }
}
