using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class player : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private RaycastHit2D hit;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        //Look at keybord inputs to move character
        float x = Input.GetAxisRaw("Horizontal");
        // -1 -> left, 0 -> nothing, 1 -> right
        float y = Input.GetAxisRaw("Vertical");
        // -1 -> Down, 0 -> nothing, 1 -> up
       
        //reset MoveDelta 
        moveDelta = new Vector3(x,y,0);

        //Swap sprite direction wether you are going right or left
        if (moveDelta.x > 0)
            transform.localScale = Vector3.one;
        else if (moveDelta.x < 0)
            transform.localScale = new Vector3(-1,1,1);
        //If we are on zero it means me arenot moving on x


        //Add Collision, make sure we can move in this direction by casting a box there. If box returns null we are allowed to move
        hit = Physics2D.BoxCast(transform.position,boxCollider.size, 0, new Vector2(0,moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor","Blocking"));
        //if no hit on box collider, we are allowed to move
        if(hit.collider == null) 
        {
            //make the object move
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }
    

        //Do the same thing for x
        //Add Collision, make sure we can move in this direction by casting a box there. If box returns null we are allowed to move
        hit = Physics2D.BoxCast(transform.position,boxCollider.size, 0, new Vector2(moveDelta.x,0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor","Blocking"));
        //if no hit on box collider, we are allowed to move
        if(hit.collider == null) 
        {
            //make the object move
            transform.Translate(moveDelta.x * Time.deltaTime,0, 0);
        }

    }
}
