using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grow : MonoBehaviour {

	public GameObject State01;
	public GameObject State02;
	public GameObject State03;
	public GameObject State04;
	public float startPos;
	public float endPos;
	public float evolveTime1 = 0.5f;
	public float evolveTime2 = 1.5f;
	public float growTime = 0.1f;
	public float growLength = 2.5f;

	void Start () {
		Debug.Log ("hallo" + transform.position.y);
		startPos = transform.position.y;
		endPos = startPos + growLength;
		Debug.Log ("end" + endPos);
	}

	void Update() {
		//transform.Translate(Vector3.forward * Time.deltaTime);
		if (transform.position.y < endPos) {
			transform.Translate (Vector3.up * growTime * Time.deltaTime, Space.World);
			Debug.Log (transform.position.y);
		}

		if (transform.position.y > startPos + evolveTime1) {
			State01.SetActive (false);
			State02.SetActive (true);
		}
		if (transform.position.y > startPos + evolveTime2) {
			State02.SetActive (false);
			State03.SetActive (true);
		}
		if (transform.position.y >= endPos) {
			State03.SetActive (false);
			State04.SetActive (true);
		}
	}
}