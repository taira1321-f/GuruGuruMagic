using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ResultDirector : MonoBehaviour {
    const short obj_ix = 4;
    int cnt = 0;
    int Get_Exp;
    public Sprite[] NUM_Image = new Sprite[10];
    public Sprite[] Chara_Image = new Sprite[4];
    public GameObject ExpNUM;
    GameObject[] NUM_obj = new GameObject[obj_ix];
    public GameObject S_Chara;
    public GameObject exp_Slider;
    Image[] obj_Image = new Image[obj_ix];
    void Start () {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 30;
        int ix = PlayerPrefs.GetInt("SelectCharactor");
        Get_Exp = PlayerPrefs.GetInt("getExp");
        S_Chara.GetComponent<Image>().sprite = Chara_Image[ix];
        for (int i = 0; i < obj_ix; i++){
            NUM_obj[i] = ExpNUM.transform.GetChild(i).gameObject;
            obj_Image[i] = NUM_obj[i].GetComponent<Image>();
        }
    }
	
    void Update () {
        Debug_Update();
    }
    void Debug_Update() {
        exp_Slider.GetComponent<Slider>().value = cnt;
        NUM_ANIM();
    }
    void NUM_ANIM() {
        if (cnt < Get_Exp){
            cnt++;
        }else return;
        Show_NUM(cnt);
    }
    void Show_NUM(int num){
        int i = 0;
        obj_Image[i++].sprite = NUM_Image[num / 1000 % 10];
        obj_Image[i++].sprite = NUM_Image[num / 100 % 10];
        obj_Image[i++].sprite = NUM_Image[num / 10 % 10];
        obj_Image[i].sprite = NUM_Image[num % 10];
    }    
}
