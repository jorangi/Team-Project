using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Test_Skill : MonoBehaviour
{
    public GameObject player;


    public GameObject partner1;
    public GameObject partner2;
    public GameObject partner3;

    public GameObject goblin;
    public GameObject fiend;
    public GameObject golem;
    public GameObject darkLord;

    Button movebtn;
    Button attackbtn;
    Button skillbtn;


    Transform movePoint;    //�÷��̾� �̵�����
    Transform movePoint2;    //���� �̵�����
    public Animator anim;
    public float moveSpeed = 10;

    public CharacterData characters;


    public GameObject testplayer;
    public Animator testAnim;

    public ParticleSystem fireparticle;
    public GameObject cureparticle;
    //public GameObject shadow;

    public bool isPlay = false;


    private void Awake()
    {
        movebtn = GameObject.Find("Move").GetComponent<Button>();
        attackbtn = GameObject.Find("Attack").GetComponent<Button>();
        skillbtn = GameObject.Find("Skill").GetComponent<Button>();
        movePoint = GameObject.Find("MovePoint").gameObject.transform;
        movePoint2 = GameObject.Find("MovePoint_2").gameObject.transform;

        characters = FindObjectOfType<CharacterData>();

        fireparticle = GameObject.Find("Mage_Particle_fire").GetComponent<ParticleSystem>();

    }


    void Start()
    {
        player = Instantiate(player, new Vector3(-6.0f, 3f, 0), Quaternion.identity);
        partner1 = Instantiate(partner1, new Vector3(-6.0f, 1f, 0), Quaternion.identity);
        partner2 = Instantiate(partner2, new Vector3(-6.0f, -1f, 0), Quaternion.identity);
        partner3 = Instantiate(partner3, new Vector3(-6.0f, -3f, 0), Quaternion.identity);
   

        goblin = Instantiate(goblin, new Vector3(6.0f, 3.0f,0), Quaternion.identity);
        fiend = Instantiate(fiend, new Vector3(6.0f, 1, 0), Quaternion.identity);
        golem = Instantiate(golem, new Vector3(6.0f, -1.0f, 0), Quaternion.identity);
        darkLord = Instantiate(darkLord, new Vector3(6.0f, -3.0f, 0), Quaternion.identity);

        anim = player.GetComponent<Animator>();
        movebtn.onClick.AddListener(onMove);
        attackbtn.onClick.AddListener(onAttack);
        skillbtn.onClick.AddListener(onSkill);

        testAnim = testplayer.GetComponent<Animator>();
        cureparticle.SetActive(false);
        //shadow.SetActive(false);

    }

    private void Update()
    {
        if (Keyboard.current.digit1Key.isPressed)
        {
            isPlay = true;
            if(isPlay)
            {
                SkillWarrior();

            }

        }else if (Keyboard.current.digit2Key.isPressed)
        {
            isPlay = true;
            if (isPlay)
            {
                SkillMage();

            }

        }else if (Keyboard.current.digit3Key.isPressed)
        {
            isPlay = true;
            if (isPlay)
            {
                SkillCleric();

            }
        }else if(Keyboard.current.digit4Key.isPressed)
        {
            isPlay = true;
            if (isPlay)
            {
                SkillThief();

            }

        }else if (Keyboard.current.digit5Key.isPressed)
        {
            isPlay = true;
            if (isPlay)
            {
                SkillPopstar();

            }
        }else if (Keyboard.current.digit6Key.isPressed)
        {
            isPlay = true;
            if (isPlay)
            {
                SkillChef();

            }
        }

    }


    //�Ϲݰ���, ���ӽð� ����
    private void onAttack()
    {
        testAnim.Play("2_Attack_Normal");
    }

    //��ų����
    private void onSkill()
    {
        //�Ϲ� ����
        testAnim.Play("2_Attack_Magic");

        //������ ��ų : ��������, ���� 2 ����, ���� �پ�ö� ���� ������ �� �ϳ��� ���ϴ�.
        //������ ��ų : ���̾�, 2, �� �ϳ����� ������ �Ҳ��� ���� ���ظ� �ݴϴ�.
        //�·� : ť��, 2, �⵵�� ������ HP�� ȸ���Ѵ�. 
        //���� : ����, 2, �ڽ� �տ� ������ ��ġ�� ������ ���� ������ ���ظ� �ݴϴ�.
        //���̵� : ���� ���� �뷡 (Earworm), 2, "�� �� ���� ���� ���Ǹ� �길�ϰ� �ؼ� �뷡�� ���� ���� �߰� �Ѵ�."
        //���� : ȸ���丮,  3, �丮�� ����� ���� �� ���� ü���� ȸ����ŵ�ϴ�.


    }

    void SkillWarrior()     //��������, trail_blue
    {
        float skillTime = 1f;

        while(skillTime >0)
        {
            testAnim.Play("5_Skill_Magic");
            skillTime -= Time.deltaTime;
        }
        //anim.Stop("5_Skill_Magic");

        //�ӽ� :  ����2 ���� 
        characters.mp -= 2;

    }

    void SkillMage()        //���̾�, ��ƼŬ + ������ٵ�2D
    {
        testAnim.Play("5_Skill_Bow");

        characters.mp -= 2;

        //���̾�
        //�ӽ÷� ����� Ÿ������ 
        Vector3 dir = darkLord.transform.position - fireparticle.transform.position;
        
        fireparticle.transform.Rotate(0, 0, 60f);

        
        if (dir.sqrMagnitude > 0.01f)
        {
            fireparticle.GetComponent<Rigidbody2D>().velocity = dir.normalized * moveSpeed; 
        }
    }

    void SkillCleric()       //ť��, 2, �⵵�� ������ HP�� ȸ��
    {
        testAnim.Play("2_Attack_Bow");
        characters.mp -= 2;

        cureparticle.SetActive(true);

    }

    void SkillThief()       //����, 2, �� �տ� ���� �����
    {
        testAnim.Play("5_Skill_Normal");
        characters.mp -= 2;
        //������ ��ġ�� ���� ǥ��

       // shadow.SetActive(true);
        //shadow.GetComponent<SpriteRenderer>().color = MathF.Ler




    }

    void SkillPopstar()     //���� ���� �뷡 (Earworm), ���� ���� �߰� ������ �� ��
    {
        testAnim.Play("2_Attack_Bow");
        characters.mp -= 2;
    }

    void SkillChef()        //ȸ���丮,  3, �丮�� ����� �ڽŰ� ���� �� ���� ü���� ȸ��
    {
        testAnim.Play("2_Attack_Magic");
        characters.mp -= 2;
    }


    private void onMove()
    {
        while ((movePoint.position - player.transform.position).sqrMagnitude > 0.1f)
        {
            Move();
        }
    }

    private void Move()
    {
        //�ִϸ��̼� ����   
        player.transform.position = Vector3.MoveTowards(player.transform.position, movePoint.position, Time.deltaTime * moveSpeed);
        goblin.transform.position = Vector3.MoveTowards(goblin.transform.position, movePoint2.position, Time.deltaTime * moveSpeed);

    }



}
