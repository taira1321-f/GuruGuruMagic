using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character
{
    protected int level;                       // キャラのレベル
    protected int maxhp;                    // キャラの最大HP
    protected int nowhp;                    // キャラの現在のHP 0になると死ぬ
    protected int power;                     // キャラの攻撃力
    protected int defense;                  // キャラの防御力
    protected string type;                   // キャラの属性

    public abstract void Initialize();
}

public class CharaState : MonoBehaviour
{

    // キャラ、敵の属性
    public enum Elements
    {
        RED,
        BLUE,
        GREEN,
        HEAL,       // 回復(ヒール)
    }

    // キャラクターの状態 (毒などのステータス異常とか)
    public enum CharaEffect
    {
        NONE,

    }

    public int TypeToInt(string type)
    {
        switch (type)
        {
            case "RED":
                return (int)Elements.RED;
            case "BLUE":
                return (int)Elements.BLUE;
            case "GREEN":
                return (int)Elements.GREEN;
            case "HEAL":
                return (int)Elements.HEAL;
            default:
                break;
        }

        return 0;
    }

    public bool IsDead(int hp)
    {
        if (hp <= 0) return true;
        return false;
    }


}
