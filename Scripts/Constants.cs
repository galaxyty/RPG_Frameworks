using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants : MonoBehaviour
{
    // DB 유저.
    public static readonly string kDB_USER = "USER";

    // 태그.
    public enum kTAG
    {
        Player,
        MainCanvas,
        Weapon
    }

    // 번들 레이블.
    public enum kLABLE
    {
        script,
        character
    }

    // 번들명.
    public enum kBUNDLE
    {
        ITEM,
        PORSION,
        Player,
        Inventory,
        InventorySlot,
        UIInventory,
        UIInventorySlot,
        UICustomInventory,
        UICustomInventorySlot,
        EQUIPMENT,
        Equitment,
        EquitmentSlot,
        UICustomEquitment,
        UICustomEquitmentSlot,
        UICharacter,
        MONSTER,
        LEVEL,
        SpawnEnemy,
        EfLevelUp,
        EfFireSlash,
        Joystick,
        PlayerCamera,
        UIRadius,
        UIHandle,
        UIInformation,
        UILevel,
        UIHPFrame,
        UIHP,
        UIAttackButton,
        UIMainMenuButton,
        MainMenu
    }

    // 몬스터명.
    public enum kMONSTER
    {
        Enemy
    }
}
