using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using BaseRPG_V1;

public class BundleManager : BaseSingleton<BundleManager>
{
    // 번들 다운로드.
    public void DownloadBundleAsync()
    {
        Addressables.DownloadDependenciesAsync("scripts").Completed += (AsyncOperationHandle handle) =>
        {            
            Debug.Log("다운로드 완료!");

            // 테이블 매니저 초기화.
            LoadScripts("TEST");

            Addressables.Release(handle);
        };
    }

    // scripts 레이블에서 해당 key 번들 로드.
    public void LoadScripts(string key)
    {
        Addressables.LoadAssetAsync<TextAsset>(key).Completed += (AsyncOperationHandle<TextAsset> obj) =>
        {
            TextAsset text = obj.Result;

            TableManager.Instance.Add(key, text);
        };
    }
}
