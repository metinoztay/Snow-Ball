using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject ballObject;
    [SerializeField] private float spawnTime;
    [SerializeField] private float spawnDelay;
    private void Start()
    {
        InvokeRepeating("Fire",spawnTime,spawnDelay);
    }
    private void Fire()
    {
        Instantiate(ballObject, firePoint.position,firePoint.rotation);
    }


}
