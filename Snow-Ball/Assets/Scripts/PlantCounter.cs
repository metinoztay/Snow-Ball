using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantCounter : MonoBehaviour
{
    [SerializeField] public int plantCount;
    [SerializeField] public int maxPlantCount;

   private void Awake() {
        plantCount = 0;
   }
}
