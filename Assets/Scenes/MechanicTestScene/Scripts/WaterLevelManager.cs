using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterLevelManager : MonoBehaviour
{
    [SerializeField] private int _barrel; 
    private int _maxBarrel = 4;
    [SerializeField] private GameObject _barricade;

    private void Update()
    {
        OpenBarricade();
    }

    public void BarrelFilled()
    {
        _barrel++;
    }

    void OpenBarricade()
    {
        if (_barrel == _maxBarrel)
        {
            Destroy(_barricade);
        }
    }
}
