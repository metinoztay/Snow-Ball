using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject ballObject;
    [SerializeField] private float spawnTime;
    [SerializeField] private float spawnDelay;

    [SerializeField] private int level;

    private Animator fireAnimator;
    private void Start()
    {
        fireAnimator = GetComponent<Animator>();
        InvokeRepeating("Fire",spawnTime,spawnDelay);
    }
    private void Fire()
    {
        fireAnimator.SetTrigger("Fire");
        Instantiate(ballObject, firePoint.position,firePoint.rotation);
        ballObject.GetComponent<BallScript>().level = this.level;
    }


}
