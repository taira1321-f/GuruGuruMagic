using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TestSave : MonoBehaviour {

    public int HP;  //キャラクターHP
    public int ATK; //キャラクター攻撃力
    public int LV;  //キャラクターレべル
    public int EXP; //キャラクター経験値
    //public string ELEMENT;//キャラクター属性
    //public bool Flg;
    //[SerializeField]
    //private GameObject Obj;

    public void SetHP(int hp)
    {
        this.HP = hp;
    }

    public void SetATK(int atk)
    {
        this.ATK = atk;
    }

    public void SetLV (int lv)
    {
        this.LV = lv;
    }

    public void SetEXP (int exp)
    {
        this.EXP = exp;
    }

    //public void SetELEMENT (string element)
    //{
    //    this.ELEMENT = element;
    //}

    //public void SetFlg(bool flg)
    //{
    //    this.Flg = flg;
    //}

    //public void SetObj(GameObject obj)
    //{
    //    this.Obj = obj;
    //}

    public int GetHP()
    {
        return HP;
    }

    public float GetATK()
    {
        return ATK;
    }

    public int GetLV()
    {
        return LV;
    }

    public int GetEXP()
    {
        return EXP;
    }

    //public string GetELEMENT()
    //{
    //    return ELEMENT; 
    //}

    //public bool IsFlg()
    //{
    //    return Flg;
    //}

    //public GameObject GetObj()
    //{
    //    return Obj;
    //}

    public string GetNormalData()
    {
        return "HP:" + HP  +  "ATK:"  +  ATK  +  "LV:"  +  LV  +  "EXP"  +  EXP; 
          //  + "ELEMENT" + ELEMENT + "Flg:" + Flg + "Obj:" + Obj;
    }

    public string GetJsonData()
    {
        return JsonUtility.ToJson(this);
    }

    

}
