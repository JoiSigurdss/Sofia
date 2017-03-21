using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour {

	// Let's pick two hand textures, for open and closed!
	public Texture texturehand;
	public Texture texturefist;

	// We're going to need to hold the hand (get it, it's a joke! ... nevermind) and the renderer
	GameObject hand;
	Renderer rend;

	// how far I can interact with things
	public float distance;
	// to make sure I know when I'm holding shit
	private bool holding = false;
	// And this is so I remember which object I am holding, so I can throw it away
	private GameObject lastKnown;

	// pretty staight forward, I need to hold what I just raycasted
	RaycastHit hit;

	void Start () {
		// Let's find the hand!
		hand = GameObject.Find("Hand");
		// Now let's get the renderer on the hand
		rend = hand.GetComponent<Renderer>();
	}

	void Update () {

		// this runs if I'm holding something
		if (holding == true && Input.GetMouseButtonDown (0)) {
			lastKnown.GetComponent<Pickable> ().drop ();
			holding = false;
			rend.material.mainTexture = texturehand;
			// audio
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
						holding = true;
						rend.material.mainTexture = texturefist;
					}
				}
			}


			//Destroy (whatIHit.collider.gameObject);
		}
	}
}
