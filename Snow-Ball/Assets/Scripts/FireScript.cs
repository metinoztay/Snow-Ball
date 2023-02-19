using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FireScript : MonoBehaviour
{   private Animator fireAnimator;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject ballObject;
    [SerializeField] private float spawnTime;
    [SerializeField] public float spawnDelay;

    [SerializeField] public float minDelay;

    [SerializeField] public int maxLevel;
    [SerializeField] private TMP_Text levelText;

    [SerializeField] public bool startFire;


    private int _level = 2;
    public int level
    {
        get { return _level; }
        set { _level = value;
               levelText.text = _level.ToString();
         }
    }
    
    
    
    private void Start()
    {
        fireAnimator = GetComponent<Animator>();
        InvokeRepeating("Fire",spawnTime,spawnDelay);
       
        
    }
    private void Fire()
    {
        if (startFire)
        {
            fireAnimator.SetTrigger("Fire");
            Instantiate(ballObject, firePoint.position,firePoint.rotation);
            ballObject.GetComponent<BallScript>().level = this.level;
        }        
    }

    public void BallLevelUp(){
        if (level < maxLevel)
        {
            level++;
        }
    }

    public void FireSpeedUp(){
        if (spawnDelay > minDelay)
        {
            spawnDelay -= 0.1f;
        }
    }
}
