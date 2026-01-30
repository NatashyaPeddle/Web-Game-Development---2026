using KBCore.Refs;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(CharacterController))]
public class PlayerInput : MonoBehaviour
{

    private InputAction move;
    private InputAction look;
    [SerializeField, Self] private CharacterController controller;
    [SerializeField] private float maxSpeed = 10.0f;
    [SerializeField] private float gravity = -30.0f;
    [SerializeField] private float rotationSpeed = 4.0f;
    [SerializeField, Child] private Camera cam;
    [SerializeField] private float mouseSensY = 5.0f;

    private Vector3 velocity;



    private void OnValidate()
    {
        this.ValidateRefs();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        move = InputSystem.actions.FindAction("Player/Move");
        look = InputSystem.actions.FindAction("Player/Look");

   
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 readMove = move.ReadValue<Vector2>();
        Vector2 readLook = look.ReadValue<Vector2>();

        ///movement of player
        Vector3 movement = transform.right * readMove.x + transform.up * readMove.y;


        //controller.Move(movement * maxSpeed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        movement *= maxSpeed * Time.deltaTime;
        movement += velocity;
        controller.Move(movement);

        ///rotation of player
        transform.Rotate(Vector3.up, readLook.x * rotationSpeed * Time.deltaTime);

        //rotate camera
        mouseSensY = mouseSensY * readLook.y;
        mouseSensY = Mathf.Clamp(mouseSensY, -90f, 90f);
        cam.gameObject.transform.localRotation = Quaternion.Euler(mouseSensY * readLook.y, 0, 0);
    }
}
