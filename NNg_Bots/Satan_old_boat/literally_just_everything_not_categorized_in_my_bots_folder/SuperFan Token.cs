using RBot;

public class Script {

	public void ScriptMain(ScriptInterface bot){
		bot.Options.SafeTimings = true;
		bot.Options.RestPackets = true;
		//Configuration
		bot.Skills.SkillTimer = 500;
		bot.Options.ExitCombatBeforeQuest = true;
		bot.Drops.RejectElse = true;
		bot.Drops.Add("Super-Fan Swag Token D");
		bot.Drops.Add("Super-Fan Swag Token C");
		bot.Drops.Add("Super-Fan Swag Token B");
		bot.Drops.Add("Super-Fan Swag Token A");
		bot.Drops.Add("Satanic Marking");
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
		bot.Skills.Add(3, 0.6f);
		bot.Skills.Add(4, 1f);
		bot.Skills.StartTimer();

		while(!bot.ShouldExit()){
			worship_satan:
			bot.Quests.EnsureAccept(1310);
			re:
			bot.Player.Join("collectorlab-1e99", "Enter", "Spawn");
			kill:
			//Quest can not be turned in
			if(!bot.Quests.CanComplete(1310))
				goto comp1;
			bot.Player.Jump("Blank", "Left");
			bot.Sleep(500);
			bot.Quests.EnsureComplete(1310);
			bot.Quests.EnsureAccept(1310);
			comp1:
			//Is in inventory
			if(bot.Inventory.Contains("Super-Fan Swag Token C", 500))
				goto buy;
			//Map is not
			if(bot.Map.Name != "collectorlab")
				bot.Player.Join("collectorlab-1e99", "Enter", "Spawn");
			//Cell is not
			if(bot.Player.Cell != "Enter")
				bot.Player.Jump("Enter", "Spawn");
			bot.Player.Kill("*");
			//Is in room
			if(bot.Monsters.Exists("*"))
				goto kill;
			goto re;
			buy:
			//Cell is not
			if(bot.Player.Cell != "Blank")
				bot.Player.Jump("Blank", "Left");
			//Map is not
			if(bot.Map.Name != "collection")
				bot.Player.Join("collection-1e99", "Enter", "Spawn");
			//Is not in inventory
			if(!bot.Inventory.Contains("Super-Fan Swag Token D", 10))
				goto buy1;
			//Is in inventory
			if(bot.Inventory.Contains("Super-Fan Swag Token C", 500))
				goto buy1;
			bot.Sleep(1000);
			bot.Shops.BuyItem(325, "Super-Fan Swag Token C");
			//Is in inventory
			if(bot.Inventory.Contains("Super-Fan Swag Token D", 10))
				goto subbuy;
			goto buy;
			subbuy:
			//Is not in inventory
			if(!bot.Inventory.Contains("Super-Fan Swag Token C", 500))
				goto buy;
			buy1:
			//Is not in inventory
			if(!bot.Inventory.Contains("Super-Fan Swag Token C", 10))
				goto buy2;
			bot.Sleep(1000);
			//Is in inventory
			if(bot.Inventory.Contains("Super-Fan Swag Token B", 200))
				goto buy2;
			bot.Shops.BuyItem(325, "Super-Fan Swag Token B");
			//Is in inventory
			if(bot.Inventory.Contains("Super-Fan Swag Token C", 10))
				goto subbuy2;
			goto buy1;
			subbuy2:
			//Is not in inventory
			if(!bot.Inventory.Contains("Super-Fan Swag Token B", 200))
				goto buy1;
			buy2:
			//Is not in inventory
			if(!bot.Inventory.Contains("Super-Fan Swag Token B", 20))
				goto kill;
			bot.Sleep(1000);
			//Is in inventory
			if(bot.Inventory.Contains("Super-Fan Swag Token A", 100))
				goto buy3;
			bot.Shops.BuyItem(325, "Super-Fan Swag Token A");
			//Is in inventory
			if(bot.Inventory.Contains("Super-Fan Swag Token B", 20))
				goto subbuy3;
			goto buy2;
			subbuy3:
			//Is not in inventory
			if(!bot.Inventory.Contains("Super-Fan Swag Token A", 100))
				goto buy2;
			buy3:
			//Is not in inventory
			if(!bot.Inventory.Contains("Super-Fan Swag Token B", 200))
				ScriptManager.RestartScript();
			//Is in inventory
			if(bot.Inventory.Contains("Super-Fan Swag Token C", 500))
				ScriptManager.StopScript();
			return;
		}
	}
}