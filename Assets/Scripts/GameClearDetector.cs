using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;
using static UnityEditor.Timeline.TimelinePlaybackControls;
using UnityEditor.Profiling;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine.SceneManagement;

public class GameClearDetector : MonoBehaviour
{
    public Hole holeRed;
    public Hole holeBlue;
    public Hole holeGreen;
    public TMPro.TextMeshProUGUI Score;//TMPのテキスト
    public int score;

    public bool isConuntDown = true;
    public bool isConuntUp = false;
    public float gametime =0;
    public float nowtime =0;
    public float time = 0;
    public TMPro.TextMeshProUGUI Times;

    public TMPro.TextMeshProUGUI TimeUp;

    // Start is called before the first frame update
    void Start()
    {
        if (isConuntDown)
        {
            nowtime = gametime;
            TimeUp.text = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
       Score.text = "Score:" + score;//スコア表示
       Times.text = "Time:" + nowtime;//残時間の表示

       if (isConuntUp == false)//タイムの測定、表示
        {
            time += Time.deltaTime;
            if (isConuntDown)
            {
                nowtime = gametime - time;
                if(nowtime <= 0.0f)
                {
                    nowtime = 0.0f;
                    isConuntUp  = true;
                }

            }
            else
            {
                nowtime = time;
                if (nowtime >= gametime)
                {
                    nowtime = gametime;
                    isConuntUp = true;
                }
                Debug.Log("Time:" + nowtime);
            }
        }

        if (isConuntUp == true)//タイムアップ時の処理
        {
            TimeUp.text = "TimeUp!\n" + "Score:" + score;//\nで改行
            Invoke("ReturnToTitle",5);//5秒後にタイトルに戻る
            enabled = false;//以降のUpdateを止める
            Physics.autoSimulation = false;//以降のボールの挙動を止める
            //Time.timeScale = 0;//ゲームを全て停止

            if(PlayerPrefs.GetInt("HighScore")< score)
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
        }

    }

    void ReturnToTitle()
    {
        SceneManager.LoadScene("Title");
    }
        


}
