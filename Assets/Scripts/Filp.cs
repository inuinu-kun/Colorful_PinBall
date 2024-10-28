using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Filp : MonoBehaviour, IPointerClickHandler//EventSystemでのクリック判定に必要
{
    public Vector3 mousePosition;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonUp(0))//0は左クリックの引数　クリックされたかどうか
        {
            Vector3 mousePosition = Input.mousePosition;//左クリックされた位置をその都度判定
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Pressed primary button.");
        Rigidbody rbody = GetComponent<Rigidbody>();
        Vector3 force = this.transform.position - mousePosition;
        rbody.AddForce(force * -2, ForceMode.Impulse);//クリックした方向と反対方向に弾く

    }

}
