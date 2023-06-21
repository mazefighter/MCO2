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
        TriggerTorch,
        TriggerWall
    }

   private bool dissolving = false;
   [SerializeField] private Type _type;
   [SerializeField] private GameObject CrystalToTrigger;
   [SerializeField] private Material _material;
   [SerializeField] private List<Material> _materials;

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

            if (gameObject.GetComponent<AscendPlayer>() != null)
            {
                gameObject.GetComponent<AscendPlayer>().Burning = true;
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
                CrystalToTrigger.SetActive(true);
            }
        }
        if (_type == Type.TriggerWall)
        {
            
            foreach (Transform trans in transform)
            {
                if (trans.gameObject.name == "Flames")
                { 
                    trans.gameObject.SetActive(true);
                }
            }
            StartCoroutine(Dissolve());
            StartCoroutine(BurnDownWithActivate());
            
        }
    }

    IEnumerator BurnDown()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }

    IEnumerator BurnDownWithActivate()
    {
        yield return new WaitForSeconds(3);
        CrystalToTrigger.SetActive(true);
        Destroy(gameObject);
    }

    #region DissolveRegion
    
    private IEnumerator Dissolve()
    {
        var comp = GetComponentsInChildren<MeshRenderer>(false);
        foreach (var c in comp)
        {
            float percent = 0;
            while (percent < 1)
            {
                percent += Time.fixedTime / 3f;
                for (int i = 0; i < c.materials.Length; i++)
                {
                    if (!dissolving)
                    {
                        _materials.Insert(i, _material);
                    }
                    _materials[i].SetFloat("_dissolveShaderFloat", Time.fixedTime / 1.5f);
                }
                dissolving = true;
                c.materials = _materials.ToArray();
            }
        }
        yield return null;
    }
    #endregion
}
