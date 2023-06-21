using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSheet : MonoBehaviour
{
    [SerializeField] private GameObject _TutorialSheet;
    [SerializeField] private Rigidbody Player;
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
            Player.constraints = RigidbodyConstraints.FreezeAll;
        }
        else
        {
            Player.constraints = RigidbodyConstraints.None;
        }
    }
}
