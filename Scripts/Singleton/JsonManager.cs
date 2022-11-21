using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BaseRPG_V1;

public class JsonManager : BaseSingleton<JsonManager>
{
    // 테이블 경로.
    private string kPATH_TABLE = "Table/{0}";

    // JSON 테이블 생성.
    public T Parse<T>(string file)
    {
        string path = string.Format(kPATH_TABLE, file);
        TextAsset text = Resources.Load(path) as TextAsset;

        return JsonUtility.FromJson<T>(text.ToString());
    }
}
