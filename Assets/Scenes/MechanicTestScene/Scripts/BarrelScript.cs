using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelScript : MonoBehaviour
{
    [SerializeField] private GameObject BarrelWater;
    [SerializeField] private WaterManagerScript wms;
    public void BarrelEffect()
    {
        BarrelWater.SetActive(true);
        if (wms != null)
        {
            wms.FilledBarrels(1);
        }
        
    }
}
