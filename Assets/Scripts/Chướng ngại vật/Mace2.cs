using UnityEngine;

public class Mace2 : MonoBehaviour
{
    public float speed = 1.5f;
    int dir = 1;
    public Transform rightCheck;
    public Transform leftCheck;

    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector2.right * speed * Time.fixedDeltaTime * dir);

        // Kiểm tra nếu bên dưới rightCheck không có mặt đất
        if (!Physics2D.Raycast(rightCheck.position, Vector2.down, 0.5f))
        {
            dir = -1; // Đổi hướng sang trái
        }

        // Kiểm tra nếu bên dưới leftCheck không có mặt đất
        if (!Physics2D.Raycast(leftCheck.position, Vector2.down, 0.5f))
        {
            dir = 1; // Đổi hướng sang phải
        }
    }
}