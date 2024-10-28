using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    // Inspecterで値を変更する
    public float spring = 40000;
    public float openAngle = 60; // 開く角度
    public float closeAngle = 0; // 閉じる角度

    // Hinge Joint
    private HingeJoint hjL; // AxisL
    private HingeJoint hjR; // AxisR

    // JointSpring
    private JointSpring jL; // AxisL
    private JointSpring jR; // AxisR

    void Start()
    {
        // AxisLとAxisRを探す
        GameObject flipperL = GameObject.Find("AxisL");
        GameObject flipperR = GameObject.Find("AxisR");

        // HingeJointを受け取る
        hjL = flipperL.GetComponent<HingeJoint>();
        hjR = flipperR.GetComponent<HingeJoint>();

        // Springを受け取る
        jL = hjL.spring;
        jR = hjR.spring;
    }

    void Update()
    {
        // Fキーを押すとフリッパーが動く　押し続けると開いたままに
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
