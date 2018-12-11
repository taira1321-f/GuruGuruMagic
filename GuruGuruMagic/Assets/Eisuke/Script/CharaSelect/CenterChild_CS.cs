﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CenterChild_CS : MonoBehaviour {
    [SerializeField]
    float _radius;
    const short child = 5;
    Vector3 target = new Vector3(0, 0, 2000);
    RectTransform[] rectT = new RectTransform[child];

    void Awake(){
        Deploy();
        GameObject[] obj_child = new GameObject[child];
        for (int i = 0; i < child; i++){
            obj_child[i] = gameObject.transform.GetChild(i).gameObject;
            rectT[i] = obj_child[i].GetComponent<RectTransform>();
        } 
    }
    void Update(){
        if (gameObject.transform.rotation.z == 360) gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        for (int i = 0; i < child; i++) rectT[i].LookAt(target);
    }
    void OnValidate(){
        Deploy();
    }
    //子を円状に配置する(ContextMenuで鍵マークの所にメニュー追加)
    [ContextMenu("Deploy")]
    void Deploy(){
        //子を取得
        List<GameObject> childList = new List<GameObject>();
        foreach (Transform child in transform){
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
        for (int i = 0; i < childList.Count; i++){
            Vector3 childPostion = transform.position;
            float angle = (90 - angleDiff * i) * Mathf.Deg2Rad;
            childPostion.x += _radius * Mathf.Cos(angle);
            childPostion.z += _radius * Mathf.Sin(angle);
            childList[i].transform.position = childPostion;
        }
    }
}
