using RenownTweaks;
using System;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace RenownTweaks
{
	// Token: 0x02000003 RID: 3
	public class SubModule : MBSubModuleBase
	{
		// Token: 0x06000003 RID: 3 RVA: 0x00002120 File Offset: 0x00000320
		protected override void OnGameStart(Game game, IGameStarter starterObject)
		{
			base.OnGameStart(game, starterObject);
			starterObject.AddModel(new BattleTweaks());
			starterObject.AddModel(new TournamentTweaks());
			starterObject.AddModel(new LostTroopTweaks());
			starterObject.AddModel(new XPTweaks());
			starterObject.AddModel(new TrainingTweaks());
		}
	}
}