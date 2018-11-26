using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CenterChild : MonoBehaviour {
    [SerializeField]
    float _radius;
    short cnt = 0;
    const short child = 6;
    Vector3 target = new Vector3(0, 0, 2000);
    GameObject[] obj_child = new GameObject[child];

    void Awake(){
        Deploy();
        for (int i = 0; i < child; i++) obj_child[i] = gameObject.transform.GetChild(i).gameObject;
    }
    void Update() {
        if (gameObject.transform.rotation.z == 360) gameObject.transform.eulerAngles = new Vector3(0, 0, 0); 
        if ((cnt++) % 30 == 0) {
            cnt = 0;
            for (int i = 0; i < child; i++) obj_child[i].GetComponent<RectTransform>().LookAt(target);
        }
    }
    void OnValidate(){
        Deploy();
    }
    //子を円状に配置する(ContextMenuで鍵マークの所にメニュー追加)
    [ContextMenu("Deploy")]
    void Deploy(){
        //子を取得
        List<GameObject> childList = new List<GameObject>();
        foreach (Transform child in transform)
        {
            childList.Add(child.gameObject);
        }
        //数値、アルファベット順にソート
        childList.Sort(
          (a, b) =>
          {
              return string.Compare(a.name, b.name);
          }
        );
        //オブジェクト間の角度差
        float angleDiff = 360f / (float)childList.Count;
        //各オブジェクトを円状に配置
        for (int i = 0; i < childList.Count; i++)
        {
            Vector3 childPostion = transform.position;
            float angle = (90 - angleDiff * i) * Mathf.Deg2Rad;
            childPostion.x += _radius * Mathf.Cos(angle);
            childPostion.y += _radius * Mathf.Sin(angle);
            childList[i].transform.position = childPostion;
        }
    }
}
