using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProcessingUI : MonoBehaviour {

    [SerializeField]
    private Text dataText;

  //  private TestSaveData Testdata;

    [SerializeField]
    private InputField HPField;
    [SerializeField]
    private InputField ATKField;
    [SerializeField]
    private InputField LVField;
    [SerializeField]
    private InputField EXPField;

    void Start()
    {
       // Testdata = GetComponent<TestSaveData>();
    }

    //　データ表示のテキストを空にする
    public void ResetText()
    {
        dataText.text = "";
    }

    //　現在のオブジェクトの変数のデータを表示する
    public void ShowParameter()
    {
        ResetText();
        dataText.text = TestSaveData.GetSaveData().GetNormalData();
    }

    //　現在のオブジェクトのJSONデータを表示
    public void ShowJsonData()
    {
        ResetText();
        dataText.text = TestSaveData.GetSaveData().GetJsonData();
    }

    //　現在のオブジェクトのJSONデータを保存する
    public void SaveData()
    {
        ResetText();
        PlayerPrefs.SetString("PlayerData", TestSaveData.GetSaveData().GetJsonData());
    }

    public void SetHP()
    {
        TestSaveData.GetSaveData().SetHP(int.Parse(HPField.text));
    }

    public void SetATK()
    {
        TestSaveData.GetSaveData().SetATK(int.Parse(ATKField.text));
    }

    public void SetLV()
    {
        TestSaveData.GetSaveData().SetLV(int.Parse(LVField.text));
    }

    public void SetEXP()
    {
        TestSaveData.GetSaveData().SetEXP(int.Parse(EXPField.text));
    }

    //　データをロードしてオブジェクトのフィールドにデータを入れる
    public void LoadFromJsonOverwrite()
    {
        ResetText();
        if (PlayerPrefs.HasKey("PlayerData"))
        {
            var data = PlayerPrefs.GetString("PlayerData");
            JsonUtility.FromJsonOverwrite(data, TestSaveData.GetSaveData());
            dataText.text = TestSaveData.GetSaveData().GetJsonData();
        }
    }

    //　データをロードしインスタンスを生成する
    public void CreateData()
    {
        ResetText();
        if (PlayerPrefs.HasKey("PlayerData"))
        {
            var data = PlayerPrefs.GetString("PlayerData");
            TestSave otherSaveData = JsonUtility.FromJson<TestSave>(data);
            dataText.text = otherSaveData.GetJsonData();
        }
    }

    //　データを削除する
    public void DeleteData()
    {
        ResetText();
        PlayerPrefs.DeleteAll();
    }

}
