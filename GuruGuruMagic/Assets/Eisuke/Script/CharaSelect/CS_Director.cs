using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CS_Director : MonoBehaviour {
/**************************変数宣言***************************/
    //定数
    const int Chara_Max = 4;
    //プライベート変数
    int Lv,Exp;
    string DIR;
    Animator StatusAnim, SelectAnim, CenterAnim;
    Vector2 spos,epos;
    RectTransform sp_rt;
    CharaData s_cd;
    //パブリック変数
    public GameObject Center, AgreePanel, StatusPanel, Text_obj;
    public CharaDataBase cdb;
    //プライベート配列
    Text[] status_text = new Text[4];
/******************************関数*****************************/
    void Start () {
        
        CenterAnim = Center.GetComponent<Animator>();
        StatusAnim = StatusPanel.GetComponent<Animator>();
        SelectAnim = AgreePanel.GetComponent<Animator>();
        for (int i = 0; i < 4; i++) status_text[i] = Text_obj.transform.GetChild(i).GetComponent<Text>();
    }
	void Update () {
        KeyGet(Input.mousePosition);        
	}
    //入力関係
    void KeyGet(Vector2 mpos) {
        if (Input.GetMouseButtonDown(0)){
            spos = new Vector2(mpos.x, mpos.y);
        }
        if (Input.GetMouseButtonUp(0)){
            epos = new Vector2(mpos.x, mpos.y);
            GetDirection(spos, epos);
        }
    }
    void GetDirection(Vector2 s,Vector2 e) {
        float dirX = e.x - s.x;
        float dirY = e.y - s.y;
        string dir = DIR = "none";
        if (Mathf.Abs(dirY) < Mathf.Abs(dirX)){
            if (30 < dirX) dir = "right";
            if (-30 > dirX) dir = "left";
        }else if (Mathf.Abs(dirY) > Mathf.Abs(dirX)){
            if (30 < dirY) dir = "up";
            if (-30 > dirY) dir = "down";
        }else dir = "touch";
        DIR = dir;
        if (dir == "left") CenterAnim.SetTrigger("Trigger");
        else if (dir == "right") CenterAnim.SetTrigger("BackTrigger");
    }

//↓↓↓↓↓↓↓↓↓↓↓↓↓ボタン関連↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
    //ホームに戻る
    public void HomeBack() {
        SceneManager.LoadScene("HomeScene");
    }
    //キャラ選択
    public void CharaSelect(GameObject obj_b) {
        if (DIR == "touch"){
            GameObject obj = AgreePanel.transform.Find("SelectChara_Img").gameObject;
            for (int i = 0; i < Chara_Max; i++){
                if (obj_b.name == cdb.CharaDataList[i].Get_NAME()) {
                    s_cd = cdb.CharaDataList[i];
                    break;
                }
            }
            obj.GetComponent<Image>().sprite = s_cd.Get_CharaImage();
            SelectAnim.SetTrigger("OpenTrigger");
        }
    }
    
    //AgreePanelのボタン
    public void Select() {
        PlayerPrefs.SetInt("SelectCharactor", s_cd.Get_ID());
        SceneManager.LoadScene("HomeScene");
    }
    public void Status_B() {
        GameObject obj = StatusPanel.transform.Find("CharaStatus_Img").gameObject;
        obj.GetComponent<Image>().sprite = s_cd.Get_CharaImage();
        Lv = PlayerPrefs.GetInt("Chara_" + s_cd.Get_NAME() + "_Lv");
        Exp = PlayerPrefs.GetInt("Chara_" + s_cd.Get_NAME() + "_HaveExp");
        int ix = 0;
        status_text[ix++].text = "LV:" + Lv;
        status_text[ix++].text = "HP:" + s_cd.Get_HP(Lv);
        status_text[ix++].text = "ATK:" + s_cd.Get_ATK(Lv);
        status_text[ix++].text = "レベルアップまで" + (s_cd.Get_TOTAL_EXP(Lv + 1) - Exp);
        StatusAnim.SetTrigger("OS_Trigger");
    }
    public void Cancel_B() {
        SelectAnim.SetTrigger("CloseTrigger");
    }
    //StatusPanelのボタン
    public void StatusBack() {
        StatusAnim.SetTrigger("CS_Trigger");
    }
//↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
}