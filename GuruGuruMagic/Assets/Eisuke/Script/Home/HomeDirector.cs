using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HomeDirector : MonoBehaviour {
    
    public GameObject ShowCharactor;
    public GameObject Center;
    public Sprite[] SelectC;
    Animator RollAnim;
    const float cnt_max = 1.0f;
    const float Anim_Speed = 1.0f;
    string dir;
    Vector2 Spos, Epos;
    void Start () {
        int sc = PlayerPrefs.GetInt("SelectCharactor");
        ShowCharactor.GetComponent<Image>().sprite = SelectC[sc];
        RollAnim = Center.GetComponent<Animator>();
        dir = "touch";
	}
	void Update () {
        KeyGet(Input.mousePosition);
	}
    void KeyGet(Vector2 mpos) {
        if (Input.GetMouseButtonDown(0)) Spos = new Vector2(mpos.x, mpos.y);
        if (Input.GetMouseButtonUp(0)) {
            Epos = new Vector2(mpos.x, mpos.y);
            GetDirection();
        }
    }
    void GetDirection() {
        float dirX = Epos.x - Spos.x;
        float dirY = Epos.y - Spos.y;
        if (Mathf.Abs(dirY) < Mathf.Abs(dirX)){
            if (30 < dirX) dir = "right";
            if (-30 > dirX) dir = "left";
        }
        else dir = "touch";
        switch (dir) {
            case "left":
                RollAnim.SetTrigger("Trigger");
                break;
            case "right":
                float z = Center.transform.eulerAngles.z;
                AnimTriggerCheck(z);
                break;
        }
    }
    void AnimTriggerCheck(float angle) {
        switch ((int)angle) {
            case 0:
                RollAnim.SetTrigger("Q-T");
                break;
            case 120:
                RollAnim.SetTrigger("C-Q");
                break;
            case 240:
                RollAnim.SetTrigger("T-C");
                break;
        }
    }

    public void QuestSelect() {
        SceneManager.LoadScene("QuestSelect");
    }
    public void CharaSelect() {
        SceneManager.LoadScene("CharaSelect");
    }
    public void TitleBack() {
        SceneManager.LoadScene("TitleScene");
    }
    public void HELP() {
        Debug.Log("ヤバイ");
    }
}
