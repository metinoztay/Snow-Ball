using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSnowController : MonoBehaviour
{
    [SerializeField] private List<GameObject> groundSnowPoints;
    

    private void Awake() {
        foreach (var groundSnowPoint in GameObject.FindGameObjectsWithTag("GroundSnowPoint"))
        {
            groundSnowPoints.Add(groundSnowPoint);
        }        
    }    

    private int _s;
    public int snowedFields
    {
        get { return _s; }
        set { _s = value; 
            GroundControl();
        }
    }
    

    private void Start() {
        snowedFields = 0;
    }

    private void GroundControl(){
        bool isSnowed;
        foreach (var field in groundSnowPoints)
        {
            isSnowed = field.GetComponent<GroundSnowScript>().isSnowed;
            
            if (!isSnowed)
            {
                return;
            }
        }

        GameManager.Instance.UpdateGameState(GameManager.GameState.Lose);
    }
}
