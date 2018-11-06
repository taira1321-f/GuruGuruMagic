using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaSelectMousePoint : MonoBehaviour {
    GameObject Mouse = null;
    Vector3 ScreenMP, WorldMP;

    void Start () {
        Mouse = this.gameObject;
        GetComponent<CircleCollider2D>().enabled = true;
	}
	void Update () {
        ScreenMP = Input.mousePosition;
        WorldMP = Camera.main.ScreenToWorldPoint(ScreenMP);
        WorldMP.z = 0.0f;
        Mouse.transform.position = WorldMP;
        if (Input.GetMouseButtonDown(0)) GetComponent<CircleCollider2D>().enabled = true;
        else if (Input.GetMouseButtonUp(0)) GetComponent<CircleCollider2D>().enabled = false;
	}
    
}
