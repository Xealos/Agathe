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
        //Grid = new bool[gridWidth, gridHeight];

    }

    //Sets the starting position of the block
    public void SetPosition(int x, int y)
    {

        Grid[x, y] = true;
        blockPosition.x = x;
        blockPosition.y = y;
    }

    //Clear position function 
    public void ClearPosition( int x, int y )
    {
        Grid[x, y] = true;
    }

    //Boundary check
    public bool isMoveLegal( int x, int y, ShapeBehavior.Direction direction )
    {
        int xNext = x, yNext = y;

        //Calculate requested cell position 
        switch(direction)
        {
            case ShapeBehavior.Direction.DOWN:
                xNext = x;
                yNext = y - 1;
                break;

            case ShapeBehavior.Direction.LEFT:
                xNext = x - 1;
                yNext = y;
                break;

            case ShapeBehavior.Direction.RIGHT:
                xNext = x + 1;
                yNext = y;
                break;
        }

        //Verify requested cell position is within boundaries of game 
        if (xNext >= gridWidth - 1
            && xNext < 0 
            && yNext >= gridHeight - 1 
            && yNext < 0)
        {
            return false;
        }

        //Verify requested cell position is not colliding with blocks 
        if(!Grid[xNext, yNext])
        {
            return false;
        }

        return true; 
    }

    public bool rowCheck( int row )
    {
        //loop through given row and determine if all cells are occupied 
        for(int currentColumn = 0; currentColumn < gridWidth; currentColumn++)
        {
            //If the space is empty
            if(!Grid[row, currentColumn])
            {
                //Row is not full
                return false;
            }
        }

        //Row is full
        return true; 
    }

    public void rowClear( int row )
    {
        //clear the given row 
        for (int currentColumn = 0; currentColumn < gridWidth; currentColumn++)
        {
            //Set current space to empty
            Grid[row, currentColumn] = true;
        }
    }

    public void shiftDown(int row)
    {
        //shift all cells that are above the given row down 1 vertically 
        for (int currentColumn = 0; currentColumn < gridWidth; currentColumn++)
        {
            //If the row is not at the bottom
            if (row != 0)
            {
                //If the current position is occupied...
                if (Grid[row, currentColumn]) {
                    //Move it down one
                    Grid[row - 1, currentColumn] = false;
                    Grid[row - 1, currentColumn] = true;
                }
            }
        }
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
