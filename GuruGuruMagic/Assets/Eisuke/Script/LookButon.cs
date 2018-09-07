using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookButon : MonoBehaviour {
    public Transform traget;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(traget);
	}
}
