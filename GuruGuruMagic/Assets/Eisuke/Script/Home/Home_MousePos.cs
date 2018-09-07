using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Home_MousePos : MonoBehaviour {
    GameObject Mouse = null;
    Vector3 ScreenMousePos;
    Vector3 WorldMousePos;
    bool ClickFlg;
    string CollName;
    void Awake() {
    }
    void Start () {
        Mouse = this.gameObject;
        ClickFlg = true;
	}
	void Update () {
        ScreenMousePos = Input.mousePosition;
        WorldMousePos = Camera.main.ScreenToWorldPoint(ScreenMousePos);
        WorldMousePos.z = 0.0f;
        Mouse.transform.position = WorldMousePos;
        if (ClickFlg && Input.GetMouseButtonDown(0)){
            switch (CollName)
            {
                case "A_Button":
                    SceneManager.LoadScene("QuestSelect");
                    break;
                case "B_Button":
                    SceneManager.LoadScene("CharaSelect");
                    break;
                case "TitleBack":
                    SceneManager.LoadScene("D_Title");
                    break;
            }
        }
	}
    
    void OnTriggerEnter2D(Collider2D coll) {
        CollName = coll.name;
        string str = GetComponent<HomeDirector>().dir;
        if (str == "touch") ClickFlg = true;
        else ClickFlg = false;
    }        
}