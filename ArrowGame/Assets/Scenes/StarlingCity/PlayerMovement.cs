using System;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof (ThirdPersonCharacter))]
public class PlayerMovement : MonoBehaviour
{

	[SerializeField] float walkToMoveStopRadius = 0.2f;

	// privates 

	private ThirdPersonCharacter m_Character;   // A reference to the ThirdPersonCharacter on the object
    private CameraRaycaster cameraRaycaster;
    private Vector3 currentClickTarget;
	private bool isInDirectMode = false;
	private Transform m_Cam;                  // A reference to the main camera in the scenes transform
	private Vector3 m_CamForward;             // The current forward direction of the camera
	private Vector3 m_Move;
	private bool m_Jump;


	private void Start()
    {
        cameraRaycaster = Camera.main.GetComponent<CameraRaycaster>();
        m_Character = GetComponent<ThirdPersonCharacter>();
        currentClickTarget = transform.position;
		if (Camera.main != null)
		{
			m_Cam = Camera.main.transform;
		}
	}

	private void Update()
	{
		if (!m_Jump)
		{
			m_Jump = Input.GetButtonDown("Jump");
		}
	}


	// Fixed update is called in sync with physics
	private void FixedUpdate()
	{
		if (Input.GetKeyDown(KeyCode.M)) // M for mode
		{
			isInDirectMode = !isInDirectMode;
		}
		if (isInDirectMode)
			ProcessMouseMovement(); 
		else
			ProcessDirectMovement();

	}

	private void ProcessDirectMovement()
	{
		// read inputs
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		bool crouch = Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.RightCommand) || Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.LeftCommand);

		m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
		m_Move = v * m_CamForward + h * m_Cam.right;
		m_Character.Move(m_Move, crouch, m_Jump);
		m_Jump = false;
	}

	private void ProcessMouseMovement()
	{
		if (Input.GetMouseButton(0))
		{
			switch (cameraRaycaster.layerHit)
			{
				case Layer.Walkable:
					currentClickTarget = cameraRaycaster.hit.point;
					break;
				case Layer.Enemy:
					break;
				default:
					break;
			}
		}
		var playerToClickPoint = currentClickTarget - transform.position;
		bool crouch = Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.RightCommand) || Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.LeftCommand);
		if (playerToClickPoint.magnitude >= walkToMoveStopRadius)
		{
			m_Character.Move(playerToClickPoint, crouch, m_Jump);
		}
		else
		{
			m_Character.Move(Vector3.zero, crouch, m_Jump);
		}
		m_Jump = false;
	}
}

