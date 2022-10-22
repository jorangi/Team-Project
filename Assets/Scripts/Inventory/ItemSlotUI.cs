using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

public class ItemSlotUI : MonoBehaviour, IPointerClickHandler
{
    uint id;

    protected ItemSlot itemSlot;
    InventoryUI invenUI;
    protected Image itemImage;
    protected TextMeshProUGUI countText;
    Inventory inven;
    PopUpMenu popUpMenu;

    Image equipment;
    string eName;

    public uint ID { get => id; }
    public ItemSlot ItemSlot { get => itemSlot; }
    protected virtual void Awake()  // �������̵� �����ϵ��� virtual �߰�
    {
        itemImage = transform.GetChild(0).GetComponent<Image>();    // ������ ǥ�ÿ� �̹��� ������Ʈ ã�Ƴ���
        countText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        
        popUpMenu = FindObjectOfType<PopUpMenu>();
        
        equipment = GameObject.Find("Equipment").transform.Find("EquipImage").GetComponent<Image>();

    }


    private void Start()
    {
        inven = new Inventory();

        string partner1 = File.ReadAllText(Application.dataPath + "/Resources/Json/" + $"/PlayerParts.json");
        jobject = JObject.Parse(partner1);

        //���� ��� �����ֱ�
        eName= jobject["5"].ToString();
        equipment.sprite = Resources.Load<Sprite>($"Character/Weapons/{eName.Replace(".png", "")}");
    }


    public void Initialize(uint newID, ItemSlot targetSlot)
    {
        invenUI = ItemDataManager.Inst.InvenUI;

        id = newID;
        itemSlot = targetSlot;
        itemSlot.onSlotItemChange = Refresh; 
    }

    private void Update()
    {
        if (popUpMenu.isChange)
        {
            ChangeEqipment();
        }
    }

    public void Refresh()
    {
        if (itemSlot.SlotItemData != null)
        {
            // �� ���Կ� �������� ������� ��
            itemImage.sprite = itemSlot.SlotItemData.sprite;  // ������ �̹��� �����ϰ�
            itemImage.color = Color.white;  // �������ϰ� �����
            countText.text = itemSlot.ItemCount.ToString();
        }
        else
        {
            // �� ���Կ� �������� ���� ��
            itemImage.sprite = null;        // ������ �̹��� �����ϰ�
            itemImage.color = Color.clear;  // �����ϰ� �����
            countText.text = "";
        }
    }

    GameObject equipmentObj;


    public void OnPointerClick(PointerEventData eventData)
    {
        // ���콺 ���� ��ư Ŭ���� ��
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            // �׳� Ŭ���� ��Ȳ
            if (!ItemSlot.IsEmpty())
            {
                //1. �˾�â : ������� ���� ���� ����� ����� �� Q
                popUpMenu.OnOffSwitch();

                //2. save ��ư ������ ��� �ٲ�
                equipmentObj = eventData.pointerCurrentRaycast.gameObject;
            }
        }
    }

    JObject jobject = new JObject();
    JObject equip = new JObject();

    public void ChangeEqipment()
    {
        Sprite temp = equipment.sprite;

        if (equipmentObj != null)
        {

            Debug.Log(this.name);
            //�� �̹��� �߰�
            equipment.sprite = equipmentObj.GetComponent<Image>().sprite;
            uint tempNum = uint.Parse(equipmentObj.name.Substring(8));

            //���߿� ���� Ȯ�� �ʿ� : ����UI �̹����� �������
            equipmentObj.GetComponentInParent<Image>().sprite = null;
            popUpMenu.isChange = false;

        }


        jobject.Remove("5");
        jobject.Add("5", $"{equipment.sprite.name}.png");

        string partner = JsonConvert.SerializeObject(jobject, Formatting.Indented);
        File.WriteAllText(Application.dataPath + "/Resources/Json/" + $"/PlayerParts.json", partner);
        /*{GameManager.Inst.partnerCount}*/

        Debug.Log($"eqipment_{equipment.sprite.name}��� �߰� ");
    }

}
