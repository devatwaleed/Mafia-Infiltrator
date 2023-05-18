using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.EventSystems;


public class playermovement : MonoBehaviour
{
    private float horizontal;
    public   float speed = 8f;
    private bool isFacingRight = true;
    public Animator animator;

 
 
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private AudioSource engageWithSomthing;


    private bool moveLeft;
    private bool moveRight;
<<<<<<< HEAD

    private bool moveUp;
    private bool moveDown;
=======
>>>>>>> parent of eef6165 (7)
    public Button actionButton;

    void Start()
    {
        
        actionButton.onClick.AddListener(EngageWithSomething);    
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        moveLeft=false;
        moveRight=false;
        if (animator == null)
        {
            Debug.LogError("Animator component is missing!");
        }
    }
    
    public void PointerDownLeft(){
        moveLeft=true;
        Debug.Log("left is true");
    }

    public void PointerUpLeft(){
        moveLeft=false;
        Debug.Log("left is false");
    }

    public void PointerDownRight(){
        moveRight=true;
        Debug.Log("right is true");
    }

    public void PointerUpRight(){
        moveRight=false;
<<<<<<< HEAD
    }

    public void PointerDownClimb(){
        moveUp=true;
    }

    public void PointerUpClimb(){
        moveUp=false;
=======
        Debug.Log("right is false");
>>>>>>> parent of eef6165 (7)
    }

    public void PointerclimbDown(){
        moveDown=true;
    }

    public void Pointerclimbup(){
        moveDown=false;
    }
    

    // Update is called once per frame
    void Update()
    {
        
        MovePlayer();

        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        Flip();
    }

<<<<<<< HEAD
   private void MovePlayer()
{
    if (isLadder)
    {
        if (moveUp)
        {
            vertical = speed;
            moveDown = false; // Disable moveDown when moveUp is pressed
        }
        else if (moveDown)
        {
            vertical = -speed;
            moveUp = false; // Disable moveUp when moveDown is pressed
        }
        else
        {
            // No vertical input, player stays at current position on the ladder
            vertical = 0;
=======
    private void MovePlayer(){
        if(moveLeft){
            horizontal=-speed;
            
        }else if(moveRight){
            horizontal=speed;
            
        }else{
            horizontal=0;
>>>>>>> parent of eef6165 (7)
        }
    }
    else
    {
        vertical = 0;
    }

    if (moveLeft)
    {
        horizontal = -speed;
    }
    else if (moveRight)
    {
        horizontal = speed;
    }
    else
    {
        horizontal = 0;
    }
}


    private void FixedUpdate()
{
    rb.velocity = new Vector2(horizontal, rb.velocity.y);

    if (isLadder)
    {
<<<<<<< HEAD
        // Apply vertical movement on the ladder
        if (moveUp)
        {
            // Move player up when the up button is pressed
            rb.velocity = new Vector2(rb.velocity.x, speed);
        }
        else if (moveDown)
        {
            // Move player down when the down button is pressed
            rb.velocity = new Vector2(rb.velocity.x, -speed);
        }
        else
        {
            // No vertical input, player stays at current position on the ladder
            rb.velocity = new Vector2(rb.velocity.x, 0f);
        }

        // Disable gravity while on the ladder
        rb.gravityScale = 0f;
=======
        rb.velocity = new Vector2(horizontal, rb.velocity.y);
>>>>>>> parent of eef6165 (7)
    }
    else
    {
        // Enable gravity when not on the ladder
        rb.gravityScale = 1f;
    }
}


    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    

    

    private void EngageWithSomething()
    {
        engageWithSomthing.Play();
    }
}
