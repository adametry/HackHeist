using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {

	public GameObject followMe;
	private GameObject attachedObject;
	// Use this for initialization
	void Start () {
		Debug.Log("Start");
		Debug.Log(gameObject.name);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newPos = followMe.transform.position;

		transform.position = newPos;
	}
}