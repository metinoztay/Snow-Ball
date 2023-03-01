using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ComboCounter : MonoBehaviour
{

    [SerializeField] private CoinsManager CoinsManager;
    [SerializeField] private GameObject comboPrefab;
    [SerializeField] float destroyComboTextTime;
    [SerializeField] private Transform comboParent;
    [SerializeField] Image comboFillImage;
    [SerializeField] private float resetTime;

    float combo=0;
    private float resetSpeed;
    private int _comboCount;
    public int comboCount
    {
        get { return _comboCount; }
        set { _comboCount = value; 
            if (comboCount == 0)
            {
                CollectCoin();
            }
        }
    }
    
    void Start()
    {
        comboCount = 0;
        resetSpeed = 1f / resetTime;
    }

    void Update()
    {
        ComboCountDown();
    }

    public void ShowCombo(Transform snowBall){
        comboCount++;
        combo = 1;
        if (comboCount == 0 || comboCount == 1)
        {
            return;
        }
        var comboObject = Instantiate(comboPrefab,snowBall.position,snowBall.rotation,comboParent);
        comboObject.GetComponentInChildren<TextMeshProUGUI>().text = "x" + comboCount.ToString();
        Destroy(comboObject,destroyComboTextTime);
    }

    private void ComboCountDown(){
        
        
        if (combo > 0)
        {
            combo -= resetSpeed*Time.deltaTime; 
        }
        else if (combo == 0)
        {
            CollectCoin();            
        }

        /*
        if (comboFillImage.fillAmount > 0)
        {
            comboFillImage.fillAmount -= resetSpeed*Time.deltaTime; 
        }
        else if (comboFillImage.fillAmount == 0)
        {
            CollectCoin();
            
        }*/
    }

    public void CollectCoin(){
        if (comboCount > 1)
        {
            CoinsManager.AddCoins(comboParent.position,comboCount);
            comboCount = 0;
        }       
    }


}
