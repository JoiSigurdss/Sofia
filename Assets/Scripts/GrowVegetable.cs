using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowVegetable : MonoBehaviour {

	public bool ShineWhenDone = true;
	private bool grow = false;
	private bool grown = false;

	public float timeLeft = 30.0f;
	public GameObject prefab;
	public Texture textures;

	Renderer rend;

	void Start() {
		rend = GetComponentInChildren <Renderer>();
	}

	void Update() {
		if (grow == true && grown == false) {

			timeLeft -= Time.deltaTime;
			if (timeLeft < 0) {
				rend.material.mainTexture = textures;
				grown = true;
				if (ShineWhenDone == true) {
					Instantiate (prefab, transform.position + new Vector3(0,0.5f,0), transform.rotation);
					ShineWhenDone = false;
				}
			}	
		}
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "Plot" && grown == false ) {
			transform.position = other.transform.position;
			GetComponent<Rigidbody> ().isKinematic = true;
			grow = true;
		}
	}
}
