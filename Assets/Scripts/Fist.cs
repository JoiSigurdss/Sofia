using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fist : MonoBehaviour {

	public Texture hand;
	public Texture fist;
	Renderer rend;

	void Start() {
		rend = GetComponent<Renderer>();
	}
	
	void Update () {
		if (Input.GetMouseButton (0) || Input.GetMouseButton (1)) {
			rend.material.mainTexture = fist;

		} else {
			rend.material.mainTexture = hand;
		}
	}
}
