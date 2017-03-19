using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowVegetable : MonoBehaviour {

	public bool ShineWhenDone = true;

	public float timeLeft = 30.0f;
	public GameObject prefab;
	public Texture[] textures;
	Renderer rend;

	void Start() {
		rend = GetComponent<Renderer>();
	}

	void Update() {

		timeLeft -= Time.deltaTime;

		if (timeLeft < 0) {
			rend.material.mainTexture = textures [1];
			if (ShineWhenDone == true) {
				Instantiate (prefab, transform.position, transform.rotation);
				ShineWhenDone = false;
			}
		}
	}
	void OnTriggerEnter(Collider other) {
		if (other.tag == "Plot") {
			Debug.Log ("hallo!");
		}
	}
}
