using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rotarScript2 : MonoBehaviour
{

    RaycastHit hit;

    /*---------------インスペクターに表示させるオブジェクトや変数等---------------*/
    [Header("回転させるのに必要なオブジェクト（見えなくて良い）")]
    [SerializeField]
    private Transform Dummy_Pointer;
    [Header("回転する水のオブジェクト")]
    [SerializeField]
    private Transform Water_Object; // 水のオブジェクト

    /*---------------定数---------------*/

    private const float DECREASE_SPEED = 0.1f;//慣性、減る速度
    private const float INCREASE_SPEED = 0.0005f;//回して増える量

    private const float POWER_MAX = 12;

    private const short SPIN_MIN = 4;//最低限回す回数

    private const short SPIN_TIME_MIN = 3;//回す時間の下限
    private const short SPIN_TIME_MAX = 8;//回す時間の上限

    private const float SPIN_PERCENT_MIN = 0.8f;//回したパーセントの下限
    private const float SPIN_PERCENT_MAX = 1.2f;//回したパーセントの上限

    /*---------------変数---------------*/
    private float fDummyOffset;//ダミーの角度を覚えさせる変数
    private float fDiscOffset;//水オブジェクトの角度を覚えさせる変数
    private float fRotatePower;//回転速度
    private float fOldAngle, fNewAngle;//新しい角度と古い角度を保存させる変数
    private float fNowWaterAngle;//水の今の角度
    private float fSpinTime;//回すのに掛かった時間
    private float fSpinNum;//回転回数
    private float fNewSpinNum, fOldSpinNum;//回転回数

    private float fW_M_Distance;//水とマウスの距離

    private bool isMouseUp = true;//マウスフラグ、最初のクリックを区別させる

    ////デバッグ用
    //private short kari_Status;//仮のステータス
    //private float kari_percent;

    ////デバッグ用---実装時消去
    //[Header("デバッグ用")]
    //public Text jikan, newSpinNum, oldSpinNum, spinNum, pasento, pawa, mizumasu, anguru;
    ////ここまで

    void Start()
    {
        fDummyOffset =
        fDiscOffset =
        fRotatePower =
        fNowWaterAngle =
        fSpinTime =
        fSpinNum = 0;
    }

    //仮のゲームステータス的な 結合するときは消してください
    void Update()
    {
        Vector3 Apos = Water_Object.transform.position;
        Vector3 Bpos = Input.mousePosition;
        fW_M_Distance = Vector3.Distance(Apos, Bpos);

        ////デバッグ用---実装時消去
        //jikan.text = fSpinTime.ToString();
        //newSpinNum.text = fNewSpinNum.ToString();
        //oldSpinNum.text = fOldSpinNum.ToString();
        //spinNum.text = fSpinNum.ToString();
        //pawa.text = fRotatePower.ToString();
        //pasento.text = kari_percent.ToString();
        //mizumasu.text = fW_M_Distance.ToString();
        //anguru.text = fNewAngle.ToString();

        //if (isEndGuruGuru()) kari_percent = getGuruguru();
        ////ココまで

        //他のスクリプトで管理する場合は削除
        Guru();
        //ココまで


    }

    //ぐるぐるするやつ
    public void Guru()
    {
        // マウスを押したら
        if (Input.GetMouseButton(0))
        {

            // Ray光線の発射
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // それが操作範囲内にあるか？
            if (Physics.Raycast(ray, out hit) && (hit.transform.name == "hitArea"))
            {
                Debug.Log("true");
                // ダミーを常にあたった方向に向かせる
                Dummy_Pointer.LookAt(hit.point);
                

                if (isMouseUp)//初回クリック時
                {

                    // ダミーと水オブジェクトの角度を記憶
                    fDummyOffset = Dummy_Pointer.eulerAngles.y;
                    fDiscOffset = Water_Object.eulerAngles.y;

                    // 最初のクリックじゃなくなる
                    isMouseUp = false;

                    //時間を初期化
                    fSpinTime = 0;
                    //回転回数を初期化
                    fNewSpinNum = 0;
                    fOldSpinNum = fSpinNum;


                    ////デバッグ用 - 削除可能
                    //kari_percent = 0;
                }
                else//初回以外のクリック時
                {
                    //マウスが回っている方向の取得
                    float fAangle = -(fDiscOffset + (Dummy_Pointer.eulerAngles.y - fDummyOffset));

                    if (fAangle > 0) fAangle = -fAangle;

                    fNewAngle = fAangle;

                    //最大回転に到達するまで
                    if (fNewSpinNum < SPIN_MIN)
                    {
                        //新しい角度の保存
                        fNewSpinNum = fSpinNum - fOldSpinNum;
                        //時間測定 少しでも水を回さないとカウントしない
                        if (fNewAngle != fOldAngle) fSpinTime += Time.deltaTime;
                    }

                    //回転速度を上昇させてゆくぅ～
                    if (fNewAngle != fOldAngle)
                    {
                        fRotatePower += fAangle * INCREASE_SPEED * ((400 - fW_M_Distance) / 400);

                        if (fRotatePower < -POWER_MAX) fRotatePower = -POWER_MAX;
                    }
                    else
                    {
                        Inertia();
                    }
                    fOldAngle = fNewAngle;
                }

            }
        }
        else//マウスを離したら
        {
            if (fNewSpinNum > SPIN_MIN) isMouseUp = true;
            Inertia();
        }

        //回転数を求める
        fSpinNum = -(fNowWaterAngle / 360);

        //水オブジェクトにぐるぐるを反映させる
        fNowWaterAngle += fRotatePower;
        Water_Object.transform.rotation = Quaternion.Euler(0.0f, 0.0f, fNowWaterAngle);
    }

    //慣性
    private void Inertia()
    {
        if (fRotatePower < 0) fRotatePower += DECREASE_SPEED;
        else fRotatePower = 0;
    }

    //終了判定のやつ
    public bool isEndGuruGuru()
    {
        //十分回したら
        if (fNewSpinNum > SPIN_MIN)
        {
            // Attack();
            return true;
        }
        return false;
    }

    //パーセンテージを取得するやつ
    public float getGuruguru()
    {
        //度が過ぎない程度に時間を治す
        if (fSpinTime < SPIN_TIME_MIN) fSpinTime = SPIN_TIME_MIN;
        if (fSpinTime > SPIN_TIME_MAX) fSpinTime = SPIN_TIME_MAX;

        //時間別のパーセントを計算
        float stage = (SPIN_PERCENT_MAX - SPIN_PERCENT_MIN) / (SPIN_TIME_MAX - SPIN_TIME_MIN);

        return (fSpinTime - SPIN_TIME_MIN) * stage + SPIN_PERCENT_MIN;
    }
}