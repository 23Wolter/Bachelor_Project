using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchTheBugs : MonoBehaviour
{
    public Transform spawnPoint;


    private void OnCollisionEnter(Collision collision)
    {
        collision.transform.position = spawnPoint.transform.position; 
    }
}
