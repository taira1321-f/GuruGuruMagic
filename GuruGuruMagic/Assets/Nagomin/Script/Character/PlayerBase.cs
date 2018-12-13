using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : Character
{
    // CharaData chara = new CharaData();

    protected int exp;
    
    public void Initialize(CharaData chara)
    {
        level = 1;
        exp = chara.Get_TOTAL_EXP(level);
        maxhp = chara.Get_HP(level);
        nowhp = maxhp;
        power = chara.Get_ATK(level);
        defense = 50;
        type = chara.Get_ATTRIBUTE();
    }

}