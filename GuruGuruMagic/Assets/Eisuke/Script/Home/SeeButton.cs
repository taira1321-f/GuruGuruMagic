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
}
