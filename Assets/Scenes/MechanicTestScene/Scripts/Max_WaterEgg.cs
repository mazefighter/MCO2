using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Max_WaterEgg : Max_Egg
{
    public override void ExecuteEffect(Collider collider)
    {
        if (collider.gameObject.CompareTag("Barrel"))
        {
            BarrelScript barrel = collider.gameObject.GetComponent<BarrelScript>();
            barrel.BarrelEffect();
        }
        print("sploosh");
    }
}
