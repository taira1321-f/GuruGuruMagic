using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ResultDirector : MonoBehaviour{

    int cnt;
    int c_ix;
    int Now_Lv = 1;
    int exp, h_exp;
    Image c_img;
    Slider e_slider;
    Text r_text;
    CharaData s_cd;
    Animator lu_anim;
    string[] Result_str = { "GameClear!!!", "GameOver" };
    public CharaDataBase cdb;
    public GameObject Chara_Image;
    public GameObject Exp_Slider;
    public GameObject LU_Text;
    public GameObject Result_Text;

    void Start() {
        c_ix = PlayerPrefs.GetInt("SelectCharactor");
        Debug.Log(c_ix);
        s_cd = cdb.CharaDataList[c_ix];
        CharaCheck(s_cd, c_ix);
        exp = PlayerPrefs.GetInt("getExp");
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 30;
        obj_Component();
        Slider_Adjustment(Now_Lv);
        Rusult_Check(0);
        cnt = 0;
        
    }
    void CharaCheck(CharaData cd,int id) {
        Now_Lv = PlayerPrefs.GetInt("Chara_" + cd.Get_NAME() + "_Lv");
        h_exp = PlayerPrefs.GetInt("Chara_" + cd.Get_NAME() + "_HaveExp");
    }
    void obj_Component(){
        c_img = Chara_Image.GetComponent<Image>();
        c_img.sprite = s_cd.Get_CharaImage();
        e_slider = Exp_Slider.GetComponent<Slider>();
        lu_anim = LU_Text.GetComponent<Animator>();
        r_text = Result_Text.GetComponent<Text>();
        
    }
    void Slider_Adjustment(int lv){
        int max = s_cd.Get_TOTAL_EXP(lv+1);
        int min = s_cd.Get_TOTAL_EXP(lv);
        e_slider.maxValue = max;
        e_slider.minValue = min;
    }
    void Rusult_Check(int i) {
        r_text.text = Result_str[i];
    }

    void Update() {
        Exp_Cnt();
    }
    void Exp_Cnt() {
        if ((h_exp + cnt) < e_slider.minValue) Now_Lv++;
        else if (cnt < exp){
            int t_exp = (cnt++) + h_exp;
            e_slider.value = t_exp;
            if (t_exp == e_slider.maxValue)
            {
                lu_anim.SetBool("Scale_Flg", true);
                if (Input.GetMouseButtonDown(0)){
                    lu_anim.SetBool("Scale_Flg", false);
                    Now_Lv++;
                    Slider_Adjustment(Now_Lv);
                }
            }
        }else if (cnt == exp){
            if (Input.GetMouseButtonDown(0)){
                lu_anim.SetBool("Scale_Flg", false);
                PlayerPrefs.SetInt("Chara_" + s_cd.Get_NAME() + "_Lv", Now_Lv);
                PlayerPrefs.SetInt("Chara_" + s_cd.Get_NAME() + "_HaveExp", cnt + h_exp);
                PlayerPrefs.Save();
                SceneManager.LoadScene("HomeScene");
            }
        }
    }
}

