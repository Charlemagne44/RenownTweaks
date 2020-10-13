using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;


namespace RenownTweaks
{
    public class BattleTweaks : DefaultBattleRewardModel
    {
		public override float CalculateRenownGain(PartyBase party, float renownValueOfBattle, float contributionShare, StatExplainer explanation = null)
		{
            if (party.NumberOfAllMembers < 20)
            {
                if (party.Owner.IsWounded)
                {
                    return base.CalculateRenownGain(party, renownValueOfBattle * 4, contributionShare, explanation);
                }
                return base.CalculateRenownGain(party, renownValueOfBattle * 3, contributionShare, explanation);
            }
            
			return base.CalculateRenownGain(party, renownValueOfBattle * 5, contributionShare, explanation); 
		}
        public override float CalculateInfluenceGain(PartyBase party, float influenceValueOfBattle, float contributionShare, StatExplainer explanation = null)
        {
            return base.CalculateInfluenceGain(party, influenceValueOfBattle * 5, contributionShare, explanation);
        }
    }
}
