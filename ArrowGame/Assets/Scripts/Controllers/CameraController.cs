using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {


	public Transform target;
	public Vector3 offset;
	public float zoomSpeed = 3f;
	public float minZoom = 5f;
	public float maxZoom = 15f; 
	public float yawSpeed = 100f;
	public float pitch = 1f;

	private float currentZoom = 5f;
	private float currentYaw = 0f;


	void Update()
	{
		currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
		currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

		currentYaw -= Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
	}

	void LateUpdate()
	{
		transform.position = target.position - offset * currentZoom;
		transform.LookAt(target.position + Vector3.up * 2f * pitch);
		transform.RotateAround(target.position, Vector3.up, currentYaw);
	}
}
