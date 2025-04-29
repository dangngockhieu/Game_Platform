using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 15f;
    [SerializeField] private LayerMask groundLayer; // LayerMask để kiểm tra mặt đất
    [SerializeField] private Transform groundCheck; // Transform để kiểm tra mặt đất
    private Animator animator; // Animator để điều khiển 
    private bool isGrounded;
    private Rigidbody2D rb;
    private void Awake()
    {
        animator = GetComponent<Animator>(); // Lấy Animator từ GameObject
        rb = GetComponent<Rigidbody2D>(); // Lấy Rigidbody2D từ GameObject
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        UpdateAnimation();
    }
    private void Move()
    {
        // Lấy input từ bàn phím (phím mũi tên trái/phải hoặc A/D)
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
        // Kiểm tra nếu người chơi đang di chuyển sang trái hoặc phải
        if (moveInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    private void Jump()
    {
        // Gõ phím Space hoặc phím mũi tên lên để nhảy với đk đang đứng trên mặt đất
        if ((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y + jumpForce);
            // Phát âm thanh khi nhảy
            AudioManager.instance.Play("Jump");
        }
        // Kiểm tra xem người chơi có đang đứng trên mặt đất hay không
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
    }
    private void UpdateAnimation()
    {
        bool isRunning = Mathf.Abs(rb.linearVelocity.x) > 0.1f; // Kiểm tra xem người chơi có đang chạy hay không
        bool isJumping = !isGrounded; // Nếu không đứng trên mặt đất thì đang nhảy
        animator.SetBool("isRunning", isRunning);
        animator.SetBool("isJumping", isJumping);
    }
}