using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public enum Elements
    {
        NONE,
        FIRE,
        THUNDER,
        WATER,
        VENOM,
        HEAL,
        SLOW,
        BUFF,
        GUARD,
        BOOST,
    }


    /* 属性の相性的な
     * 要素はダメージの倍率
     */

    protected string name;     // キャラの名前
    protected int level;                       // キャラのレベル
    protected int maxhp;                    // キャラの最大HP
    public int MaxHP
    {
        get { return maxhp; }
        set
        {
            maxhp = value;
        }
    }
    protected int nowhp;                    // キャラの現在のHP 0になると死ぬ
    public int NowHP
    {
        get { return nowhp; }
        set
        {
            nowhp = Mathf.Min(value, maxhp);
        }
    }
    protected int power;                     // キャラの攻撃力
    protected int defense;                  // キャラの防御力
    protected string type;             // キャラの属性

    struct status
    {
        bool IsVenom;
        bool IsDVenom;
        bool IsSlow;
        bool IsSlow2;
        bool IsBuff;
        int BoostCnt;
    }

    // public abstract void Initialize();


    // 死んでるかどうかの判定
    public bool IsDead(int hp)
    {
        if (hp <= 0) return true;
        return false;
    }


}

