using UnityEngine;

using System.Collections;

public class UIManager : MonoBehaviour {

	private Animator menuAnim;
	private bool menuOn = false;
	public GameObject MoveArrows;
	public GameObject Player;

	// Use this for initialization



	void Start () {
	
	}

	void Awake(){
		menuAnim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("right shift")){
			BeginMenu();
		}
	}

	public void BeginMenu(){
		if (!menuOn) {
			Debug.Log ("FadeIn");
			menuAnim.SetTrigger ("FadeIn");
			menuOn = true;
		} else {
			Debug.Log ("FadeOut");
			menuAnim.SetTrigger ("FadeOut");
			menuOn = false;
		}
	}

	public void DrawArrows(){
		Debug.Log ("Run");
		Vector3 PlayerPos = Player.transform.position;
		Vector3 NewPlayerPos = new Vector3(PlayerPos.x += 5.0f, 0, 0);
		Debug.Log (PlayerPos.x);
		Vector3 position = new Vector3(Random.Range(-10.0F, 10.0F), 0, Random.Range(-10.0F, 10.0F));
		Instantiate(MoveArrows, PlayerPos, Quaternion.identity);
	}

}
