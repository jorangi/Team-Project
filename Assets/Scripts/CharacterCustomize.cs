using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterCustomize : MonoBehaviour
{
    public Button nextScene;              //������ ���� ��ư
    private void Start()
    {
        //nextScene = GameObject.Find("NextButton0").GetComponent<Button>();
        Customized custom = FindObjectOfType<Customized>();
        nextScene.onClick.AddListener(() => {
            for(int i = 0; i<10; i++)
            {
                GameManager.Inst.temp[i, 0] = custom.parts[i].sprite;
            }
            SceneManager.LoadScene("CharacterSelect");
            }); //addListener�� �̺�Ʈ �߻� �ø��� �����
    }
}
