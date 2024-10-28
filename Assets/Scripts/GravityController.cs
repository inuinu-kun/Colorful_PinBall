using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GravityController : MonoBehaviour//基本的な重力の制御とキー入力によりボールに力を加える
{
    const float Gravity = 9.81f;
    public float gravityScale = 1.0f;
    public float x = 1.0f;//各々の方向に掛ける力の変数
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

        if (Application.isConsolePlatform)//スマホ操作用　開発中
        {
            vector.x = Input.acceleration.x;
            vector.z = Input.acceleration.y;
            vector.y = Input.acceleration.z;
        }
        else
        {

            if (Input.GetKey("s"))//下方向に力を加える
            {
                vector.z = z;
            }
            if (Input.GetKey("d"))//右方向に力を加える
            {
                vector.x = x;
            }
            if (Input.GetKey("a"))//左方向に力を加える
            {
                vector.x = l;
                vector.y = -1.0f;
            }
            else
            {
                vector.y = -1.0f;
            }
        }
        //シ－ンの重力を入力ボタンに合わせて変化させる　変数で掛け算
        Physics.gravity = Gravity * vector * gravityScale;

    }
}
