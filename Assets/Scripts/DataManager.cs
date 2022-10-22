using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class DataManager : MonoBehaviour
{
    //Json �����ϱ� ���� ����
    public JObject jsonPlayer = new JObject();
    public JObject parts = new JObject();
    public JObject partnerParts = new JObject();
    public JToken jtoken;

    public JObject jPartner1 = new JObject();
    public JObject jPartner2 = new JObject();

    string SAVE_DATA_DIRECTORY;

    public Sprite[] weapons = new Sprite[3];
    public Sprite[] shields = new Sprite[3];
    public uint weaponCount = 1;
    public uint shieldCount = 0;
    public uint EquipCount; 


    //ĳ���� Ŀ���͸�����(����) ����
    GameObject character0;
    GameObject character1;
    Customized[] customized = new Customized[2];

    //�÷��̾� ����
    CharacterStat characterStat;
    public CharacterStat CharacterStat => characterStat;

    //���� ����
    PartnerSelectView partnerSelectView;
    public PartnerSelectView PartnerSelectView => partnerSelectView;

    PartnerSelectBoard partnerSelectBoard;
    public PartnerSelectBoard PartnerSelectBoard => partnerSelectBoard;

    //�̱��� ---------------------------------------
    static DataManager instance = null;

    public static DataManager Instance => instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);

        }
        else
        {
            if (instance != this)
            {
                Destroy(this.gameObject);
            }
        }
    }
    //---------------------------------------------------

    private void Start()
    {
        character0 = GameObject.Find("Character0");

        if(character0 != null)
        customized[0] = character0.GetComponent<Customized>();


        SAVE_DATA_DIRECTORY = Application.dataPath + "/Resources/Json/";
        Test();

    }

    void Test()
    {
        //weapons[1] = Resources.Load<Sprite>($"Character/Weapons/Sword_2");
        //Debug.Log(weapons[1].ToString());
    }


    public Sprite[] sprites = new Sprite[10];


    //�÷��̾� ������ PlayerParts.json �� ����
    public void SavePlayerParts()
    {

        // 0: ��, 1: ���, 2: ����, 3: �Ƹ�, 4: ����, 5:������ ����, 6 : �޼� ����
        characterStat = FindObjectOfType<CharacterStat>();

        //���� 0~2��, ����
        for (int i = 0; i < 3; i++)
        {
            parts.Add($"{i}", GameManager.Inst.partsName[i]);
            parts.Add($"color{i}", GameManager.Inst.partsColor[i, 0].ToString());
            //Debug.Log($"{i}, {GameManager.Inst.partsColor[i, 0]}");
        }

        parts.Add($"{3}", GameManager.Inst.partsName[3]);
        parts.Add($"{4}", GameManager.Inst.partsName[6]);
        parts.Add($"{5}", GameManager.Inst.partsName[8]);
        parts.Add($"{6}", GameManager.Inst.partsName[9]);

        //�÷��̾� ���� : 0��
        //weapons[0] = characterStat.weapon;
        //array.Add(weapons[0]);
        parts.Add("weapon0", characterStat.weapon);

        //����
        string jsonPlayerParts = JsonConvert.SerializeObject(parts, Formatting.Indented);
        File.WriteAllText(SAVE_DATA_DIRECTORY + "/PlayerParts.json", jsonPlayerParts);
        Debug.Log("�÷��̾� ���� ����");        
    }


    //������ ������ ���� �÷��̾� �����͸� Player.json �� �ʱ�ȭ
    public void SetPlayerToJson()
    {
        if (!Directory.Exists(SAVE_DATA_DIRECTORY))
            Directory.CreateDirectory(SAVE_DATA_DIRECTORY);

        jtoken = characterStat.jTokenplayer;
        
        //DataManager�� �÷��̾� ���� ������ ���ļ� �����Ϸ��� �ߴµ� ����... ���߿� ����
        string player = JsonConvert.SerializeObject(jtoken, Formatting.Indented);
        File.WriteAllText(SAVE_DATA_DIRECTORY + "/Player.json", player);

        Debug.Log("�÷��̾� ������ Json �ʱ�ȭ");
    }

    //�̹��� ������� LoadParts.cs�� �� ����
    public void LoadPlayerparts()
    {


    }

    //Partner_1 ~3�� �����̹����� ����
    public void SavePartnerParts()
    {
        character1 = GameObject.Find("Character1");
        customized[1] = character1.GetComponent<Customized>();
        if (!Directory.Exists(SAVE_DATA_DIRECTORY))
            Directory.CreateDirectory(SAVE_DATA_DIRECTORY);

        //���� 0~2��, ����
        for (int i = 0; i < 3; i++)
        {
            partnerParts.Add($"{i}", GameManager.Inst.partsName[i]);
            partnerParts.Add($"color{i}", GameManager.Inst.partsColor[i, 0].ToString());
            //Debug.Log($"{i}, {GameManager.Inst.partsColor[i, 0]}");
        }

        partnerParts.Add($"{3}", GameManager.Inst.partsName[3]);
        partnerParts.Add($"{4}", GameManager.Inst.partsName[6]);
        partnerParts.Add($"{5}", GameManager.Inst.partsName[8]);
        partnerParts.Add($"{6}", GameManager.Inst.partsName[9]);

        string partnersParts = JsonConvert.SerializeObject(partnerParts, Formatting.Indented);
        File.WriteAllText(SAVE_DATA_DIRECTORY + $"/PartnerParts_{GameManager.Inst.partnerCount}.json", partnersParts);
        Debug.Log($"PartnerParts_{GameManager.Inst.partnerCount} ����");
    }

    public void SetPartnerToJson()
    {
        partnerSelectView = FindObjectOfType<PartnerSelectView>();

        if (!Directory.Exists(SAVE_DATA_DIRECTORY))
            Directory.CreateDirectory(SAVE_DATA_DIRECTORY);

        jtoken = PartnerSelectView.jTokenPartner;

        string partner = JsonConvert.SerializeObject(jtoken, Formatting.Indented);
        File.WriteAllText(SAVE_DATA_DIRECTORY + $"/Partner_{GameManager.Inst.partnerCount}.json", partner);

        Debug.Log($"��Ʈ�� ������_{GameManager.Inst.partnerCount}�� Json �ʱ�ȭ");
    }


    //SelectPartner������ ���õ� ������ ������ �������� ���� �Լ�
    public void LoadPartnerData()
    {

        if (GameManager.Inst.partnerCount == 1 || GameManager.Inst.partnerCount == 2)
        {
            string partner1 = File.ReadAllText(SAVE_DATA_DIRECTORY + $"/Partner_{GameManager.Inst.partnerCount- 1}.json");
            jPartner1 = JObject.Parse(partner1);

        }else if(GameManager.Inst.partnerCount == 3)
        {
            string partner1 = File.ReadAllText(SAVE_DATA_DIRECTORY + $"/Partner_{GameManager.Inst.partnerCount - 2}.json");
            jPartner1 = JObject.Parse(partner1);

            string partner2 = File.ReadAllText(SAVE_DATA_DIRECTORY + $"/Partner_{GameManager.Inst.partnerCount - 1}.json");
            jPartner2 = JObject.Parse(partner2);

        }
    }


    //5:������ ����_����, 6 : �޼� ����_��
    string weaponName;
    string shieldName;

    //���� ����̹��� �ʱ⿡ ����
    public void PopEquipmentImage()
    {

    }

    public void GainWeapon()
    {
        //weapon : ���ҽ�/���� ���� sword 6�� �̹��� �� 
        int weaponIndex = Random.Range(0, 7);
        weaponName = $"Sword_{weaponIndex}";

        weapons[1]= Resources.Load<Sprite>($"Character/Weapons/Sword_2");

    }

    public void GainShield()
    {
        //shield : ���ҽ�/�ǵ� ���� 9�� �̹���
        int shieldIndex = Random.Range(0, 10);
        shieldName = $"Shield_{shieldIndex}";

    }

}
