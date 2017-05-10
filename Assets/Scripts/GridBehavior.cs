using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GridBehavior : MonoBehaviour {

    private bool[,] gridArray;
    private int gridHeight;
    private int gridWidth;
    private GameObject grid;
    private GridRenderer gridRenderer; 

    // Use this for initialization
    void Start ()
    {
        grid = GameObject.FindWithTag("grid");

        //Get the grid components 
        if (grid != null)
        {
            gridRenderer = grid.GetComponent<GridRenderer>();
        }

        //Get the height and width from the renderer and copy 
        //it locally 
        gridHeight = gridRenderer.GridHeight;
        gridWidth = gridRenderer.GridWidth;
        
        //Build an array to monitor cell positions based on 
        //the size of the grid built by the renderer
        gridArray = new bool[gridWidth, gridHeight];
    }

    //Sets the starting position of the block
    public void CellSet(int x, int y)
    {
        gridArray[x, y] = true;
    }

    //Clear position function 
    public void CellClear( int x, int y )
    {
        gridArray[x, y] = false;
    }

    //Boundary check
    public bool IsMoveLegal( int x, int y, ShapeBehavior.DirectionType direction )
    {
        int xNext = x, yNext = y;

        //Calculate requested cell position 
        switch(direction)
        {
            case ShapeBehavior.DirectionType.DOWN:
                xNext = x;
                yNext = y - 1;
                break;

            case ShapeBehavior.DirectionType.LEFT:
                xNext = x - 1;
                yNext = y;
                break;

            case ShapeBehavior.DirectionType.RIGHT:
                xNext = x + 1;
                yNext = y;
                break;

            default:
            // No direction
                return false;
        }

        //Verify requested cell position is within boundaries of game 
        if (xNext >= gridWidth
            || xNext < 0
            || yNext >= gridHeight
            || yNext < 0)
        {
            return false;
        }

        //Verify requested cell position is not colliding with blocks 
        if (gridArray[xNext, yNext])
        {
            return false;
        }

        return true; 
    }

    public bool RowCheck( int row )
    {
        //loop through given row and determine if all cells are occupied 
        for(int currentColumn = 0; currentColumn < gridWidth; currentColumn++)
        {
            //If the space is empty
            if(!gridArray[row, currentColumn])
            {
                //Row is not full
                return false;
            }
        }

        //Row is full
        return true; 
    }

    public void RowClear( int row )
    {
        //clear the given row 
        for (int currentColumn = 0; currentColumn < gridWidth; currentColumn++)
        {
            //Set current space to empty
            gridArray[row, currentColumn] = true;
        }
    }

    public void ShiftDown(int row)
    {
        //shift all cells that are above the given row down 1 vertically 
        for (int currentColumn = 0; currentColumn < gridWidth; currentColumn++)
        {
            //If the row is not at the bottom
            if (row != 0)
            {
                //If the current position is occupied...
                if (gridArray[row, currentColumn]) {
                    //Move it down one
                    gridArray[row - 1, currentColumn] = false;
                    gridArray[row - 1, currentColumn] = true;
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
