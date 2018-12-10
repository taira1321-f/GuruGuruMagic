using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[System.Serializable]
public class CharaData : ScriptableObject
{
    public string NAME;
    public string ATTRIBUTE;
    public int[] HP;
    public int[] ATK;
    public int[] LvUp_EXP;
    public string Get_NAME() {
        return NAME;    
    }
    public string Get_ATTRIBUTE() {
        return ATTRIBUTE;
    }
    public int Get_HP(int nowLv) {
        int hp = HP[nowLv - 1];
        return hp;
    }
    public int Get_ATK(int nowLv){
        int atk = ATK[nowLv - 1];
        return atk;
    }
    public int Get_TOTAL_EXP(int nowLv) {
        if (nowLv == 20) return -1;
        int lvup_exp = LvUp_EXP[nowLv]; 
        return lvup_exp;
    }
}

