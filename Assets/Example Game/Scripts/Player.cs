using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    public string logText = "Hello world again";
    public float speed = 2;
    public float jumpspeed = 3;
    public float health = 10;

    // Use this for initialization
    void Start()
    {
        Debug.Log(logText);
        //ApplyDamage(1);
    }

    // Update is called once per frame
    void Update()
    {
        //Getting rigidbody from the game object we are attached to
        Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();

        //Number between -1 and 1 based on player pressing space bar
        float horizontal = Input.GetAxis("Horizontal");

        //Boolean (true/false) based on player pressing space bar
        bool jump = Input.GetButtonDown("Jump");

        //Find out if we are touching the ground

        //Get the collider component attached to this object
        Collider2D collider = GetComponent <Collider2D>();

        //Find out if we are colliding with the ground
        LayerMask groundlayer = LayerMask.GetMask("Ground");
        bool touchingGround = collider.IsTouchingLayers(groundlayer);

        //Debug.Log(horizontal);

        // Cashe a local copy of our rigidbody's velocity
        Vector2 velocity = rigidBody.velocity;

        // Set the x (left/right) component of the velocity based on input
        velocity.x = horizontal * speed;

        //Determine the speed for the animator
        float animatorSpeed = Mathf.Abs(velocity.x);

        //Get the animator component from the game object
        Animator animatorComponent = GetComponent<Animator>();

        //Set the speed on animator
        animatorComponent.SetFloat("Speed", animatorSpeed);
 
        // Set the y (up/down) component of the velocity based on jump
        if (jump == true && touchingGround == true) 
        {
            velocity.y = jumpspeed;
        }
        // Set our rigdbody velocity based on our local copy
        rigidBody.velocity = velocity;

        //Print log when the mouse button is pressed
        if (Input.GetMouseButton(0))
        {
            {
                Debug.Log("Mouse button down!");
            }
            //Print a log of the mouse position
            Vector2 mouseposition = Input.mousePosition;
            Debug.Log("Mouse position is" + mouseposition);
        }

}

    public void ApplyDamage(float damageToDeal)
    {
        health = health - damageToDeal;
    }
}
