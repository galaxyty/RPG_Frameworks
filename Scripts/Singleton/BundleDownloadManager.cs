using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using BaseRPG_V1;

// 서버 번들 다운로드.
public class BundleDownloadManager : BaseSingleton<BundleDownloadManager>
{
    // 번들 다운로드.
    public void DownloadBundleAsync(string name, Action callback = null, Action failCallback = null)
    {
        Addressables.GetDownloadSizeAsync(name).Completed += (size) =>
        {
            // 번들 다운로드 할 것이 있는지 체크.
            if (size.Status == AsyncOperationStatus.Succeeded && size.Result > 0)
            {
                // 번들 다운로드.
                Addressables.DownloadDependenciesAsync(name, true).Completed += (download) =>
                {
                    // 다운로드가 성공적으로 완료되었는지 확인.
                    if ( ((AsyncOperationHandle)download).Status != AsyncOperationStatus.Succeeded)
                    {
                        // 다운로드 실패 시 에러.
                        failCallback();
                    }

                    // 다운로드 성공.
                    callback();
                };
            }
            else
            {
                // 이미 다운로드 완료 상태.
                callback();
            }
        };
    }
}
