using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BaseRPG_V1;

public class SpawnEnemy : MonoBehaviour
{
    [Header("생성 할 몬스터 수")]
    [SerializeField]
    private int m_Count;

    [Header("생성 주기 시간")]
    [SerializeField]
    private float m_SpawnCount;

    // 현재 생성한 몬스터 수.
    private int m_currentCount;

    private IEnumerator cor = null;

    private void Start()
    {
        for (int i = 0; i < m_Count; i++)
        {
            PoolManager.Instance.Create<EnemyController>(Constants.kMONSTER.Enemy.ToString());
        }

        StartSpawn();
    }

    // 스폰 시작.
    public void StartSpawn()
    {
        cor = ESpawn();
        StartCoroutine(cor);
    }

    private IEnumerator ESpawn()
    {
        // 일정시간 후에 생성.
        yield return new WaitForSeconds(m_SpawnCount);

        // 풀매니저에서 생성한 몬스터 필드에 생성.
        var obj = PoolManager.Instance.Pop<EnemyController>(transform);
        obj.spawnEnemy = this;
        obj.Index = TableManager.Instance.GetMonsterData().Find(foundData => foundData.INDEX == 1).INDEX;
        m_currentCount++;

        // 최대 인원수 넘으면 생성 종료.
        if (m_currentCount >= m_Count)
        {
            StopCoroutine(cor);
            yield return null;
        }

        StartSpawn();
    }
}
