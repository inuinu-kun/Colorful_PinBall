using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;

public class Ballgnerator : MonoBehaviour
{
    // Start is called before the first frame update
    public int ball = 3;//現在のボールの個数
    public int balllimit = 10;//ボールの上限
    public GameObject[] BallPrefabs; //Instantiateで生成する対象（配列
    public float delayTime = 3.0f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (ball < balllimit)//limit未満ならボールを生成
        {
            BallGnerator();
            ball += 1;
        }
    }

    GameObject sampleBall()
    {
        int index = Random.Range(0, BallPrefabs.Length);
        return BallPrefabs[index];//プレハブからランダムにとった数値をプレハブに返す 下のメソッドでのランダム生成の準備
    }

    void BallGnerator()
    {

        Instantiate(sampleBall());//sampleBallからボールを生成

    }

   public  void reduce(int ball)
    {
        Debug.Log("reduce");
        return;
    }
}