using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BaseRPG_V1;

// 팝업 매니저.
public class PopupManager : BaseSingleton<PopupManager>
{
    // 팝업 스택.
    private Stack<BaseObject> m_StackOfPopup = new Stack<BaseObject>();

    private void Update()
    {
        // 스택 존재 여부 확인.
        if (m_StackOfPopup == null || m_StackOfPopup.Count == 0)
        {
            return;
        }

        // 팝업 닫기.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ClosePopup();
        }
    }

    // 팝업 오픈.
    public T Open<T>(string tag) where T : BaseObject
    {
        // 이미 팝업이 열려있으면 함수 종료.
        if (PoolManager.Instance.GetObject<T>() != null)
        {
            return null;
        }

        // 풀매니저에서 Pop.
        var obj = PoolManager.Instance.Pop<T>(tag);

        // null 체크.
        if (obj == null)
        {
            Debug.Log("@@ " + typeof(T).ToString() + " 스크립트를 풀 오브젝트에 할당(Create) 해주세요");
        }

        // Pop한 오브젝트를 팝업 스택에 넣음.
        m_StackOfPopup.Push(obj);

        return obj as T;
    }

    // 최상단 팝업 닫기.
    private void ClosePopup()
    {
        // 팝업 스택에서 Pop.
        var obj = m_StackOfPopup.Pop();

        // null 체크.
        if (obj == null)
        {
            Debug.Log("@@ 닫을 팝업이 존재하지 않습니다.");
            return;
        }

        // 풀매니저에서 닫음.
        PoolManager.Instance.Push(obj);
    }
}
