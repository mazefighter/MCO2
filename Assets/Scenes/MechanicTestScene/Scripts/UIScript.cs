using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    [SerializeField]private GameObject[] ElementSlots = new GameObject[4];
    void Start()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Canvas");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        foreach (Transform trans in transform)
        {
            switch (trans.gameObject.name)
            {
                case "FireEquipped":
                    if (ElementSlots[1] != null)
                    {
                        trans.gameObject.SetActive(true);
                    }
                    break;
                case "WaterEquipped":
                    if (ElementSlots[2] != null)
                    {
                        trans.gameObject.SetActive(true);
                    }
                    break;
                case "EarthEquipped":
                    if (ElementSlots[3] != null)
                    {
                        trans.gameObject.SetActive(true);
                    }
                    break;
                case "WindEquipped":
                    if (ElementSlots[0] != null)
                    {
                        trans.gameObject.SetActive(true);
                    }
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetElementSlot(int slot, GameObject content)
    {
        ElementSlots[slot] = content;
        foreach (Transform trans in transform)
        {
            switch (trans.gameObject.name)
            {
                case "FireEquipped":
                    if (ElementSlots[1] != null)
                    {
                        trans.gameObject.SetActive(true);
                        ElementSlots[1] = trans.gameObject;
                    }
                    break;
                case "WaterEquipped":
                    if (ElementSlots[2] != null)
                    {
                        trans.gameObject.SetActive(true);
                        ElementSlots[2] = trans.gameObject;
                    }
                    break;
                case "EarthEquipped":
                    if (ElementSlots[3] != null)
                    {
                        trans.gameObject.SetActive(true);
                        ElementSlots[3] = trans.gameObject;
                    }
                    break;
                case "WindEquipped":
                    if (ElementSlots[0] != null)
                    {
                        trans.gameObject.SetActive(true);
                        ElementSlots[0] = trans.gameObject;
                    }
                    break;
            }
        }
    }
    public GameObject GetElementSlot(int slot)
    {
        return ElementSlots[slot];
    }
}
