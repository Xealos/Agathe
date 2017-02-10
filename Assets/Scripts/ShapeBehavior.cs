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
    //TODO: Consider moving all the timeout/move time funcationality to the 
    //game controller 
    public float CooldownTimeX;
    public float CooldownTimeY;
    public float MoveTime;

    private GameObject grid;
    private GridBehavior gridBehavior;
    private ShapeProperties shapeProp;
    private float lastTimePressedX;
    private float lastTimePressedY;
    private float lastMove;

    public enum Direction
    {
        LEFT,
        RIGHT,
        DOWN,
        NONE
    };

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
	void Update ()
    {
        Vector2 playerInput;
        bool rotate;
        Direction shapeDir = Direction.NONE;

        //Get key inputs
        playerInput.x = Input.GetAxis("Horizontal");
        playerInput.y = Input.GetAxis("Vertical");

        playerInput = new Vector2(playerInput.x, playerInput.y).normalized; 

        //Check for 'rotate' key and rotate the shape
        rotate = Input.GetKeyDown(KeyCode.R);

        //Assign a direction based on the input
        if (playerInput.x == 1)
        {
            shapeDir = Direction.RIGHT; 
        }
        else if (playerInput.x == -1)
        {
            shapeDir = Direction.LEFT; 
        }
        else if (playerInput.y == -1)
        {
            shapeDir = Direction.DOWN; 
        }

        //BRP TODO: See if this logic can be simplified between the player input 
        //and requested direction 
        if( gridBehavior.IsMoveLegal( shapeProp.x_pos, shapeProp.y_pos, shapeDir ) )
        {
            if (playerInput.x != 0
                && Time.time > ( lastTimePressedX + CooldownTimeX ))
            {
                updatePosition( shapeDir );
                lastTimePressedX = Time.time;
            }

            if (playerInput.y == -1
                && Time.time > ( lastTimePressedY + CooldownTimeY ))
            {
                updatePosition( shapeDir );
                lastTimePressedY = Time.time; 
            }

            //BRP TODO: This else if needs to be moved outside the parent if function 
            //because we need to check for a valid DOWN move before trying to 
            //execute this 
            else if (playerInput.y == 0 && Time.time > ( lastMove + MoveTime ))
            {
                updatePosition( Direction.DOWN );
                lastMove = Time.time;
            }
        }
    }

    private void destroyShape()
    {
        //instantiate 4 blocks in the correct positions on grid 

        //destroy the shape object 
    }

    private void setRotation()
    {
        //Ask the grid if this move is within boundaries and doesn't collide with blocks
        
        //Sets the shape's rotation

        //Return FALSE if a collision occurs 
    }

    private void updatePosition( Direction direction )
    {
        Vector2 curPos; 

        // Get block's current position
        curPos = transform.position;

        //Clear the current position on the grid 
        gridBehavior.CellClear( (int)curPos.x, (int)curPos.y );

        //Increment position based on the direction
        if (direction == Direction.RIGHT)
        {
            curPos.x += 1;
        }
        else if (direction == Direction.LEFT )
        {
            curPos.x -= 1; 
        }
        else
        {
            curPos.y -= 1; 
        }

        //Update the position of the block by moving it the size of the block 
        transform.position = curPos;

        //Let the grid know of the new position
        gridBehavior.CellSet( (int)curPos.x, (int)curPos.y );
    }

}
