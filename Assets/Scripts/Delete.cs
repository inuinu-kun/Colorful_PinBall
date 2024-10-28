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
            Ballgnerator ballgnerator; //呼ぶスクリプトにあだなつける
            GameObject obj = GameObject.Find("BallGnerator"); //BallGneratoオブジェクトを探す 大文字に注意
            ballgnerator = obj.GetComponent<Ballgnerator>(); //付いているスクリプトを取得
            ballgnerator.ball -= 1;
        }

        else
        {
            Destroy(other.gameObject);
            Ballgnerator ballgnerator; //呼ぶスクリプトにあだなつける
            GameObject obj = GameObject.Find("BallGnerator"); //BallGneratorオブジェクトを探す
            ballgnerator = obj.GetComponent<Ballgnerator>(); //付いているスクリプトを取得
            ballgnerator.ball -= 1;
        }


    }
 
}
