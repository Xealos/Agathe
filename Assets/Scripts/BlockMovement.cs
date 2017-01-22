using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BlockMovement : MonoBehaviour {

    public Vector2 PlayerInput;
    public Vector2 curPos;
    public float CooldownTime_x;
    public float CooldownTime_y;
    public float MoveTime;

    public enum Direction
    {
        LEFT,
        RIGHT,
        DOWN
    };

    private GridBehavior gridBehavior;
    private SpriteRenderer rend;
    private float lastTimePressed_x;
    private float lastTimePressed_y;
    private float lastMove;
    private List<GameObject> blocks = new List<GameObject>();

    // Use this for initialization
    void Start () {
        rend = GetComponent<SpriteRenderer>();
        lastTimePressed_x = -100.0f;
        lastTimePressed_y = -100.0f;
        lastMove = 0.0f;
        gridBehavior = transform.parent.gameObject.GetComponent<GridBehavior>();
        gridBehavior.SetPosition(4, 0);

        blocks.Add(transform.GetChild(0).gameObject);
        blocks.Add(transform.GetChild(1).gameObject);
        blocks.Add(transform.GetChild(2).gameObject);
        blocks.Add(transform.GetChild(3).gameObject);
    }
	
	// Update is called once per frame
	void Update () {
        bool validMove;
        // Getting left/right input from player
        PlayerInput.x = Input.GetAxis("Horizontal");
        PlayerInput.y = Input.GetAxis("Vertical");

        PlayerInput = new Vector2(PlayerInput.x, PlayerInput.y).normalized; 

        if( PlayerInput.x != 0 
            && Time.time > lastTimePressed_x + CooldownTime_x )
        {
            
            //Pass the block's direction to the grid so that it can track it

            if (PlayerInput.x == 1) {
                validMove = gridBehavior.UpdatePosition(Direction.RIGHT);
            }
            else
            {
                validMove = gridBehavior.UpdatePosition(Direction.LEFT);
            }

            if (validMove)
            {
                // Get block's current position
                curPos = transform.position;

                //Increment position based on the horizontal direction
                curPos.x += PlayerInput.x;

                Debug.Log("Current position is being updated");

                //Update the position of the block by moving it the size of the block 
                transform.position = curPos;

                lastTimePressed_x = Time.time;
            }
        }

        if( PlayerInput.y == -1 
            && Time.time > lastTimePressed_y + CooldownTime_y )
        {
            
            //Pass the block's direction to the grid so that it can track it
            validMove = gridBehavior.UpdatePosition(Direction.DOWN);

            if (validMove)
            {
                // Get block's current position
                curPos = transform.position;

                //Increment position based on the vertical direction 
                curPos.y += PlayerInput.y;

                Debug.Log("Current position is being updated");

                //Update the position of the block by moving it the size of the block 
                transform.position = curPos;

                lastTimePressed_y = Time.time;
            }
        }
        else if( PlayerInput.y == 0 && Time.time > lastMove + MoveTime)
        {

            //TODO: Pass the block's direction to the grid so that it can track it
            validMove = gridBehavior.UpdatePosition(Direction.DOWN);

            if (validMove)
            {
                // Get block's current position
                curPos = transform.position;

                //Decrement position based on the vertical direction 
                curPos.y -= 1;

                Debug.Log("Current position is being updated");

                //Update the position of the block by moving it the size of the block 
                transform.position = curPos;

                lastMove = Time.time;
            }
        }
	}
}
