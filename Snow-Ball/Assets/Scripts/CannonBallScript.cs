using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallScript : MonoBehaviour
{
    [SerializeField] private Transform cannonTransformPoint;
    [SerializeField] private GameObject cannonObject;
    [SerializeField] private float spawnTime;
    [SerializeField] private float spawnDelay;
    private void Start()
    {
        InvokeRepeating("Spawn",spawnTime,spawnDelay);

    }
    private void Spawn()
    {
        Instantiate(cannonObject, cannonTransformPoint);
    }

}
