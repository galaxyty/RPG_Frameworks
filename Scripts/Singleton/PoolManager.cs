using System;
using System.Collections.Generic;
using UnityEngine;
using BaseRPG_V1;

public class PoolManager : BaseSingleton<PoolManager>
{
    // 풀 오브젝트 비활성화 리스트.
    private List<BaseCharacter> m_PoolDisable = new List<BaseCharacter>();

    // 풀 오브젝트 활성화 리스트.
    private List<BaseCharacter> m_PoolEnable = new List<BaseCharacter>();

    // 풀 오브젝트 생성.
    public void Create<T>(string path, int count = 1) where T : BaseCharacter
    {
        // 재귀함수 종료.
        if (count-- <= 0)
            return;

        BaseCharacter component = null;

        // 리소스.
        GameObject resource = Resources.Load(path) as GameObject;

        // 리소스 null 체크.
        if (resource == null)
        {
            Debug.Log("@@ " + path + "오브젝트가 존재하지 않아 생성할 수 없습니다");
            return;
        }
        
        // 오브젝트 생성.
        var obj = Instantiate(resource, transform);
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
        Create<T>(path, count);
    }

    // 풀 오브젝트에서 가져온다.
    public BaseCharacter Pop<T>() where T : BaseCharacter
    {
        BaseCharacter component = null;

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

        return component;
    }

    // 풀 오브젝트로 돌려보낸다.
    public void Push(BaseCharacter obj)
    {        
        // 비활성화 리스트로 보냄.
        m_PoolDisable.Add(obj);

        // 활성화 리스트에서 제거.
        m_PoolEnable.Remove(obj);

        obj.DisposeObject();
        obj.gameObject.SetActive(false);
    }
}
