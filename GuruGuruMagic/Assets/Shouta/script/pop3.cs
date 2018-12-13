using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pop3 : MonoBehaviour {

    public GameObject rubyPrefab;
    GameObject suihan;
    GameObject ruby;


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
        ruby = (GameObject)Instantiate(rubyPrefab, new Vector3(x, y, z), Quaternion.identity);
        ruby.transform.parent = suihan.transform;


    }
}
