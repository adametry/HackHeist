using UnityEngine;
using UnityEngine.UI;

public class GameMenu : SceneController
{

	public Button startButton;
	public Button exitButton;
	
	public void BeginGame()
	{
		GotoScene("MuseumBattle");
	}

	public void ExitGame()
	{
		Application.Quit();
	}
	
}
