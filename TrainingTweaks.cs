using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;

namespace RenownTweaks
{
    public class TrainingTweaks : DefaultPartyTrainingModel
    {
        public override int GetHourlyUpgradeXpFromTraining(MobileParty party, StatExplainer explainer)
        {
            return base.GetHourlyUpgradeXpFromTraining(party, explainer) * 5; //hourly training XP boosted by factor of 5
        }

        public override int GetSkillXpFromUpgradingTroops(PartyBase party, CharacterObject troop, int numberOfTroops)
        {
            return base.GetSkillXpFromUpgradingTroops(party, troop, numberOfTroops) * 3; // upgrade troop xp factor upped by 3
        }
    }
}