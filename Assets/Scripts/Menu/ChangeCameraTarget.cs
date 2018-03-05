using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraTarget : MonoBehaviour
{
	[SerializeField] private GameObject camera;
	[SerializeField] private Transform newTarget;

	private CameraMovement cameraMovement;

	private void Awake()
	{
		cameraMovement = camera.GetComponent<CameraMovement>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player1")
		{
			cameraMovement.CurrentTarget = newTarget;
		}
	}
}
