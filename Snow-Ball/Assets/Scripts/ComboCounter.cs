using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ComboCounter : MonoBehaviour
{
    [SerializeField] private CoinsManager CoinsManager;
    [SerializeField] GameObject comboPrefab;

    [SerializeField] Transform comboBar;
    [SerializeField] RectTransform particalParent;
    [SerializeField] Image circleImage;
    [SerializeField] TMP_Text comboText;
    [SerializeField] [Range(0,1)] float comboTimer;

    [SerializeField] float resetTime;

    private int _comboCount;
    public int comboCount
    {
        get { return _comboCount; }
        set { 
                _comboCount = value; 
                ComboTextChange();
            }
    }
    

    float resetSpeed;
    private void Start() {
        resetSpeed = 1f / resetTime;
        comboCount = 0;
    }
    void Update()
    {
        ComboCountDown();
    }

 
    private void ComboCountDown(){
        
        if (circleImage.fillAmount > 0)
        {
            circleImage.fillAmount -= resetSpeed*Time.deltaTime;
            particalParent.rotation = Quaternion.Euler(new Vector3(0f,0f,-circleImage.fillAmount*360));
        }
        else if (circleImage.fillAmount == 0 && comboCount > 0)
        {
            ResetCombo();
        }
    }

    private void ComboTextChange(){
            if (comboCount==0 || comboCount == 1){
                comboText.text = string.Empty;
            }
            else{
                comboText.text = "x"+comboCount.ToString();
            }
    }

        public void ShowCombo(Transform snowBall){
        comboCount++;
        circleImage.fillAmount = 1f;
        if (comboCount == 0 || comboCount == 1)
        {
            return;
        }
        var comboObject = Instantiate(comboPrefab,snowBall.position,snowBall.rotation,comboBar);
        comboObject.GetComponentInChildren<TextMeshProUGUI>().text = "x" + comboCount.ToString();
        Destroy(comboObject,0.8f);
    }

    private void CollectCoin(){
        if (comboCount > 1)
        {
            CoinsManager.AddCoins(comboBar.position,comboCount);
        }       
    }

    public void ResetCombo(){
        CollectCoin();
        comboCount = 0;
        comboText.text = string.Empty;
        circleImage.fillAmount = 0;
    }
 


}
