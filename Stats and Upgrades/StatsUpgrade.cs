    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(menuName = "Hex/Upgrades/Stats Upgrade")]
    public class StatsUpgrade : Upgrade
    {
        [Tooltip("The stats that this upgrade applies to.")]
        [SerializeField]
        public List<Stats> unitsToUpgrade = new List<Stats>();
        public Dictionary<Stat, float> upgradeToApply = new Dictionary<Stat, float>();
        public bool isPercentUpgrade = false;

        public override void DoUpgrade()
        {
            foreach (var unitToUpgrade in unitsToUpgrade)
            {
                foreach (var upgrade in upgradeToApply)
                {
                    unitToUpgrade.UnlockUpgrade(this);
                }
            }
        }

    }

