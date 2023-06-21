using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class WaterManagerScript : MonoBehaviour
{
    /*Qick and dirty coding, a result from deadline pressure*/
    
    [SerializeField] private Transform _target;
    [SerializeField] private GameObject hideSceneLoad;
    [SerializeField] private GameObject _barricade;
    private float speed = 1f;
    [SerializeField] private int barrelInt; 
    private int _maxBarrelInt = 4;
    private bool stoneCollided;

    private void Update()
    {
        if (stoneCollided)
        {
            var step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, _target.position, step);
            hideSceneLoad.SetActive(false);
        }
        
        if (barrelInt == _maxBarrelInt)
        {
            Destroy(_barricade);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("WaterStone"))
        {
            Debug.Log("Man over Board!");
            stoneCollided = true;
        }
    }

    public void FilledBarrels(int amount)
    {
        barrelInt += amount;
    }
}
