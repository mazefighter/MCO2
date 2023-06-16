using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleMove : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;

    [SerializeField] private Material[] matArr = new Material[4];
    private void OnEnable()
    {
        Max_Egg.EggExplode += Max_EggOnEggExplode;
    }

    private void OnDisable()
    {
        Max_Egg.EggExplode -= Max_EggOnEggExplode;
    }

    private void Max_EggOnEggExplode(Vector3 position, int element)
    {
        transform.position = position;
        switch (element)
        {
            case 1:
                _particleSystem.GetComponent<Renderer>().material = matArr[0];
                break;
            case 2:
                _particleSystem.GetComponent<Renderer>().material = matArr[1];
                break;
            case 3:
                _particleSystem.GetComponent<Renderer>().material = matArr[2];
                break;
            case 4:
                _particleSystem.GetComponent<Renderer>().material = matArr[3];
                break;
        }
        _particleSystem.Emit(100);
    }
}
