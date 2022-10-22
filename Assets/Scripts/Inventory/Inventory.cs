using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public const int InvenSize = 6;
    ItemSlot[] slots = null;

    public int SlotCount => slots.Length;
    public ItemSlot this[int index] => slots[index]; 
    public Inventory(int size = InvenSize)
    {
        slots = new ItemSlot[size];     
        for (int i = 0; i < size; i++)
        {
            slots[i] = new ItemSlot();
        }
    }
    public bool AddItem(uint id)
    {
        return AddItem(ItemDataManager.Inst.ItemData[id]);
    }
    public bool AddItem(ItemCode code)
    {
        return AddItem(ItemDataManager.Inst.ItemData[code]);
    }
    public bool AddItem(ItemData data)
    {
        bool result = false;
        //Debug.Log($"�κ��丮�� {data.itemName}�� �߰��մϴ�");

        ItemSlot target = FindSameItem(data);   // ���� ������ �������� �κ��丮�� �ִ��� ã��
        if (target != null)
        {
            // ���� ������ �������� ������ 1�� ������Ų��.
            target.IncreaseSlotItem();
            result = true;
            //Debug.Log($"{data.itemName}�� �ϳ� ������ŵ�ϴ�.");
        }
        else
        {
            // ���� ������ �������� ����.
            ItemSlot empty = FindEmptySlot();    // ������ �� ���� ã��
            if (empty != null)
            {
                empty.AssignSlotItem(data);      // ������ �Ҵ�
                result = true;
                //Debug.Log($"������ ���Կ� {data.itemName}�� �Ҵ��մϴ�.");
            }
            else
            {
                // ��� ���Կ� �������� ����ִ�.(�κ��丮�� ����á��.)
                //Debug.Log($"���� : �κ��丮�� ����á���ϴ�.");
            }
        }

        return result;
    }
    public bool AddItem(uint id, uint index)
    {
        return AddItem(ItemDataManager.Inst.ItemData[id], index);
    }
    public bool AddItem(ItemCode code, uint index)
    {
        return AddItem(ItemDataManager.Inst.ItemData[code], index);
    }
    public bool AddItem(ItemData data, uint index)
    {
        bool result = false;

        ItemSlot slot = slots[index];   // index��°�� ���� ��������

        if (slot.IsEmpty())              // ã�� ������ ������� Ȯ��
        {
            slot.AssignSlotItem(data);  // ��������� ������ �߰�
            result = true;
            Debug.Log($"�߰��� �����߽��ϴ�.");
        }
        else
        {
            if (slot.SlotItemData == data)  // ���� ������ �������ΰ�?
            {
                if (slot.IncreaseSlotItem() == 0)  // �� �ڸ��� �ִ°�?
                {
                    result = true;
                    Debug.Log($"������ ���� ������ �����߽��ϴ�.");
                }
                else
                {
                    Debug.Log($"���� : ������ ���� á���ϴ�.");
                }
            }
            else
            {
                Debug.Log($"���� : {index} ���Կ��� �ٸ� �������� ����ֽ��ϴ�.");
            }
        }

        return result;
    }
    private ItemSlot FindSameItem(ItemData itemData)
    {
        ItemSlot slot = null;
        for (int i = 0; i < SlotCount; i++)
        {
            if (slots[i].SlotItemData == itemData && slots[i].ItemCount < slots[i].SlotItemData.maxStackCount)
            {
                slot = slots[i];
                break;
            }
        }
        return slot;
    }
    public bool RemoveItem(uint slotIndex, uint decreaseCount = 1)
    {
        bool result = false;

        //Debug.Log($"�κ��丮���� {slotIndex} ������ �������� {decreaseCount}�� ���ϴ�.");
        if (IsValidSlotIndex(slotIndex))        // slotIndex�� ������ �������� Ȯ��
        {
            ItemSlot slot = slots[slotIndex];
            slot.DecreaseSlotItem(decreaseCount);
            //Debug.Log($"������ �����߽��ϴ�.");
            result = true;
        }
        else
        {
            Debug.Log($"���� : �߸��� �ε����Դϴ�.");
        }

        return result;
    }
    private ItemSlot FindEmptySlot()
    {
        ItemSlot result = null;

        foreach (var slot in slots)  
        {
            if (slot.IsEmpty())    
            {
                result = slot;      
                break;
            }
        }
        return result;
    }
    public void TempRemoveItem(uint from, uint count = 1, bool equiped = false)
    {
        if (IsValidAndNotEmptySlot(from))  // from�� ������ �����̸�
        {
            ItemSlot slot = slots[from];
            slot.DecreaseSlotItem(count);   // from ���Կ��� �ش� ������ŭ ����            
        }
    }
    private bool IsValidSlotIndex(uint index) => (index < SlotCount);
    
    private bool IsValidAndNotEmptySlot(uint index)
    {
        ItemSlot testSlot = null;

        return (IsValidSlotIndex(index) && !testSlot.IsEmpty());
    }
    public void PrintInventory()
    {
        // ���� �κ��丮 ������ �ܼ�â�� ����ϴ� �Լ�

        string printText = "[";
        for (int i = 0; i < SlotCount - 1; i++)         // ������ ��ü6���� ��� 0~4������ �ϴ� �߰�(5���߰�)
        {
            if (slots[i].SlotItemData != null)
            {
                printText += $"{slots[i].SlotItemData.itemName}({slots[i].ItemCount})";
            }
            else
            {
                printText += "(��ĭ)";
            }
            printText += ",";
        }
        ItemSlot slot = slots[SlotCount - 1]; 
        if (!slot.IsEmpty())
        {
            printText += $"{slot.SlotItemData.itemName}({slot.ItemCount})]";
        }
        else
        {
            printText += "(��ĭ)]";
        }

        Debug.Log(printText);
    }
}
