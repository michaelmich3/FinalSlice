using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSelect : MonoBehaviour
{
	[SerializeField] private GameObject unloadRoom;
	[SerializeField] private GameObject loadRoom;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player1")
		{
			unloadRoom.SetActive(false);
			loadRoom.SetActive(true);
		}
	}
}
