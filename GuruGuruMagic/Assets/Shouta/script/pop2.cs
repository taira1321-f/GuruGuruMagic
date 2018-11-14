using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pop2 : MonoBehaviour {

    public GameObject safaPrefab;
    GameObject suihan;
    GameObject safa;


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
        safa = (GameObject)Instantiate(safaPrefab, new Vector3(x, y, z), Quaternion.identity);
        safa.transform.parent = suihan.transform;


    }
}
