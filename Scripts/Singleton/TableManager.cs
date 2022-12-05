using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using BaseRPG_V1;

public class TableManager : BaseSingleton<TableManager>
{
    // 캐싱 테이블.
    private Dictionary<string, TextAsset> m_Dic = new Dictionary<string, TextAsset>();

    // 테이블 생성 구간.
    public void Init()
    {
        Parse<Test>("TEST");
    }

    // 어드레서블 에셋에서 딕셔너리 캐싱 테이블 생성.
    private void Parse<T>(string key)
    {
        TextAsset text = null;

        Addressables.LoadAssetAsync<TextAsset>(key).Completed += (AsyncOperationHandle<TextAsset> obj) =>
        {
            text = obj.Result;

            m_Dic.Add(key, text);
        };
    }

    public Test GetTestData()
    {
        var table = GetTable<Test>("TEST");

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
