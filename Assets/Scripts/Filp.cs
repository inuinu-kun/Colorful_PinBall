using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Filp : MonoBehaviour, IPointerClickHandler//EventSystem�ł̃N���b�N����ɕK�v
{
    public Vector3 mousePosition;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonUp(0))//0�͍��N���b�N�̈����@�N���b�N���ꂽ���ǂ���
        {
            Vector3 mousePosition = Input.mousePosition;//���N���b�N���ꂽ�ʒu�����̓s�x����
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Pressed primary button.");
        Rigidbody rbody = GetComponent<Rigidbody>();
        Vector3 force = this.transform.position - mousePosition;
        rbody.AddForce(force * -2, ForceMode.Impulse);//�N���b�N���������Ɣ��Ε����ɒe��

    }

}
