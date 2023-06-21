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
<<<<<<< Updated upstream
            Ascend();
=======
            Player.GetComponent<Rigidbody>().AddForce(0,1500,0);
            Burning = false;
>>>>>>> Stashed changes
        }
    }

    void Ascend()
    {
        Player.GetComponent<Rigidbody>().AddForce(0,2,0);
    }
}
