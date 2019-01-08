using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCamera : MonoBehaviour {

    public Transform playercam;
    public Vector3 cam;//store the location of the camera xyz
    public Vector3 cameraOffset;
	
	// Update is called once per frame
	void Update () {

        //this tells the object with  this script its postion on run time.
        //it is set to the player's postion then "cam" which is an offset so it is not first person
        cameraOffset = playercam.position + cam;

        //this will freeze the tranform postion on the camera on the x-axis
        //this freezes the postion to 0 <-- important
        cameraOffset.x = 0;

        //this pretty much creates a legger to modify or restrict
        transform.position = cameraOffset;
        

    }
}
