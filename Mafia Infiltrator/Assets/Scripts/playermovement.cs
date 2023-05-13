using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.EventSystems;


public class playermovement : MonoBehaviour
{
    private float horizontal;

    private float vertical;

    public   float speed = 8f;
    private bool isFacingRight = true;
    public Animator animator;

    private bool isLadder;

 
 
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private AudioSource engageWithSomthing;


    private bool moveLeft;
    private bool moveRight;

    private bool moveUp;
    public Button actionButton;

    void Start()
    {
        
        actionButton.onClick.AddListener(EngageWithSomething);    
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        moveLeft=false;
        moveRight=false;
        moveUp=false;
        if (animator == null)
        {
            Debug.LogError("Animator component is missing!");
        }
    }
    
    public void PointerDownLeft(){
        moveLeft=true;
    }

    public void PointerUpLeft(){
        moveLeft=false;
    }

    public void PointerDownRight(){
        moveRight=true;
    }

    public void PointerUpRight(){
        moveRight=false;
    }

    public void PointerDownClimb(){
        moveUp=true;
        Debug.Log("Up is true");
    }

    public void PointerUpClimb(){
        moveUp=false;
        Debug.Log("Up is false");
    }

    // Update is called once per frame
    void Update()
    {
        
        MovePlayer();

        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        if(isLadder){
            animator.SetFloat("Speed", Mathf.Abs(vertical));
        }else{

        }
        Flip();
    }

    private void MovePlayer(){
        if(moveLeft){
            horizontal=-speed;
            Debug.Log(horizontal);
            
        }else if(moveRight){
            horizontal=speed;
            Debug.Log(horizontal);
            
        }else if(moveUp){
            vertical=speed;
            Debug.Log(vertical);
            }else{
            horizontal=0;
        }
    }



    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal, rb.velocity.y);
        rb.velocity = new Vector2(rb.velocity.x, vertical);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
        }
    }

    private void EngageWithSomething()
    {
        engageWithSomthing.Play();
    }
}
