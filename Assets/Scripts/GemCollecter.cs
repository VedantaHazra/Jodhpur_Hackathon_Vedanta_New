using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GemCollecter : MonoBehaviour
{
    public UIScript uiScript;

    public void Start()
    {
      
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "gem")
        {
            Destroy(other.gameObject);
            uiScript.IncreaseGemCount();

        }
    }
}
