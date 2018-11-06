using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R_Director : MonoBehaviour {
    public Sprite[] CharaImage = new Sprite[8];
    public GameObject ImgObj;
    bool ClearFlg;
    enum C_CHECK { CLEAR, OVER };
    C_CHECK c_type;
	void Start () {
        ClearFlg = true;
        Clear_Check();
	}
    void Clear_Check() {
        if (ClearFlg){
            c_type = C_CHECK.CLEAR;
        }else {
            c_type = C_CHECK.OVER;
        } 
    }
	void Update () {
        switch (c_type) {
            case C_CHECK.CLEAR:
                break;
            case C_CHECK.OVER:
                break;
        }
	}
}
