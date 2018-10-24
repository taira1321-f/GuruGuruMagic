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
        BlueSlime,
        GreenSlime,
        Goblin,
        Dwarf,
    }

    protected EnemyName name;     // キャラの名前
    protected float interval;                // 何秒おきに攻撃するかの設定
    protected float atkTime;               // この値が0になると敵が行動する

    override void Initialize()
    {
        name = EnemyName.None;
        level = 1;
        maxhp = 100;
        nowhp = maxhp;
        power = 10;
        defense = 10;
        type = "RED";
        interval = 10.0f;
        atkTime = interval;
    }
}
