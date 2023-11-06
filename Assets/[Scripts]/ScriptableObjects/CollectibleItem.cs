using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "New Collectible Item", menuName = "Pickups/Collectible Item")]
public class CollectibleItem : ScriptableObject
{
    public string itemName;
    [FormerlySerializedAs("isCollected")] public bool IsCollected = false;
}
