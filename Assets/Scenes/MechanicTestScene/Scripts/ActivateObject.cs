using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObject : MonoBehaviour
{
    [SerializeField] private GameObject nextCrystal;
    [SerializeField] private GameObject gate;

    private void Awake()
    {
        StartCoroutine(Activate());
    }
    
    
    IEnumerator Activate()
    {
        yield return new WaitForSeconds(1);
        nextCrystal.SetActive(true);
            if (gate != null)
            {
                gate.SetActive(false);
            }
    }
}
