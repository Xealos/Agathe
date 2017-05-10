using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeProperties : MonoBehaviour {
    
    public enum ShapeType
    {
        SHAPE_I,
        SHAPE_J,
        SHAPE_L,
        SHAPE_O,
        SHAPE_S, 
        SHAPE_T,
        SHAPE_Z
    }

    public enum ColorType
    {
        BLUE,
        GREEN, 
        RED, 
        YELLOW
    }

    public GameObject Block; 
    public ShapeType Shape;
    public ColorType Color;
    public float rotation;  

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setShapePosition(ShapeType Shape)
    {

    }
    
}
