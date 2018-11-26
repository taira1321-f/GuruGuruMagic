using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anime : MonoBehaviour {

    Animator ani;


	// Use this for initialization
	void Start () {
        ani = GetComponent<Animator>();	
	}

    void flg()
    {
        ani.SetBool("atkflg", false);
        ani.SetBool("dmgflg", false);
    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown(KeyCode.Z)) {
            ani.SetBool("atkflg",true);
            Invoke("flg",0.3f);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            ani.SetBool("dmgflg", true);
            Invoke("flg", 0.3f);
        }


    }
}
