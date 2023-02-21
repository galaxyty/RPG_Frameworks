
// 플레이어 기본 뼈대.

/*
    - 구현 목록 -

    1. WSAD 이동 구현.
    2. 마우스를 통해 좌, 우 회전 구현.
    3. m_Speed 변수를 통해 이동속도 조절 가능.
    4. 좌클릭 함수 추가.
    5. 인벤토리 추가.
    6. 장비 장착 추가.

    Move함수와 ThreeView함수, LeftClick 함수는 상속받으면 Update문에 선언해줄 것.

    ex)
    public class Player : BasePlayerCharacter
    {
        private void Update()
        {
            ThreeView();
            Move();
        }
    }
 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BaseRPG_V1
{
    [RequireComponent(typeof(Rigidbody))]
    public class BasePlayerCharacter : BaseCharacter
    {
        // 애니메이터 이넘.
        public enum kMOVE
        {
            None = 0,
            Forward,
            Back,
            Left,
            Right,
            ForwardLeft,
            ForwardRight,
            BackLeft,
            BackRight,
            Attack
        }

        // 이동속도.
        [SerializeField]
        protected int m_Speed;

        // 자신 리지드바디.
        [SerializeField]
        protected Rigidbody m_Rigidbody;

        // 무기.
        protected EquipmentData m_Weapon;

        // 방어구.
        protected EquipmentData m_Armor;

        // 무기 래퍼런스.
        public EquipmentData Weapon
        {
            get
            {
                return m_Weapon;
            }
        }

        // 방어구 래퍼런스.
        public EquipmentData Armor
        {
            get
            {
                return m_Armor;
            }
        }

        // 인벤토리 아이템.
        protected List<ItemData> m_Inventory = new List<ItemData>();

        // 인벤토리.
        public List<ItemData> Inventory
        {
            get
            {
                return m_Inventory;
            }
        }

        public override void Initialization()
        {
            m_Rigidbody = GetComponent<Rigidbody>();
            m_Weapon = null;
            m_Armor = null;
        }

        public override void DisposeObject()
        {   
        }

        // 캐릭터 이동 WSAD.
        public virtual void Move()
        {
            // 키를 꾹 입력 했을 시.
            if (Input.GetKey(KeyCode.W))
            {
                W_Key();
            }

            if (Input.GetKey(KeyCode.S))
            {
                S_Key();
            }

            if (Input.GetKey(KeyCode.A))
            {
                A_Key();
            }

            if (Input.GetKey(KeyCode.D))
            {
                D_Key();
            }



            // 키를 떼었을 경우.
            if (Input.GetKeyUp(KeyCode.W))
            {
                W_KeyUp();
            }

            if (Input.GetKeyUp(KeyCode.S))
            {
                S_KeyUp();
            }

            if (Input.GetKeyUp(KeyCode.A))
            {
                A_KeyUp();
            }

            if (Input.GetKeyUp(KeyCode.D))
            {
                D_KeyUp();
            }
        }

        // 3인칭 마우스 회전.
        public virtual void ThreeView()
        {
            // 좌, 우 회전을 위해 마우스 회전 값 구해옴.
            float posX = Input.GetAxis("Mouse X");

            // 마우스 좌우 회전.
            Quaternion qt = transform.rotation;
            qt.eulerAngles = new Vector3(qt.eulerAngles.x, qt.eulerAngles.y + posX, qt.eulerAngles.z);

            transform.rotation = qt;
        }

        // 좌클릭 함수.
        public virtual void LeftClick()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                OnLeftClick();   
            }
        }

        // 좌클릭 이벤트 구현 함수.
        public virtual void OnLeftClick()
        {
        }

        // 앞 움직임.
        public virtual void W_Key()
        {        
            m_Rigidbody.velocity = transform.rotation * new Vector3(m_Rigidbody.velocity.x, m_Rigidbody.velocity.y, m_Speed);
        }

        // 앞 움직임 키 뗐을 시.
        public virtual void W_KeyUp()
        {
            m_Rigidbody.velocity = Vector3.zero;
        }

        // 뒤 움직임.
        public virtual void S_Key()
        {
            m_Rigidbody.velocity = transform.rotation * new Vector3(m_Rigidbody.velocity.x, m_Rigidbody.velocity.y, -m_Speed);
        }

        // 뒤 움직임 키 뗏을 시.
        public virtual void S_KeyUp()
        {
            m_Rigidbody.velocity = Vector3.zero;
        }

        // 왼쪽 움직임.
        public virtual void A_Key()
        {
            m_Rigidbody.velocity = transform.rotation * new Vector3(-m_Speed, m_Rigidbody.velocity.y, m_Rigidbody.velocity.z);
        }

        // 왼쪽 움직임 키 뗏을 시.
        public virtual void A_KeyUp()
        {
            m_Rigidbody.velocity = Vector3.zero;
        }

        // 오른쪽 움직임.
        public virtual void D_Key()
        {
            m_Rigidbody.velocity = transform.rotation * new Vector3(m_Speed, m_Rigidbody.velocity.y, m_Rigidbody.velocity.z);
        }

        // 오른쪽 움직임 키 뗏을 시.
        public virtual void D_KeyUp()
        {
            m_Rigidbody.velocity = Vector3.zero;
        }

        // 무기 장착.
        public void UpdateWeapon(EquipmentData data)
        {
            // null 체크.
            if (data == null)
                return;

            if (m_Weapon == null)
            {
                // 장착.
                m_Weapon = data;
                m_AttackPower += data.ATTACK;
            }
            else
            {
                // 해제.
                m_Weapon = null;
                m_AttackPower -= data.ATTACK;
            }
        }

        // 무기 장착 (오버로딩).
        public void UpdateWeapon(ItemData data)
        {
            // null 체크.
            if (data == null)
                return;
            
            var equit = TableManager.Instance.GetEquipmentData();

            // null 체크.
            if (equit == null)
                return;
            
            var found = equit.Find(foundData => foundData.ITEM_INDEX == data.INDEX);

            UpdateWeapon(found);
        }

        // 방어구 장착.
        public void UpdateArmor(EquipmentData data)
        {
            // null 체크.
            if (data == null)
                return;

            if (m_Armor == null)
            {
                // 장착.
                m_Armor = data;
                m_Defense += data.DEFENSE;
            }
            else
            {
                // 해제.
                m_Armor = null;
                m_Defense -= data.DEFENSE;
            }
        }

        // 방어구 장착 (오버로딩).
        public void UpdateArmor(ItemData data)
        {
            // null 체크.
            if (data == null)
                return;

            var equit = TableManager.Instance.GetEquipmentData();

            // null 체크.
            if (equit == null)
                return;

            var found = equit.Find(foundData => foundData.ITEM_INDEX == data.INDEX);

            UpdateArmor(found);
        }
    }
}