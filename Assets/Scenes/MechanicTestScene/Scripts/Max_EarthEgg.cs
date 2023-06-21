using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Max_EarthEgg : Max_Egg
{
    [SerializeField] private GameObject EarthBlock;
    private bool spawned;
    public override void ExecuteEffect(Collider collider)
    {
        if (!spawned)
        {
           GameObject Block = Instantiate(EarthBlock,  new Vector3(transform.position.x,transform.position.y + 0.65f, transform.position.z) , Quaternion.Euler(0,180,0));
           Block.GetComponent<DestroyEarthBlock>().DestroyEarth();
            spawned = true;
        }
        
    }
}
