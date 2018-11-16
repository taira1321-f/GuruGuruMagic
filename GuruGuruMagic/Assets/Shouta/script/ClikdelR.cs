using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClikdelR : MonoBehaviour {

    GameObject clickedGameObject;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetMouseButtonDown(0))
        {

            clickedGameObject = null;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

            if (hit2d)
            {
                clickedGameObject = hit2d.transform.gameObject;

            }

            if (clickedGameObject.name == "ruby(Clone)")
            {

                //Destroy(clickedGameObject);
                Destroy(GameObject.Find("ruby(Clone)"));
                Debug.Log(clickedGameObject);
            }

        }



    }
}
