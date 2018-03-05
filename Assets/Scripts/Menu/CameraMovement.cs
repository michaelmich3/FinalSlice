using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float travelTime = 1f;
    public Transform CurrentTarget;
    
    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, CurrentTarget.transform.position, ref velocity, travelTime);
    }
}
