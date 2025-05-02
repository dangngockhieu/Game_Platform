using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SyncButtons : MonoBehaviour
{
    public Button muteButton; // Gắn nút tắt nhạc từ Inspector
    public Button playButton; // Gắn nút bật nhạc từ Inspector
    void Start()
    {
        // Đồng bộ nút khi bắt đầu scene
        SyncWithAudioManager();
        // Đăng ký sự kiện khi scene được tải
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDestroy()
    {
        // Hủy đăng ký sự kiện để tránh lỗi
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Đồng bộ lại nút khi scene được tải
        SyncWithAudioManager();
    }

    public void SyncWithAudioManager()
    {
        if (AudioManager.instance == null) return;
        if (AudioManager.isFirstLoad)
        {
            AudioManager.isFirstLoad = false;
            return; // Không sync lần đầu
        }
        if (muteButton == null)
            muteButton = GameObject.Find("muteButton")?.GetComponent<Button>();
        if (playButton == null)
            playButton = GameObject.Find("playButton")?.GetComponent<Button>();

        if (muteButton != null && playButton != null)
        {
            AudioManager.instance.SyncButtons(muteButton, playButton);
        }
    }
}