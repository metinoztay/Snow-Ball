using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FireScript : MonoBehaviour
{   private Animator fireAnimator;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject ballObject;
    [SerializeField] private float spawnTime;
    [SerializeField] public float fireSpeed;

    [SerializeField] public float minDelay;

    [SerializeField] public int maxLevel;
    [SerializeField] private TMP_Text levelText;

    [SerializeField] public bool startFire;


    private int _level = 2;
    public int ballLevel
    {
        get { return _level; }
        set { _level = value;
               levelText.text = _level.ToString();
         }
    }
    
    
    
    private void Start()
    {
        ballLevel = PlayerPrefs.GetInt(nameof(ballLevel));
        fireSpeed = PlayerPrefs.GetFloat(nameof(fireSpeed));
        fireAnimator = GetComponent<Animator>();
        InvokeRepeating("Fire",spawnTime,fireSpeed);
    }
    private void Fire()
    {
        if (startFire)
        {
            fireAnimator.SetTrigger("Fire");
            Instantiate(ballObject, firePoint.position,firePoint.rotation);
            ballObject.GetComponent<BallScript>().level = this.ballLevel;
        }        
    }

    public void BallLevelUp(){
        if (ballLevel < maxLevel)
        {
            ballLevel++;
            PlayerPrefs.SetInt(nameof(ballLevel),ballLevel);
        }
    }

    public void FireSpeedUp(){
        if (fireSpeed > minDelay)
        {
            fireSpeed -= 0.1f;
            PlayerPrefs.SetFloat(nameof(fireSpeed),fireSpeed);
        }
    }
}
