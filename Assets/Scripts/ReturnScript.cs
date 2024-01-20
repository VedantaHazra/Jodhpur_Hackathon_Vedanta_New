using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnScript : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 pos = new Vector3(-86f, -2.89f, -43f);

    public GameObject gun;
    public Transform spawnPoint;
    public void Return()
    {
        playerTransform.position = pos;
    }

    public void InstantiateGun()
    {
        Instantiate(gun, spawnPoint.position, Quaternion.identity);
    }
}
