using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSaveData : MonoBehaviour {

    private static TestSave savedata;
    [SerializeField]
    private GameObject obj;

    // Use this for initialization
    public void Start () {
      //  GameObject obj = new GameObject("Canvas");
        savedata = new TestSave();

        savedata.SetHP(100);
        savedata.SetATK(10);
        savedata.SetLV(1);
        savedata.SetEXP(0);
        //savedata.SetELEMENT(null);
        //savedata.SetFlg(true);
        //savedata.SetObj(obj);

    }

    public static TestSave GetSaveData()
    {
        return savedata;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
