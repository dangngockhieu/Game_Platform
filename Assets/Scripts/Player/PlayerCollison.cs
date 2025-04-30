using UnityEngine;
using System.Collections;
public class PlayerCollison : MonoBehaviour
{
    private GameManger gameManager;
    private PlayerHealth playerHealth;
    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManger>(); // Find the GameManager in the scene
        playerHealth = FindAnyObjectByType<PlayerHealth>(); // Find the PlayerHealth in the scene
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            Destroy(collision.gameObject); // Destroy coin
            gameManager.AddScore(1); // Add score 
            AudioManager.instance.Play("Coin"); // Phát âm thanh khi ăn coin
        }
        else if (collision.CompareTag("Heart"))
        {
            Destroy(collision.gameObject); // Destroy heart
            playerHealth.AddHeart(1); // Add heart
        }
        else if (collision.CompareTag("Trap") || collision.CompareTag("Bullet"))
        {
            playerHealth.DecreaseHealth(1);
            if (playerHealth.IsDead())
            {
                StartCoroutine(DelayGameOver());
            }
        }
        // Nếu va chạm với chìa khóa thì Win
        else if (collision.CompareTag("Key"))
        {
            StartCoroutine(DelayGameWin());
        }
        else if (collision.CompareTag("DeathZone"))
        {
            playerHealth.DecreaseHealth(1);
            if (playerHealth.IsDead())
            {
                StartCoroutine(DelayGameOver());
            }
            else
            {
                GameObject player = GameObject.FindWithTag("Player");
                player.transform.position = new Vector3(151, 8, 0); // Reset player position
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Gai"))
        {
            playerHealth.DecreaseHealth(1);
            if (playerHealth.IsDead())
            {
                StartCoroutine(DelayGameOver());
            }
        }
    }

    private System.Collections.IEnumerator DelayGameOver()
    {
        yield return new WaitForSeconds(0.3f); // Wait for 2 seconds
        gameManager.GameOver(); // Call GameOver method in GameManager
        AudioManager.instance.Play("GameOver"); // Play GameOver sound
    }
    private System.Collections.IEnumerator DelayGameWin()
    {
        yield return new WaitForSeconds(0.3f); // Wait for 2 seconds
        gameManager.GameWin(); // Call GameOver method in GameManager
        AudioManager.instance.Play("GameWin"); // Play GameOver sound
    }
}