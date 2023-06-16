using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burn : MonoBehaviour
{

    enum Type
    {
        BurnDown,
        DontBurnDown
    }

   [SerializeField] private Type _type;

    private void Awake()
    {
        
    }

    public void Burning()
    {
        if (_type == Type.BurnDown)
        {
            foreach (Transform trans in transform)
            {
                if (trans.gameObject.name == "Flames")
                { 
                    trans.gameObject.SetActive(true);
                }
            }
            StartCoroutine(BurnDown());
        }

        if (_type == Type.DontBurnDown)
        {
            foreach (Transform trans in transform)
            {
                if (trans.gameObject.name == "Flames")
                {
                    if (trans.gameObject.activeSelf == false)
                    {
                        trans.gameObject.SetActive(true);
                    }
                }
            }
        }
    }

    IEnumerator BurnDown()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
    
}
