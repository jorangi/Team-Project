using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CC : MonoBehaviour
{
    private void OnMouseEnter()  //���콺�� ������Ʈ ���� ���� ��
    {
        transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
    }

    private void OnMouseExit()
    {
        transform.localScale = new Vector3(1, 1, 1);
    }
}
