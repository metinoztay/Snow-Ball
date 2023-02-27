using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FireScript : MonoBehaviour
{   private Animator fireAnimator;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject ballObject;
    [SerializeField] private float spawnStartTime;
    [SerializeField] public float fireSpeed=1;

    [SerializeField] public float minDelay;

    [SerializeField] public int maxLevel;
    [SerializeField] private TMP_Text levelText;

    [SerializeField] public bool startFire;


    private int _level;
    public int ballLevel
    {
        get { return _level; }
        set { _level = value;
               levelText.text = _level.ToString();
         }
    }
    
    private void Awake() {
        LoadPlayerSaves();
    }
    private void Start()
    {
        
        fireAnimator = GetComponent<Animator>();
        
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

    public void StartFire(){
        startFire = true;
        InvokeRepeating("Fire",spawnStartTime,fireSpeed);
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

    private void LoadPlayerSaves(){
        ballLevel = PlayerPrefs.GetInt(nameof(ballLevel));
        fireSpeed = PlayerPrefs.GetFloat(nameof(fireSpeed));
        
        if(ballLevel==0)    
            ballLevel = 1;
        if(fireSpeed==0)
            fireSpeed = 1f;

        Debug.Log(ballLevel  + " " +  fireSpeed);
        
    }
}
