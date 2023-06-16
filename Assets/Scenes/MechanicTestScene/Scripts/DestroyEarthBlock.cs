using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEarthBlock : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyEarth()
    {
        StartCoroutine(DestroyTimer());
    }

    IEnumerator DestroyTimer()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }
}
