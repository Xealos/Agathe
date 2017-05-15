using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject ShapeContainer; /* Our shape container prefab */
    private GridRenderer gridRenderer; 

    //BRP NOTE: You can pause the game by setting Time.timeScale to 0 

	// Use this for initialization
	void Start () {
        //Get the grid reference 
        GameObject grid = GameObject.Find("grid");
        if( grid != null )
        {
            gridRenderer = grid.GetComponent<GridRenderer>(); 
        }
	}
	
	// Update is called once per frame
	void Update () {


        shapeProcessing(); 
        
        //TODO: Row checking 

        //TODO: Score calculation 

        //TODO: Check for Game Over 

	}

    private void shapeProcessing()
    {
        //Get the active shape container 
        GameObject activeShapeContainer = GameObject.Find("ShapeContainer");
        //If we don't have a shape actively on the screen, we need 
        //to create a enw one 
        if (activeShapeContainer == null)
        {
            activeShapeContainer = (GameObject)Instantiate(ShapeContainer);
            ShapeContainer sp = activeShapeContainer.GetComponent<ShapeContainer>();
            //BRP TODO: These are temporary for now, will randomize later 
            sp.ShapePropsSet(ShapeProperties.ShapeType.SHAPE_L, ShapeProperties.ColorType.BLUE);
            //Put it at the top & center of the player's screen 
            activeShapeContainer.transform.position = new Vector2(gridRenderer.MidPoint, gridRenderer.GridHeight);
        }
        else
        {
            //Find the active shape container on the game screen 
            ShapeContainer shapeContainerProperites = activeShapeContainer.GetComponent<ShapeContainer>();

            if (shapeContainerProperites.doneMoving)
            {
                //Get the absolute position of the shape container
                Vector2 containerPostiion = activeShapeContainer.transform.position;
                //Get the offset coordinates of the shape, instantiate block objects in their place 

                //Destroy the shape container 
                GameObject.Destroy(activeShapeContainer);
            }
        }
    }

}
