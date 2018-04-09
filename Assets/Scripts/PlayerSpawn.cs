using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] private GameObject player2;
    [SerializeField] private GameObject player3;
    [SerializeField] private GameObject player4;

    [SerializeField] private Transform player2Spawn;
    [SerializeField] private Transform player3Spawn;
    [SerializeField] private Transform player4Spawn;

    static bool p2IsSpawned = false;
    static bool p3IsSpawned = false;
    static bool p4IsSpawned = false;
    private bool canSpawn = false;

    private void Update()
    {
        SpawnPlayer();
    }

    private void SpawnPlayer() //Spawn Player X (2,3,4) when Start(2,3,4) button is pressed
    {
        if (canSpawn)
        {
            if (!p2IsSpawned && Input.GetButton("Start2"))
            {
                p2IsSpawned = true;
                player2.transform.position = player2Spawn.position;
                player2.SetActive(true);
            }
            if (!p3IsSpawned && Input.GetButton("Start3"))
            {
                p3IsSpawned = true;
                player3.transform.position = player3Spawn.position;
                player3.SetActive(true);
            }
            if (!p4IsSpawned && Input.GetButton("Start4"))
            {
                p4IsSpawned = true;
                player4.transform.position = player4Spawn.position;
                player4.SetActive(true);
            }
        }
    }

    private void DespawnPlayers() //Deactivate Players 2,3,4 and set transform back to original position
    {
        player2.SetActive(false);
        player3.SetActive(false);
        player4.SetActive(false);

        p2IsSpawned = false;
        p3IsSpawned = false;
        p4IsSpawned = false;

        player2.transform.position = player2Spawn.position;
        player3.transform.position = player3Spawn.position;
        player4.transform.position = player4Spawn.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player1")
        {
            canSpawn = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player1")
        {
            canSpawn = false;

            DespawnPlayers();
        }
    }

}
