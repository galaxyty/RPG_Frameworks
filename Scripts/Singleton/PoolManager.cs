using System;
using System.Collections.Generic;
using UnityEngine;
using BaseRPG_V1;

public class PoolManager : BaseSingleton<PoolManager>
{
    // 풀 오브젝트 비활성화 리스트.
    private List<BaseObject> m_PoolDisable = new List<BaseObject>();

    // 풀 오브젝트 활성화 리스트.
    private List<BaseObject> m_PoolEnable = new List<BaseObject>();

    // 풀 오브젝트 생성.
    public void Create<T>(string key, int count = 1) where T : BaseObject
    {
        // 재귀함수 종료.
        if (count-- <= 0)
            return;

        BaseObject component = null;

        // 번들에서 프리팹 생성.
        BundleManager.Instance.Instantiate(key, (GameObject obj) => 
        {
            // null 체크.
            if (obj == null)
            {
                Debug.Log("@@ " + key + "오브젝트가 존재하지 않아 생성할 수 없습니다");
                return;
            }
            
            // 오브젝트 풀매니저로 기본 부모 설정.
            obj.transform.SetParent(transform);
            
            // 오브젝트 비활성화.
            obj.SetActive(false);

            // 컴포넌트 가져옴.
            component = obj.GetComponent<T>();

            // 컴포넌트 null 체크.
            if (component == null)
            {
                Debug.Log("@@ " + obj.name + " 프리팹에서 컴포넌트가 존재하지 않아 생성할 수 없습니다");
                return;
            }

            // 비활성화 리스트 추가.
            m_PoolDisable.Add(component);

            // 갯수만큼 생성.
            Create<T>(key, count);
        });
    }

    // 풀 오브젝트에서 가져온다.
    public T Pop<T>(Transform parent = null) where T : BaseObject
    {
        T component = null;

        // 풀 리스트에서 컴포넌트 가져옴.
        m_PoolDisable.ForEach((data) => 
        {
            component = data.GetComponent<T>();

            if (component != null)
            {             
                // 활성화 리스트 추가.
                m_PoolEnable.Add(component);
                return;
            }
        });                

        // null 체크.
        if (component == null)
        {
            Debug.Log("@@ " + typeof(T).ToString() + " 스크립트를 풀 오브젝트에 할당 해주세요");
            return null;
        }

        // 비활성화 리스트 제거.
        m_PoolDisable.Remove(component);

        component.Initialization();
        component.gameObject.SetActive(true);

        // 부모 설정.
        component.transform.SetParent(parent);

        return component;
    }

    // 풀 오브젝트에서 가져온다.
    public T Pop<T>(string tag) where T : BaseObject
    {
        T component = null;

        // 풀 리스트에서 컴포넌트 가져옴.
        m_PoolDisable.ForEach((data) =>
        {
            component = data.GetComponent<T>();

            if (component != null)
            {
                // 활성화 리스트 추가.
                m_PoolEnable.Add(component);
                return;
            }
        });

        // null 체크.
        if (component == null)
        {
            Debug.Log("@@ " + typeof(T).ToString() + " 스크립트를 풀 오브젝트에 할당 해주세요");
            return null;
        }

        // 비활성화 리스트 제거.
        m_PoolDisable.Remove(component);

        component.Initialization();
        component.gameObject.SetActive(true);

        // string으로 해당 태그 오브젝트 찾아온다.
        Transform parent = GameObject.FindWithTag(tag).transform;

        // 부모 설정.
        component.transform.SetParent(parent);

        return component;
    }

    // 풀 오브젝트로 돌려보낸다.
    public void Push(BaseObject obj)
    {        
        // 비활성화 리스트로 보냄.
        m_PoolDisable.Add(obj);

        // 활성화 리스트에서 제거.
        m_PoolEnable.Remove(obj);

        obj.DisposeObject();
        obj.gameObject.SetActive(false);
    }
}
