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

        if (collider.gameObject.CompareTag("Tomb"))
        {
            GameObject lantern = GameObject.Find("Laternen");
            foreach (Transform trans in lantern.transform)
            {
                foreach (Transform trans2 in trans.transform)
                {
                    trans2.gameObject.SetActive(true);
                }
            }
            Destroy(collider.gameObject);
        }
    }
}
