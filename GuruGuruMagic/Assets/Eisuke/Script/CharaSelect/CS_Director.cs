using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class CS_Director : MonoBehaviour {
    enum SWIPE { NONE, LEFT, RIGHT };
    SWIPE s_type;
    public GameObject center;
    public GameObject Canvas;
    Vector2 spos,epos;
    float cnt;
    const float cnt_max = 1.0f;
    int c_ix,old_ix;
    const int ix_max = 5;
    bool StatusFlg;
    public Sprite[] See_B = new Sprite[2];
    Vector3[] Chara_Index = { 
                                new Vector3(0,0,0),
                                new Vector3(0,72,0),
                                new Vector3(0,144,0),
                                new Vector3(0,216,0),
                                new Vector3(0,288,0),
                            };
	void Start () {
        QualitySettings.vSyncCount = 0;     //VSyncをOFFにする
        Application.targetFrameRate = 60;   //ターゲットフレームレート
        cnt = 0;
        c_ix = old_ix = 0;
        StatusFlg = false;
        GameObject obj = Canvas.transform.Find("Chara_Status").gameObject;
        obj.SetActive(StatusFlg);
        
	}
	
	void Update () {
        if (s_type != SWIPE.NONE) Swipe_Roll();
        else KeyGet(Input.mousePosition);
        
	}
    void Swipe_Roll() {
        if (cnt <= cnt_max){
            cnt += Time.deltaTime;
            Quaternion q1 = Quaternion.Euler(Chara_Index[old_ix]);
            Quaternion q2 = Quaternion.Euler(Chara_Index[c_ix]);
            center.transform.rotation = Quaternion.Lerp(q1, q2, cnt);
        }else{
            s_type = SWIPE.NONE;
            cnt = 0;
        }
    }
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

    public void StatusView(GameObject b_obj) {
        StatusFlg = !StatusFlg;
        GameObject obj = Canvas.transform.Find("Chara_Status").gameObject;
        obj.SetActive(StatusFlg);
        if (StatusFlg) b_obj.GetComponent<Image>().sprite = See_B[0];
        else b_obj.GetComponent<Image>().sprite = See_B[1];
    }
}
