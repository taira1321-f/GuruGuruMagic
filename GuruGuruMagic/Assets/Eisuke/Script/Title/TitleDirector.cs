using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TitleDirector : MonoBehaviour {
    enum SET_TYPE { START, TITLE, CHANGE };
    SET_TYPE set_type;
    public GameObject TitleRogo;
    float moveY = -0.05f;
    public GameObject canvas;
    float cnt;
    const float CntMax = 0.5f;
    Vector3 start_rogo = new Vector3(0.7f, 0.7f, 0.0f);
    float scale;
    void Awake() {
        TitleRogo.transform.localScale = start_rogo;
        GameObject rogo = canvas.transform.transform.Find("S_Text").gameObject;
        rogo.SetActive(true);
        set_type = SET_TYPE.START;
        PlayerPrefs.SetString("SelectStage", "none");
        PlayerPrefs.SetString("SelectChara", "none");
    }
    void Start() {
        QualitySettings.vSyncCount = 0;     //VSyncをOFFにする
        Application.targetFrameRate = 60;   //ターゲットフレームレート
    }
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
        switch (set_type) {
            case SET_TYPE.START:
                TitleRogo.transform.position += new Vector3(0, moveY, 0);
                if (TitleRogo.transform.position.y <= 0.0f) {
                    Transform go = TitleRogo.transform.GetChild(0);
                    go.position += new Vector3(0, moveY, 0);
                    if (go.position.y <= 1.0f){
                        moveY = 0;
                        set_type = SET_TYPE.TITLE;
                    }
                }
                break;
            case SET_TYPE.TITLE:
                Flash_Rogo();
                break;
            case SET_TYPE.CHANGE:
                Roll_Rogo();
                if (TitleRogo.transform.localScale.x <= 0.01f){
                    SceneManager.LoadScene("HomeScene");
                    set_type = SET_TYPE.START;
                }
                break;
        }
	}
    void Flash_Rogo()
    {
        if (Input.GetMouseButtonDown(0))
        {
            set_type = SET_TYPE.CHANGE;
            scale = TitleRogo.transform.localScale.x;
            GameObject rogo = canvas.transform.Find("S_Text").gameObject;
            rogo.SetActive(false);
        }
        cnt += Time.deltaTime;
        if (cnt <= CntMax)
        {
            GameObject rogo = canvas.transform.Find("S_Text").gameObject;
            rogo.SetActive(false);
        }
        else if (cnt > CntMax && cnt < CntMax * 2)
        {
            GameObject rogo = canvas.transform.Find("S_Text").gameObject;
            rogo.SetActive(true);
        }
        else
        {
            cnt = 0;
        }

    }
    void Roll_Rogo()
    {
        scale -= Time.deltaTime * 0.25f;
        TitleRogo.transform.Rotate(new Vector3(0, 0, 3.0f));
        TitleRogo.transform.localScale = new Vector3(scale, scale, 1);
    }
}
