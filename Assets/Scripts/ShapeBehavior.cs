using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeProperties
{
    public int x_pos;
    public int y_pos;
    public int rotation;
    public int type; 
}

public class ShapeBehavior : MonoBehaviour
{
    private GameObject grid;
    private GridBehavior gridBehavior;
    private ShapeProperties shapeProp;
    private float lastTimePressed_x;
    private float lastTimePressed_y;

    public enum Direction
    {
        LEFT,
        RIGHT,
        DOWN,
        NONE
    };

    //private variables to hold shape type, rotation, and position? 

    // Use this for initialization
    void Start ()
    {

        grid = GameObject.FindWithTag("grid");

        //Get the grid components 
        if ( grid != null )
        {
            gridBehavior = grid.GetComponent<GridBehavior>(); 
        }

        shapeProp = new ShapeProperties(); 

        //initialize the kind of shape we're going to be
        shapeProp.type = 0;

        //initialize the rotation 
        shapeProp.rotation = 0;

        //initialize the position 
        shapeProp.x_pos = 5;
        shapeProp.y_pos = 0; 

	}
	
	// Update is called once per frame
	void Update () {

        Vector2 playerInput;
        Vector2 curPos; 
        bool rotate;
        Direction shapeDir = Direction.NONE;

        //Get key inputs
        playerInput.x = Input.GetAxis("Horizontal");
        playerInput.y = Input.GetAxis("Vertical");

        playerInput = new Vector2(playerInput.x, playerInput.y).normalized; 

        //Check for 'rotate' key and rotate the shape
        rotate = Input.GetKeyDown(KeyCode.R);

        //Assign a direction based on the input
        if(playerInput.x == 1)
        {
            shapeDir = Direction.RIGHT; 
        }
        else if(playerInput.x == -1)
        {
            shapeDir = Direction.LEFT; 
        }
        else if(playerInput.y == -1)
        {
            shapeDir = Direction.DOWN; 
        }

        //If a collision occurs during any of the above input processing, call the destroy shape function 
        if( gridBehavior.isMoveLegal( shapeProp.x_pos, shapeProp.y_pos, shapeDir ) )
        {
            // Get block's current position
            curPos = transform.position;

            //Increment position
            curPos.x += playerInput.x;
            curPos.y += playerInput.y;

            //Update the position of the block by moving it the size of the block 
            transform.position = curPos;
        }
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
