
// 사물이 가지는 기본 뼈대.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BaseRPG_V1
{
    public class BaseCharacter : BaseObject
    {
        // 체력.
        [SerializeField]
        private int m_Hp = 0;    

        // 최대 체력.
        [SerializeField]
        private int m_MaxHp = 0;

        // 체력 프로퍼티.
        public int Hp
        {
            get
            {
                return m_Hp;
            }
        }

        // 최대 체력 프로퍼티.
        public int MaxHp
        {
            get
            {
                return m_MaxHp;
            }
        }        

        // 타격 함수.
        public virtual void Attack()
        {
            Debug.Log("타격");
        }

        // 피격 함수.
        public virtual void Hit(int damage)
        {
            // 체력 감소.
            m_Hp -= damage;

            // 사망 조건 확인.
            if (m_Hp <= 0)
            {
                Die();
            }
        }

        // 사망 시 호출 될 함수.
        public virtual void Die()
        {
            m_Hp = 0;
        }

        public override void Initialization()
        {            
        }

        public override void DisposeObject()
        {
        }
    }
}