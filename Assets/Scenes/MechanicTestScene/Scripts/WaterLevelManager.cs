using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterLevelManager : MonoBehaviour
{
    [SerializeField] private int _barrel; 
    private int _maxBarrel = 4;
    [SerializeField] private GameObject _barricade;
    public bool getBarrel;

    private void Update()
    {
        OpenBarricade();
        
        /*if (getBarrel)
        {
            BarrelFilled();
            getBarrel = false;
        }*/
    }

    public void BarrelFilled()
    {
        _barrel =+ 1;
        Debug.Log("yeah");
    }

    void OpenBarricade()
    {
        if (_barrel == _maxBarrel)
        {
            Destroy(_barricade);
        }
    }
}
