using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BaseRPG_V1;

public class TableManager : BaseSingleton<TableManager>
{
    // 캐싱 테이블.
    private Dictionary<string, TextAsset> m_Dic = new Dictionary<string, TextAsset>();

    // 캐싱 테이블 생성.
    public void Add(string key, TextAsset asset)
    {
        m_Dic.Add(key, asset);
    }

    // 캐싱 테이블 삭제.
    public void Clear()
    {
        m_Dic.Clear();
    }

    // 아이템 테이블 반환.
    public ItemData GetItemData()
    {
        var table = GetTable<ItemData>(Constants.kBUNDLE.ITEM.ToString());

        if (table == null)
            return null;
        
        return table;
    }

    // Key 테이블 반환.
    private T GetTable<T>(string key)
    {
        if (m_Dic.ContainsKey(key) == false)
        {
            return default(T);
        }

        return JsonUtility.FromJson<T>(m_Dic[key].ToString());
    }
}
