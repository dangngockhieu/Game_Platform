using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManger : MonoBehaviour
{
    private int score = 0; // Số coin hiện tại
    [SerializeField] private TextMeshProUGUI scoreText; // TextMeshProUGUI để hiển thị điểm số
    [SerializeField] private GameObject gameOverPanel; // Bảng Game Over
    [SerializeField] private GameObject gameWinPanel; // Bảng Game Win
    [SerializeField] private GameObject beginPanel; // Bảng bắt đầu
    [SerializeField] private GameObject pausePanel; // Bảng tạm dừng
    [SerializeField] private GameObject buttonPause; // Nút tạm dừng

    void Start()
    {   // Ban đầu thì Panel begin sẽ hiện lên trong 3s 
        UpdateScoreText();
        gameOverPanel.SetActive(false);
        pausePanel.SetActive(false);
        beginPanel.SetActive(true);
        buttonPause.SetActive(true);
        StartCoroutine(HideBeginPanelAfterDelay(3f));
        // Update is called once per frame
    }
    void Update()
    {

    }
    // Hàm này sẽ ẩn bảng bắt đầu sau một khoảng thời gian nhất định
    private System.Collections.IEnumerator HideBeginPanelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Chờ 2 giây
        beginPanel.SetActive(false); // Ẩn beginPanel
    }
    public void AddScore(int points)
    {
        score += points; // Add points to the score
        UpdateScoreText();
    }
    // Hàm này sẽ cập nhật điểm số trên UI
    public void UpdateScoreText()
    {
        scoreText.text = score.ToString(); // Update the score text in the UI
    }
    // Hàm này sẽ được gọi khi người chơi chết
    public void GameOver()
    {
        score = 0; // Reset the score to 0
        Time.timeScale = 0; // Pause the game
        gameOverPanel.SetActive(true); // Hiện gameover panel
        buttonPause.SetActive(false); // Nút tạm dừng sẽ bị ẩn và ko sử dụng đc
        // Nếu đang có nhạc nền thì tắt đi
        if (AudioManager.instance != null)
        {
            AudioManager.instance.Stop("BackGround");
        }
    }
    public void GameWin()
    {
        Time.timeScale = 0; // Pause the game
        pausePanel.SetActive(false);
        gameWinPanel.SetActive(true); // Hiện gamewin panel
        buttonPause.SetActive(false); // Nút tạm dừng sẽ bị ẩn và ko sử dụng đc
        // Nếu đang có nhạc nền thì tắt đi
        if (AudioManager.instance != null)
        {
            AudioManager.instance.Stop("BackGround");
        }
    }
    public void RestartGame()
    {
        Time.timeScale = 1;
        score = 0;
        UpdateScoreText();
        SceneManager.LoadScene(1); // Load the game scene again
        if (AudioManager.instance != null)
        {
            AudioManager.instance.Play("BackGround");
            AudioManager.instance.SetMusicState(true);
            AudioManager.instance.UpdateButtonStates(); // cập nhật lại nút
        }
    }
    public void BackToMenu()
    {
        Time.timeScale = 1; // Ensure the game is not paused
        SceneManager.LoadScene(0); // Load the menu scene
        if (AudioManager.instance != null)
        {
            AudioManager.instance.Play("BackGround");
            AudioManager.instance.SetMusicState(true);
            AudioManager.instance.UpdateButtonStates(); // cập nhật lại nút
        }
    }
    public void Pause(string sound)
    {
        Time.timeScale = 0; // Pause the game
        pausePanel.SetActive(true); // Hiện bảng tạm dừng

        // Tạm dừng nhạc nền thông qua AudioManager
        if (AudioManager.instance != null)
        {
            AudioManager.instance.Pause("BackGround");
        }
    }
    public void Resume()
    {
        Time.timeScale = 1; // Resume the game
        pausePanel.SetActive(false); // Ẩn bảng tạm dừng

        // Tiếp tục phát nhạc nền thông qua AudioManager
        if (AudioManager.instance != null)
        {
            AudioManager.instance.Resume("BackGround");
        }
    }
}