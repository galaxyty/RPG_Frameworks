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
        // scripts 테이블 초기화.
        Addressables.DownloadDependenciesAsync(Constants.kLABLE.scripts.ToString()).Completed += (AsyncOperationHandle handle) =>
        {
            // 아이템 테이블 매니저 초기화.
            LoadToScripts(Constants.kBUNDLE.ITEM.ToString());

            Addressables.Release(handle);
        };

        // Characters 테이블 초기화.
        Addressables.DownloadDependenciesAsync(Constants.kLABLE.characters.ToString()).Completed += (AsyncOperationHandle handle) =>
        {
            // 플레이어 생성.
            InstantiateAsync(Constants.kBUNDLE.PLAYER.ToString());

            Addressables.Release(handle);
        };
    }

    // scripts 레이블에서 해당 key 번들 로드.
    public void LoadToScripts(string key)
    {
        // 어드레서블 에셋에서 로드 후 테이블매니저에 캐싱.
        Addressables.LoadAssetAsync<TextAsset>(key).Completed += (AsyncOperationHandle<TextAsset> obj) =>
        {
            TextAsset text = obj.Result;

            TableManager.Instance.Add(key, text);            
        };
    }

    // key 오브젝트 씬에 생성.
    public void InstantiateAsync(string key)
    {
        Addressables.InstantiateAsync(key).Completed += (AsyncOperationHandle<GameObject> obj) => 
        {
            GameObject o = obj.Result;

            Debug.Log(o.name);
        };
    }
}
