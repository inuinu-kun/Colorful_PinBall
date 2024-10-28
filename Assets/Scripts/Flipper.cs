using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    // Inspecter�Œl��ύX����
    public float spring = 40000;
    public float openAngle = 60; // �J���p�x
    public float closeAngle = 0; // ����p�x

    // Hinge Joint
    private HingeJoint hjL; // AxisL
    private HingeJoint hjR; // AxisR

    // JointSpring
    private JointSpring jL; // AxisL
    private JointSpring jR; // AxisR

    void Start()
    {
        // AxisL��AxisR��T��
        GameObject flipperL = GameObject.Find("AxisL");
        GameObject flipperR = GameObject.Find("AxisR");

        // HingeJoint���󂯎��
        hjL = flipperL.GetComponent<HingeJoint>();
        hjR = flipperR.GetComponent<HingeJoint>();

        // Spring���󂯎��
        jL = hjL.spring;
        jR = hjR.spring;
    }

    void Update()
    {
        // F�L�[�������ƃt���b�p�[�������@����������ƊJ�����܂܂�
        if (Input.GetButtonDown("Fire1"))
        {
            jL.spring = spring;
            jL.targetPosition = openAngle;
            hjL.spring = jL;

        }
        
        if (Input.GetButtonUp("Fire1"))
        {
            jL.spring = spring;
            jL.targetPosition = closeAngle;
            hjL.spring = jL;
        }
        
        if (Input.GetButtonDown("Fire1"))
        {
            jR.spring = spring;
            jR.targetPosition = -openAngle;
            hjR.spring = jR;
        }
        
        if (Input.GetButtonUp("Fire1"))
        {
            jR.spring = spring;
            jR.targetPosition = closeAngle;
            hjR.spring = jR;
        }
    }
}
