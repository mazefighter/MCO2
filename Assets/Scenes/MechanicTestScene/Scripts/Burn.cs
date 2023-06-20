using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

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
   [SerializeField] private bool BurnBitch = false;
   private int allMats;


   private void Awake()
   {
       allMats = 0;
   }

   private void Update()
   {
       StartDissolve();
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
            StartCoroutine(Dissolve());
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
        Destroy(gameObject);
    }

    #region DissolveRegion

    

    private void StartDissolve()
    {
        if (BurnBitch)
        {
            StartCoroutine(Dissolve());
        }
    }

    private IEnumerator Dissolve()
    {
        var comp = GetComponentsInChildren<MeshRenderer>(false);
        float percent = 0;
        while (percent < 1)
        {
            percent += Time.time / 3f;
            foreach (var c in comp)
            {
                while (allMats < c.materials.Length)
                {
                    c.materials[allMats] = _material;
                    c.materials[allMats].SetFloat("_dissolveShaderFloat", Time.time / 3f);
                    allMats++;
                }
            }
        }
        yield return null;
    }
    
    private IEnumerator OldDissolve()
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
    #endregion
}
