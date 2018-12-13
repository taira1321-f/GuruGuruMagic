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
        Application.targetFrameRate = 30;
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
        DIR = "none";
        if (Mathf.Abs(dirY) < Mathf.Abs(dirX)){
            if (30 < dirX) DIR = "right";
            if (-30 > dirX) DIR = "left";
        }else if (Mathf.Abs(dirY) > Mathf.Abs(dirX)){
            if (30 < dirY) DIR = "up";
            if (-30 > dirY) DIR = "down";
        }else DIR = "touch";

        switch (DIR){
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
            int i = QS_Select(obj.name);
            PlayerPrefs.SetInt("SelectStage", i);
            SceneManager.LoadScene("Main");
        }
    }
    short QS_Select(string str) {
        switch (str){
            case "Stage01":
                PlayerPrefs.SetInt("getExp", 26);
                return 1;
            case "Stage02":
                PlayerPrefs.SetInt("getExp", 39);
                return 2;
            case "Stage03":
                PlayerPrefs.SetInt("getExp", 70);
                return 3;
            case "Stage04":
                PlayerPrefs.SetInt("getExp", 113);
                return 4;
            case "Stage05":
                PlayerPrefs.SetInt("getExp", 137);
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
