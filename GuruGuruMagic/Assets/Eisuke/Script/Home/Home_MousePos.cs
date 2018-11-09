using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Home_MousePos : MonoBehaviour {
    GameObject Mouse = null;
    Vector3 ScreenMousePos;
    Vector3 WorldMousePos;

    void Start () {
        Mouse = this.gameObject;
	}
    
    void Update(){
        ScreenMousePos = Input.mousePosition;
        WorldMousePos = Camera.main.ScreenToWorldPoint(ScreenMousePos);
        WorldMousePos.z = 0.0f;
        Mouse.transform.position = WorldMousePos;
    }
}