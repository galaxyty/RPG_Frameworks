using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using BaseRPG_V1;

public class BundleManager : BaseSingleton<BundleManager>
{
    // 해당 Addressable 이름의 JSON 로드 (동기).
    public TextAsset LoadToScript(string name)
    {
        TextAsset text = Addressables.LoadAssetAsync<TextAsset>(name).WaitForCompletion();

        return text;
    }

    // 해당 Addressable 이름의 Sprite 이미지 로드 (동기).
    public Sprite LoadToSprite(string name)
    {
        Sprite sprite = Addressables.LoadAssetAsync<Sprite>(name).WaitForCompletion();

        return sprite;
    }

    // Addressable 이름의 오브젝트를 씬에 생성 (동기).
    public void Instantiate(string name, Action<GameObject> callback)
    {
        GameObject obj = Addressables.InstantiateAsync(name).WaitForCompletion();

        callback(obj);
    }
}
