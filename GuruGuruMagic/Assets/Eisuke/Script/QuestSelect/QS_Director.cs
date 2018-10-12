using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QS_Director : MonoBehaviour {
    enum SWIPE { NONE, LEFT, RIGHT };
    SWIPE s_type;
    public GameObject Center;
    const int child_max = 6;
    GameObject[] CenterChild = new GameObject[child_max];
    Vector2 Spos = new Vector2(0, 0);
    Vector2 Epos = new Vector2(0, 0);
    float cnt;
    const float cnt_max = 1.0f;
    int q_ix,old_ix;
    const int ix_max = 6;
    Vector3[] Quest_Index = {
                                new Vector3(0,0,0),
                                new Vector3(0,0,60),
                                new Vector3(0,0,120),
                                new Vector3(0,0,180),
                                new Vector3(0,0,240),
                                new Vector3(0,0,300),
                            };
    void Start () {
        QualitySettings.vSyncCount = 0;     //VSyncをOFFにする
        Application.targetFrameRate = 60;   //ターゲットフレームレート
        cnt = 0;
        q_ix = old_ix = 0;
        int c_cnt = Center.transform.childCount;
        for (int i = 0; i < c_cnt; i++) {
            CenterChild[i] = Center.transform.GetChild(i).gameObject;    
        }
	}   
	void Update () {
        if (s_type != SWIPE.NONE) Roll_Sprite();
        else KeyGet(Input.mousePosition);
	}
    void Roll_Sprite() {
        if (cnt <= cnt_max) {
            cnt += Time.deltaTime;
            Quaternion q1 = Quaternion.Euler(Quest_Index[old_ix]);
            Quaternion q2 = Quaternion.Euler(Quest_Index[q_ix]);
            Center.transform.rotation = Quaternion.Lerp(q1, q2, cnt);
        }else{
            s_type = SWIPE.NONE;
            cnt = 0;
        }
    }
    void KeyGet(Vector2 mpos) {
        if (Input.GetMouseButtonDown(0)) {
            Spos = new Vector2(mpos.x, mpos.y);
            cnt = 0;
        }
        if (Input.GetMouseButtonUp(0)) {
            Epos = new Vector2(mpos.x, mpos.y);
            GetDirction(Spos,Epos);
        }
    }
    void GetDirction(Vector2 s, Vector2 e) {
        float dirX = e.x - s.x;
        float dirY = e.y - s.y;
        string dir = "none";
        s_type = SWIPE.NONE;
        if (Mathf.Abs(dirY) < Mathf.Abs(dirX)){
            if (30 < dirX) dir = "right";
            if (-30 > dirX) dir = "left";
        }else if (Mathf.Abs(dirY) > Mathf.Abs(dirX)){
            if (30 < dirY) dir = "up";
            if (-30 > dirY) dir = "down";
        }else dir = "touch";
        switch (dir){
            case "right":
                s_type = SWIPE.RIGHT;
                old_ix = q_ix;
                q_ix--;
                break;
            case "left":
                s_type = SWIPE.LEFT;
                old_ix = q_ix;
                q_ix++;
                break;
        }
        if (q_ix >= ix_max) q_ix = 0;
        if (q_ix < 0) q_ix = ix_max - 1;
    }
    public void QS_Button() {
        Debug.Log("q_ix" + q_ix);
        if (q_ix == 5) SceneManager.LoadScene("HomeScene");
        else {
            PlayerPrefs.SetInt("SelectQuest", q_ix);
            SceneManager.LoadScene("D_Main");
        }
    }
}
