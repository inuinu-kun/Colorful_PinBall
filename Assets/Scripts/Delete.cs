using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete : MonoBehaviour
{

    //Ballgnerator ballgnerator = new Ballgnerator();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BallGreen")
        {
            Destroy(other.gameObject);
            Ballgnerator ballgnerator; //�ĂԃX�N���v�g�ɂ����Ȃ���
            GameObject obj = GameObject.Find("BallGnerator"); //BallGnerato�I�u�W�F�N�g��T�� �啶���ɒ���
            ballgnerator = obj.GetComponent<Ballgnerator>(); //�t���Ă���X�N���v�g���擾
            ballgnerator.ball -= 1;
        }

        else
        {
            Destroy(other.gameObject);
            Ballgnerator ballgnerator; //�ĂԃX�N���v�g�ɂ����Ȃ���
            GameObject obj = GameObject.Find("BallGnerator"); //BallGnerator�I�u�W�F�N�g��T��
            ballgnerator = obj.GetComponent<Ballgnerator>(); //�t���Ă���X�N���v�g���擾
            ballgnerator.ball -= 1;
        }


    }
 
}
