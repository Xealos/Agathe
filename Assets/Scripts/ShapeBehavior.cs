using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeBehavior : MonoBehaviour {

    public enum Direction
    {
        LEFT,
        RIGHT,
        DOWN,
        NONE
    };

    //private variables to hold shape type, rotation, and position? 

    // Use this for initialization
    void Start () {

        //initialize the kind of shape we're going to be

        //initialize the rotation 

        //initialize the position 
		
        //based on the kind of shape we are, we know what 4 cells we are occupying 
	}
	
	// Update is called once per frame
	void Update () {

        Vector2 PlayerInput;
        bool rotate;
        Direction shapeDir = Direction.NONE; 

        //Get key inputs
        PlayerInput.x = Input.GetAxis("Horizontal");
        PlayerInput.y = Input.GetAxis("Vertical");

        PlayerInput = new Vector2(PlayerInput.x, PlayerInput.y).normalized; 

        //Check for 'rotate' key and rotate the shape
        rotate = Input.GetKeyDown(KeyCode.R);

        //Assign a direction based on the input
        if( PlayerInput.x == 1 )
        {
            shapeDir = Direction.RIGHT; 
        }
        else if( PlayerInput.x == -1 )
        {
            shapeDir = Direction.LEFT; 
        }
        else if( PlayerInput.y == -1 )
        {
            shapeDir = Direction.DOWN; 
        }

        //If a collision occurs during any of the above input processing, call the destroy shape function 

        //On timeout, move the shape down 1 row BY FORCE 
    }

    private void setRotation()
    {
        //Ask the grid if this move is within boundaries and doesn't collide with blocks

        //Sets the shape's rotation

        //Return FALSE if a collision occurs 
    }

    private void setPosition()
    {
        //Ask the grid if this move is within boundaries and doesn't collide with blocks  

        //Sets the shape's position 
    }

    private void destroyShape()
    {
        //instantiate 4 blocks in the correct positions on grid 

        //destroy the shape object 
    } 

}
