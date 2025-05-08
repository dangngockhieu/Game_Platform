using UnityEngine;

public class TrapScript : MonoBehaviour
{
    public GameObject largeBall; // Prefab quả cầu
    public float speed = 5f;

    private static bool hasTriggered = false; // Biến static để dùng chung giữa các instance, đảm bảo chỉ có 1 quả cầu được tạotạo
    private GameObject spawnedBall;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasTriggered && other.CompareTag("Player"))
        {
            hasTriggered = true; // Đánh dấu đã kích hoạt
            Vector3 spawnPosition = new Vector3(135.44f, 7.14f, 0f); // Vị trí tạo quả cầu
            spawnedBall = Instantiate(largeBall, spawnPosition, Quaternion.identity);

            Rigidbody2D rb = spawnedBall.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 direction = Vector2.left;
                rb.linearVelocity = direction * speed;// tạo vận tốc cho quả cầu
            }
        }
    }
}