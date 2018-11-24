
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed =8;
    public float rotationSpeed = 10;
    public float jumpForce;
    public float fallingOffset = 0.5f;

    private bool buttonPressed = false;
    private bool inAir = false;
    private float pastYPosition;
    private Rigidbody2D rb;
    

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();

        if(GameData.RotationSensitivity > 0)
            rotationSpeed = GameData.RotationSensitivity;
        if (GameData.MovementSensitivity > 0)
            speed = GameData.MovementSensitivity;
        speed = speed / 10;
        jumpForce = jumpForce * 100;
	}

    void OnCollisionEnter2D(Collision2D col){
        Debug.Log("Collision ENTER");
        inAir = false;
        pastYPosition = transform.position.y - fallingOffset;
        buttonPressed = false;
    }

    void FixedUpdate () {
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontal * speed, 0f, 0f);

        transform.position += movement;

        if(inAir && Input.GetKeyUp(KeyCode.Space)) //if releasing Space while in air jumping...
        {
            Debug.Log("released space");
            buttonPressed = true;
        }


        if (Input.GetKey(KeyCode.Space))
        {
            if(transform.position.y < pastYPosition) // if falling down, space = rotation
            {
                Debug.Log("falling down");
                transform.Rotate(new Vector3(0, 0, rotationSpeed), Space.Self);
            }else if (!inAir) // if not falling down and if not in air - jump and set in air to true
            {
                Debug.Log("jump!");
                rb.AddForce(new Vector2(0f, jumpForce));
                inAir = true;
            }else if(inAir && buttonPressed) // if in air and not fallling down when pressing space - rotate
            {
                Debug.Log("rotate while jumping");
                transform.Rotate(new Vector3(0, 0, rotationSpeed), Space.Self);
            }

        }

    }

    

}
