using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeContainer : MonoBehaviour {

    public GameObject block;
    public bool doneMoving = false;
    private ShapeProperties shapeProps;

    private int[,] tracker;


    //TBA TODO: Put the list of coordinates for each shape here, make them private. 

    // I SHAPE

    private List<int[,]> IShapePosition = new List<int[,]>
    {
        new int[4, 4] {
            {0, 0, 1, 0},
            {0, 0, 1, 0},
            {0, 0, 1, 0},
            {0, 0, 1, 0}
        },
        new int[4, 4] {
            {0, 0, 0, 0},
            {0, 0, 0, 0},
            {1, 1, 1, 1},
            {0, 0, 0, 0}
        },
        new int[4, 4] {
            {0, 1, 0, 0},
            {0, 1, 0, 0},
            {0, 1, 0, 0},
            {0, 1, 0, 0}
        },
        new int[4, 4] {
            {0, 0, 0, 0},
            {1, 1, 1, 1},
            {0, 0, 0, 0},
            {0, 0, 0, 0}
        }
    };

    // J SHAPE

    private List<int[,]> JShapePosition = new List<int[,]>
    {
        new int[4, 4] {
            {0, 0, 1, 0},
            {0, 0, 1, 0},
            {0, 1, 1, 0},
            {0, 0, 0, 0}
        },
        new int[4, 4] {
            {0, 1, 0, 0},
            {0, 1, 1, 1},
            {0, 0, 0, 0},
            {0, 0, 0, 0}
        },
        new int[4, 4] {
            {0, 0, 1, 1},
            {0, 0, 1, 0},
            {0, 0, 1, 0},
            {0, 0, 0, 0}
        },
        new int[4, 4] {
            {0, 1, 1, 1},
            {0, 0, 0, 1},
            {0, 0, 0, 0},
            {0, 0, 0, 0}
        }
    };

    // L SHAPE

    private List<int[,]> LShapePosition = new List<int[,]>
    {
        new int[4, 4] {
            {0, 1, 0, 0},
            {0, 1, 0, 0},
            {0, 1, 1, 0},
            {0, 0, 0, 0}
        },
        new int[4, 4] {
            {0, 0, 0, 0},
            {1, 1, 1, 0},
            {1, 0, 0, 0},
            {0, 0, 0, 0}
        },
        new int[4, 4] {
            {1, 1, 0, 0},
            {0, 1, 0, 0},
            {0, 1, 0, 0},
            {0, 0, 0, 0}
        },
        new int[4, 4] {
            {0, 0, 1, 0},
            {1, 1, 1, 0},
            {0, 0, 0, 0},
            {0, 0, 0, 0}
        }
    };

    // O SHAPE

    private List<int[,]> OShapePosition = new List < int[,] >
    {
        new int[4, 4] {
            {0, 1, 1, 0},
            {0, 1, 1, 0},
            {0, 0, 0, 0},
            {0, 0, 0, 0}
        },
        new int[4, 4] {
            {0, 1, 1, 0},
            {0, 1, 1, 0},
            {0, 0, 0, 0},
            {0, 0, 0, 0}
        },
        new int[4, 4] {
            {0, 1, 1, 0},
            {0, 1, 1, 0},
            {0, 0, 0, 0},
            {0, 0, 0, 0}
        },
        new int[4, 4] {
            {0, 1, 1, 0},
            {0, 1, 1, 0},
            {0, 0, 0, 0},
            {0, 0, 0, 0}
        }
    };

    // S SHAPE

    private List<int[,]> SShapePosition = new List<int[,]>
    {
        new int[4, 4] {
            {0, 1, 1, 0},
            {1, 1, 0, 0},
            {0, 0, 0, 0},
            {0, 0, 0, 0}
        },
        new int[4, 4] {
            {0, 1, 0, 0},
            {0, 1, 1, 0},
            {0, 0, 1, 0},
            {0, 0, 0, 0}
        },
        new int[4, 4] {
            {0, 0, 0, 0},
            {0, 1, 1, 0},
            {1, 1, 0, 0},
            {0, 0, 0, 0}
        },
        new int[4, 4] {
            {1, 0, 0, 0},
            {1, 1, 0, 0},
            {0, 1, 0, 0},
            {0, 0, 0, 0}
        }
    };

    // T SHAPE

    private List<int[,]> TShapePosition = new List<int[,]>
    {
        new int[4, 4] {
            {0, 1, 0, 0},
            {1, 1, 1, 0},
            {0, 0, 0, 0},
            {0, 0, 0, 0}
        },
        new int[4, 4] {
            {0, 1, 0, 0},
            {0, 1, 1, 0},
            {0, 1, 0, 0},
            {0, 0, 0, 0}
        },
        new int[4, 4] {
            {0, 0, 0, 0},
            {1, 1, 1, 0},
            {0, 1, 0, 0},
            {0, 0, 0, 0}
        },
        new int[4, 4] {
            {0, 1, 0, 0},
            {1, 1, 0, 0},
            {0, 1, 0, 0},
            {0, 0, 0, 0}
        }
    };

    // Z SHAPE

    private List<int[,]> ZShapePosition = new List<int[,]>
    {
        new int[4, 4] {
            {1, 1, 0, 0},
            {0, 1, 1, 0},
            {0, 0, 0, 0},
            {0, 0, 0, 0}
        },
        new int[4, 4] {
            {0, 0, 1, 0},
            {0, 1, 1, 0},
            {0, 1, 0, 0},
            {0, 0, 0, 0}
        },
        new int[4, 4] {
            {0, 0, 0, 0},
            {1, 1, 0, 0},
            {0, 1, 1, 0},
            {0, 0, 0, 0}
        },
        new int[4, 4] {
            {0, 1, 0, 0},
            {1, 1, 0, 0},
            {1, 0, 0, 0},
            {0, 0, 0, 0}
        }
    };

    // Use this for initialization
    void Start () {
        tracker = new int[4, 4];

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
