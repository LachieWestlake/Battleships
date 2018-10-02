
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
//using System.Data;
using System.Diagnostics;
using SwinGameSDK;
static class GameLogic
{
	public static void Main()
	{
		//Opens a new Graphics Window
		SwinGame.OpenGraphicsWindow("Battle Ships", 800, 600);

		//Load Resources
		GameResources.LoadResources();
		Random rnd = new Random();
		int songNumber = rnd.Next(1, 5);

		//FIXME only songs 1 and 4 play correctly
		switch (songNumber)
		{
			case 1:
				SwinGame.PlayMusic(GameResources.GameMusic("Background1"));
				break;
			case 2:
				SwinGame.PlayMusic(GameResources.GameMusic("Background2"));
				break;
			case 3:
				SwinGame.PlayMusic(GameResources.GameMusic("Background3"));
				break;
			case 4:
				SwinGame.PlayMusic(GameResources.GameMusic("Background4"));
				break;
		}
		

		//Game Loop
		do {
			GameController.HandleUserInput();
			GameController.DrawScreen();
		} while (!(SwinGame.WindowCloseRequested() == true | GameController.CurrentState == GameState.Quitting));

		SwinGame.StopMusic();

		//Free Resources and Close Audio, to end the program.
		GameResources.FreeResources();
	}
}