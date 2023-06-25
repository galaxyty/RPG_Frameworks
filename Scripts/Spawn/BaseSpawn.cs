
// 몬스터 스폰 프레임워크.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BaseRPG_V1
{
    public abstract class BaseSpawn : BaseObject
    {
        [Header("스폰시킬 몬스터 인덱스")]
        [SerializeField]
        protected int m_SpawnIndex;

        [Header("생성 할 몬스터 수")]
        [SerializeField]
        protected int m_Count;

        [Header("생성 주기 시간")]
        [SerializeField]
        private float m_SpawnCount;

        // 현재 생성한 몬스터 수.
        protected int m_currentCount;

        // 생성 코루틴.
        private IEnumerator cor = null;

        // 스폰 몬스터 최초 생성.
        private void Start() 
        {
            SpawnCreate();

            StartSpawn();
        }        

        // 일정 시간 마다 스폰시킬 대상 (풀매니저 Create).
        public abstract void SpawnCreate();

        // 스폰시킬 대상을 일정시간 마다 필드에 소환 (풀매니저 Pop).
        public abstract void SpawnPop();

        // 스폰 시작.
        public void StartSpawn()
        {
            cor = ESpawn();
            StartCoroutine(cor);
        }

        // 스폰 코루틴.
        public virtual IEnumerator ESpawn()
        {
            // 일정시간 후에 생성.
            yield return new WaitForSeconds(m_SpawnCount);

            // Create한 몬스터 필드에 소환.
            SpawnPop();

            // 최대 인원수 넘으면 생성 종료.
            if (m_currentCount >= m_Count)
            {
                StopCoroutine(cor);
                yield return null;
            }

            // 스폰 다시 시작.
            StartSpawn();
        }

        public override void Initialization()
        {
        }

        public override void DisposeObject()
        {
        }
    }
}