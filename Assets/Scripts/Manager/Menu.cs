using UnityEngine;
using UnityEngine.SceneManagement;
// Quản lý các UI trong Game
public class Menu : MonoBehaviour
{
    void Start()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.Play("BackGround"); // Phát nhạc nền khi vào Menu
        }
    }
    // Nếu bấm "Play" thì chuyển từ màn hình Menu qua Màn hình để chơi Level1
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    // Nếu bấm "Exit" thì thoát khỏi Game
    public void ExitGame()
    {
        Application.Quit();
    }
}