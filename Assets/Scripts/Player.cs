using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] float mouseSensitivity = 3f;
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float mass = 1f;
    [SerializeField] Transform camaraTransform;

    CharacterController characterController;
    Vector3 velocity;
    Vector2 look;

    public GameOverController gameovercontroller;
    public GameObject gameover;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();

        gameover = GameObject.FindWithTag("Game Over");
        gameovercontroller = gameover.GetComponent<GameOverController>();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        UpdateLook();
        UpdateMovement();
        UpdateGravity();
    }

    void UpdateGravity()
    {
        var gravity = Physics.gravity * mass * Time.deltaTime;
        velocity.y = characterController.isGrounded ? -1f : velocity.y + gravity.y;
    }

    void UpdateLook()
    {
        look.x += Input.GetAxis("Mouse X") * mouseSensitivity;
        look.y += Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Prevents vertical camera movement from breaking the player's neck
        look.y = Mathf.Clamp(look.y, -89f, 89f);

        camaraTransform.localRotation = Quaternion.Euler(-look.y, 0, 0);
        transform.localRotation = Quaternion.Euler(0, look.x, 0);
    }

    void UpdateMovement()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        var input = new Vector3();
        input += transform.forward * y;
        input += transform.right * x;
        
        // Prevents diagonal movement from being faster
        input = Vector3.ClampMagnitude(input, 1f);

        characterController.Move((input * movementSpeed + velocity) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy Weapon"))
        {
            gameovercontroller.ShowGameOver("�MORISTE!");
        }
    }
}
