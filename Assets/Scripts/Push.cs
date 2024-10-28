using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;

public class Push : MonoBehaviour//左の動く壁用のスクリプト
{

    Vector3 StartPos;
    public float disy = 0;
    public float disz = 0;
    public float speed = 0;
    // Start is called before the first frame update
    void Start()
    {

        StartPos = transform.position;
    }

    private void Update()
    {
        transform.position = new Vector3(StartPos.x, StartPos.y + Mathf.PingPong(Time.time, disy), StartPos.z + Mathf.PingPong(Time.time, disz)*speed);//Mathf.PingPongで往復させる
    }


}
