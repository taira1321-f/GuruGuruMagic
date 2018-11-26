using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CS_Director : MonoBehaviour {
/**************************変数宣言***************************/
    //定数

    //プライベート変数
    Animator animator;
    Animator CenterAnim;
    Vector2 spos,epos;
    short Chara_num;
    string DIR;
    //プライベート配列

    //パブリック変数
    public GameObject Center;
    public GameObject AgreePanel;
    public GameObject StatusPanel;
    //パブリック配数
    public Sprite[] Chara_Image = new Sprite[4];
/******************************関数*****************************/
    void Start () {
        CenterAnim = Center.GetComponent<Animator>();
        QualitySettings.vSyncCount = 0;     //VSyncをOFFにする
        Application.targetFrameRate = 30;   //ターゲットフレームレート
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
        switch (dir) {
            case "left":
                CenterAnim.SetTrigger("Trigger");
                break;
            case "right":
                float y = Center.transform.eulerAngles.y;
                AnimCheckTrigger(y);
                break;
        }
    }
    void AnimCheckTrigger(float angle) {
        switch ((int)angle) {
            case 0:
                CenterAnim.SetTrigger("Chara1-H");
                break;
            case 72:
                CenterAnim.SetTrigger("H-Chara4");
                break;
            case 144:
                CenterAnim.SetTrigger("Chara4-3");
                break;
            case 216:
                CenterAnim.SetTrigger("Chara3-2");
                break;
            case 288:
                CenterAnim.SetTrigger("Chara2-1");
                break;
        }
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
            Chara_num = Chara_name(obj_b.name);
            obj.GetComponent<Image>().sprite = Chara_Image[Chara_num];
            animator = AgreePanel.GetComponent<Animator>();
            animator.SetTrigger("OpenTrigger");
        }
    }
    short Chara_name(string str) {
        switch (str) {
            case "Chara1":
                return 0;
            case "Chara2":
                return 1;
            case "Chara3":
                return 2;
            case "Chara4":
                return 3;
        }
        return -1;
    }
    //AgreePanelのボタン
    public void Select() {
        PlayerPrefs.SetInt("SelectCharactor", Chara_num);
        SceneManager.LoadScene("HomeScene");
    }
    public void Status_B() {
        animator = StatusPanel.GetComponent<Animator>();
        animator.SetTrigger("OS_Trigger");
    }
    public void Cancel_B() {
        animator = AgreePanel.GetComponent<Animator>();
        animator.SetTrigger("CloseTrigger");
    }
    //StatusPanelのボタン
    public void StatusBack() {
        animator = StatusPanel.GetComponent<Animator>();
        animator.SetTrigger("CS_Trigger");
    }
//↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
}