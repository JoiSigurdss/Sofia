using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ignorePlayerCollision : MonoBehaviour {
	GameObject player;

	void Start () {
		player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		Physics.IgnoreCollision(player.GetComponent<Collider>(), GetComponent<Collider>());
	}
}
