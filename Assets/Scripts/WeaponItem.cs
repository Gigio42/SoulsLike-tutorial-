using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dark 
{
    [CreateAssetMenu(menuName = "Items/Weapon Item")]
    public class WeaponItem : Item
    {
        public GameObject modelPrefab;
        public bool isUnarmed;

        [Header("Idol Animations")]
        public string right_hand_idle;
        public string left_hand_idle;
        public string two_hand_idle;

        [Header("Attack Animations")]
        public string OH_Light_Attack_1;
        public string OH_Light_Attack_2;
        public string OH_Heavy_Attack_1;
        public string TH_Hand_Attack_01;
        public string TH_Hand_Attack_02;

        [Header("Stamina Costs")]
        public int baseStamina;
        public float lightAttackMultiplier;
        public float heavyAttackMultiplier;
    }
}