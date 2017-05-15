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

    public ShapeType Shape;
    public ColorType Color;
    public int Rotation;
    public int[,] Coordinates;  
    
}
