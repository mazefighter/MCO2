using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Max_WindEgg : Max_Egg
{
    public override void ExecuteEffect(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            collider.gameObject.GetComponent<Rigidbody>().AddForce(0,550,0);
        }
        if (collider.gameObject.CompareTag("Wind"))
        {
            Wind wind = collider.gameObject.GetComponent<Wind>();
            wind.Windy();
        }
    }
}
