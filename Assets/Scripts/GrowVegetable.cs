using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowVegetable : MonoBehaviour {

	public bool ShineWhenDone = true;
	private bool grow = false;

	public float timeLeft = 30.0f;
	public GameObject prefab;
	public Texture[] textures;
	Renderer rend;

	void Start() {
		rend = GetComponent<Renderer>();
	}

	void Update() {
		if (grow == true) {

			timeLeft -= Time.deltaTime;
			if (timeLeft < 0) {
				rend.material.mainTexture = textures [1];
				if (ShineWhenDone == true) {
					Instantiate (prefab, transform.position + new Vector3(0,0.5f,0), transform.rotation);
					ShineWhenDone = false;
				}
			}	
		}
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "Plot") {
			transform.position = other.transform.position;
			Debug.Log ("hallo!");
			GetComponent<Rigidbody> ().isKinematic = true;
			grow = true;

		}
	}
}
