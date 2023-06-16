using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SpawnEggOfElement : MonoBehaviour
{
    [SerializeField] private UIScript UI;
    [SerializeField] private GameObject EggHinge;
    [SerializeField] private Rigidbody PlayerBody;
    [SerializeField] private Transform SpawnPosition;

    public bool _spawnEgg = true;
    private float timer;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton0)&& _spawnEgg)
        {
            if (UI.GetElementSlot(0) != null)
            {
                SpawnEgg(0);
                
            }
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton1)&& _spawnEgg)
        {
            if (UI.GetElementSlot(1) != null)
            {
                SpawnEgg(1);
            }
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton2)&& _spawnEgg)
        {
            if (UI.GetElementSlot(2) != null)
            {
                SpawnEgg(2);
            }
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton3)&& _spawnEgg)
        {
            if (UI.GetElementSlot(3) != null)
            {
                SpawnEgg(3);
            }
        }
    }

    void SpawnEgg(int btn)
    {
        PlayerBody.constraints = RigidbodyConstraints.FreezeAll;
        GameObject EggInstance = Instantiate(EggHinge, SpawnPosition.position, Quaternion.identity);
        switch (UI.GetElementSlot(btn).name)
        {
            case "FireEquipped":
                EggInstance.GetComponent<EggController>().element = 1;
                break;
            case "WaterEquipped":
                EggInstance.GetComponent<EggController>().element = 2;
                break;
            case "EarthEquipped":
                EggInstance.GetComponent<EggController>().element = 3;
                break;
            case "WindEquipped":
                EggInstance.GetComponent<EggController>().element = 4;
                break;
        }
        
        EggInstance.GetComponent<EggController>().button = btn;
        _spawnEgg = false;
    }
}
