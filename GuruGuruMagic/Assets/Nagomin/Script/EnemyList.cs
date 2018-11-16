using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyList : EnemyBase {

    public void RedSlime(int lv)
    {
        name = EnemyName.RedSlime;
        level = lv;
        maxhp = 100;
        nowhp = maxhp;
        power = 10;
        defense = 10;
        type = Elements.RED;
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
        type = Elements.GREEN;
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
        type = Elements.BLUE;
        interval = 10.0f;
        atkTime = interval;
    }

    public void RedDwarf(int lv)
    {
        name = EnemyName.RedDwarf;
        level = lv;
        maxhp = 200;
        nowhp = maxhp;
        power = 20;
        defense = 20;
        type = Elements.RED;
        interval = 15.0f;
        atkTime = interval;
    }

    public void GreenDwarf(int lv)
    {
        name = EnemyName.GreenDwarf;
        level = lv;
        maxhp = 200;
        nowhp = maxhp;
        power = 20;
        defense = 20;
        type = Elements.GREEN;
        interval = 15.0f;
        atkTime = interval;
    }

    public void BlueDwarf(int lv)
    {
        name = EnemyName.BlueDwarf;
        level = lv;
        maxhp = 200;
        nowhp = maxhp;
        power = 20;
        defense = 20;
        type = Elements.BLUE;
        interval = 15.0f;
        atkTime = interval;
    }


}
