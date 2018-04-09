using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    [SerializeField] private bool isEnabled = true;
    [SerializeField] private int minTime = 5;
    [SerializeField] private int maxTime = 15;
    [SerializeField] private GameObject[] items;
    [SerializeField] private Transform spawnLocationParent;

    private List<Transform> spawnLocations = new List<Transform>();
    private GameObject currentItem;
    private Transform currentSpawnLocation;
    private int timeInterval;
    private bool doNotSpawn = false;



    private void Start()
    {
        LoadLocations();
        timeInterval = Random.Range(minTime, maxTime);
        InvokeRepeating("SpawnItem", timeInterval, timeInterval); //Spawn a random item at a random location every minTime to maxTime
    }



    private void LoadLocations() //Finds all transform locations for the item spawner
    {
        foreach (Transform child in spawnLocationParent)
        {
            spawnLocations.Add(child.transform);
        }
    }

    private void RandomItem() //Choose random item to spawn from list
    {
        currentItem = items[Random.Range(0, items.Length)];
    }

    private void RandomLocation() //Choose random location to spawn from list
    {
        int stopLoop = 10;
        currentSpawnLocation = spawnLocations[Random.Range(0, spawnLocations.Count)];
        while (currentSpawnLocation.childCount > 0 && stopLoop > 0) //Find an empty spawn location - stop looking after 10 tries
        {
            currentSpawnLocation = spawnLocations[Random.Range(0, spawnLocations.Count)];
            stopLoop--;
            Debug.Log("Retry #" + stopLoop);

            if (stopLoop <= 0) //If no free location after 10 tries, do not spawn
            {
                doNotSpawn = true;
            }
        }
    }

    private void SpawnItem() //Spawn chosen item to target location every X seconds
    {
        timeInterval = Random.Range(minTime, maxTime);
        RandomItem();
        RandomLocation();

        if (!doNotSpawn) //Spawn an item only if there is a free spawn location
        {
            Instantiate(currentItem, currentSpawnLocation);
        }
    }
}
