using UnityEngine;

public class GameEntry : SceneController
{

	public float Delay = 1.0f;
		
	protected void Start ()
	{
		Invoke("GotoGameMenu", Delay);
	}

	protected void GotoGameMenu()
	{
		GotoScene("GameMenu");
	}

}
