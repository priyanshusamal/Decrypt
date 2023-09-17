using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    //Player Movement
    //I recommend 7 for the move speed, and 1.2 for the force damping
    [Header("Movements")]
    public Rigidbody rb;
    public float moveSpeed;
    public Vector3 forceToApply;
    public Vector3 PlayerInput;
    public Vector3 PlayerLook;
    public float rotationSpeed;
    public float forceDamping;
    public float jumpforce = 100f;
    public bool jumping;
    public bool punching;
    public bool punchTime;

    //Player Device Jump
    [SerializeField] GameObject keyboardPosition;
    [SerializeField] GameObject MonitorPosition;

    [SerializeField] dg_simpleCamFollow cameraFollowScript;
    
    public bool OnKeyboard = true;

    Animator anim;
    [Header("Post-Processing")]
    public GameObject postProcessing;
    public GameObject spotLights1;
    public GameObject spotLights2;
    public GameObject SFX;
    public GameObject SFXPosition;

    [Header("Raycast")]
    public float buffer = 1f;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(1).IsName("Punch") && anim.GetCurrentAnimatorStateInfo(1).normalizedTime > 1f)
        {
            anim.SetBool("Punch", false);
            punching = false;
            punchTime = false;
        }
        //Input
        if (OnKeyboard)
        {
            PlayerInput = new Vector3(-Input.GetAxisRaw("Vertical"), 0, Input.GetAxisRaw("Horizontal")).normalized;
            PlayerLook = new Vector3(-Input.GetAxisRaw("Vertical"), 0, Input.GetAxisRaw("Horizontal")).normalized;
        }
            
        else
        {
            PlayerInput = new Vector3(0, Input.GetAxisRaw("Vertical"), Input.GetAxisRaw("Horizontal")).normalized;
            PlayerLook = new Vector3(-Input.GetAxisRaw("Vertical"), 0, Input.GetAxisRaw("Horizontal")).normalized;
            //transform.rotation = Quaternion.Euler(PlayerLook.x, PlayerLook.y, -90);
        }

        //Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(!jumping && OnKeyboard)
            {
                jumping = true;
                anim.SetBool("Jump", jumping);
                rb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
                //rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
            }
    
        }
        ChangeDeviceJump();

        if (Input.GetMouseButtonDown(1))
        {
            PunchAnimation();
        }
        RaycastHit hit;
        Debug.DrawRay(transform.position,transform.TransformDirection(-Vector3.up)* buffer,Color.blue);
        if(Physics.Raycast(transform.position,-Vector3.up,out hit, buffer))
        {
            if(Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("Hello world!");
                if(hit.transform.gameObject.GetComponent<Key>() != null){
                    hit.transform.gameObject.GetComponent<Key>().Pressed();
                    Debug.Log(hit.transform.gameObject.GetComponent<Key>().getdata());
                }
                // hit.transform.gameObject.GetComponent<Key>().Pressed();
                // hit.transform.gameObject.GetComponent<Key>().pressable=false;
            }
        }
        //RotationFreeze
        //rb.constraints = RigidbodyConstraints.FreezeRotation;
    }
    void FixedUpdate()
    {
        //movement
        Vector3 moveForce = PlayerInput * moveSpeed;

        //rotation
        if (PlayerInput != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(PlayerLook, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
            
        moveForce += forceToApply;
        forceToApply /= forceDamping;
        if (Mathf.Abs(forceToApply.x) <= 0.01f && Mathf.Abs(forceToApply.y) <= 0.01f)
        {
            forceToApply = Vector3.zero;
        }
        if(!jumping)
        {
            //rb.constraints = RigidbodyConstraints.None;
            //rb.constraints = RigidbodyConstraints.FreezePositionZ;
            rb.velocity = moveForce;
            if (PlayerInput != Vector3.zero)
            {
                anim.SetBool("Run", true);
                anim.SetBool("Punch", false);
                punching = false;
                punchTime = false;
            }
                
            else
                anim.SetBool("Run", false);
        }
           
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider)
        {
            //forceToApply += new Vector3(-20, 0);
            //Destroy(collision.gameObject);
            jumping = false;
            anim.SetBool("Jump", jumping);
        }
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("PopUp"))
        {
            if (punching)
            {
                if(punchTime)
                    collision.gameObject.SetActive(false);
            }
                
            //forceToApply += new Vector3(-20, 0);
            //Destroy(collision.gameObject);

        }
    }
    public void ChangeDeviceJump()
    {
        //Screen Jump
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            if(OnKeyboard)
            {
                OnKeyboard = false;
                transform.position = MonitorPosition.transform.position;               
                cameraFollowScript.generalOffset = new Vector3(8, 0, 0);
                rb.useGravity = false;
                postProcessing.SetActive(false);
                spotLights1.SetActive(false);
                spotLights2.SetActive(false);
            }
            else
            {
                OnKeyboard = true;
                transform.position = keyboardPosition.transform.position;                
                cameraFollowScript.generalOffset = new Vector3(5, 8, 0);
                rb.useGravity = true;
                postProcessing.SetActive(true);
                spotLights1.SetActive(true);
                spotLights2.SetActive(true); 
            }
            
            
        }
    }
    public void PunchAnimation()
    {
        anim.SetLayerWeight(1, 1);
        anim.SetBool("Punch", true);
        punching = true;
    }
    public void PunchMechanic()
    {
        punchTime = true;
        Instantiate(SFX, SFXPosition.transform.position, Quaternion.identity);
    }
}