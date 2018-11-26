using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QS_Director : MonoBehaviour {
    string DIR;
    Animator Center_Anim;
    Vector2 Spos = new Vector2(0, 0);
    Vector2 Epos = new Vector2(0, 0);
    public GameObject QS_Center;
    void Start () {
        Center_Anim = QS_Center.GetComponent<Animator>();
	}   
	void Update () {
        KeyGet(Input.mousePosition);
	}
    
    void KeyGet(Vector2 mpos) {
        if (Input.GetMouseButtonDown(0)) Spos = new Vector2(mpos.x, mpos.y);
        if (Input.GetMouseButtonUp(0)) {
            Epos = new Vector2(mpos.x, mpos.y);
            GetDirction(Spos,Epos);
        }
    }
    void GetDirction(Vector2 s, Vector2 e) {
        float dirX = e.x - s.x;
        float dirY = e.y - s.y;
        string dir = "none";
        if (Mathf.Abs(dirY) < Mathf.Abs(dirX)){
            if (30 < dirX) dir = "right";
            if (-30 > dirX) dir = "left";
        }else if (Mathf.Abs(dirY) > Mathf.Abs(dirX)){
            if (30 < dirY) dir = "up";
            if (-30 > dirY) dir = "down";
        }else dir = "touch";
        DIR = dir;
        switch (dir){
            case "left":
                Center_Anim.SetTrigger("Trigger");
                break;
            case "right":
                float angleZ = QS_Center.transform.eulerAngles.z;
                AnimTriggerCheck(angleZ);
                break;
        }
    }
    void AnimTriggerCheck(float angle) {
        switch ((int)angle) {
            case 0:
                Center_Anim.SetTrigger("Stage1-Home");
                break;
            case 60:
                Center_Anim.SetTrigger("Stage2-1");
                break;
            case 120:
                Center_Anim.SetTrigger("Stage3-2");
                break;
            case 180:
                Center_Anim.SetTrigger("Stage4-3");
                break;
            case 240:
                Center_Anim.SetTrigger("Stage5-4");
                break;
            case 300:
                Center_Anim.SetTrigger("Home-Stage5");
                break;
            
        }
    }
    public void QS_Button(GameObject obj) {
        if (DIR == "touch"){
            Debug.Log(obj.name);
            int i = QS_Select(obj.name);
            Debug.Log(i);
        }
    }
    short QS_Select(string str) {
        switch (str){
            case "Stage01":
                return 1;
            case "Stage02":
                return 2;
            case "Stage03":
                return 3;
            case "Stage04":
                return 4;
            case "Stage05":
                return 5;
        }
        return -1;
    }
    public void HomeBack(){
        if (DIR == "touch"){
            SceneManager.LoadScene("HomeScene");
        }
    }
}
