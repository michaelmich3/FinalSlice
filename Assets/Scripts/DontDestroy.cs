using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    [SerializeField] private GameObject[] gameObjects;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);

        foreach (var gameObject in gameObjects)
        {
            DontDestroyOnLoad(gameObject.transform.gameObject);
        }
    }
}
