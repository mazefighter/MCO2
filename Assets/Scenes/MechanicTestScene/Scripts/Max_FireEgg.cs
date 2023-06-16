using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Max_FireEgg : Max_Egg
{

    public override void ExecuteEffect(Collider _collider)
    {
        if (_collider.gameObject.CompareTag("Burn"))
        {
            Burn burnable = _collider.gameObject.GetComponent<Burn>();
             burnable.Burning();
        }
        
    }
}
