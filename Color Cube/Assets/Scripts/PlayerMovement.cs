
using UnityEngine;
using Cinemachine;

public class PlayerMovement : MonoBehaviour {

    public float rotationSpeed = 10;
    public float jumpForce = 70;
    public float speed = 250;
    private bool forceMovement = false;
    public float moveForce = 3;
    public float maxVelocity = 20;

    private float horizontal;
    private bool rotate = false;
    private bool rotationAvailable = true;
    private bool jump = false;
    private bool inAir = true;

    public ParticleSystem dustFX;
    public ParticleSystem trailFX;
    public ParticleSystem jumpDustFX;
    private float startTimeBtwTrail, timeBtwTrail;
    private Animator cameraShake;


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

        forceMovement = GameData.ForceMovement;

        cameraShake = FindObjectOfType<CinemachineVirtualCamera>().GetComponent<Animator>();

        startTimeBtwTrail = Time.deltaTime;
        timeBtwTrail = 0;
    }

    void OnCollisionEnter2D(Collision2D col){
        inAir = false;
        cameraShake.SetTrigger("Shake");
        Instantiate(dustFX,transform.position+new Vector3(0f,-0.6f,0f), transform.localRotation);

    }

    void OnCollisionExit2D(Collision2D col)
    {
        inAir = true;
    }

    //Updates every frame
    void Update()
    {
        //Get horizontal movement
        horizontal = Input.GetAxis("Horizontal")*speed;


        if(horizontal != 0)
        {
            if (timeBtwTrail <= 0)
            {
                Instantiate(trailFX, transform.position + new Vector3(0f, -0.6f, 0f), Quaternion.identity);
                timeBtwTrail = startTimeBtwTrail;
            }
            else
            {
                timeBtwTrail -= Time.deltaTime;
            }
        }

        //Jump button pressed
        if (Input.GetButton("Jump")) 
        {
            if (inAir && rotationAvailable)
                rotate = true;

            if (!inAir)
            {
                jump = true;
                rotationAvailable = false;  //Player will not rotate directly on jump
                Instantiate(jumpDustFX, transform.position + new Vector3(0f, -0.6f, 0f), transform.localRotation);

            }
        }

        //Jump button released
        if (Input.GetButtonUp("Jump"))
        {
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
            Vector2 move = new Vector2(horizontal*moveForce, 0f);
            if (rb.velocity.x < maxVelocity) 
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
            rb.AddForce(new Vector2(0f, jumpForce));
            inAir = true;
            jump = false;
        }

        //Rotate
        if(rotate)
        {
            transform.Rotate(new Vector3(0, 0, rotationSpeed), Space.Self);
        }

    }
    
}
