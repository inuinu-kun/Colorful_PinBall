using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;

public class Ballgnerator : MonoBehaviour
{
    // Start is called before the first frame update
    public int ball = 3;//���݂̃{�[���̌�
    public int balllimit = 10;//�{�[���̏��
    public GameObject[] BallPrefabs; //Instantiate�Ő�������Ώہi�z��
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
        if (ball < balllimit)//limit�����Ȃ�{�[���𐶐�
        {
            BallGnerator();
            ball += 1;
        }
    }

    GameObject sampleBall()
    {
        int index = Random.Range(0, BallPrefabs.Length);
        return BallPrefabs[index];//�v���n�u���烉���_���ɂƂ������l���v���n�u�ɕԂ� ���̃��\�b�h�ł̃����_�������̏���
    }

    void BallGnerator()
    {

        Instantiate(sampleBall());//sampleBall����{�[���𐶐�

    }

   public  void reduce(int ball)
    {
        Debug.Log("reduce");
        return;
    }
}