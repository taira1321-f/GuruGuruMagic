/* -------------------------------------------------------------------------------------------- *
 * デバッグ用！！！
 * 削除可能
 * -------------------------------------------------------------------------------------------- */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class debugChangeColor : MonoBehaviour {

    Color redColor = new Color(255, 0, 0);
    Color yellowColor = new Color(255, 255, 0);

    public GameObject mizu;

	// Update is called once per frame
	void Update () {
        if (mizu.GetComponent<rotarScript>().isEndGuruGuru())
        {
            this.GetComponent<Image>().color = yellowColor;
        }
        else
        {
            this.GetComponent<Image>().color = redColor;
        }
	}
}
