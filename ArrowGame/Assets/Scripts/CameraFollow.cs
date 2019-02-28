using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	public class CameraFollowScript : MonoBehaviour
	{

		GameObject player;
		void Start()
		{
			player = PlayerManager.instance.player;
		}

		void LateUpdate()
		{
			transform.position = player.transform.position;
		}
	}

}
