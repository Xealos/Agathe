using UnityEngine;
using System.Collections;

public class BlockMovement : MonoBehaviour {

    public Vector2 PlayerInput;
    public Vector2 curPos;
    public float CooldownTime; 


    public enum Direction
    {
        LEFT,
        RIGHT,
        DOWN
    };

    private SpriteRenderer rend;
    private float lastTimePressed; 

	// Use this for initialization
	void Start () {
        rend = GetComponent<SpriteRenderer>();
        lastTimePressed = -100.0f; 
    }
	
	// Update is called once per frame
	void Update () {
        // Getting left/right input from player
        PlayerInput.x = Input.GetAxis("Horizontal");

        PlayerInput = new Vector2(PlayerInput.x, PlayerInput.y).normalized; 

        if( PlayerInput.x != 0 
            && Time.time > lastTimePressed + CooldownTime )
        {
            // Normalize the input so value is -1 or 1
            PlayerInput = new Vector2(PlayerInput.x, PlayerInput.y).normalized;
            // Get block's current position
            curPos = transform.position;

            //TODO: Pass the block's direction to the grid so that it can track it

            //Increment position based on the horizontal direction 
            curPos.x += PlayerInput.x;

            Debug.Log("Current position is being updated");

            //Update the position of the block by moving it the size of the block 
            transform.position = curPos;

            lastTimePressed = Time.time; 
        }
	}
}
