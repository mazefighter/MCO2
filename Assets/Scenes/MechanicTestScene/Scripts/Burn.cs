using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burn : MonoBehaviour
{

    enum Type
    {
        BurnDown,
        DontBurnDown,
        Torch,
        TriggerTorch
    }

   [SerializeField] private Type _type;
   [SerializeField] private ActivateObject _activ;
   [SerializeField] private Material _material;

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
        if (_type == Type.Torch)
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
        if (_type == Type.TriggerTorch)
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
                _activ.OnMaker();
            }
        }
    }

    IEnumerator BurnDown()
    {
        yield return new WaitForSeconds(3);
        StartCoroutine(Dissolve());
        Destroy(gameObject);
    }
    
    private IEnumerator Dissolve()
    {
        var comp = GetComponentsInChildren<MeshRenderer>(false);
        float percent = 0;
        while (percent < 1)
        {
            percent += Time.time / 1.5f;
            foreach (var c in comp)
            {
                c.material = _material;
                c.material.SetFloat("_dissolveShaderFloat", Time.time / 1.5f );
            }
        }
        yield return null;
    }
}
