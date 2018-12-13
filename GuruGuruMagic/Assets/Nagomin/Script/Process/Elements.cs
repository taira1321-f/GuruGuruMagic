using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elements : MonoBehaviour
{

    public GameObject emePrefab;
    GameObject suihan;
    GameObject eme;


    // Use this for initialization
    void Start()
    {

        suihan = GameObject.Find("suihan");


    }

    // Update is called once per frame
    void Update()
    {


    }
    public void OnCrik()
    {


        float x = Random.Range(-0.5f, 0.6f);
        float y = Random.Range(-2.0f, -3.0f);
        float z = Random.Range(0.0f, 0.0f);
        eme = (GameObject)Instantiate(emePrefab, new Vector3(x, y, z), Quaternion.identity);
        eme.transform.parent = suihan.transform;


    }
}