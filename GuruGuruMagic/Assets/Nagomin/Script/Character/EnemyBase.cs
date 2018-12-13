using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyBase : Character
{
    // E_EnemyStatus eStatus = new E_EnemyStatus();

    protected float interval;                // 何秒おきに攻撃するかの設定
    protected float atkTime;               // この値が0になると敵が行動する
    protected bool bossFlg;
    public bool boss_Flg
    {
        get { return bossFlg; }
    }


    public void Initialize(E_EnemyStatus eStatus)
    {
        name = eStatus.get_Name();
        maxhp = eStatus.get_MaxHp();
        nowhp = maxhp;
        power = eStatus.get_Atk();
        defense = 10;
        type = eStatus.get_Attribute();
        interval = eStatus.get_AtkTime();
        atkTime = interval;
        bossFlg = eStatus.get_bossflg();
    }
}
