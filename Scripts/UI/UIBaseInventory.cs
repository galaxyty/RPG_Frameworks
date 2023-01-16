using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BaseRPG_V1;

public class UIBaseInventory : BaseInventory
{
    // 인벤토리 슬롯.
    private List<UIBaseInventorySlot> m_ListOfSlot = new List<UIBaseInventorySlot>();    

    public override void Initialization()
    {
        base.Initialization();

        // 인벤토리 슬롯 풀 생성.
        PoolManager.Instance.Create<UIBaseInventorySlot>(Constants.kBUNDLE.InventorySlot.ToString(), m_Count);        
    }

    public override void DisposeObject()
    {
        base.DisposeObject();

        // 인벤토리 슬롯 풀 반환.
        PoolManager.Instance.PushList(m_ListOfSlot);
    }

    // 인벤토리 업데이트.
    public void UpdateUI(List<ItemData> list)
    {
        // 인벤토리 슬롯 생성.
        for (int i = 0; i < m_Count; i++)
        {
            var obj = PoolManager.Instance.Pop<UIBaseInventorySlot>(m_Grid.transform);            
            m_ListOfSlot.Add(obj);

            if (list.Count <= i)
                continue;

            obj.UpdateUI(list[i]);
        }
    }
}
