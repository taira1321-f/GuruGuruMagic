using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushJewel : MonoBehaviour {

    [SerializeField]
    [Header("鍋に入る石のPrefab")]
    GameObject PJewel;

    GameObject pot;
    GameObject jewel;
    SpellRecipe2 recipe;

    // Use this for initialization
    void Start()
    {
        pot = GameObject.Find("PotWater");
        recipe = pot.GetComponent<SpellRecipe2>();
    }

    public void OnClick()
    {

        if (recipe.Count() < recipe.stack_max)
        {

            float x = Random.Range(Random.Range(-200.0f, -80.0f), Random.Range(80.0f, 200.0f));
            float y = Random.Range(Random.Range(-200.0f, -80.0f), Random.Range(80.0f, 200.0f));
            jewel = (GameObject)Instantiate(PJewel);
            jewel.transform.parent = pot.transform;
            jewel.GetComponent<RectTransform>().localPosition = new Vector3(x, y, 0);

          recipe.Push(jewel.tag);

        }
    }
}
