using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Look_UI_Button : MonoBehaviour {

    Vector3 target = new Vector3(0,0,2000);
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
}
