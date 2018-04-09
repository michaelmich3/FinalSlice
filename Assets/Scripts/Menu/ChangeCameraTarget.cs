using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraTarget : MonoBehaviour
{
	[SerializeField] private GameObject camera;
	[SerializeField] private Transform newTarget;

	private MoveToTarget moveToTarget;

	private void Awake()
	{
		moveToTarget = camera.GetComponent<MoveToTarget>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player1")
		{
			moveToTarget.CurrentTarget = newTarget;
		}
	}
}
