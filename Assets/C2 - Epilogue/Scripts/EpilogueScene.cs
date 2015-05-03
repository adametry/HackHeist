using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EpilogueScene : SceneController
{

	public float CreditsSpeed = 1.0f;
	
	private GameObject credits;
	
	void Start ()
	{
		credits = GameObject.Find("Credits");
	}
	
	public void FixedUpdate ()
	{
		Vector3 pos = credits.transform.position;
		pos.y += CreditsSpeed * Time.fixedDeltaTime;
		credits.transform.position = pos;
		
		if(pos.y > 9.9f) {
			GotoGameMenu();
		}
	}
	
	public void GotoGameMenu()
	{
		GotoScene("GameMenu");
	}

}
