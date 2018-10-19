using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DM_director : MonoBehaviour {
    public GameObject[] TextObj = new GameObject[4];
    //string NowLevel = "NowLevel:";
    //string NowExp = "NowExp:";
    //string AddExp = "AddExp:";
    int exp;
    int add_exp;
    int Level;
    int[] Exp_ix = { 8, 17, 36, 76, 160, 336, 707, 1485, 3119, 6550, 13755, 28886, 60660, 121320, 242640, 485280, 970560, 19411290, 3882240, 7764480, };

	void Start () {
        add_exp = exp = 0;
        Level = 1;
	}
	void Update () {
        getKey();
        TextRender();
	}
    void getKey() {
        Debug.Log(add_exp);
        if (Input.GetKeyDown(KeyCode.UpArrow)) add_exp += 1;
        else if (Input.GetKeyDown(KeyCode.DownArrow)) add_exp -= 1;
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) add_exp += 10;
        else if (Input.GetKeyDown(KeyCode.RightArrow)) add_exp -= 10;

        if (Input.GetKeyDown(KeyCode.Space)) {
            exp += add_exp;
            while (Exp_ix[Level - 1] - exp < 0){
                if (exp >= Exp_ix[Level - 1]) Level++;
            }
            add_exp = 0;
        }
    }
    void TextRender() {
        TextObj[0].GetComponent<Text>().text = "" + Level;
        TextObj[1].GetComponent<Text>().text = "" + exp;
        TextObj[2].GetComponent<Text>().text = "" + add_exp;
        TextObj[3].GetComponent<Text>().text = "次のレベルまで" + (Exp_ix[Level - 1] - exp);
    }
    public void SceneChange() {
        SceneManager.LoadScene("ResultScene");
    }
}
