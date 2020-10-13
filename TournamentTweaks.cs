using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace RenownTweaks
{
	// Token: 0x02000004 RID: 4
	public class TournamentTweaks : DefaultTournamentModel
	{
		// Token: 0x06000004 RID: 4 RVA: 0x000020A0 File Offset: 0x000002A0
		public override int GetRenownReward(Hero winner, Town town)
		{
			return base.GetRenownReward(winner, town) * 5;
		}
	}
}
