using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Repair : MonoBehaviour
{
    int hp = 10;
    int mp = 10;
    int atk = 10;
    int magic = 10;
    int def = 10;
    int dex = 10;

    public GameObject p_BaconEgg;
    public GameObject p_ChickenLeg;
    public GameObject p_BeerChicken;
    public GameObject p_Winebread;
    public GameObject p_CakeCookie;

    public GameObject hp_up;
    public GameObject mp_up;
    public GameObject atk_up;
    public GameObject magic_up;
    public GameObject def_up;
    public GameObject dex_up;

    public GameObject yesBtn;
    public GameObject yesBtn1;
    public GameObject yesBtn2;
    public GameObject yesBtn3;
    public GameObject yesBtn4;
    public GameObject noBtn;

    public GameObject animBE;
    public GameObject animCL;
    public GameObject animBC;
    public GameObject animWB;
    public GameObject animCC;

    public Text hp_upText;
    public Text mp_upText;
    public Text atk_upText;
    public Text magic_upText;
    public Text def_upText;
    public Text dex_upText;

    public Text hp_now;
    public Text mp_now;
    public Text atk_now;
    public Text magic_now;
    public Text def_now;
    public Text dex_now;

    public AudioClip eatsound;
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(hp<31)
        hp_now.text = $"{hp}";
        else
        {
            hp_now.text = "<color=#ff0000>" + "30" + "</color>";        // �۾� ���������� �ٲ��
            hp_upText.text = "MAX";
        }

        if (atk < 31)
            atk_now.text = $"{atk}";
        else
        {
            atk_now.text = "<color=#ff0000>" + "30" + "</color>";        
            atk_upText.text = "MAX";
        }

        if (dex < 31)
            dex_now.text = $"{dex}";
        else
        {
            dex_now.text = "<color=#ff0000>" + "30" + "</color>";
            dex_upText.text = "MAX";
        }

        if (mp < 31)
            mp_now.text = $"{mp}";
        else
        {
            mp_now.text = "<color=#ff0000>" + "30" + "</color>";
            mp_upText.text = "MAX";
        }

        if (def < 31)
            def_now.text = $"{def}";
        else
        {
            def_now.text = "<color=#ff0000>" + "30" + "</color>";
            def_upText.text = "MAX";
        }

        if (magic < 31)
            magic_now.text = $"{magic}";
        else
        {
            magic_now.text = "<color=#ff0000>" + "30" + "</color>";
            magic_upText.text = "MAX";
        }

        if (Input.GetMouseButtonDown(0))        // ��ư�� ���� ����. 0�� ���콺 ����, 1�� ������, 2�� ��?
        {
            // ������Ʈ Ŭ���ǰ��ϱ�
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            

            if (hit.collider == null)       //hit.collider ����� ��(�� �ƴ� ��) ��쵵 �־�� ������ �ȶ�..
                Debug.Log("�� ���� Ŭ��");
            else
            {
                if (hit.collider.gameObject.tag == "BE")
                {
                    p_ChickenLeg.gameObject.SetActive(false);
                    p_BeerChicken.gameObject.SetActive(false);
                    p_Winebread.gameObject.SetActive(false);
                    p_CakeCookie.gameObject.SetActive(false);
                    p_BaconEgg.gameObject.SetActive(true);

                    mp_up.gameObject.SetActive(false);
                    dex_up.gameObject.SetActive(false);
                    def_up.gameObject.SetActive(false);
                    magic_up.gameObject.SetActive(false);
                    hp_up.gameObject.SetActive(true);
                    atk_up.gameObject.SetActive(true);

                    yesBtn1.gameObject.SetActive(false);
                    yesBtn2.gameObject.SetActive(false);
                    yesBtn3.gameObject.SetActive(false);
                    yesBtn4.gameObject.SetActive(false);
                    yesBtn.gameObject.SetActive(true);
                    noBtn.gameObject.SetActive(true);
                }

                if (hit.collider.gameObject.tag == "CL")
                {
                    p_BaconEgg.gameObject.SetActive(false);
                    p_BeerChicken.gameObject.SetActive(false);
                    p_Winebread.gameObject.SetActive(false);
                    p_CakeCookie.gameObject.SetActive(false);

                    hp_up.gameObject.SetActive(false);
                    dex_up.gameObject.SetActive(false);
                    def_up.gameObject.SetActive(false);
                    magic_up.gameObject.SetActive(false);

                    mp_up.gameObject.SetActive(true);
                    atk_up.gameObject.SetActive(true);

                    p_ChickenLeg.gameObject.SetActive(true);

                    yesBtn.gameObject.SetActive(false);
                    yesBtn2.gameObject.SetActive(false);
                    yesBtn3.gameObject.SetActive(false);
                    yesBtn4.gameObject.SetActive(false);
                    yesBtn1.gameObject.SetActive(true);
                    noBtn.gameObject.SetActive(true);

                }
                
                if (hit.collider.gameObject.tag == "BC")
                {
                    p_BaconEgg.gameObject.SetActive(false);
                    p_ChickenLeg.gameObject.SetActive(false);
                    p_Winebread.gameObject.SetActive(false);
                    p_CakeCookie.gameObject.SetActive(false);

                    hp_up.gameObject.SetActive(false);
                    def_up.gameObject.SetActive(false);
                    mp_up.gameObject.SetActive(false);
                    atk_up.gameObject.SetActive(false);

                    magic_up.gameObject.SetActive(true);
                    dex_up.gameObject.SetActive(true);

                    p_BeerChicken.gameObject.SetActive(true);

                    yesBtn.gameObject.SetActive(false);
                    yesBtn1.gameObject.SetActive(false);
                    yesBtn3.gameObject.SetActive(false);
                    yesBtn4.gameObject.SetActive(false);
                    yesBtn2.gameObject.SetActive(true);
                    noBtn.gameObject.SetActive(true);

                }

                if (hit.collider.gameObject.tag == "WB")
                {
                    p_BaconEgg.gameObject.SetActive(false);
                    p_ChickenLeg.gameObject.SetActive(false);
                    p_BeerChicken.gameObject.SetActive(false);
                    p_CakeCookie.gameObject.SetActive(false);

                    atk_up.gameObject.SetActive(false);
                    magic_up.gameObject.SetActive(false);
                    def_up.gameObject.SetActive(false);

                    hp_up.gameObject.SetActive(true);
                    mp_up.gameObject.SetActive(true);
                    dex_up.gameObject.SetActive(true);

                    p_Winebread.gameObject.SetActive(true);

                    yesBtn.gameObject.SetActive(false);
                    yesBtn1.gameObject.SetActive(false);
                    yesBtn2.gameObject.SetActive(false);
                    yesBtn4.gameObject.SetActive(false);
                    yesBtn3.gameObject.SetActive(true);
                    noBtn.gameObject.SetActive(true);

                }

                if (hit.collider.gameObject.tag == "CC")
                {
                    p_BaconEgg.gameObject.SetActive(false);
                    p_ChickenLeg.gameObject.SetActive(false);
                    p_BeerChicken.gameObject.SetActive(false);
                    p_Winebread.gameObject.SetActive(false);

                    hp_up.gameObject.SetActive(false);
                    atk_up.gameObject.SetActive(false);
                    dex_up.gameObject.SetActive(false);
                    mp_up.gameObject.SetActive(false);

                    def_up.gameObject.SetActive(true);
                    magic_up.gameObject.SetActive(true);

                    p_CakeCookie.gameObject.SetActive(true);

                    yesBtn.gameObject.SetActive(false);
                    yesBtn1.gameObject.SetActive(false);
                    yesBtn1.gameObject.SetActive(false);
                    yesBtn3.gameObject.SetActive(false);
                    yesBtn4.gameObject.SetActive(true);
                    noBtn.gameObject.SetActive(true);

                }
            }
        }
    }

    public void EraseAll()
    {
        yesBtn.gameObject.SetActive(false);
        yesBtn1.gameObject.SetActive(false);
        yesBtn2.gameObject.SetActive(false);
        yesBtn3.gameObject.SetActive(false);
        yesBtn4.gameObject.SetActive(false);
        noBtn.gameObject.SetActive(false);

        hp_up.gameObject.SetActive(false);
        atk_up.gameObject.SetActive(false);
        dex_up.gameObject.SetActive(false);
        mp_up.gameObject.SetActive(false);
        def_up.gameObject.SetActive(false);
        magic_up.gameObject.SetActive(false);

        EraseFood();
    }
    public void BE()
    {
        int hpup = Random.Range(5, 11);
        int atkup = Random.Range(5, 11);

        hp_upText.text = $"+{hpup}";
        StartCoroutine(BlinkHP());
        hp += hpup;

        atk_upText.text = $"+{atkup}";
        StartCoroutine(BlinkATK());
        atk += atkup;
        
        animBE.gameObject.SetActive(true);
        audioSource.clip = eatsound;
        audioSource.Play();

        //Destroy(hp_upText, 7.0f);
        //Destroy(atk_upText, 7.0f);        destroy�ϸ� �� ������Ʈ�� �ƿ� ���ŵǱ� ������ ��Ȱ��ȭ�� ���Ѿ���. 

        //Invoke("EraseAll", 7.0f);         �굵 �ȵǳ�.. ��Ȱ��ȭ���ѵ� �ڷ�ƾ ������ �ٽ� Ȱ��ȭ�Ǵµ���

        //StopAllCoroutines();              �̷��� �ϸ� �ڷ�ƾ�� �ٷ� ���缭 �ȵ�!!
        Invoke("StopBlink", 6.0f);
        Invoke("FinishEating", 6.0f);
        Invoke("animReset", 6.0f);
    }
    public void CL()
    {
        int mpup = Random.Range(5, 11);
        int atkup = Random.Range(5, 11);

        mp += mpup;
        mp_upText.text = $"+{mpup}";
        StartCoroutine(BlinkMP());

        atk += atkup;
        atk_upText.text = $"+{atkup}";
        StartCoroutine(BlinkATK());

        animCL.gameObject.SetActive(true);
        audioSource.clip = eatsound;
        audioSource.Play();

        Invoke("StopBlink", 6.0f);
        Invoke("FinishEating", 6.0f);
        Invoke("animReset", 6.0f);
    }
    public void BC()
    {
        int magicup = Random.Range(5, 11);
        int dexup = Random.Range(5, 11);

        magic += magicup;
        magic_upText.text = $"+{magicup}";
        StartCoroutine(BlinkMAGIC());

        dex += dexup;
        dex_upText.text = $"+{dexup}";
        StartCoroutine(BlinkDEX());

        animBC.gameObject.SetActive(true);
        audioSource.clip = eatsound;
        audioSource.Play();

        Invoke("StopBlink", 6.0f);
        Invoke("FinishEating", 6.0f);
        Invoke("animReset", 6.0f);
    }
    public void WB()
    {
        int hpup = Random.Range(5, 11);
        int mpup = Random.Range(5, 11);
        int dexup = Random.Range(5, 11);

        hp += hpup;
        hp_upText.text = $"+{hpup}";
        StartCoroutine(BlinkHP());
        mp += mpup;
        mp_upText.text = $"+{mpup}";
        StartCoroutine(BlinkMP());
        dex += dexup;
        dex_upText.text = $"+{dexup}";
        StartCoroutine(BlinkDEX());

        animWB.gameObject.SetActive(true);
        audioSource.clip = eatsound;
        audioSource.Play();

        Invoke("StopBlink", 6.0f);
        Invoke("FinishEating", 6.1f);
        Invoke("animReset", 6.0f);
    }
    public void CC()
    {
        int magicup = Random.Range(5, 11);
        int defup = Random.Range(5, 11);

        magic += magicup;
        magic_upText.text = $"+{magicup}";
        StartCoroutine(BlinkMAGIC());

        def += defup;
        def_upText.text = $"+{defup}";
        StartCoroutine(BlinkDEF());

        animCC.gameObject.SetActive(true);
        audioSource.clip = eatsound;
        audioSource.Play();

        Invoke("StopBlink", 6.0f);
        Invoke("FinishEating", 6.1f);
        Invoke("animReset", 6.0f);
    }
    public void EraseFood()
    {
        p_BaconEgg.gameObject.SetActive(false);
        p_ChickenLeg.gameObject.SetActive(false);
        p_BeerChicken.gameObject.SetActive(false);
        p_Winebread.gameObject.SetActive(false);
        p_CakeCookie.gameObject.SetActive(false);
    }
    IEnumerator BlinkHP()
    {
        while (true)
        {
            hp_upText.gameObject.SetActive(true);
            yield return new WaitForSeconds(.5f);
            hp_upText.gameObject.SetActive(false);
            yield return new WaitForSeconds(.5f);
        }
    }
    IEnumerator BlinkMP()
    {
        while (true)
        {
            mp_upText.gameObject.SetActive(true);
            yield return new WaitForSeconds(.5f);
            mp_upText.gameObject.SetActive(false);
            yield return new WaitForSeconds(.5f);
        }
    }
    IEnumerator BlinkATK()
    {
        while (true)
        {
            atk_upText.gameObject.SetActive(true);
            yield return new WaitForSeconds(.5f);
            atk_upText.gameObject.SetActive(false);
            yield return new WaitForSeconds(.5f);
        }
    }
    IEnumerator BlinkMAGIC()
    {
        while (true)
        {
            magic_upText.gameObject.SetActive(true);
            yield return new WaitForSeconds(.5f);
            magic_upText.gameObject.SetActive(false);
            yield return new WaitForSeconds(.5f);
        }
    }
    IEnumerator BlinkDEF()
    {
        while (true)
        {
            def_upText.gameObject.SetActive(true);
            yield return new WaitForSeconds(.5f);
            def_upText.gameObject.SetActive(false);
            yield return new WaitForSeconds(.5f);
        }
    }
    IEnumerator BlinkDEX()
    {
        while (true)
        {
            dex_upText.gameObject.SetActive(true);
            yield return new WaitForSeconds(.5f);
            dex_upText.gameObject.SetActive(false);
            yield return new WaitForSeconds(.5f);
        }
    }
    private void FinishEating()
    {
        EraseAll();
    }
    private void StopBlink()
    {
        StopAllCoroutines();
        EraseAll();
    }
    private void animReset()
    {
        animBE.gameObject.SetActive(false);
        animCL.gameObject.SetActive(false);
        animBC.gameObject.SetActive(false);
        animWB.gameObject.SetActive(false);
        animCC.gameObject.SetActive(false);
    }
    //���� �ִ� ���ϱ�
    //ȭ�� �̹����� �ݶ��̴��ְ�(Ŭ�� �ǵ���) �ݶ��̴� ��Ʈ���� ���� ��Ʈ�� ���� ũ���Ѵ�����.. Ŭ���ϸ� ��ҵǰ�?

    //�������� ���� Ȯ�� �ٲ��
    public void ChangeToMain()
    {
        SceneManager.LoadScene("MainScene");
    }
}

//���ÿ� ������ �ִ� ���¿����� ���ĸ޴��� ���콺�����ص� ���� �ȶߵ���...