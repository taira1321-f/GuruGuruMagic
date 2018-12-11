using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyBase : Character
{
    // 敵キャラの名前のリスト
    protected enum EnemyName
    {
        None,
        RedSlime,
        GreenSlime,
        BlueSlime,
        // PoisonSlime,
        RedDwarf,
        GreenDwarf,
        BlueDwarf,
        RedDragon,
        Knight,
        Ork,
        Witch,
    }

    protected EnemyName name;     // キャラの名前
    protected float interval;                // 何秒おきに攻撃するかの設定
    protected float atkTime;               // この値が0になると敵が行動する

    public int GetDamage(int dmg)
    {
        NowHP -= dmg;
        Debug.Log("HP:" + NowHP);

        if (IsDead())
        {
            Debug.Log("しにました");
            Destroy(this.gameObject);
        }


        return dmg;
    }


    public override void Initialize()
    {
        name = EnemyName.None;
        level = 1;
        maxhp = 1000;
        nowhp = maxhp;
        power = 10;
        defense = 10;
        type = Elements.RED;
        interval = 10.0f;
        atkTime = interval;
    }
}
