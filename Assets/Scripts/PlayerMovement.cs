using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 4;

    [SerializeField]
    private Animator _animator;

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = Input.GetAxis("Horizontal") * transform.right + Input.GetAxis("Vertical") * transform.forward;
        Vector3 currentMovement = movement.normalized;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentMovement *= 2;
        }
        transform.position += currentMovement * movementSpeed * Time.deltaTime;

        //walking left
        if(Input.GetKey(KeyCode.A))
        {
            _animator.SetInteger("direction", -1);
        } else if(Input.GetKey(KeyCode.D))
        {
            _animator.SetInteger("direction", 1);
        } else {
            _animator.SetInteger("direction", 0);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            _animator.SetTrigger("Fight Pose");
        } else if (Input.GetKey(KeyCode.F))
        {
            _animator.SetTrigger("idle");
        }

        if (Input.GetKey(KeyCode.E))
        {
            _animator.SetTrigger("Punch");
        }

        if (Input.GetKey(KeyCode.Mouse1))
        {
            _animator.SetTrigger("Gun Pose");
        }

        if (Input.GetKey(KeyCode.Mouse2))
        {
            _animator.SetTrigger("Shoot");
        }

        _animator.SetFloat("speed", currentMovement.magnitude);
    }
}
