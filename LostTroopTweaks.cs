using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;
using TaleWorlds.Core;

namespace RenownTweaks
{
    class LostTroopTweaks : DefaultTroopSacrificeModel
    {
        public override int GetLostTroopCountForBreakingInBesiegedSettlement(MobileParty party, SiegeEvent siegeEvent)
        {
            return base.GetLostTroopCountForBreakingInBesiegedSettlement(party, siegeEvent) / 5;
        }

        public override int GetLostTroopCountForBreakingOutOfBesiegedSettlement(MobileParty party, SiegeEvent siegeEvent)
        {
            return base.GetLostTroopCountForBreakingOutOfBesiegedSettlement(party, siegeEvent) / 3;
        }

        public override int GetNumberOfTroopsSacrificedForTryingToGetAway(BattleSideEnum battleSide, MapEvent mapEvent)
        {
            return base.GetNumberOfTroopsSacrificedForTryingToGetAway(battleSide, mapEvent) / 5;
        }
    }
}
