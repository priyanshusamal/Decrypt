using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDevice : MonoBehaviour
{
    [SerializeField] dg_simpleCamFollow cameraFollowScript;
    [SerializeField] PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeCameraPosition()
    {
        if(playerMovement.OnKeyboard)
            cameraFollowScript.generalOffset = new Vector3(1, 12, 0);
        else
            cameraFollowScript.generalOffset = new Vector3(18, 0, 0);
    }
}
