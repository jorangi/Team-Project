using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BE : MonoBehaviour
{
    private void OnMouseEnter()  //���콺�� ������Ʈ ���� ���� ��
    {
        transform.localScale = new Vector3(1.1f, 1.2f, 1.2f);
    }

    private void OnMouseExit()
    {
        transform.localScale = new Vector3(0.9f, 1, 1);
    }
}
