using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform pointA; // Biên trái
    [SerializeField] private Transform pointB; // Biên phải
    public float speed = 2f; // Speed 
    private Vector3 target; // Mục tiêu hiện tại mà nền tảng sẽ di chuyển tới
    void Start()
    {
        target = pointA.position; // Đặt mục tiêu ban đầu là pointA
    }

    // Update được gọi mỗi frame
    void Update()
    {
        // Di chuyển nền tảng tới mục tiêu với tốc độ xác định
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime); // Move towards the target

        if (Vector3.Distance(transform.position, target) < 0.1f) // Kiểm tra nếu nền tảng đã gần tới mục tiêu
        {
            // Chuyển đổi mục tiêu giữa pointA và pointB
            target = (target == pointA.position) ? pointB.position : pointA.position; // Switch target
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Kiểm tra nếu đối tượng va chạm là "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Đặt "Player" làm con của nền tảng để di chuyển cùng 1 tốc độ
            collision.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        // Kiểm tra nếu đối tượng rời khỏi nền tảng là "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Gỡ "Player" khỏi hệ thống con của nền tảng
            collision.transform.SetParent(null);
        }
    }
}