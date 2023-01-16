using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BaseRPG_V1;
using UnityEngine.UI;

public class UIBaseInventorySlot : BaseInventorySlot
{
    // 인덱스 텍스트 UI.
    [SerializeField]
    protected Text m_TextOfIndex;

    // 아이템 소지 데이터.
    protected ItemData m_Data;

    public override void Initialization()
    {
        base.Initialization();

        m_TextOfIndex.gameObject.SetActive(false);
    }

    public override void DisposeObject()
    {
        base.DisposeObject();

        m_TextOfIndex.gameObject.SetActive(false);
        m_Data = null;
    }

    // 인벤토리 슬롯 업데이트.
    public void UpdateUI(ItemData data)
    {
        m_Data = data;

        m_TextOfIndex.gameObject.SetActive(true);
        m_TextOfIndex.text = m_Data.INDEX.ToString();
    }
}
