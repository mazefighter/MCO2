using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Max_Egg : MonoBehaviour
{
    
    public int Seconds => _seconds;

    public float MaxRadius => maxRadius;

    public int _seconds = 3;
    public float maxRadius = 5;

    private SpawnEggOfElement eggSpawn;

    public delegate void MoveHere(Vector3 position, int element);

    public static event MoveHere EggExplode;
    

    [SerializeField] private int _color;

    private void Awake()
    {
        eggSpawn = GameObject.Find("Player").GetComponent<SpawnEggOfElement>();
    }

    public void TriggerEffekt()
    {
        StartCoroutine(Effect());
    }

    IEnumerator Effect()
    {
        yield return new WaitForSeconds(Seconds);
        eggSpawn._spawnEgg = true;
        EffectRadius(transform.position, maxRadius);
        EggExplode?.Invoke(transform.position,_color);
        Destroy(gameObject);
    }

    public void EffectRadius(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        foreach (Collider _collider in hitColliders)
        {
            ExecuteEffect(_collider);
        }
    }

    public abstract void ExecuteEffect(Collider collider);

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, maxRadius);
    }
}
