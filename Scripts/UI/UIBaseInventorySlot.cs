using UnityEngine;
using BaseRPG_V1;
using UnityEngine.UI;

public class UIBaseInventorySlot : BaseInventorySlot
{
    // 인덱스 텍스트 UI.
    [SerializeField]
    protected Text m_TextOfIndex;

    // 아이템 이미지.
    [SerializeField]
    protected Image m_ImageOfItem;

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
        m_TextOfIndex.text = null;
        m_ImageOfItem.sprite = null;
        m_Data = null;
    }

    // 인벤토리 슬롯 업데이트.
    public void UpdateUI(ItemData data)
    {
        // 데이터 넣기.
        m_Data = data;

        // null 체크.
        if (m_Data == null) 
            return;

        // ui 갱신.
        m_TextOfIndex.gameObject.SetActive(true);
        m_TextOfIndex.text = m_Data.INDEX.ToString();
    }

    // 인벤토리 슬롯 버튼.
    public override void OnTouchEvent()
    {
        if (m_Data == null)
            return;
    }
}
