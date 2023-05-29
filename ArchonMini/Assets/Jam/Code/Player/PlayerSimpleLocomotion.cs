using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jam
{
    public class PlayerSimpleLocomotion : MonoBehaviour
    {
        [SerializeField] float moveSpeed = 1f;


        Rigidbody rb;
        Transform playerMesh;
        PlayerInputHandler inputHandler;


        void Awake()
        {
            rb = GetComponent<Rigidbody>();
            playerMesh = GetComponentInChildren<Transform>();
            inputHandler = GetComponent<PlayerInputHandler>();
        }


        void FixedUpdate()
        {
            rb.MovePosition(rb.position + moveSpeed * Time.fixedDeltaTime * inputHandler.moveVector);
            //Quaternion rotationAngle = Mathf.atan2(normalizedVector.y, normalizedVector.x)
            if(inputHandler.moveVector != Vector3.zero)
                rb.MoveRotation(Quaternion.LookRotation(inputHandler.moveVector));
        }


    }

}
