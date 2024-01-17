using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenCylinderScript : MonoBehaviour
{
    public PlayerScript playerScript;

    private void OnTriggerEnter(Collider other)
    {
       

        if (other.tag == "Left Hand")
        {
            playerScript.UpdateTimer();
        }
    }
}
