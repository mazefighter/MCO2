using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    [SerializeField]private GameObject[] ElementSlots = new GameObject[4];
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetElementSlot(int slot, GameObject content)
    {
        
    }
    public GameObject GetElementSlot(int slot)
    {
        return ElementSlots[slot];
    }
}
