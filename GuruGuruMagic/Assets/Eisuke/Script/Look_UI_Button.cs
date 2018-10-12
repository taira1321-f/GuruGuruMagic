using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Look_UI_Button : MonoBehaviour {

    public Transform target;
	void Update () {
        GetComponent<RectTransform>().LookAt(target);
	}
    
    public void A_Button() {
        SceneManager.LoadScene("QuestSelect");
    }
    public void B_Button() {
        SceneManager.LoadScene("CharaSelect");
    }
    public void TitleBack() {
        SceneManager.LoadScene("D_Title");
    }
    public void StageSelect() {
        Debug.Log(gameObject.name);
        SceneManager.LoadScene("D_main");
    }
    public void HomeBack() {
        SceneManager.LoadScene("HomeScene");
    }
    public void CharaSelect() {
        int Chara_Ix =  Switch_Chara(gameObject.name);
        if (0 <= Chara_Ix && Chara_Ix <= 3) PlayerPrefs.SetInt("SelectCharactor", Chara_Ix);
        SceneManager.LoadScene("HomeScene");
    }
    int Switch_Chara(string str) {
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

}
