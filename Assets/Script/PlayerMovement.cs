using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Player Movement
    //I recommend 7 for the move speed, and 1.2 for the force damping
    public Rigidbody rb;
    public float moveSpeed;
    public Vector3 forceToApply;
    public Vector3 PlayerInput;
    public Vector3 PlayerLook;
    public float rotationSpeed;
    public float forceDamping;
    [Header("Raycast")]
    public float buffer = 1f;

    //Player Device Jump
    [SerializeField] GameObject keyboardPosition;
    [SerializeField] GameObject MonitorPosition;

    [SerializeField] dg_simpleCamFollow cameraFollowScript;

    public bool OnKeyboard = true;

    void Update()
    {

        PlayerInput = new Vector3(-Input.GetAxisRaw("Vertical"), 0, Input.GetAxisRaw("Horizontal")).normalized;
        PlayerLook = new Vector3(Input.GetAxisRaw("Horizontal"),0, Input.GetAxisRaw("Vertical")).normalized;
        Vector3 dir = -Vector3.up;
        // Ray theRay = new Ray(transform.position,transform.TransformDirection(dir*buffer));
        RaycastHit hit;
        Debug.DrawRay(transform.position,transform.TransformDirection(-Vector3.up)* buffer,Color.blue);
        if(Physics.Raycast(transform.position,-Vector3.up,out hit, buffer))
        {
            if(Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("Hello world!");
                hit.transform.gameObject.GetComponent<Key>().Pressed();
                Debug.Log(hit.transform.gameObject.GetComponent<Key>().getdata());
                // hit.transform.gameObject.GetComponent<Key>().pressable=false;
            }
        }
            
    }
    void FixedUpdate()
    {
        Vector3 moveForce = PlayerInput * moveSpeed;
        if (PlayerInput != Vector3.zero)
        {
            Quaternion toRotation;
            if (OnKeyboard)
                toRotation = Quaternion.LookRotation(PlayerLook, Vector3.up);
            else
                toRotation = Quaternion.LookRotation(PlayerLook, Vector3.right);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
            
        moveForce += forceToApply;
        forceToApply /= forceDamping;
        if (Mathf.Abs(forceToApply.x) <= 0.01f && Mathf.Abs(forceToApply.y) <= 0.01f)
        {
            forceToApply = Vector3.zero;
        }
        rb.velocity = moveForce;
    }





}