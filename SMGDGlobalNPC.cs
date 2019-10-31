using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace StatueMobsGiveDrops
{
    public sealed class SMGDGlobalNPC : GlobalNPC
    {
        private static readonly Dictionary<int, NPC> _baseNPCs = new Dictionary<int, NPC>();
        private static List<NPC> _ranNPCs = new List<NPC>(Main.npc.Length);

        public override bool PreAI(NPC npc)
        {
            const bool returnValue = true;

            if (!npc.SpawnedFromStatue) return returnValue;

            if (!_baseNPCs.ContainsKey(npc.type))
            {
                NPC baseNPC = (NPC)Activator.CreateInstance(npc.GetType());
                baseNPC.SetDefaults(npc.type);

                _baseNPCs.Add(npc.type, baseNPC);
            }

            if (_ranNPCs.Contains(npc)) return returnValue;

            npc.SpawnedFromStatue = !mod.GetConfig<SMGDConfiguration>().GiveDrops;
            npc.value = _baseNPCs[npc.type].value * mod.GetConfig<SMGDConfiguration>().GoldPercentage;

            _ranNPCs.Add(npc);

            return returnValue;
        }

        public override bool PreNPCLoot(NPC npc)
        {
            _ranNPCs.Remove(npc);

            return base.PreNPCLoot(npc);
        }
    }
}
