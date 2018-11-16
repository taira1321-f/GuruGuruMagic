using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CS_Director : MonoBehaviour {
    /**************************変数宣言***************************/
    //定数
    enum SWIPE { NONE, LEFT, RIGHT };
    const float cnt_max = 1.0f;
    const int ix_max = 5;
    //プライベート変数
    Animator animator;
    SWIPE s_type;
    Vector2 spos,epos;
    float cnt;
    int c_ix,old_ix;
    int Chara_num;
    //プライベート配列
    Vector3[] Chara_Index = { new Vector3(0, 0, 0), new Vector3(0, 72, 0), new Vector3(0, 144, 0), new Vector3(0, 216, 0), new Vector3(0, 288, 0), };
    //パブリック変数
    public GameObject Center;
    public GameObject AgreePanel;
    public GameObject StatusPanel;
    //パブリック配数
    public Sprite[] Chara_Image = new Sprite[4];
    /******************************関数*****************************/
    void Start () {
        QualitySettings.vSyncCount = 0;     //VSyncをOFFにする
        Application.targetFrameRate = 60;   //ターゲットフレームレート
        cnt = 0;
        c_ix = old_ix = 0;
	}
	void Update () {
        if (s_type != SWIPE.NONE) Swipe_Roll();
        else KeyGet(Input.mousePosition);
	}
    //選択回転処理
    void Swipe_Roll() {
        if (cnt <= cnt_max){
            cnt += Time.deltaTime;
            Quaternion q1 = Quaternion.Euler(Chara_Index[old_ix]);
            Quaternion q2 = Quaternion.Euler(Chara_Index[c_ix]);
            Center.transform.rotation = Quaternion.Lerp(q1, q2, cnt);
        }else{
            s_type = SWIPE.NONE;
            cnt = 0;
        }
    }
    //入力関係
    void KeyGet(Vector2 mpos) {
        if (Input.GetMouseButtonDown(0)){
            spos = new Vector2(mpos.x, mpos.y);
            cnt = 0;
        }
        if (Input.GetMouseButtonUp(0)){
            epos = new Vector2(mpos.x, mpos.y);
            GetDirection(spos, epos);
        }
    }
    void GetDirection(Vector2 s,Vector2 e) {
        float dirX = e.x - s.x;
        float dirY = e.y - s.y;
        string dir = "none";
        if (Mathf.Abs(dirY) < Mathf.Abs(dirX)){
            if (30 < dirX) dir = "right";
            if (-30 > dirX) dir = "left";
        }else dir = "touch";
        switch (dir) {
            case "right":
                s_type = SWIPE.RIGHT;
                old_ix = c_ix;
                c_ix--;
                break;
            case "left":
                s_type = SWIPE.LEFT;
                old_ix = c_ix;
                c_ix++;
                break;
        }
        if (c_ix >= ix_max) c_ix = 0;
        else if (c_ix < 0) c_ix = ix_max - 1;
    }
//↓↓↓↓↓↓↓↓↓↓↓↓↓ボタン関連↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
    //ホームに戻る
    public void HomeBack() {
        SceneManager.LoadScene("HomeScene");
    }
    //キャラ選択
    public void CharaSelect(GameObject obj_b) {
        GameObject obj = AgreePanel.transform.Find("Image").gameObject;
        Chara_num = Chara_name(obj_b.name);
        obj.GetComponent<Image>().sprite = Chara_Image[Chara_num];
        animator = AgreePanel.GetComponent<Animator>();
        animator.SetBool("Open", true);  
    }
    int Chara_name(string str) {
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
        animator.SetBool("Open", true);
    }
    public void Cancel_B() {
        animator = AgreePanel.GetComponent<Animator>();
        animator.SetBool("Open", false);
    }
    //StatusPanelのボタン
    public void StatusBack() {
        animator = StatusPanel.GetComponent<Animator>();
        animator.SetBool("Close", true);
    }
//↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
}