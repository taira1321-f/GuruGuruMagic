using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CS_Director : MonoBehaviour {
    enum SWIPE { NONE, LEFT, RIGHT };
    SWIPE s_type;
    public GameObject center;
    Vector2 spos = new Vector2(0, 0);
    Vector2 epos = new Vector2(0, 0);
    Vector3 dpos;
    float cnt;
    const float cnt_max = 1.0f;
    int c_ix;
    const int ix_max = 4;
    Vector3[] Chara_Index = { 
                                new Vector3(  0,0,0),
                                new Vector3( -5,0,0),
                                new Vector3(-10,0,0),
                                new Vector3(-15,0,0),
                            };
	void Start () {
        QualitySettings.vSyncCount = 0;     //VSyncをOFFにする
        Application.targetFrameRate = 60;   //ターゲットフレームレート
        cnt = 0;
        c_ix = 0;
        dpos = spos - epos;
	}
	
	void Update () {
        if (s_type != SWIPE.NONE) Slide_Sprite();
        else KeyGet(Input.mousePosition);
	}
    void Slide_Sprite() {
        center.transform.position += dpos * 5.0f * Time.deltaTime;
        cnt += Time.deltaTime;
        dpos = (Chara_Index[c_ix] - center.transform.position) * cnt * 1.25f;
        if (cnt >= cnt_max){
            center.transform.position = Chara_Index[c_ix];
            cnt = 0;
            s_type = SWIPE.NONE;
            
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
                c_ix--;
                break;
            case "left":
                s_type = SWIPE.LEFT;
                c_ix++;
                break;
        }
        if (c_ix >= ix_max) c_ix = ix_max - 1;
        else if (c_ix < 0) c_ix = 0;
    }
    public void Select_Chara() {
        PlayerPrefs.SetInt("SelectCharactor", c_ix);
        SceneManager.LoadScene("HomeScene");
    }
    public void HomeBack() {
        SceneManager.LoadScene("HomeScene");
    }
}
