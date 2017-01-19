using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GridBehavior : MonoBehaviour {

    public GameObject Block;
    public int gridHeight;
    public int gridWidth; 

    private SpriteRenderer rend; 
    private Vector2 cellSize;
    
    // Use this for initialization
    void Start ()
    {
        rend = Block.GetComponent<SpriteRenderer>();
        
        //Based on the size of the block object, build a tetris grid 
        //Get the size of our cells
        cellSize = rend.sprite.rect.size;
    }
	
	// Update is called once per frame
	void Update ()
    {

	}

    void SetNewPosition(BlockMovement.Direction direction)
    {

    }
}
