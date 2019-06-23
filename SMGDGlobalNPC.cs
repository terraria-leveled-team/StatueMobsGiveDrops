using Terraria;
using Terraria.ModLoader;

namespace StatueMobsGiveDrops
{
    public sealed class SMGDGlobalNPC : GlobalNPC
    {
        public override bool PreAI(NPC npc)
        {
            npc.SpawnedFromStatue = false;

            return base.PreAI(npc);
        }
    }
}
