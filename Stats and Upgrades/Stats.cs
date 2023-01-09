using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System;

[CreateAssetMenu(menuName = "Unit Stats")]
public class Stats : SerializedScriptableObject
{
    public Dictionary<Stat, float> instanceStats = new Dictionary<Stat, float>();
    public Dictionary<Stat, float> stats = new Dictionary<Stat, float>();
    private List<StatsUpgrade> appliedUpgrades = new List<StatsUpgrade>();

    public event Action<Stats, StatsUpgrade> upgradeApplied;

    public float GetStat(Stat stat)
    {
        if (instanceStats.TryGetValue(stat, out var instanceValue))
            return GetUpgradedValue(stat, instanceValue);
        else if (stats.TryGetValue(stat, out float value))
            return GetUpgradedValue(stat, value);
        else
        {
            Debug.LogError($"No stat value found for {stat} on {this.name}");
            return 0;
        }
    }

    public int GetStatAsInt(Stat stat)
    {
        return (int)GetStat(stat);
    }

    public void UnlockUpgrade(StatsUpgrade upgrade)
    {
        if (!appliedUpgrades.Contains(upgrade))
        {
            appliedUpgrades.Add(upgrade);
            upgradeApplied?.Invoke(this, upgrade);
        }
    }

    private float GetUpgradedValue(Stat stat, float baseValue)
    {
        foreach (var upgrade in appliedUpgrades)
        {
            if (!upgrade.upgradeToApply.TryGetValue(stat, out float upgradeValue))
                continue;

            if (upgrade.isPercentUpgrade)
                baseValue *= (upgradeValue / 100f) + 1f;
            else
                baseValue += upgradeValue;
        }

        return baseValue;
    }

    [Button]
    public void ResetAppliedUpgrades()
    {
        appliedUpgrades.Clear();
    }
}

