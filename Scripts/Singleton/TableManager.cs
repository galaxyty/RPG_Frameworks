using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BaseRPG_V1;

public class TableManager : BaseSingleton<TableManager>
{
    // 아이템 테이블 반환.
    public ItemData GetItemData()
    {
        var table = GetTable<ItemData>(Constants.kBUNDLE.ITEM.ToString());

        if (table == null)
            return null;
        
        return table;
    }

    // 해당 Key 테이블 반환.
    private T GetTable<T>(string key)
    {    
        TextAsset text = BundleManager.Instance.LoadToScripts(key);

        return JsonUtility.FromJson<T>(text.ToString());
    }
}
