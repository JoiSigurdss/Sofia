using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour {

	// Let's pick two hand textures, for open and closed!
	public Texture texturehand;
	public Texture texturefist;

	// And let's set our ready time, think of it as a response time to interact with things
	public float readyTime = 0.3f;
	private float readyTimer = 0.3f;

	// We're going to need to hold the hand (get it, it's a joke! ... nevermind) and the renderer
	GameObject hand;
	Renderer rend;

	// We're also going to need the shoulder to move the hand around
	GameObject shoulder;

	// how far I can interact with things
	public float distance;
	// to make sure I know when I'm holding shit
	private bool holding = false;
	// And this is so I remember which object I am holding, so I can throw it away
	private GameObject lastKnown;
	// Also, when can I interact with the object again, after interacting with it last?
	private bool ready = true;

	// pretty staight forward, I need to hold what I just raycasted
	RaycastHit hit;

	public float ArmLocalXRotationMax;
	public float ArmRaiseTime;
	public float ArmRaiseForceMax;
	public float ArmRaiseForceMin;

	private float HoldDownCounter;

	private Quaternion ArmDefaultRotation;

	void Start () {

		// Let's find the hand!
		hand = GameObject.Find("Hand");
		shoulder = GameObject.Find("Shoulder");
		// Now let's get the renderer on the hand
		rend = hand.GetComponent<Renderer>();

		readyTimer = readyTime;

		ArmDefaultRotation = shoulder.transform.localRotation;

	}

	void Update () {

		if (ready == false) {
			readyTimer -= Time.deltaTime;
			if (readyTimer < 0) {
				readyTimer = 0.3f;
				ready = true;
			}
		}

		if (ready == true) {
			if (holding ) 
			{
				var weight = lastKnown.GetComponent<Pickable>().weight;
				var totalTime = ArmRaiseTime * weight;
				var fraction = HoldDownCounter / totalTime;

				if (Input.GetMouseButtonDown (0)) 
				{
					HoldDownCounter = 0;
					Debug.Log ("STARTED T OHOLD DOWN");
				}
				if (Input.GetMouseButton (0)) {
					Debug.Log (HoldDownCounter);

					if (HoldDownCounter < totalTime) {
						// figure out arm max rotation and lerp
						var ArmRotationMaxQuaternion = Quaternion.Euler (ArmLocalXRotationMax, 0, 0);
						shoulder.transform.localRotation = Quaternion.Lerp(ArmDefaultRotation, ArmRotationMaxQuaternion, fraction);

						// keep counting time
						HoldDownCounter += Time.deltaTime;
					}
				}
				if(Input.GetMouseButtonUp (0)) {

					var relativeFraction = fraction / weight;

					var throwForce = Mathf.Lerp (ArmRaiseForceMin, ArmRaiseForceMax, relativeFraction);

					lastKnown.GetComponent<Pickable>().drop(throwForce);
					holding = false;
					rend.material.mainTexture = texturehand;
					//reset shoulder rotation

					shoulder.transform.localRotation = ArmDefaultRotation;

					// audio
				}

			} 

			// Ok, this is a magic, first, detect what's in front of me
			if(Physics.Raycast(this.transform.position, this.transform.forward, out hit, distance)){
				// then check if it's a trigger, I use triggers to make it easier to grab things, larger hit area
				if(hit.collider.isTrigger)
				{
					// now I check what tag the object has, that I just hit
					// if it's Pickable, I want to pick it up!
					if (hit.transform.tag == "Pickable") {
						// ok, first I check if I'm already holding things AND if I just pressed the mouse button
						if (holding == false && Input.GetMouseButtonDown (0)) {
							hit.transform.gameObject.GetComponent<Pickable> ().pickup ();
							lastKnown = hit.transform.gameObject;
							//lastKnown.GetComponent<Pickable> ().throwForce = lastKnown.GetComponent<Pickable> ().minForce;
							holding = true;
							HoldDownCounter = 0;
							ready = false;
							rend.material.mainTexture = texturefist;
						}
					}
				}


			//Destroy (whatIHit.collider.gameObject);
			}
		}
	}
}
