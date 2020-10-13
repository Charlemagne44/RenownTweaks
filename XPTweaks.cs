using Helpers;
using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;
using TaleWorlds.Library;

namespace RenownTweaks
{
    public class XPTweaks : DefaultCombatXpModel
    {
        public override void GetXpFromHit(CharacterObject attackerTroop, CharacterObject attackedTroop, PartyBase party, int damage, bool isFatal, MissionTypeEnum missionType, out int xpAmount)
        {
			int num = attackedTroop.MaxHitPoints();
			float num2 = 0.4f * ((attackedTroop.GetPower() + 0.5f) * (float)(Math.Min(damage, num) + (isFatal ? num : 0)));
			num2 *= ((missionType == CombatXpModel.MissionTypeEnum.NoXp) ? 0f : ((missionType == CombatXpModel.MissionTypeEnum.PracticeFight) ? 0.0625f : ((missionType == CombatXpModel.MissionTypeEnum.Tournament) ? 0.33f : ((missionType == CombatXpModel.MissionTypeEnum.SimulationBattle) ? 0.9f : ((missionType == CombatXpModel.MissionTypeEnum.Battle) ? 1f : 1f)))));
			ExplainedNumber explainedNumber = new ExplainedNumber(num2, null);
			if (party != null)
			{
				this.GetBattleXpBonusFromPerks(party, ref explainedNumber, attackerTroop);
			}
			xpAmount = MathF.Round(explainedNumber.ResultNumber) * 3; //buffed by a factor of 3 -> had to import the private Getbattlexp as this method uses an out in the inputs
		}

        public override float GetXpMultiplierFromShotDifficulty(float shotDifficulty)
        {
            return base.GetXpMultiplierFromShotDifficulty(shotDifficulty) * 3; //shot difficulty multiplier doubled (can exceed maximum difficulty of 14.4)
        }

        private void GetBattleXpBonusFromPerks(PartyBase party, ref ExplainedNumber xpToGain, CharacterObject troop)
		{
			if (party.IsMobile && party.MobileParty.LeaderHero != null)
			{
				if (!troop.IsArcher && party.MobileParty.HasPerk(DefaultPerks.OneHanded.Trainer, true))
				{
					xpToGain.AddFactor(DefaultPerks.OneHanded.Trainer.SecondaryBonus * 0.01f, DefaultPerks.OneHanded.Trainer.Name);
				}
				if (troop.IsInfantry)
				{
					if (party.MobileParty.HasPerk(DefaultPerks.OneHanded.CorpsACorps, false))
					{
						xpToGain.AddFactor(DefaultPerks.OneHanded.CorpsACorps.PrimaryBonus * 0.01f, DefaultPerks.OneHanded.CorpsACorps.Name);
					}
					if (party.MobileParty.HasPerk(DefaultPerks.TwoHanded.BaptisedInBlood, true))
					{
						xpToGain.AddFactor(DefaultPerks.TwoHanded.BaptisedInBlood.SecondaryBonus * 0.01f, DefaultPerks.TwoHanded.BaptisedInBlood.Name);
					}
				}
				if (party.MobileParty.HasPerk(DefaultPerks.OneHanded.LeadByExample, false))
				{
					xpToGain.AddFactor(DefaultPerks.OneHanded.LeadByExample.PrimaryBonus * 0.01f, DefaultPerks.OneHanded.LeadByExample.Name);
				}
				if (party.MobileParty.HasPerk(DefaultPerks.Leadership.Companions, false))
				{
					xpToGain.AddFactor(DefaultPerks.Leadership.Companions.PrimaryBonus * 0.01f, DefaultPerks.Leadership.Companions.Name);
				}
				if (troop.IsArcher && party.MobileParty.HasPerk(DefaultPerks.Crossbow.MountedCrossbowman, true))
				{
					xpToGain.AddFactor(DefaultPerks.Crossbow.MountedCrossbowman.SecondaryBonus * 0.01f, DefaultPerks.Crossbow.MountedCrossbowman.Name);
				}
			}
			if (party.IsMobile && party.MobileParty.IsGarrison)
			{
				Settlement currentSettlement = party.MobileParty.CurrentSettlement;
				if (((currentSettlement != null) ? currentSettlement.Town.Governor : null) != null)
				{
					PerkHelper.AddPerkBonusForTown(DefaultPerks.TwoHanded.Yadomejutsu, party.MobileParty.CurrentSettlement.Town, ref xpToGain);
					if (troop.IsMounted)
					{
						PerkHelper.AddPerkBonusForTown(DefaultPerks.Polearm.Guards, party.MobileParty.CurrentSettlement.Town, ref xpToGain);
					}
				}
			}
		}
	}
}