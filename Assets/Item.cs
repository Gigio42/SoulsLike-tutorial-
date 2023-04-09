using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dark
{
    public class Item : ScriptableObject
    {
        [Header("Item information")]
        public Sprite itemIcon;
        public string itemName;
    }
}
