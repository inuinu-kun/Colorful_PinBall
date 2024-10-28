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
    public TMPro.TextMeshProUGUI Score;//TMP�̃e�L�X�g
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
       Score.text = "Score:" + score;//�X�R�A�\��
       Times.text = "Time:" + nowtime;//�c���Ԃ̕\��

       if (isConuntUp == false)//�^�C���̑���A�\��
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

        if (isConuntUp == true)//�^�C���A�b�v���̏���
        {
            TimeUp.text = "TimeUp!\n" + "Score:" + score;//\n�ŉ��s
            Invoke("ReturnToTitle",5);//5�b��Ƀ^�C�g���ɖ߂�
            enabled = false;//�ȍ~��Update���~�߂�
            Physics.autoSimulation = false;//�ȍ~�̃{�[���̋������~�߂�
            //Time.timeScale = 0;//�Q�[����S�Ē�~

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
