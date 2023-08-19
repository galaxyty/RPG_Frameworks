// 싱글톤 뼈대.

using System;
using UnityEngine;

namespace BaseRPG_V1
{
    public class BaseSingleton<T> : MonoBehaviour where T : BaseSingleton<T>
    {
        private static T m_Instance = null;

        public static T Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    Initialzation();
                }
                
                return m_Instance;
            }
        }

        // 싱글톤 초기화.
        private static void Initialzation()
        {
            // 타입.
            Type type = typeof(T);

            // 오브젝트 생성.
            GameObject obj = new GameObject();

            // 오브젝트 이름 재정의.
            obj.name = type.ToString();

            // 싱글톤 스크립트 생성.
            obj.AddComponent<T>();
        }

        private void Awake() 
        {
            // 이 싱글톤이 탄생했으면 자기 자신을 넣어준다.
            m_Instance = this as T;

            // 씬 파괴 막아놓기.
            DontDestroyOnLoad(this);
        }
    }
}