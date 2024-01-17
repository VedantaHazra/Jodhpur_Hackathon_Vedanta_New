using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public int health = 100;
    public UIScript uiScript;
    public float Timer = 200;
    private float timer;
  //CharacterController characterController;
//  Rigidbody _rigidbody;
  //public Swimmer swimmer;

 /*private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        characterController.enabled = false;
        swimmer.enabled = false;
        _rigidbody = GetComponent<Rigidbody>();
    }*/
    void Start()
    {
        uiScript.SetHealth(health);
        timer = Timer;
       
       //wimmer = GetComponent<Swimmer>();
       


    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {

        health -= damage;
        uiScript.SetHealth(health);
        if (health <= 0) 
        {
            SceneManager.LoadScene(
                SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer = timer - Time.deltaTime;

        }
        else if (timer < 0)
        {
            timer = 0;
            TakeDamage(health);
        }

        uiScript.SetTimer(timer);
    }

    public void UpdateTimer()
    {
      
        timer = Timer;
        uiScript.SetTimer(timer);

    }


  

    private void OnTriggerEnter(Collider other)
    {
      /*if (other.tag == "Surface")
        {
            //_rigidbody.isKinematic = true;
            _rigidbody.useGravity = false;
            characterController.enabled = false;
            swimmer.enabled = true;
        }*/

        if (other.tag == "SceneChange")
        {
            TakeDamage(health);
        }
    }
 /*private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Surface")
        {
            _rigidbody.useGravity = true;
            characterController.enabled = true;
            // _rigidbody.isKinematic = false;
            swimmer.enabled = false;
        }
    }*/
}
