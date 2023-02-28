using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ComboCounter : MonoBehaviour
{
    [SerializeField] private GameObject comboPrefab;
    [SerializeField] float destroyComboTextTime;

    [SerializeField] private Transform comboParent;

    private int _cc;
    public int comboCount
    {
        get { return _cc; }
        set { _cc = value; 
        }
    }
    
    void Start()
    {
        comboCount = 0;
    }

    void Update()
    {
        
    }

    public void ShowCombo(Transform snowBall){
        comboCount++;
        if (comboCount == 0 || comboCount == 1)
        {
            return;
        }
        var comboObject = Instantiate(comboPrefab,snowBall.position,snowBall.rotation,comboParent);
        comboObject.GetComponentInChildren<TextMeshProUGUI>().text = "x" + comboCount.ToString();
        Destroy(comboObject,destroyComboTextTime);
    }
}
