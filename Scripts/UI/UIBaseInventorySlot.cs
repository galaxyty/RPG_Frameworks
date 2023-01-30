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
        m_Data = data;

        if (m_Data == null) 
            return;

        m_TextOfIndex.gameObject.SetActive(true);
        m_TextOfIndex.text = m_Data.INDEX.ToString();

        m_ImageOfItem.sprite = BundleManager.Instance.LoadToItem(m_Data.INDEX.ToString());
    }

    public override void OnTouchEvent()
    {
        if (m_Data == null)
            return;
            
        var data = TableManager.Instance.GetPorsionData().Find(foundData => foundData.ITEM_INDEX == m_Data.INDEX);

        if (data == null)
            return;
            
        var player = PoolManager.Instance.GetObject<PlayerController>();

        if (player == null)
            return;
        
        // 체력 회복.
        player.CureHP(data.HP);
    }
}
