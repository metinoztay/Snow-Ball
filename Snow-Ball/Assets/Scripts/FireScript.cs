using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FireScript : MonoBehaviour
{   private Animator fireAnimator;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject ballObject;
    [SerializeField] private float spawnTime;
    [SerializeField] private float spawnDelay;
    [SerializeField] private TMP_Text levelText;


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
        fireAnimator.SetTrigger("Fire");
        Instantiate(ballObject, firePoint.position,firePoint.rotation);
        ballObject.GetComponent<BallScript>().level = this.level;
    }


}
