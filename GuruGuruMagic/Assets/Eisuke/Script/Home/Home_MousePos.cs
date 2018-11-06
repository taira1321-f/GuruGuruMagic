using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Home_MousePos : MonoBehaviour {
    GameObject Mouse = null;
    Vector3 ScreenMousePos;
    Vector3 WorldMousePos;
    bool ClickFlg;
    string CollName;
    void Awake() {
    }
    void Start () {
        Mouse = this.gameObject;
        ClickFlg = true;
	}
    void Update(){
        ScreenMousePos = Input.mousePosition;
        WorldMousePos = Camera.main.ScreenToWorldPoint(ScreenMousePos);
        WorldMousePos.z = 0.0f;
        Mouse.transform.position = WorldMousePos;
    }
}