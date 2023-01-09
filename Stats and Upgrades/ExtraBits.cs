using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HelperFunctions
{
    public static List<T> GetScriptableObjects<T>(string path) where T : ScriptableObject
    {
#if UNITY_EDITOR


        string[] guids = UnityEditor.AssetDatabase.FindAssets("t:" + typeof(T).ToString(), new[] { path });
        List<T> scriptableObjects = new List<T>();

        foreach (var guid in guids)
        {
            UnityEditor.AssetDatabase.GUIDToAssetPath(guid);
            string assetPath = UnityEditor.AssetDatabase.GUIDToAssetPath(guid);
            scriptableObjects.Add(UnityEditor.AssetDatabase.LoadAssetAtPath(assetPath, typeof(T)) as T);
        }

        return scriptableObjects;
#else
        return null;
#endif
    }
}

///EXTRA BITS...

[System.Serializable]
public struct ResourceAmount
{
    public ResourceAmount(ResourceType type, int amount)
    {
        this.type = type;
        this.amount = amount;
    }

    public ResourceType type;
    public int amount;

    public static ResourceAmount operator +(ResourceAmount a, ResourceAmount b)
    {
        return new ResourceAmount(a.type, a.amount + b.amount);
    }

    public static ResourceAmount operator -(ResourceAmount a, ResourceAmount b)
    {
        return new ResourceAmount(a.type, a.amount - b.amount);
    }

    public override string ToString()
    {
        return $"{type} {amount}";
    }

    public string ToPrettyString()
    {
        return $"Type: {type} Amount: {amount}";
    }

    public void ClearResource()
    {
        amount = 0;
    }
}

public enum ResourceType
{
    Red,
    Food,
    Colonists,
    Energy,
    TiOre,
    Gas,
    Research
}

public enum Stat
{
    hitPoints,
    armor,
    speed,
    movementRange,
    unused3,
    minRange,
    maxRange,
    reloadTime,
    damage,
    aoeRange,
    unused2,
    maxStorage,
    unused1,
    workers,
    housing
}

