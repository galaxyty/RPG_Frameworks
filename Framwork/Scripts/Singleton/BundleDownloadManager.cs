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
    // 번들 용량 코루틴.
    private IEnumerator m_IBundleSize = null;

    // 번들 다운로드 퍼센트.
    public float Percent;

    // 번들 다운로드.
    public void DownloadBundleAsync(string name, Action callback = null, Action failCallback = null)
    {
        Addressables.GetDownloadSizeAsync(name).Completed += (size) =>
        {
            // 번들 다운로드 할 것이 있는지 체크.
            if (size.Status == AsyncOperationStatus.Succeeded && size.Result > 0)
            {
                // 번들 용량 비동기 실행 코루틴 넣기.
                m_IBundleSize = IBundleSize(name);

                // 번들 용량 비동기 코루틴 실행.
                StartCoroutine(m_IBundleSize);

                // 번들 다운로드.
                Addressables.DownloadDependenciesAsync(name, true).Completed += (download) =>
                {
                    // 번들 용량 비동기 코루틴 중지.
                    StopCoroutine(m_IBundleSize);

                    // 다운로드가 성공적으로 완료되었는지 확인.
                    if ( ((AsyncOperationHandle)download).Status != AsyncOperationStatus.Succeeded)
                    {
                        // 다운로드 실패 시 에러.
                        if (failCallback == null)
                        {
                            return;
                        }

                        failCallback();
                        return;
                    }

                    // 다운로드 성공.
                    if (callback == null)
                    {
                        return;
                    }

                    callback();
                };
            }
            else
            {
                // 이미 다운로드 완료 상태.
                if (callback == null)
                {
                    return;
                }
                
                callback();
            }
        };
    }

    // 번들 다운로드 받았는지 확인하고 콜백함수 실행.
    public void DownloadCheck(string name, Action callback = null, Action alreadycallback = null)
    {
        Addressables.GetDownloadSizeAsync(name).Completed += (size) => 
        {
            // 번들 다운로드 할 것이 있는지 체크.
            if (size.Status == AsyncOperationStatus.Succeeded && size.Result > 0)
            {
                // 다운로드 받아야하는 콜백.
                if (callback == null)
                {
                    return;
                }

                callback();
            }
            else
            {
                // 이미 다운로드 완료 상태라 다음 단계로 진행하는 콜백.
                if (alreadycallback == null)
                {
                    return;
                }
                
                alreadycallback();
            }
        };
    }

    // 번들 용량 비동기용.
    private IEnumerator IBundleSize(string name)
    {
        while (true)
        {
            Percent = Addressables.DownloadDependenciesAsync(name).PercentComplete;
            yield return null;
        }
    }
}
