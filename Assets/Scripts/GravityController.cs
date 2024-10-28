using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GravityController : MonoBehaviour//��{�I�ȏd�͂̐���ƃL�[���͂ɂ��{�[���ɗ͂�������
{
    const float Gravity = 9.81f;
    public float gravityScale = 1.0f;
    public float x = 1.0f;//�e�X�̕����Ɋ|����͂̕ϐ�
    public float l = -1.0f;
    public float z = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vector = new Vector3();

        if (Application.isConsolePlatform)//�X�}�z����p�@�J����
        {
            vector.x = Input.acceleration.x;
            vector.z = Input.acceleration.y;
            vector.y = Input.acceleration.z;
        }
        else
        {

            if (Input.GetKey("s"))//�������ɗ͂�������
            {
                vector.z = z;
            }
            if (Input.GetKey("d"))//�E�����ɗ͂�������
            {
                vector.x = x;
            }
            if (Input.GetKey("a"))//�������ɗ͂�������
            {
                vector.x = l;
                vector.y = -1.0f;
            }
            else
            {
                vector.y = -1.0f;
            }
        }
        //�V�|���̏d�͂���̓{�^���ɍ��킹�ĕω�������@�ϐ��Ŋ|���Z
        Physics.gravity = Gravity * vector * gravityScale;

    }
}
