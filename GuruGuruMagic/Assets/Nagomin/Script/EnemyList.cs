using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemylist : EnemyBase {

    public void RedSlime(int lv)
    {
        name = EnemyName.RedSlime;
        level = lv;
        maxhp = 100;
        nowhp = maxhp;
        power = 10;
        defense = 10;
        type = "RED";
        interval = 10.0f;
        atkTime = interval;
    }

    public void BlueSlime(int lv)
    {
        name = EnemyName.BlueSlime;
        level = lv;
        maxhp = 100;
        nowhp = maxhp;
        power = 10;
        defense = 10;
        type = "RED";
        interval = 10.0f;
        atkTime = interval;
    }

    public void GreenSlime(int lv)
    {
        name = EnemyName.RedSlime;
        level = lv;
        maxhp = 100;
        nowhp = maxhp;
        power = 10;
        defense = 10;
        type = "RED";
        interval = 10.0f;
        atkTime = interval;
    }


}
