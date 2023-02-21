using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEquitmentSlot : BaseEquitmentSlot
{
    public override void Initialization()
    {
        base.Initialization();
    }

    public override void DisposeObject()
    {
        base.DisposeObject();
    }

    // 장비창 슬롯 업데이트.
    public void UpdateUI(EquipmentData data)
    {
        // null 체크.
        if (data == null)
        {
            return;
        }
        
        // 슬롯에 인덱스 표시.
        m_TextOfIndex.text = data.ITEM_INDEX.ToString();
    }
}
