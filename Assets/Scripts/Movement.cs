using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    public float speed;
    public float jump;
    public LayerMask groundLayer;
    public Transform GroundCheck;
    public Animator animator;
    public float CheckWidth = 0.3f;
    public Transform childObject;
    public float CheckHeight = 0.3f;
    private bool isGrounded;
    private bool facingRight;
    public SpriteRenderer sprite;
    public bool allowMove;
    void Start()
    {
        allowMove = true;
        rb = GetComponent<Rigidbody2D>();
        facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCapsule(GroundCheck.position, new Vector2(CheckWidth, CheckHeight), CapsuleDirection2D.Vertical, 0, groundLayer);
        if (allowMove)
        {
            moveDirection.x = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(moveDirection.x * speed, rb.velocity.y);
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                rb.AddForce(new Vector2(rb.velocity.x, jump));
            }
        }else if(!allowMove)
        {
            moveDirection.x = 0;
            rb.velocity = Vector2.zero;
        }
        if (moveDirection.x < 0 && facingRight)
        {
            facingRight = !facingRight;
            sprite.flipX = true;
        }
        else if (moveDirection.x > 0 && !facingRight)
        {
            facingRight = !facingRight;
            sprite.flipX = false;
        }
        animator.SetFloat("speed", Mathf.Abs(moveDirection.x));
    }
}

