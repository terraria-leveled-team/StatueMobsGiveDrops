using System.ComponentModel;
using System.IO;
using Terraria;
using Terraria.IO;
using Terraria.ModLoader.Config;

namespace StatueMobsGiveDrops
{
    public sealed class SMGDConfiguration : ModConfig
    {
        [Label("Gold Percentage"), Tooltip("The percentage of gold that the enemy should give when killed.")]
        [ReloadRequired]
        [Range(0, 1), DefaultValue(0)]
        public float GoldPercentage { get; set; }

        [Label("Give Drops")]
        [ReloadRequired]
        [DefaultValue(true)]
        public bool GiveDrops { get; set; }

        public override ConfigScope Mode => ConfigScope.ServerSide;
    }
}
