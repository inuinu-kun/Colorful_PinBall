using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    //�ǂ̃{�[�����z���񂹂邩�^�O�Ŏw��
    public string targetTag;
    bool isHolding;
    public GameObject effectPrefab;//�G�t�F�N�g�����[���A�����𖞂������Ƃ��ɌĂяo��
    public Vector3 effectRotation;

    //�{�[���������Ă��邩��Ԃ�
    public bool IsHolding()
    {
        return isHolding;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == targetTag) 
        {
            isHolding = true;
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == targetTag)
        {
            isHolding=false;
        }
    }


    private void OnTriggerStay(Collider other)//Stay�͗��܂��Ă����
    {
        //�R���C�_�ɐG��Ă���I�u�W�F�N�g��Rigidbody�R���|�[�l���g���擾
        Rigidbody r = other.gameObject.GetComponent<Rigidbody>();

        //�{�[�����ǂ̕����ɂ���̂����v�Z
        Vector3 direction = other.gameObject.transform.position - transform.position;
        direction.Normalize();

        //�^�O�ɉ����ă{�[���ɗ͂�������
        if(other.gameObject.tag == targetTag)
        {
            //���S�n�_�Ń{�[�����~�߂邽�߂ɑ��x������������
            r.velocity *= 0.7f;
            r.AddForce(direction * -20.0f,ForceMode.Acceleration);//Acceleration ���X�ɗ͂�������Ă����@���΂̓C���p���X
            GameClearDetector gamecleardetector; //�ĂԃX�N���v�g�ɂ����Ȃ���
            GameObject obj = GameObject.Find("GameClearDetector"); //GameClearDetecto�I�u�W�F�N�g��T��
            gamecleardetector = obj.GetComponent<GameClearDetector>(); //�t���Ă���X�N���v�g���擾
            gamecleardetector.score += 1;
            Ballgnerator ballgnerator; //�ĂԃX�N���v�g�ɂ����Ȃ���
            GameObject obja = GameObject.Find("BallGnerator"); //BallGnerator�I�u�W�F�N�g��T��
            ballgnerator = obja.GetComponent<Ballgnerator>(); //�t���Ă���X�N���v�g���擾
            ballgnerator.ball -= 1;//�{�[���J�E���g��1���炷
            Destroy(other.gameObject);//�{�[�����폜
            if(effectPrefab != null)//�{�[�����z�[���ɓ������ۂɃG�t�F�N�g��\��
            {
                Instantiate(
                    effectPrefab,
                    other.transform.position,
                    Quaternion.Euler(effectRotation));
            }
        }
        else
        {
            {
                r.AddForce(direction* 80.0f,ForceMode.Acceleration);
            }
        }
    }
}
