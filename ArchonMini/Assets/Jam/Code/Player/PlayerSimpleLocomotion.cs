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


        void Update()
        {
            Vector3 myPosition = rb.position;
            rb.MovePosition(myPosition + (moveSpeed * Time.deltaTime) * inputHandler.i_moveVector);
        }


    }

}
