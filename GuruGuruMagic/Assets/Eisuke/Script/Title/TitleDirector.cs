using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TitleDirector : MonoBehaviour {
    //プライベート変数
    Animator Rg_anim;
    Animator Title_anim;
    //パブリック変数
    public GameObject Rogo;
    void Awake() {

    }
    void Start() {
        GameObject obj = Rogo.transform.GetChild(0).gameObject;
        Title_anim = obj.GetComponent<Animator>();
        Title_anim.SetBool("FallFlg", true);
    }
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
        if (Title_anim.GetBool("FallFlg")){
            if (Input.GetMouseButtonDown(0)){
                GameObject obj = Rogo.transform.GetChild(0).gameObject;
                Title_anim = obj.GetComponent<Animator>();
                Title_anim.SetBool("SmallFlg", true);
                Rg_anim = Rogo.GetComponent<Animator>();
                Rg_anim.SetBool("RollFlg", true);
            }
            Transform trf = Rogo.transform.GetChild(0);
            if (trf.localScale.x == 0) SceneManager.LoadScene("HomeScene");
            
        }
    }
    
}
