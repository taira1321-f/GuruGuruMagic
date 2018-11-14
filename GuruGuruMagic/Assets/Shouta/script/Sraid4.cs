using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sraid4 : MonoBehaviour {

    [SerializeField]
    Animator animator;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.UpArrow))
            animator.SetBool("SraidUp", true);
        if (Input.GetKeyDown(KeyCode.DownArrow))
            animator.SetBool("SraidUp", false);
		
	}
}
