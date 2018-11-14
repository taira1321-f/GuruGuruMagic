using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyButton2 : MonoBehaviour {

    [SerializeField]
    Animator animator;

    public bool changeFlg = false;
    private ParticleSystem par;
    public GameObject BagMenu;
    public GameObject BagMenu2;
    //public GameObject emePrefab;
    
	// Use this for initialization
	void Start () {
        par = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {

        if (changeFlg == true)
        {
            //GameObject.Find("BagMenu").enabled = true;
            BagMenu.SetActive(true);
            animator.SetBool("SraidUp", false);
            changeFlg = false;
            BagMenu2.SetActive(false);
         


        }
		
	}

    public void OnClick2()
    {
        changeFlg = true;

        
    }
}
