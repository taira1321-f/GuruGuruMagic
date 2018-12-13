using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class lol2 : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Transform myTransform = this.transform;

        // ローカル座標基準で、現在の回転量へ加算する
        myTransform.Rotate(0.0f, 0.0f, 1.0f);
		
	}

    
 
 
}

    

