using UnityEngine;
using System.Collections;

public class BlockMovement : MonoBehaviour {

    public Vector2 PlayerInput;
    public Vector2 curPos;
    public float speed;

    public enum Direction
    {
        LEFT,
        RIGHT,
        DOWN
    };

    private SpriteRenderer rend; 

	// Use this for initialization
	void Start () {
        rend = GetComponent<SpriteRenderer>(); 
    }
	
	// Update is called once per frame
	void Update () {
        // Getting left/right input from player
        PlayerInput.x = Input.GetAxis("Horizontal");

        // Normalize the input so value is -1 or 1
        PlayerInput = new Vector2(PlayerInput.x, PlayerInput.y).normalized;
        // Get block's current position
        curPos = transform.position;
        // Change position based on input and speed.
        //curPos += PlayerInput * speed * Time.deltaTime;

        //Pass the block's direction to the grid so that it can track it 


        curPos.x += PlayerInput.x * rend.sprite.rect.size.x; 
        //Update the position of the block by moving it the size of the block 
        transform.position = curPos;
	}
}
