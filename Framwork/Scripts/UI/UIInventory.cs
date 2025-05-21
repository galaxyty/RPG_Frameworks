using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BaseRPG_V1;

public class UIInventory : BaseInventory
{
    // 인벤토리 슬롯.
    private List<UIInventorySlot> m_ListOfSlot = new List<UIInventorySlot>();

    public override void Initialization()
    {
        base.Initialization();

        // 인벤토리 슬롯 풀 생성.
        PoolManager.Instance.Create<UIInventorySlot>(Constants.kBUNDLE.InventorySlot.ToString(), m_Count);        
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
            var obj = PoolManager.Instance.Pop<UIInventorySlot>(m_Grid.transform);            
            m_ListOfSlot.Add(obj);

            // 아이템 있으면 표시, 없으면 기본 표시.
            if (list.Count <= i)
                continue;

            obj.UpdateUI(list[i]);
        }
    }
}
