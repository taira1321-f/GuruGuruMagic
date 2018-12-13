using UnityEngine;

[CreateAssetMenu(menuName="Player/CreateData")]
[System.Serializable]
public class CharaData : ScriptableObject
{
    public int ID;
    public string NAME;
    public string ATTRIBUTE;
    public Sprite CharaImage;
    public int[] HP;
    public int[] ATK;
    public int[] LvUp_EXP;

    public int Get_ID() {
        return ID;
    }
    public string Get_NAME() {
        return NAME;    
    }
    public string Get_ATTRIBUTE() {
        return ATTRIBUTE;
    }
    public Sprite Get_CharaImage() {
        return CharaImage;
    }
    public int Get_HP(int nowLv) {
        if (nowLv < 1) nowLv = 1;
        int hp = HP[nowLv - 1];
        return hp;
    }
    public int Get_ATK(int nowLv){
        int atk = ATK[nowLv - 1];
        return atk;
    }
    public int Get_TOTAL_EXP(int nowLv) {
        if (nowLv > 20) {
            Debug.Log("エラー,レベルの数がおかしい");
            return -1;
        }
        int lvup_exp = LvUp_EXP[nowLv-1]; 
        return lvup_exp;
    }
}

