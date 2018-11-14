using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyButton : MonoBehaviour
{

    [SerializeField]
    Animator animator;

    public bool changeFlg = false;
    private ParticleSystem par;
    public GameObject BagMenu;
    public GameObject BagMenu2;
    //public GameObject emePrefab;



    // Use this for initialization
    void Start()
    {
        par = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {

        if (changeFlg == true)
        {
            BagMenu2.SetActive(true);
            animator.SetBool("SraidUp", true);
            changeFlg = false;
            BagMenu.SetActive(false);
            //GameObject eme = Instantiate(emePrefab) as GameObject;

        }

    }

    public void OnClick()
    {
        changeFlg = true;
        

        
    }


    //void Check(string ball)
    //{
    //    tagObjects = GameObject.FindGameObjectsWithTag(ball);
    //    Debug.Log(tagObjects.Length);
    //    if (tagObjects.Length >= 8)
    //    {
    //        Destroy(GameObject.Find("Sphere(Clone)"));
    //        Debug.Log("消えた");
    //    }
    //}



    }

