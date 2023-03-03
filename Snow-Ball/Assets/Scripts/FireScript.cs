using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FireScript : MonoBehaviour
{   private Animator fireAnimator;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject ballPrefab;

    [Space]
    [Header ("Balls to prepare")]
    [SerializeField] private int maxBalls;
    public Queue<GameObject> ballsQueue = new Queue<GameObject>();
    [SerializeField] private int ballSpeed;
    [SerializeField] public float fireSpeed=1;

    [SerializeField] public float minDelay;

    [SerializeField] public int maxLevel;
    [SerializeField] private TMP_Text levelText;
    Coroutine fireCoroutine;
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
        
        fireAnimator = GetComponent<Animator>();
    }

    public void StartFire(){
        PrepareBalls();
        fireCoroutine = StartCoroutine(Fire());
    }

    public void StopFire(){
        StopCoroutine(fireCoroutine);
    }
    IEnumerator Fire()
    {
        while(true)
        {
            yield return new WaitForSecondsRealtime(fireSpeed);

            fireAnimator.SetTrigger("Fire");
            GameObject ball = ballsQueue.Dequeue(); 
            ball.transform.position = firePoint.transform.position;
            ball.SetActive(true);
            
            
            ball.GetComponent<Rigidbody2D>().AddForce(transform.up*ballSpeed);
            ball.GetComponent<BallScript>().ballsQueue = ballsQueue; 
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
            fireSpeed -= 0.05f;
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
    }

    private void PrepareBalls(){
        for (int i = 0; i < maxBalls; i++)
        {
            GameObject ball;
            ball = Instantiate(ballPrefab);
            ball.GetComponent<BallScript>().level = ballLevel;
            ball.SetActive(false);
            ballsQueue.Enqueue(ball);
        }
    }

}
