using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    [SerializeField] private List<Stats> statsList;
    private const string statsPath = "Assets/Prefabs/Units/Stats/";

    private void OnApplicationQuit()
    {
        statsList = HelperFunctions.GetScriptableObjects<Stats>(statsPath);
        
        foreach (var stat in statsList)
        {
            stat.ResetAppliedUpgrades();
        }
    }

}



