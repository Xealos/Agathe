using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GridBehavior : MonoBehaviour {

    public GameObject ControlBlock; 

    private SpriteRenderer rend; 
    private Vector2 cellSize;
    private bool[,] Grid;
    private int gridHeight;
    private int gridWidth;
    private Vector2 blockPosition;

    // Use this for initialization
    void Start ()
    {
        //rend = Block.GetComponent<SpriteRenderer>();
        
        //Based on the size of the block object, build a tetris grid 
        //Get the size of our cells
        //cellSize = rend.sprite.rect.size;

        gridHeight = 22;
        gridWidth = 10;

        Grid = new bool[gridWidth,gridHeight];

        GameObject childBlock = (GameObject)Instantiate(ControlBlock);
        childBlock.transform.parent = transform; 
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

    public bool UpdatePosition(BlockMovement.Direction direction)
    {
        //Check for valid boundary
        bool retVal = false;
        Vector2 newBlockPos = blockPosition;
        switch (direction)
        {
            case BlockMovement.Direction.LEFT:
                if(blockPosition.x >= 1)
                {
                    retVal = true;
                    newBlockPos.x--;
                }
                break;

            case BlockMovement.Direction.RIGHT:
                if (blockPosition.x < 9)
                {
                    retVal = true;
                    newBlockPos.x++;
                }
                break;

            case BlockMovement.Direction.DOWN:
                if (blockPosition.y < 21)
                {
                    retVal = true;
                    newBlockPos.y++;
                }
                break;

            default:
                break;
        }

        //Update Position in array based on direction
        if(retVal)
        {
            Grid[(int)blockPosition.x, (int)blockPosition.y] = false;
            Grid[(int)newBlockPos.x, (int)newBlockPos.y] = true;

            //Update to the new position 
            blockPosition = newBlockPos;
        }

        return retVal;
    }
}
