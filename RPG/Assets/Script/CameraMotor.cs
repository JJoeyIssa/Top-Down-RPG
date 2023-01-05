using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    public Transform lookAt;
    
    //create the bounds where the camera will change
    public float boundX = 0.15f;
    public float boundY = 0.05f;
    
    private void LateUpdate()
    {
        Vector3 delta = Vector3.zero;

        //Check if we're inside the bounds on the X axis
        //get the distance between the center of the camera and the player
        float deltaX = lookAt.position.x - transform.position.x;


        //if distance is greater, player is out of bounds and we have to move the camera
        if(deltaX > boundX || deltaX < -boundX)
        {
            //check if the change is left or right
            if(transform.position.x < lookAt.position.x)
            {
                delta.x = deltaX - boundX;
            }
            else
            {
                delta.x = deltaX + boundX;
            }
        }

        //Check if we're inside the bounds on the Y axis
        //get the distance between the center of the camera and the player
        float deltaY = lookAt.position.y - transform.position.y;


        //if distance is greater, player is out of bounds and we have to move the camera
        if(deltaY > boundY || deltaY < -boundY)
        {
            //check if the change is left or right
            if(transform.position.y < lookAt.position.y)
            {
                delta.y = deltaY - boundY;
            }
            else
            {
                delta.y = deltaY + boundY;
            }
        }

        transform.position += new Vector3(delta.x, delta.y, 0);

    }


}
