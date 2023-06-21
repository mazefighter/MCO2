using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
   [SerializeField] private bool TriggerWind;
   [SerializeField] private GameObject Bridge;
   private float duration = 30;
   private float elapsedTime;
   private bool Trigger;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Trigger)
        {
            elapsedTime += Time.deltaTime;
            float percentageComplete = elapsedTime / duration;
            
            Bridge.transform.position = Vector3.Lerp(Bridge.transform.position, new Vector3(13.43f, 0.46f, 32.81f), percentageComplete);
        }
    }

    public void Windy()
    {
        gameObject.GetComponent<Animator>().SetTrigger("Wind");
        if (TriggerWind)
        {
            Bridge.SetActive(true);
            Trigger = true;
        }
    }
    
}
