using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Aura_Next_Stage2 : MonoBehaviour
{
    //�縷������ �̵�
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("Stage_2.5");
        }
        

    }
}
