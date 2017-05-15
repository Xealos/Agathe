using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeContainer : MonoBehaviour {

    public GameObject block;
    public bool doneMoving = false;
    private ShapeProperties shapeProps; 

    //TBA TODO: Put the list of coordinates for each shape here, make them private. 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShapePropsSet( ShapeProperties.ShapeType shape, ShapeProperties.ColorType color )
    {
        shapeProps.Shape = shape; 
        shapeProps.Color = color; 
    }

    public int[,] ShapeCoordsGet()
    {
        //TBA TODO: Return the current coordinates of the shape
        //temp value 
        return new int[0, 0];
    }
}
