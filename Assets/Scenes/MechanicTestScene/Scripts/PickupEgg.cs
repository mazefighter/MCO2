using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupEgg : MonoBehaviour
{
    private UIScript UI;

    private void Awake()
    {
        UI = GameObject.Find("Canvas").GetComponent<UIScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PickUp"))
        {
            switch (other.gameObject.name)
            {
                case "FireEgg":
                    UI.SetElementSlot(1,other.gameObject);
                    break;
                case "WaterEgg":
                    UI.SetElementSlot(2,other.gameObject);
                    break;
                case "EarthEgg":
                    UI.SetElementSlot(3,other.gameObject);
                    break;
                case "WindEgg":
                    UI.SetElementSlot(0,other.gameObject);
                    break;
            }
        }
    }
}
