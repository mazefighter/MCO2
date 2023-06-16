using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggController : MonoBehaviour
{
    private Vector3 _input;
    [SerializeField] private Rigidbody _rigidBody;
    [SerializeField] private List<Material> _material;
    [SerializeField] private GameObject Egg;
     private Rigidbody PlayerBody;
     private float _speed = 200;
     public int button;
     public int element;

     private void Awake()
     {
         PlayerBody = GameObject.Find("Player").GetComponent<Rigidbody>();
     }

     private void Start()
     {
         switch (element)
         {
                 case 1:
                 Egg.GetComponent<MeshRenderer>().material = _material[0];
                 break;
             case 2:
                 Egg.GetComponent<MeshRenderer>().material = _material[1];
                 break;
             case 3:
                 Egg.GetComponent<MeshRenderer>().material = _material[2];
                 break;
             case 4:
                 Egg.GetComponent<MeshRenderer>().material = _material[3];
                 break;
         }
     }

     // Update is called once per frame
    void Update()
    {
        GatherInput();

        if (Input.GetKeyUp(KeyCode.JoystickButton0) && button == 0)
        {
            DropEgg();
        }
        if (Input.GetKeyUp(KeyCode.JoystickButton1) && button == 1)
        {
            DropEgg();
        }
        if (Input.GetKeyUp(KeyCode.JoystickButton2) && button == 2)
        {
            DropEgg();
        }
        if (Input.GetKeyUp(KeyCode.JoystickButton3) && button == 3)
        {
            DropEgg();
        }
    }

    void DropEgg()
    {
        PlayerBody.constraints = RigidbodyConstraints.None;
        Egg.transform.SetParent(Egg.transform.parent.parent);
        switch (element)
        {
            case 1:
                Egg.GetComponent<Max_FireEgg>().TriggerEffekt();
                break;
            case 2:
                Egg.GetComponent<Max_WaterEgg>().TriggerEffekt();
                break;
            case 3:
                Egg.GetComponent<Max_EarthEgg>().TriggerEffekt();
                break;
            case 4:
                Egg.GetComponent<Max_WindEgg>().TriggerEffekt();
                break;
        }
            
        Destroy(gameObject);
    }
    private void FixedUpdate() {
        MoveController();
    }

    public void GatherInput()
    {
        _input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }
    
    
    private void MoveController()
    {
        _rigidBody.velocity = _input.ToIso() * (_speed * Time.deltaTime);
    }
}
