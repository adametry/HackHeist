using UnityEngine;
using System.Collections;

public class ClickToMove : MonoBehaviour {
	
	private float smooth = 0.5f;
	public float speed = 1.5f;
	private Vector3 target;
	private GameObject currentObj;

	private Vector3 wantedPos;

	private Animator animate;
	int walkHash = Animator.StringToHash("Run");
	// Use this for initialization
	void Start () {
		target = transform.position;
		animate = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
		{
			Move();
		}
	}

	void Move(){
		animate.SetTrigger (walkHash);
		Vector3 mousePos = Input.mousePosition;
		wantedPos = Camera.main.ScreenToWorldPoint (new Vector3 (mousePos.x, mousePos.y, 1f));
		Vector3 relativePos = wantedPos - transform.position ;
		iTween.MoveTo(gameObject,wantedPos,2);
	}
} 