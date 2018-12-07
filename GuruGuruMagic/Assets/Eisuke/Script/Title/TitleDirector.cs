using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TitleDirector : MonoBehaviour {
    //プライベート変数
    Animator Rg_anim;
    Animator Title_anim;
    bool Flash_flg;
    short cnt = 0;
    //パブリック変数
    public GameObject Rogo;
    public GameObject Canvas;
    void Awake() {

    }
    void Start() {
        Flash_flg = true;
        GameObject obj = Rogo.transform.GetChild(0).gameObject;
        Title_anim = obj.GetComponent<Animator>();
        Title_anim.SetBool("FallFlg", true);
    }
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
        if (Title_anim.GetBool("FallFlg")){
            Flash_Text();
            if (Input.GetMouseButtonDown(0)){
                GameObject obj = Rogo.transform.GetChild(0).gameObject;
                Title_anim = obj.GetComponent<Animator>();
                Title_anim.SetBool("SmallFlg", true);
                Rg_anim = Rogo.GetComponent<Animator>();
                Rg_anim.SetTrigger("Rolling");
            }
            Transform trf = Rogo.transform.GetChild(0);
            if (trf.localScale.x == 0) SceneManager.LoadScene("HomeScene");
            
        }
    }
    void Flash_Text(){
        if (cnt++ > 10) {
            GameObject obj = Canvas.transform.Find("S_Text").gameObject;
            obj.SetActive(Flash_flg);
            cnt = 0;
            Flash_flg = !Flash_flg;
        }
        
    }
    
}
