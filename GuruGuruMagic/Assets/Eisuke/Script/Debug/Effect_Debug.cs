using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_Debug : MonoBehaviour {
    bool Tapflg;
    bool Holdflg;
	void Start () {
		
	}
	void Update () {
        gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        MouseCheck();
	}
    void MouseCheck() {
        if (Input.GetMouseButtonDown(0)){
            Tapflg = true;
            GetComponent<ParticleSystem>().Play();
        }
        else if (Input.GetMouseButton(0)) {
            Holdflg = true;
        } 
        if (Input.GetMouseButtonUp(0)) {
            Holdflg = false;
            Tapflg = false;
            GetComponent<ParticleSystem>().Stop();
        }
    }
}
