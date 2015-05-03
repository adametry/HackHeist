using UnityEngine;
using System.Collections;

public class NextSceneOnCollide : MonoBehaviour {

	public string NextSceneName = null;
	public Color FadeToColor = new Color(0, 0, 0, 1);
	public float FadeDuration = 1.0f;
	public string Tag;

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == Tag) {
			//coll.gameObject.GetComponent<PlayerFreeze>().Freeze();
			Camera.main.GetComponent<SceneCamera>().GotoScene(NextSceneName, FadeDuration, FadeToColor);
		}
	}
}
