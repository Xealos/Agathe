using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeBehavior : MonoBehaviour
{
    //TODO: Consider moving all the timeout/move time funcationality to the 
    //game controller 
    public float CooldownTimeX;
    public float CooldownTimeY;
    public float MoveTime;
    public Vector2 StartPos;

    public GameObject Block;
    public ShapeType Shape;
    public ColorType Color;
    public float rotation;

    public enum ShapeType
    {
        Shape_I,
        Shape_J,
        Shape_L,
        Shape_O,
        Shape_S,
        Shape_T,
        Shape_Z
    };

    public enum DirectionType
    {
        LEFT,
        RIGHT,
        DOWN,
        NONE
    };

    public enum ColorType
    {
        BLUE,
        GREEN,
        RED,
        YELLOW
    };

    /* position of each block for each shape */ 
    private static readonly List<int[,]> posList = new List<int[,]>
        {
        new int[4, 2] { { 0, 0 }, { 1, 0 }, { 2, 0 }, { 3, 0 } },   /* I shape positions */ 
        new int[4, 2] { { 0, 0 }, { 1, 0 }, { 1, 1 }, { 1, 2 } },   /* J shape positions */ 
        new int[4, 2] { { 0, 0 }, { 1, 0 }, { 0, 1 }, { 0, 2 } },   /* L shape positions */ 
        new int[4, 2] { { 0, 0 }, { 1, 0 }, { 0, 1 }, { 1, 1 } },   /* O shape positions */ 
        new int[4, 2] { { 0, 0 }, { 1, 0 }, { 1, 1 }, { 2, 1 } },   /* S shape positions */ 
        new int[4, 2] { { 0, 0 }, { 1, 0 }, { 1, 1 }, { 2, 0 } },   /* T shape positions */ 
        new int[4, 2] { { 0, 1 }, { 1, 0 }, { 2, 0 }, { 1, 1 } },   /* Z shape positions */ 
        };

    private GridBehavior gridBehavior;
    private float lastTimePressedX;
    private float lastTimePressedY;
    private float lastMove;

    // Use this for initialization
    void Start ()
    {
        GameObject grid = GameObject.FindWithTag("grid");

        //Get the grid components 
        if ( grid != null )
        {
            gridBehavior = grid.GetComponent<GridBehavior>(); 
        }

        transform.position = StartPos; 
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 playerInput;
        bool rotate;
        DirectionType shapeDir = DirectionType.NONE;

        //Get key inputs
        playerInput.x = Input.GetAxis("Horizontal");
        playerInput.y = Input.GetAxis("Vertical");

        playerInput = new Vector2(playerInput.x, playerInput.y).normalized; 

        //Check for 'rotate' key and rotate the shape
        rotate = Input.GetKeyDown(KeyCode.R);

        //Assign a direction based on the input
        if (playerInput.x == 1)
        {
            shapeDir = DirectionType.RIGHT; 
        }
        else if (playerInput.x == -1)
        {
            shapeDir = DirectionType.LEFT; 
        }
        else if (playerInput.y == -1)
        {
            shapeDir = DirectionType.DOWN; 
        }

        //BRP TODO: See if this logic can be simplified between the player input 
        //and requested direction 
        if (gridBehavior.IsMoveLegal((int)transform.position.x, (int)transform.position.y, shapeDir))
        {
            if (playerInput.x != 0
                && Time.time > (lastTimePressedX + CooldownTimeX))
            {
                updatePosition(shapeDir);
                lastTimePressedX = Time.time;
            }

            if (playerInput.y == -1
                && Time.time > (lastTimePressedY + CooldownTimeY))
            {
                updatePosition(shapeDir);
                lastTimePressedY = Time.time;
            }
        }

        if (playerInput.y == 0 && Time.time > (lastMove + MoveTime)
            && gridBehavior.IsMoveLegal((int)transform.position.x, (int)transform.position.y, DirectionType.DOWN))
        {
            updatePosition(DirectionType.DOWN);
            lastMove = Time.time;
        }
    }

    public void RenderShape(ShapeType Shape)
    {
        int[,] shape = posList[(int)Shape];

        /* Instantiate the four blocks */

    }

    private void destroyShape()
    {
        //instantiate 4 blocks in the correct positions on grid 

        //Destroy the shape 
        Destroy(gameObject);
    }

    private void setRotation()
    {
        //Ask the grid if this move is within boundaries and doesn't collide with blocks
        
        //Sets the shape's rotation

        //Return FALSE if a collision occurs 
    }

    private void updatePosition( DirectionType direction )
    {
        Vector2 curPos; 

        // Get block's current position
        curPos = transform.position;

        //Clear the current position on the grid 
        gridBehavior.CellClear( (int)curPos.x, (int)curPos.y );

        //Increment position based on the DirectionType
        if (direction  == DirectionType.RIGHT)
        {
            curPos.x += 1;
        }
        else if (direction == DirectionType.LEFT )
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
