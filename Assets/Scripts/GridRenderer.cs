using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridRenderer : MonoBehaviour {

    public GameObject CellSprite;
    public int GridHeight;
    public int GridWidth;
    public int MidPoint; 

	// Use this for initialization
	void Start () {

        //Create the grid by instantiating cells 
        createGrid();

        //Set the 'middle' point of the grid so we don't have to 
        //do the math operation for each new shape we make 
        MidPoint = (GridWidth / 2);
	}
	
    private void createGrid()
    {
        //Instantiate new game cells based on the given width and height
        for( int x = 0; x < GridWidth; x++ )
        {
            for( int y = GridHeight; y >= 0; y-- )
            {
                GameObject newCell = Instantiate(CellSprite, new Vector2(x, y), Quaternion.identity);
                newCell.transform.parent = gameObject.transform; 
            }
        }
    }
}
