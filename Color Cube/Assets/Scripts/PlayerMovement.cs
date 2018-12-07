
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float rotationSpeed = 10;
    public float jumpForce = 70;
    public float speed = 250;
    public bool forceMovement = false;

    private float horizontal;
    private bool rotate = false;
    private bool rotationAvailable = true;
    private bool jump = false;
    private bool inAir = true;


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
        Debug.Log("Player: Collision ENTER");
        inAir = false;
    }

    void OnCollisionExit2D(Collision2D col)
    {
        Debug.Log("Player: Collision EXIT");
        inAir = true;
    }

    //Updates every frame
    void Update()
    {
        //Get horizontal movement
        horizontal = Input.GetAxis("Horizontal")*speed;

        //Jump button pressed
        if (Input.GetButton("Jump")) 
        {
            if (inAir && rotationAvailable)
                rotate = true;

            if (!inAir)
            {
                jump = true;
                rotationAvailable = false;  //Player will not rotate directly on jump
            }
        }

        //Jump button released
        if (Input.GetButtonUp("Jump"))
        {
            Debug.Log("Released jump button");
            if (inAir)
                rotate = false;

            rotationAvailable = true;   //Player is able to rotate if pressing the jump button again
        }
    }

    //For physics
    void FixedUpdate () {
        //Move horizontal
        if (forceMovement)
        {
            Vector2 move = new Vector2(horizontal, 0f);
            rb.AddForce(move);
        }
        else
        {
            Vector3 movement = new Vector3(horizontal, 0f, 0f) * Time.fixedDeltaTime;
            transform.position += movement;
        }


        //Jump
        if (jump)
        {
            Debug.Log("JUMP!");
            rb.AddForce(new Vector2(0f, jumpForce));
            inAir = true;
            jump = false;
        }

        //Rotate
        if(rotate)
        {
            Debug.Log("ROTATE!");
            transform.Rotate(new Vector3(0, 0, rotationSpeed), Space.Self);
        }

    }
    
}
