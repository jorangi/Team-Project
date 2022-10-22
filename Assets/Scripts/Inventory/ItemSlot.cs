using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlot : MonoBehaviour
{
    ItemData slotItemData;
    uint itemCount;
    public ItemSlot() { }

    public System.Action onSlotItemChange;

    public ItemSlot(ItemData data, uint count)
    {
        slotItemData = data;
        itemCount = count;
    }
    public ItemData SlotItemData
    {
        get => slotItemData;
        private set
        {
            if (slotItemData != value)
            {
                slotItemData = value;
                onSlotItemChange?.Invoke(); 

            }
        }
    }
    public uint ItemCount
    {
        get => itemCount;
        private set
        {
            itemCount = value;
            onSlotItemChange?.Invoke();

        }
    }
    public ItemSlot(ItemSlot other)
    {
        slotItemData = other.SlotItemData;
        itemCount = other.ItemCount;
    }
    public uint IncreaseSlotItem(uint count = 1)
    {
        uint newCount = ItemCount + count;
        int overCount = (int)newCount - (int)SlotItemData.maxStackCount;
        if (overCount > 0)
        {
            ItemCount = SlotItemData.maxStackCount;
        }
        else
        {
            ItemCount = newCount;
            overCount = 0;
        }
        return (uint)overCount; 
    }

    public void DecreaseSlotItem(uint count = 1)
    {
        int newCount = (int)ItemCount - (int)count;
        if (newCount < 1)   // ���������� ������ 0�̵Ǹ� ���� ����
        {
            // �� ����.
            ClearSlotItem();
        }
        else
        {
            ItemCount = (uint)newCount;
        }
    }
    public void AssignSlotItem(ItemData itemData, uint count = 1)
    {
        ItemCount = count;
        SlotItemData = itemData;
    }
    public void UseSlotItem(GameObject target = null)
    {
        IUsable usable = SlotItemData as IUsable;   // �� �������� ��밡���� ���������� Ȯ��
        if (usable != null)
        {
            // �������� ��밡���ϸ�
            usable.Use(target); // ������ ����ϰ�
            DecreaseSlotItem(); // ���� �ϳ� ����
        }
    }
    public bool IsEmpty()
    {
        return slotItemData == null;
    }
    public void ClearSlotItem()
    {
        SlotItemData = null;
        ItemCount = 0;
    }
}
