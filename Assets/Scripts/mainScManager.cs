using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainScManager : MonoBehaviour
{
    public GameObject minigame;
    public GameObject cooking;
    //public GameObject Village;

    public void pointEnter1()   //ui ��ư�� eventTrigger �߰��ؼ� mouseEnter(���콺 Ŀ�� �÷��� ��)
    {
        minigame.gameObject.SetActive(true);
    }

    public void pointExit1()    //ui ��ư�� eventTrigger �߰��ؼ� mouseExit(���콺 Ŀ�� ����� ��)
    {
        minigame.gameObject.SetActive(false);
    }

    public void pointEnter2()
    {
        cooking.gameObject.SetActive(true);
    }

    public void pointExit2()
    {
        cooking.gameObject.SetActive(false);
    }

    //public void pointEnter3()
    //{
    //    Village.gameObject.SetActive(true);
    //}

    //public void pointExit3()
    //{
    //    Village.gameObject.SetActive(false);
    //}

    public void SceneChange()
    {
        SceneManager.LoadScene("FoodScene");
    }
}
