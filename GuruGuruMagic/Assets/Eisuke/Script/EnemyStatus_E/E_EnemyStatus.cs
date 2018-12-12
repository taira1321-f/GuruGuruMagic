using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
[System.Serializable]
public class E_EnemyStatus : ScriptableObject {

    public string Name;
    public string Attribute;
    public int Max_Hp;
    public int Atk;
    public int Atk_Time;
    public bool boss_flg;

    public string get_Name() { return Name; }
    public string get_Attribute() { return Attribute; }
    public int get_MaxHp() { return Max_Hp; }
    public int get_Atk() { return Atk; }
    public int get_AtkTime() { return Atk_Time; }
    public bool get_bossflg() { return boss_flg; }
}
