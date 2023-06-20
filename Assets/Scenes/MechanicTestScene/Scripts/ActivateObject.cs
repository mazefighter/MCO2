using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObject : MonoBehaviour
{
    [SerializeField] private GameObject currentCrystal;
    [SerializeField] private GameObject nextCrystal;
    [SerializeField] private GameObject gate;

    private void Awake()
    {
        currentCrystal.SetActive(false);
        gate.SetActive(true);
    }

    public void OnMaker()
    {
        StartCoroutine(Activate());
    }
    
    IEnumerator Activate()
    {
        yield return new WaitForSeconds(1);
        if (!currentCrystal)
        {
            currentCrystal.SetActive(true);
            nextCrystal.SetActive(true);
        }
        else
        {
            nextCrystal.SetActive(true);
            gate.SetActive(false);
        }
        
    }
}
