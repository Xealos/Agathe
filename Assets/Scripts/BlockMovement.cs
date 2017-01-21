using UnityEngine;
using System.Collections;

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

    private SpriteRenderer rend;
    private float lastTimePressed_x;
    private float lastTimePressed_y;
    private float lastMove;

	// Use this for initialization
	void Start () {
        rend = GetComponent<SpriteRenderer>();
        lastTimePressed_x = -100.0f;
        lastTimePressed_y = -100.0f;
        lastMove = 0.0f;
    }
	
	// Update is called once per frame
	void Update () {
        // Getting left/right input from player
        PlayerInput.x = Input.GetAxis("Horizontal");
        PlayerInput.y = Input.GetAxis("Vertical");

        PlayerInput = new Vector2(PlayerInput.x, PlayerInput.y).normalized; 

        if( PlayerInput.x != 0 
            && Time.time > lastTimePressed_x + CooldownTime_x )
        {
            // Get block's current position
            curPos = transform.position;

            //TODO: Pass the block's direction to the grid so that it can track it

            //Increment position based on the horizontal direction 
            curPos.x += PlayerInput.x;

            Debug.Log("Current position is being updated");

            //Update the position of the block by moving it the size of the block 
            transform.position = curPos;

            lastTimePressed_x = Time.time; 
        }

        if( PlayerInput.y == -1 
            && Time.time > lastTimePressed_y + CooldownTime_y )
        {
            // Get block's current position
            curPos = transform.position;

            //TODO: Pass the block's direction to the grid so that it can track it

            //Increment position based on the vertical direction 
            curPos.y += PlayerInput.y;

            Debug.Log("Current position is being updated");

            //Update the position of the block by moving it the size of the block 
            transform.position = curPos;

            lastTimePressed_y = Time.time;
        }
        else if( PlayerInput.y == 0 && Time.time > lastMove + MoveTime)
        {
            // Get block's current position
            curPos = transform.position;

            //TODO: Pass the block's direction to the grid so that it can track it

            //Decrement position based on the vertical direction 
            curPos.y -= 1;

            Debug.Log("Current position is being updated");

            //Update the position of the block by moving it the size of the block 
            transform.position = curPos;

            lastMove = Time.time;
        }
	}
}
