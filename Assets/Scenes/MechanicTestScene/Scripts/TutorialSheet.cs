using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSheet : MonoBehaviour
{
    [SerializeField] private GameObject _TutorialSheet;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton5))
        {
            _TutorialSheet.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.JoystickButton5))
        {
            _TutorialSheet.SetActive(false);
        }

        if (_TutorialSheet.activeSelf)
        {
            GameObject.Find("Player").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
        else
        {
            GameObject.Find("Player").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
    }
}
