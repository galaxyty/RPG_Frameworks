using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using BaseRPG_V1;

public class BundleManager : BaseSingleton<BundleManager>
{
    // scripts 레이블에서 해당 key 번들 로드 (동기).
    public TextAsset LoadToScripts(string key)
    {
        TextAsset text = Addressables.LoadAssetAsync<TextAsset>(key).WaitForCompletion();

        return text;
    }

    // key 오브젝트 씬에 생성 (동기).
    public void Instantiate(string key, Action<GameObject> callback)
    {
        GameObject obj = Addressables.InstantiateAsync(key).WaitForCompletion();

        callback(obj);
    }
}
