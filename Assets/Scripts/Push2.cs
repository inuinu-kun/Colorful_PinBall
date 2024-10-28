using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Push2 : MonoBehaviour//右の動く壁用のスクリプト
{

    // Start is called before the first frame update
    Vector3 StartPos;
    public float disy = 0;
    public float disz = 0;
    public float speedy = 0;
    public float speedz = 0;

    // Start is called before the first frame update
    void Start()
    {

        StartPos = transform.position;
    }

    private void Update()
    {
        transform.position = new Vector3(StartPos.x, StartPos.y + Mathf.PingPong(Time.time, disy)*speedy, StartPos.z + Mathf.PingPong(Time.time, disz) * speedz);//Mathf.PingPongで往復させる
    }


}
