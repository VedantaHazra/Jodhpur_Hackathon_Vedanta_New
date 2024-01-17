using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class Swimmer : MonoBehaviour
{
    [Header("Values")]
    public float swimForce = 2f;
    public float dragForce = 1f;
    public float minForce;
    public float minTimeBetweenStrokes;

    [Header("Referenes")]
    public InputActionReference leftContollerSwimReference;
    public InputActionReference leftControllerVelocity;
    public InputActionReference rightContollerSwimReference;
    public InputActionReference rightControllerVelocity;

    public Transform trackingReference;

    Rigidbody _rigidbody;
    CharacterController characterController;
    float _cooldownTimer;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.useGravity = true;
        _rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        characterController = GetComponent<CharacterController>();
        characterController.enabled = false;
        //_rigidbody.isKinematic = false;
    }

    private void FixedUpdate()
    {
        _cooldownTimer += Time.fixedDeltaTime;
        if(_cooldownTimer > minTimeBetweenStrokes && leftContollerSwimReference.action.IsPressed() && rightContollerSwimReference.action.IsPressed())
        {
            var leftHandVelocity = leftControllerVelocity.action.ReadValue<Vector3>();
            var rightHandVelocity = rightControllerVelocity.action.ReadValue<Vector3>();
            Vector3 localVelocity = leftHandVelocity + rightHandVelocity;
            localVelocity *= -1;

            if(localVelocity.sqrMagnitude > minForce)
            {
                Vector3 worldVelocity = trackingReference.TransformDirection(localVelocity);
                _rigidbody.AddForce(worldVelocity * swimForce, ForceMode.Acceleration);
            }
        }

        if(_rigidbody.velocity.sqrMagnitude > 0.01f)
        {
            _rigidbody.AddForce(- _rigidbody.velocity * dragForce, ForceMode.Acceleration);
        }
    }

   private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Surface")
        {
            //_rigidbody.isKinematic = true;
            _rigidbody.useGravity = false;
            characterController.enabled = false;
            Debug.Log("Underwater");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Surface")
        {
            _rigidbody.useGravity = true;
            characterController.enabled = true;
            // _rigidbody.isKinematic = false;
            Debug.Log("Above Water");
        }
    }
}
