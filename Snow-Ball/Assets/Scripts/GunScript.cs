using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    [SerializeField] private Transform gunTransform;
    [SerializeField] private GameObject flameObject;
    [SerializeField] private float spawnTime;
    [SerializeField] private float spawnDelay;

    private void Start()
    {
        InvokeRepeating("Spawn",spawnTime,spawnDelay);
    }
    private void Spawn()
    {

        Instantiate(flameObject, gunTransform);
    }
}
