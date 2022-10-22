using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CursorController : MonoBehaviour
{
    public Texture2D cursor;
    public Texture2D cursorClicked;

    private CursorControlls controls;

    private void Awake()
    {
        //InputAction Asset ��������
        controls = new CursorControlls();

        //Ŀ���̹��� ����
        ChangeCursor(cursor); 


        //Cursor.lockState = CursorLockMode.Confined; //���� â ������ ���콺�� �ȳ���

        //Cursor.lockState = CursorLockMode.Locked; // ���콺�� ���� �߾� ��ǥ�� ������Ű�� ���콺Ŀ���� �Ⱥ���
        //Cursor.lockState = CursorLockMode.None; // ���콺Ŀ�� ����

    }


    public void OnEnable()
    {
        controls.Enable();
        //��������Ʈ����
        controls.Mouse.Click.started += _ => StartedClick();
        controls.Mouse.Click.canceled += _ => EndedClick();
    }

    public void OnDisable()
    {
        controls.Mouse.Click.canceled -= _ => EndedClick();
        controls.Mouse.Click.started -= _ => StartedClick();
        controls.Disable();
    }


    public void StartedClick()
    {
        ChangeCursor(cursorClicked);
    }

    public void EndedClick()
    {
        ChangeCursor(cursor);
    }

    
    public void ChangeCursor(Texture2D cursorType)
    {
        //hotspot : Cursor Texture�� ��� �κ��� ���콺�� ��ǥ������ ����
        Vector2 hotSpot = new Vector2(cursorType.width /2, cursorType.height /2);   
        Cursor.SetCursor(cursorType, Vector2.zero, CursorMode.Auto);
    }

}
