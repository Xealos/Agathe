using UnityEngine;
using System.Collections;

public class BlockMovement : MonoBehaviour {

    public Vector2 PlayerInput;
    public Vector2 curPos;
    public float speed;

	// Use this for initialization
	void Start () {
        
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
        curPos += PlayerInput * speed * Time.deltaTime;
        // Update position
        transform.position = curPos;
	}
}
