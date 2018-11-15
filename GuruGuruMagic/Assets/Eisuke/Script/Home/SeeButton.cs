using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SeeButton : MonoBehaviour {
    public GameObject Canvas;
    GameObject C_child;
    public GameObject S_button;
    public Sprite[] Eyes;
    bool C_Active;
    
	void Start () {
        C_Active = true;
        C_child = Canvas.transform.Find("Center").gameObject;
        C_child.SetActive(C_Active);
	}
	void Update () {
        C_child.SetActive(C_Active);
	}
    public void See_B() {
        if (C_Active) S_button.GetComponent<Image>().sprite = Eyes[0];
        else S_button.GetComponent<Image>().sprite = Eyes[1];

        C_Active = !C_Active;
        Debug.Log("( ﾟдﾟ)");
    }
    public void CharaSelectHomeBack(GameObject obj){
        Debug.Log(obj.name);
        int Chara_Ix = Switch_Chara(obj.name);
        if (0 <= Chara_Ix && Chara_Ix <= 3) PlayerPrefs.SetInt("SelectCharactor", Chara_Ix);
    }
    int Switch_Chara(string str){
        switch (str){
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
}
