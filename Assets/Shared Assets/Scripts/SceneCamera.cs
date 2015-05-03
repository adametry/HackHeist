using UnityEngine;
using System.Collections;

public class SceneCamera : MonoBehaviour
{

	public float fadeInDuration = 2f;
	public Color fadeInFrom= Color.black;

	[HideInInspector]
	public bool isFading = true;

	private GUIStyle backgroundStyle = new GUIStyle(); // Style for background tiling
	private Texture2D fadeTexture;// 1x1 pixel texture used for fading
	private Color currentScreenOverlayColor = new Color(0, 0, 0, 0); // default starting color: black and fully transparrent
	private Color targetScreenOverlayColor = new Color(0, 0, 0, 0); // default target color: black and fully transparrent
	private Color deltaColor = new Color(0,0,0,0); // the delta-color is basically the "speed / second" at which the current color should change
	private int fadeGUIDepth = -1000; // make sure this texture is drawn on top of everything
	

	private void Awake()
	{
		FadeIn();
	}

	private void FadeIn()
	{
		fadeTexture = new Texture2D(1, 1);
		backgroundStyle.normal.background = fadeTexture;
		
		SetScreenOverlayColor(fadeInFrom);
		
		// start the fade in
		StartFade(new Color(fadeInFrom.r, fadeInFrom.g, fadeInFrom.b, 0), fadeInDuration);
	}

	
	public void StartFade(Color newScreenOverlayColor, float fadeDuration)
	{
		isFading = true;
		
		if (fadeDuration <= 0.0f)		// can't have a fade last -2455.05 seconds!
		{
			SetScreenOverlayColor(newScreenOverlayColor);
		}
		else					// initiate the fade: set the target-color and the delta-color
		{
			targetScreenOverlayColor = newScreenOverlayColor;
			deltaColor = (targetScreenOverlayColor - currentScreenOverlayColor) / (fadeDuration * 2);
		}
	}

	
	// draw the texture and perform the fade:
	private void OnGUI()
	{
		// if the current color of the screen is not equal to the desired color: keep fading!
		if (currentScreenOverlayColor != targetScreenOverlayColor)
		{
			// if the difference between the current alpha and the desired alpha is smaller than delta-alpha * deltaTime, then we're pretty much done fading:
			if (Mathf.Abs(currentScreenOverlayColor.a - targetScreenOverlayColor.a) < Mathf.Abs(deltaColor.a) * Time.deltaTime)
			{
				currentScreenOverlayColor = targetScreenOverlayColor;
				SetScreenOverlayColor(currentScreenOverlayColor);
				deltaColor = new Color(0,0,0,0);
			}
			else
			{
				// fade!
				SetScreenOverlayColor(currentScreenOverlayColor + deltaColor * Time.deltaTime);
			}
		} else {
			isFading = false;
		}
		
		// only draw the texture when the alpha value is greater than 0:
		if (currentScreenOverlayColor.a > 0)
		{
			GUI.depth = fadeGUIDepth;
			//GUI.Label(AspectUtility.screenRect, fadeTexture, backgroundStyle);
		}
	}


	public void SetScreenOverlayColor(Color newScreenOverlayColor)
	{
		currentScreenOverlayColor = newScreenOverlayColor;
		fadeTexture.SetPixel(0, 0, currentScreenOverlayColor);
		fadeTexture.Apply();
	}


	public void GotoScene(string sceneName)
	{
		GotoScene(sceneName, fadeInDuration);
	}

	public void GotoScene(string sceneName, float seconds)
	{
		GotoScene(sceneName, seconds, Color.black);
	}

	public void GotoScene(string nextScene, float seconds, Color fadeTo)
	{
		StartCoroutine(GotoSceneCoroutine(nextScene, seconds, fadeTo));
	}
	
	private IEnumerator GotoSceneCoroutine(string nextScene, float seconds, Color fadeTo)
	{
		SetScreenOverlayColor (new Color(fadeTo.r, fadeTo.g, fadeTo.b, 0));
		StartFade(fadeTo, seconds);
		yield return new WaitForSeconds(seconds);
		if(nextScene != null)
			Application.LoadLevel(nextScene);
	}
}