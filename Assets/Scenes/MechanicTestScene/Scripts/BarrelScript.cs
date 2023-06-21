using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelScript : WaterLevelManager
{
    [SerializeField] private GameObject BarrelWater;
    public void BarrelEffect()
    {
        BarrelWater.SetActive(true);
        BarrelFilled();
    }
}
