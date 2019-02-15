using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour {

	// Use this for initialization

	GameObject player;
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		print("Found player" + player.ToString());
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = player.transform.position;
	}
}
