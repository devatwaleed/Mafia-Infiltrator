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
    private float jumpingPower = 20f;
    private bool isFacingRight = true;
    public Animator animator;

 
 
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private AudioSource engageWithSomthing;


    private bool moveLeft;
    private bool moveRight;
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
        Debug.Log("Left true");
    }

    public void PointerUpLeft(){
        moveLeft=false;
        Debug.Log("Left false");
    }

    public void PointerDownRight(){
        moveRight=true;
        Debug.Log("Right true");
    }

    public void PointerUpRight(){
        moveRight=false;
        Debug.Log("Right false");
    }


    // Update is called once per frame
    void Update()
    {
        
        MovePlayer();

        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonDown("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        Flip();
    }

    private void MovePlayer(){
        if(moveLeft){
        Debug.Log("the move left is 2 "+moveLeft);
        Debug.Log("the move right is 2 "+moveRight);
            horizontal=-speed;
            Debug.Log("left"+horizontal);
            
        }else if(moveRight){
            horizontal=speed;
            
        Debug.Log("the move left is 3"+moveLeft);
        Debug.Log("the move right is 3"+moveRight);
            Debug.Log("right"+horizontal);
        }else{
            horizontal=0;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal, rb.velocity.y);
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
