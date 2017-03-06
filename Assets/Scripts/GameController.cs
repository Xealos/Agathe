using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject ShapeContainer; /* Our shape container prefab */

    private GameObject newShape; 

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        //If we don't have a shape actively on the screen, we need 
        //to create a enw one 
        if (GameObject.Find("Shape Container") == null)
        {
            newShape = (GameObject)Instantiate(ShapeContainer);

            //BRP TODO: Set the shape properties of the container
            //TBA TODO: Come up with a way to randomly select a shape  
        }
        
        //If a shape is not active  
            //Check for changes to the grid 
            //If the grid has changed, check to see if any rows can be cleared and the board updated 
            //Instantiate the next shape in the queue 

        //TODO: Check for Game Over 

	}

}
