using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class suithi : MonoBehaviour {

    private ParticleSystem par;
    public GameObject eme;
    public GameObject safa;
    public GameObject ruby;
    GameObject[] tagObjects;
    GameObject[] tagObjects1;
    GameObject[] tagObjects2;

	// Use this for initialization
	void Start () {

        par = GetComponent<ParticleSystem>();
       
		
	}
	
	// Update is called once per frame
    void Update()
    {

        Check("eme","safa","ruby");

		
	}

    

    void Check(string eme, string safa, string ruby)
    {
        
        tagObjects = GameObject.FindGameObjectsWithTag(eme);
        tagObjects1 = GameObject.FindGameObjectsWithTag(safa);
        tagObjects2 = GameObject.FindGameObjectsWithTag(ruby);
        Debug.Log(tagObjects.Length);
        Debug.Log(tagObjects1.Length);
        Debug.Log(tagObjects2.Length);

        if (tagObjects.Length >= 4)
        {
            Debug.Log("ロック");
            GameObject.Find("eme1").GetComponent<Button>().enabled = false;
            GameObject.Find("safa1").GetComponent<Button>().enabled = false;
            GameObject.Find("ruby1").GetComponent<Button>().enabled = false;
            //Destroy(transform.GetChild(1));
            
        }
        if (tagObjects.Length == 3)
        {
            GameObject.Find("eme1").GetComponent<Button>().enabled = true;
            GameObject.Find("safa1").GetComponent<Button>().enabled = true;
            GameObject.Find("ruby1").GetComponent<Button>().enabled = true;
            Debug.Log("解除");
        }
        

    }
}
