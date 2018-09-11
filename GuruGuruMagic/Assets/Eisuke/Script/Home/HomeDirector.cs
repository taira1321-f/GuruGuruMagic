using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeDirector : MonoBehaviour {
    
    enum ROLL { NONE, LEFT, RIGHT };
    ROLL r_mode;
    public GameObject ShowCharactor;
    public GameObject Center;
    public Sprite[] SelectC; 
    float cnt;
    const float cnt_max = 1.0f;
    int h_ix, old_ix;
    const int ix_max = 3;
    string dir;
    Vector2 Spos, Epos;
    Vector3[] AngleZ = { 
                           new Vector3(0, 0, 0),
                           new Vector3(0, 0, 120),
                           new Vector3(0, 0, 240),
                       };
    
	void Start () {
        int sc = PlayerPrefs.GetInt("SelectCharactor");
        ShowCharactor.GetComponent<SpriteRenderer>().sprite = SelectC[sc];
        QualitySettings.vSyncCount = 0;     //VSyncをOFFにする
        Application.targetFrameRate = 60;   //ターゲットフレームレート
        r_mode = ROLL.NONE;
        cnt = 0;
        h_ix = old_ix = 0;
        dir = "touch";
	}
	void Update () {
        if (r_mode != ROLL.NONE) Roll_Button();
        else KeyGet(Input.mousePosition);
	}
    void KeyGet(Vector2 mpos) {
        if (Input.GetMouseButtonDown(0)) {
            Spos = new Vector2(mpos.x, mpos.y);
            cnt = 0;
        }
        if (Input.GetMouseButtonUp(0)) {
            Epos = new Vector2(mpos.x, mpos.y);
            GetDirection();
        }
    }
    void GetDirection() {
        float dirX = Epos.x - Spos.x;
        float dirY = Epos.y - Spos.y;
        r_mode = ROLL.NONE;
        if (Mathf.Abs(dirY) < Mathf.Abs(dirX)){
            if (30 < dirX) dir = "right";
            if (-30 > dirX) dir = "left";
        }else if (Mathf.Abs(dirY) > Mathf.Abs(dirX)){
            if (30 < dirY) dir = "up";
            if (-30 > dirY) dir = "down";
        }else dir = "touch";
        switch (dir) {
            case "right":
                r_mode = ROLL.RIGHT;
                old_ix = h_ix;
                h_ix--;
                break;
            case "left":
                r_mode = ROLL.LEFT;
                old_ix = h_ix;
                h_ix++;
                break;
        }
        if (h_ix > ix_max - 1) h_ix = 0;
        if (h_ix < 0) h_ix = ix_max - 1;
    }
    void Roll_Button() {
        if (cnt <= cnt_max) {
            cnt += Time.deltaTime;
            Quaternion q1 = Quaternion.Euler(AngleZ[old_ix]);
            Quaternion q2 = Quaternion.Euler(AngleZ[h_ix]);
            Center.transform.rotation = Quaternion.Lerp(q1, q2, cnt);
        }else{
            r_mode = ROLL.NONE;
            cnt = 0;
        }        
    }
}
