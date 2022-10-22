using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using System;

public class PartnerBoard : MonoBehaviour
{
    TextMeshPro requestTxt;
    TextMeshPro countTxt;

    Button partnerListButton; //���Ḯ��Ʈ ��ư


    //��������Ʈ
    //�Ʒ� 2�� ���� �ؾ��ϳ�??
    public Action onPartnerSelectBoardOpen;
    public Action onPartnerSelectBoardClose;
    public Action onOffSwitch;

    PopupController popupController;

    WaitForSeconds delayTime = new WaitForSeconds(0.5f);

    private void Awake()
    {
        requestTxt = transform.GetChild(0).GetComponent<TextMeshPro>();
        countTxt = transform.GetChild(1).GetComponent<TextMeshPro>();

        partnerListButton = transform.GetComponentInChildren<Button>();
        popupController = GameObject.Find("PopupNextSceneController").gameObject.GetComponent<PopupController>();

    }

    private void Start()
    {
        Initialize();

        partnerListButton.onClick.AddListener(OnOffSelectBoard);

        popupController.OnPartnerCount += OpenPartnerCount;

    }

    void Initialize()
    {
        requestTxt.text = "���Ḧ �����ϼ���";
        if(GameManager.Inst.partnerCount < 4)
        {

            countTxt.text = GameManager.Inst.partnerCount.ToString();
        }
        else
        {
            Debug.Log("�����ο��� ����");
        }
        
        StartCoroutine(PopUpQuestion());
    }
    IEnumerator PopUpQuestion()
    {
        yield return delayTime;
    }


    //���Ḯ��Ʈ��ư : PartnerSelectBoard �¿��� ����ġ
    public void OnOffSelectBoard()
    {
        onOffSwitch?.Invoke();
    }

    private void OpenPartnerCount()
    {
        StartCoroutine(OpenPartnerBoard());
    }

    IEnumerator OpenPartnerBoard()
    {
        yield return delayTime;
        requestTxt.text = "���Ḧ �����߽��ϴ�";
        countTxt.text = GameManager.Inst.partnerCount.ToString();
        FindObjectOfType<PartnerSelectBoard>().OnCheck();
    }

}
