using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GridBehavior : MonoBehaviour {

    public GameObject Shape; 

    private SpriteRenderer rend; 
    private Vector2 cellSize;
    private bool[,] Grid;
    private int gridHeight;
    private int gridWidth;
    private Vector2 blockPosition;
    private Transform shapeTransform;
    private List<GameObject> blocks = new List<GameObject>();

    // Use this for initialization
    void Start ()
    {
        //rend = Block.GetComponent<SpriteRenderer>();
        
        //Based on the size of the block object, build a tetris grid 
        //Get the size of our cells
        //cellSize = rend.sprite.rect.size;

        //gridHeight = 22;
        //gridWidth = 10;

        ////Make our grid 
        //Grid = new bool[gridWidth,gridHeight];

    }
	
	// Update is called once per frame
	void Update ()
    {

	}

    //Sets the starting position of the block
    public void SetPosition(int x, int y)
    {

        Grid[x, y] = true;
        blockPosition.x = x;
        blockPosition.y = y;
    }

    //Clear position funciton 
    public void ClearPosition( int x, int y )
    {

    }

    //Boundary check
    public bool isMoveLegal( int x, int y, ShapeBehavior.Direction direction )
    {
        //Calculate requested cell position 

        //Verify requested cell position is within boundaries of game 

        //Verify requested cell position is not colliding with blocks 

        return true; 
    }

    public bool rowCheck( int row )
    {
        //loop through given row and determine if all cells are occupied 

        return true; 
    }

    public void rowClear( int row )
    {
        //clear the given row 
    }

    public void shiftDown( int row )
    {
        //shift all cells that are above the given row down 1 vertically 
    }

    //public bool UpdatePosition(BlockMovement.Direction direction)
    //{
    //    //Check for valid boundary
    //    bool retVal = true;
    //    Vector2 newBlockPos = blockPosition;
    //    switch (direction)
    //    {

    //        case BlockMovement.Direction.LEFT:
    //            foreach (GameObject block in blocks)
    //            {
    //                if (blockPosition.x < 1)
    //                {
    //                    retVal = false;
    //                    newBlockPos.x--;
    //                }
    //            }
    //            break;

    //        case BlockMovement.Direction.RIGHT:
    //            if (blockPosition.x >= 9)
    //            {
    //                retVal = false;
    //                newBlockPos.x++;
    //            }
    //            break;

    //        case BlockMovement.Direction.DOWN:
    //            if (blockPosition.y >= 21)
    //            {
    //                retVal = false;
    //                newBlockPos.y++;
    //            }
    //            break;

    //        default:
    //            break;
    //    }

    //    //Update Position in array based on direction
    //    if(retVal)
    //    {
    //        Grid[(int)blockPosition.x, (int)blockPosition.y] = false;
    //        Grid[(int)newBlockPos.x, (int)newBlockPos.y] = true;

    //        //Update to the new position 
    //        blockPosition = newBlockPos;
    //    }

    //    return retVal;
    //}
}
