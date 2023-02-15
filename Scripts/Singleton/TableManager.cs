using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BaseRPG_V1;

public class TableManager : BaseSingleton<TableManager>
{
    // 아이템 리스트 테이블 반환.
    public List<ItemData> GetItemData()
    {
        var table = GetTable<ItemListData>(Constants.kBUNDLE.ITEM.ToString()).ITEM;

        if (table == null)
            return null;
        
        return table;
    }

    // 포션 리스트 테이블 반환.
    public List<PorsionData> GetPorsionData()
    {
        var table = GetTable<PorsionListData>(Constants.kBUNDLE.PORSION.ToString()).PORSION;

        if (table == null)
            return null;
        
        return table;
    }

    // 장비 리스트 테이블 반환.
    public List<EquipmentData> GetEquipmentData()
    {
        var table = GetTable<EquipmentListData>(Constants.kBUNDLE.EQUIPMENT.ToString()).EQUIPMENT;

        if (table == null)
            return null;
        
        return table;
    }

    // 해당 Addressable 이름의 테이블 반환.
    private T GetTable<T>(string name)
    {    
        TextAsset text = BundleManager.Instance.LoadToScript(name);

        return JsonUtility.FromJson<T>(text.ToString());
    }
}
