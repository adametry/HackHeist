using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class SceneController : MonoBehaviour
{
	
	public virtual void OnEnable()
	{

	}

	public virtual void OnDisable()
	{
		
	}


	protected void GotoScene(string sceneName)
	{
		Camera.main.GetComponent<SceneCamera>().GotoScene(sceneName);
	}

	protected void GotoScene(string sceneName, float seconds)
	{
		Camera.main.GetComponent<SceneCamera>().GotoScene(sceneName, seconds);
	}

	protected void GotoScene(string sceneName, float seconds, Color fadeTo)
	{
		Camera.main.GetComponent<SceneCamera>().GotoScene(sceneName, seconds, fadeTo);
	}


}
