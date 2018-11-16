using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellRecipe : MonoBehaviour {


    //GameObject[] tagObjects;
    //GameObject[] tagObjects1;
    //GameObject[] tagObjects2;

     


    //GameObject pot1;

	// Use this for initialization
	void Start () {

        
        
	}
	
	// Update is called once per frame
	void Update () {

        //pot1 = null;

         //pot1 = GameObject.Find("eme(Clone)");
        //GameObject pot2 = transform.GetChild(1).gameObject;
        //GameObject pot3 = transform.GetChild(2).gameObject;
        //CancelInvoke("eme","safa","ruby");
        

       

        
	}


    public void OnClick()
    {

       GameObject[] tagObjects = GameObject.FindGameObjectsWithTag("eme");
       GameObject[] tagObjects1 = GameObject.FindGameObjectsWithTag("safa");
       GameObject[] tagObjects2 = GameObject.FindGameObjectsWithTag("ruby");

        if (tagObjects.Length == 4 || tagObjects.Length == 3 || tagObjects.Length == 2)
            {
                Debug.Log("風");
            }
        if (tagObjects1.Length == 4 || tagObjects1.Length == 3 || tagObjects1.Length == 2)
        {
            Debug.Log("水");
        }
        if (tagObjects2.Length == 4 || tagObjects2.Length == 3 || tagObjects2.Length == 2)
        {
            Debug.Log("火");
        }
        if (tagObjects2.Length == 1 & tagObjects1.Length == 1 || tagObjects2.Length == 2 & tagObjects1.Length == 2)
        {
            Debug.Log("毒");
        }
        if (tagObjects2.Length == 1 & tagObjects.Length == 1)
        {
            Debug.Log("回復");
        }
        if (tagObjects2.Length == 2 & tagObjects.Length == 2)
        {
            Debug.Log("回復(大)");
        }
        if (tagObjects1.Length == 1 & tagObjects.Length == 1 || tagObjects1.Length == 2 & tagObjects.Length == 2)
        {
            Debug.Log("妨害");
        }
        if (tagObjects1.Length == 2 & tagObjects2.Length == 1)
        {
            Debug.Log("攻撃力バフ");
        }
        if (tagObjects1.Length == 1 & tagObjects.Length == 2)
        {
            Debug.Log("ガード魔法");
        }
        if (tagObjects2.Length == 1 & tagObjects.Length == 2)
        {
            Debug.Log("ブースト");
        }



    }


    
}
