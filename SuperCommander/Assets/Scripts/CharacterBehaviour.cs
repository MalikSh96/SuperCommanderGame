using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Source used: https://www.youtube.com/watch?time_continue=736&v=Xnyb2f6Qqzg
//This script is used to tell the animator controller which parameter is to be used
//Basically updating the parameters
public class CharacterBehaviour : MonoBehaviour
{
    public float maxSpeed = 10f; //maximum speed
    bool _facingRight = true; //tells what side the character is facing

    //Creating a reference to the animator
    Animator anim;

    //Checks if on ground, used for jump/fall
    bool _grounded = false;
    //Creates an object to represent where the ground should be to the character
    public Transform groundCheck;
    //How big are the circles going to be when checking for the ground
    float _groundRadius = 0.2f;
    //Used to tell the characater what is considered ground
    /*Layer mask is a 32-bit flag which is represented by an integer. 
    Bit shift is used to change the value of the layer mask flag.
    Source: http://gyanendushekhar.com/2017/06/29/understanding-layer-mask-unity-5-tutorial/*/
    public LayerMask whatIsGround;
    public float jumpForce = 700f;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    //So the animator can work in sync
    void FixedUpdate()
    {
        //Always check if the character are on the ground
        //Checks if we hit any colliders in this circle
        //groundCheck.position generates the circle, _groundRadius sets the circle's radius, 
        //whatIsGround is the things that the character will collide with
        _grounded = Physics2D.OverlapCircle(groundCheck.position, _groundRadius, whatIsGround);
        //^will return either true or false, if the character hit ground or not

        anim.SetBool("Ground", _grounded);
        //how fast we move up or down
        anim.SetFloat("VerticalSpeed", GetComponent<Rigidbody2D>().velocity.y);
        
        //^above code snip is meant for jumping, which does not work

        //--------------------------------------------------------------------------
        //FixedUpdate is good for physics beehaviour (?)
        //In fixedUpdate using time.deltaTime is not necessary
        //Reading in how much we are moving
        float move = Input.GetAxis("Horizontal");

        //if we are moving 1 or -1, we are just passing 1
        anim.SetFloat("Speed", Mathf.Abs(move));

        //to move the character
        //move * maxSpeed is for how much we are pressing the buttons times our maxSpeed
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed,
            GetComponent<Rigidbody2D>().velocity.y);

        //If we are moving to the right and not facing right we flip
        if(move > 0 && !_facingRight)
        {
            Flip();
        }
        //if we are moving to the left and facing right we flip
        else if(move < 0 && _facingRight)
        {
            Flip();
        }
    }

    void Update()
    {
        //Does not work 
        if (_grounded && Input.GetKeyDown(KeyCode.Space))
        {
            //we immediatly gives the info we are jumping
            anim.SetBool("Ground", false);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
        }    
    }

    void Flip()
    {
        //flipping our facing
        //whenever we flip
        //we are facing the opposite direction
        _facingRight = !_facingRight;
        //let us get the local scale
        Vector3 theScale = transform.localScale;
        //flips the x axis
        theScale.x *= -1;
        //applying it back to the local scale
        transform.localScale = theScale;
        //This means we don't need an animation for facing left or right
    }
}
