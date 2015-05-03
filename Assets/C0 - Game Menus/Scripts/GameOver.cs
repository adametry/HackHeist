using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOver : SceneController
{

	public GUIText gameOverText;

	public void Start()
	{
		if (gameOverText) {
			gameOverText.text = "Game Over";
		}
	}

	public void Replay()
	{
		GotoScene("MuseumBattle");
	}

	public void GoToMainMenu()
	{
		GotoScene("GameMenu");
	}
	
}
