using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BaseRPG_V1;

public class UIEquitmentSlot : BaseInventorySlot
{
    // 장비 소지 데이터. (new 키워드로 m_Data 숨김).
    protected new EquipmentData m_Data;

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

        m_Data = data;
    }

    public override void OnTouchEvent()
    {
        Debug.Log(m_Data.ITEM_INDEX);
    }
}
