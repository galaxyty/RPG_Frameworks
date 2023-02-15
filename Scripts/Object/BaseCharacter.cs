
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
        protected int m_Hp = 0;    

        // 최대 체력.
        [SerializeField]
        protected int m_MaxHp = 0;

        // 공격력.
        [SerializeField]

        protected int m_AttackPower = 0;

        // 방어력.
        [SerializeField]
        protected int m_Defense = 0;

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

        // 공격력 프로퍼티.
        public int AttackPower
        {
            get
            {
                return m_AttackPower;
            }
        }

        // 방어력 프로퍼티.
        public int Defense
        {
            get
            {
                return m_Defense;
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

        // 체력 회복 함수.
        public virtual void CureHP(int hp)
        {
            m_Hp += hp;

            // 최대 HP 못 넘게 막아놓기.
            if (m_Hp > m_MaxHp)
            {
                m_Hp = m_MaxHp;
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