using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemScript : MonoBehaviour
{
    public UIScript uiScript;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            
            uiScript.IncreaseGemCount();
            Destroy(this.gameObject);

        }
    }
}
