using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeBehavior : MonoBehaviour {

    public enum Direction
    {
        LEFT,
        RIGHT,
        DOWN
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

        //Monitor for key inputs 

        //Check for 'rotate' key and rotate the shape
        
        //Check for 'movement' keys and move the shape 

        //If a collision occurs during any of the above input processing, call the destroy shape function 
		
        //On timeout, move the shape down 1 row BY FORCE 
	}

    private void SetRotation()
    {
        //Ask the grid if this move is within boundaries and doesn't collide with blocks

        //Sets the shape's rotation

        //Return FALSE if a collision occurs 
    }

    private void SetPosition()
    {
        //Ask the grid if this move is within boundaries and doesn't collide with blocks  

        //Sets the shape's position 
    }

    private void DestroyShape()
    {
        //instantiate 4 blocks in the correct positions on grid 

        //destroy the shape object 
    } 

}
