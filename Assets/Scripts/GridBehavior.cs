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

        gridHeight = 22;
        gridWidth = 10;

        Grid = new bool[gridWidth,gridHeight];

        GameObject childBlock = (GameObject)Instantiate(Shape);
        childBlock.transform.parent = transform;

        //Getting the transform of the shape
        shapeTransform = transform.GetChild(0).GetComponent<Transform>();

        //Getting the blocks of the shape
        blocks.Add(shapeTransform.GetChild(0).gameObject);
        blocks.Add(shapeTransform.GetChild(1).gameObject);
        blocks.Add(shapeTransform.GetChild(2).gameObject);
        blocks.Add(shapeTransform.GetChild(3).gameObject);
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
        bool retVal = true;
        Vector2 newBlockPos = blockPosition;
        switch (direction)
        {
            
            case BlockMovement.Direction.LEFT:
                foreach (GameObject block in blocks)
                {
                    if (blockPosition.x < 1)
                    {
                        retVal = false;
                        newBlockPos.x--;
                    }
                }
                break;

            case BlockMovement.Direction.RIGHT:
                if (blockPosition.x >= 9)
                {
                    retVal = false;
                    newBlockPos.x++;
                }
                break;

            case BlockMovement.Direction.DOWN:
                if (blockPosition.y >= 21)
                {
                    retVal = false;
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
