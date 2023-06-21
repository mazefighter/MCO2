using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AscendPlayer : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    public bool Burning;
    void Start()
    {
        
        
    }

    private void Update()
    {
        if (Burning)
        {
            Player.GetComponent<Rigidbody>().AddForce(0,1400,0);
            Burning = false;
        }
    }
    
}
