using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public enum Elements
    {
        NONE,
        RED,
        BLUE,
        GREEN,
        VENOM,
        HEAL,
        PHEAL,
        JAMA,
        BUFF,
        GUARD,
        BOOST,
    }

    /* 属性の相性的な
     * 要素はダメージの倍率
     */
    protected float[,] damageRate = new float[,] {
        { 1.0f, 0.5f, 1.5f },   // 赤
        { 1.5f, 1.0f, 0.5f },   // 青
        { 0.5f, 1.5f, 1.0f },   // 緑
    };


    protected int level;                       // キャラのレベル
    protected int maxhp;                    // キャラの最大HP
    public int MaxHP
    {
        get;
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
    protected Elements type;             // キャラの属性

    public abstract void Initialize();


    // 死んでるかどうかの判定
    public bool IsDead()
    {
        if (nowhp <= 0) return true;
        return false;
    }


}

