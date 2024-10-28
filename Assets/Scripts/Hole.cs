using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    //どのボールを吸い寄せるかタグで指定
    public string targetTag;
    bool isHolding;
    public GameObject effectPrefab;//エフェクトを収納し、条件を満たしたときに呼び出す
    public Vector3 effectRotation;

    //ボールが入っているかを返す
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


    private void OnTriggerStay(Collider other)//Stayは留まっている間
    {
        //コライダに触れているオブジェクトのRigidbodyコンポーネントを取得
        Rigidbody r = other.gameObject.GetComponent<Rigidbody>();

        //ボールがどの方向にあるのかを計算
        Vector3 direction = other.gameObject.transform.position - transform.position;
        direction.Normalize();

        //タグに応じてボールに力を加える
        if(other.gameObject.tag == targetTag)
        {
            //中心地点でボールを止めるために速度を減速させる
            r.velocity *= 0.7f;
            r.AddForce(direction * -20.0f,ForceMode.Acceleration);//Acceleration 徐々に力が加わっていく　反対はインパルス
            GameClearDetector gamecleardetector; //呼ぶスクリプトにあだなつける
            GameObject obj = GameObject.Find("GameClearDetector"); //GameClearDetectoオブジェクトを探す
            gamecleardetector = obj.GetComponent<GameClearDetector>(); //付いているスクリプトを取得
            gamecleardetector.score += 1;
            Ballgnerator ballgnerator; //呼ぶスクリプトにあだなつける
            GameObject obja = GameObject.Find("BallGnerator"); //BallGneratorオブジェクトを探す
            ballgnerator = obja.GetComponent<Ballgnerator>(); //付いているスクリプトを取得
            ballgnerator.ball -= 1;//ボールカウントを1減らす
            Destroy(other.gameObject);//ボールを削除
            if(effectPrefab != null)//ボールがホールに入った際にエフェクトを表示
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
