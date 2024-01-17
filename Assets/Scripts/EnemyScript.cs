using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public EnemyAI enemy;

    public int damage = 10;
    public Vector3 shift = new Vector3(0, 10, 0);


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
            enemy.TakeDamage(damage);
        }
        else if(other.tag == "Surface")
        {
            transform.position = transform.position - shift;
        }

    }

    
}
