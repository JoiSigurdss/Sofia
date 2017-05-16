using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crop : MonoBehaviour {

	public GameObject State01;
	public GameObject State02;
	public GameObject State03;
	public GameObject State04;
	public GameObject Shine;

	bool state2done = false;
	bool state3done = false;

	public GameObject Reap;
	public GameObject Harvest;

	bool grown = false;

	public float timeLeft = 30.0f;
	float switchtime1 = 20.0f;
	float switchtime2 = 10.0f;

	// Use this for initialization
	void Start () {
		switchtime1 = (timeLeft / 1.5f);
		switchtime2 = (timeLeft / 3f);
	}
	
	// Update is called once per frame
	void Update () {
		if (grown == false) {


			transform.Translate (Vector3.up * 0.02f * Time.deltaTime, Space.World);
			timeLeft -= Time.deltaTime;

			if (timeLeft < switchtime1 && state2done == false) {
				State01.SetActive (false);
				State02.SetActive (true);
				state2done = true;
			}
			if (timeLeft < switchtime2 && state3done == false) {
				State02.SetActive (false);
				State03.SetActive (true);
				state3done = true;
			}
			if (timeLeft < 0) {
				State03.SetActive (false);
				State04.SetActive (true);
				Shine.SetActive (true);
				grown = true;
			}	
		}
	}

	public void harvest () {
		if (grown == true) {
			Instantiate (Harvest, transform.position + new Vector3 (0, 0, 0), transform.rotation);
			Instantiate (Reap, transform.position + new Vector3 (0, 0.5f, 0), transform.rotation);
			Destroy (gameObject);
		}
	}

}
