using RBot;

public class Script {

	public void ScriptMain(ScriptInterface bot){
		bot.Options.SafeTimings = true;
		bot.Options.RestPackets = true;
		//Configuration
		bot.Skills.SkillTimer = 500;
		bot.Options.ExitCombatBeforeQuest = true;
		bot.Drops.RejectElse = true;
		bot.Drops.Add("Escherion's Helm");
		bot.Drops.Add("Voucher of Nulgath (non-mem)");
		bot.Drops.Add("Voucher of Nulgath");
		bot.Drops.Add("Tainted Gem");
		bot.Drops.Add("Unidentified 13");
		bot.Drops.Add("Unidentified 10");
		bot.Drops.Add("Dark Crystal Shard");
		bot.Drops.Add("Blood Gem of the Archfiend");
		bot.Drops.Add("Tainted Core");
		bot.Drops.Add("Gem of Nulgath");
		bot.Drops.Start();
		bot.Options.AutoRelogin = true;
		bot.Options.SafeRelogin = false;
		bot.Options.LoginServer = ServerList.Servers.Find(x => x.Name == "Twilly");
		bot.Options.InfiniteRange = true;
		bot.Options.SkipCutsenes = true;
		bot.Options.WalkSpeed = 8;
		//Skills
		bot.Skills.Add(1, 1f);
		bot.Skills.Add(2, 1f);
		bot.Skills.Add(3, 1f);
		bot.Skills.Add(4, 1f);
		bot.Skills.StartTimer();

		while(!bot.ShouldExit()){
			bot.Quests.EnsureAccept(609);
			kill1:
			//Map is not
			if(bot.Map.Name != "nulgath")
				bot.Player.Join("nulgath-1e99", "End", "Left");
			bot.Player.Kill("*");
			//Is in room
			if(bot.Monsters.Exists("*"))
				goto kill1;
			bot.Player.Join("nulgath-1e99", "End", "Left");
			//Is not in temp
			if(!bot.Inventory.ContainsTempItem("Tainted Core", 1))
				goto kill1;
			//Map is not
			if(bot.Map.Name != "Blank")
				bot.Player.Jump("Blank", "Left");
			bot.Sleep(500);
			bot.Quests.EnsureComplete(609);
			bot.Quests.EnsureAccept(2857);
			bot.Sleep(300);
			bot.Quests.EnsureComplete(2857);
		}
	}
}