using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Player player = new Player()
        {
            level = 1,
            maxhp = 100,
            power = 500,
            type = "RED"
        };
        Enemy enemy1 = new Enemy()
        {
            maxhp = 100,
            power = 10,
            type = "GREEN",
            interval = 10.0f,
        };
        Enemy enemy2 = new Enemy()
        {
            maxhp = 150,
            power = 15,
            type = "RED",
            interval = 10.0f,
        };
        Enemy enemy3 = new Enemy()
        {
            maxhp = 200,
            power = 20,
            type = "BLUE",
            interval = 10.0f,
        };
    }

    // Update is called once per frame
    void Update()
    {

    }
}
