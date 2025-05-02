using System;
using UnityEngine;
using UnityEngine.UI;
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public Sound[] sounds; // Mảng chứa âm thanh
    public Button muteButton; // Gắn nút tắt nhạc từ Inspector
    public Button playButton; // Gắn nút bật nhạc từ Inspector
    private bool isMusicPlaying = true; // Biến để theo dõi trạng thái nhạc
    public static bool isFirstLoad = true; // Biến để xem có phải là lần load scene đầu hay ko

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>(); // Tên
            s.source.clip = s.clip; // Source âm thanh
            s.source.volume = s.volume; // Âm lượng
            s.source.pitch = s.pitch; // Tốc độ phát
            s.source.loop = s.loop; // Lặp lại âm thanh
        }
    }
    void Start()
    {
        UpdateButtonStates(); // Cập nhật trạng thái nút tắt, bật âm thanh
    }

    public void UpdateButtonStates()
    {
        if (isMusicPlaying) // Nếu nhạc đang phát
        {
            muteButton.gameObject.SetActive(true);  // Hiện nút tắt nhạc
            playButton.gameObject.SetActive(false); // Ẩn nút bật nhạc
        }
        else
        {
            muteButton.gameObject.SetActive(false); // Ẩn nút tắt nhạc
            playButton.gameObject.SetActive(true);  // Hiện nút bật nhạc
        }
    }
    public void SetMusicState(bool isPlaying)
    {
        isMusicPlaying = isPlaying;
    }
    // Cập nhật khi mình restart game, lúc đó âm thanh nhạc nền luôn đc bật
    public void UpdateRestart()
    {
        if (!isMusicPlaying)
        {
            muteButton.gameObject.SetActive(true);  // Hiện nút tắt nhạc
            playButton.gameObject.SetActive(false); // Ẩn nút bật nhạc
        }
    }
    public void Play(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        s.source.Play();
    }

    public void Stop(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        s.source.Stop();
    }
    public void Pause(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            return;
        }
        s.source.Pause(); // Tạm dừng nhạc
    }

    public void Resume(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            return;
        }
        s.source.UnPause(); // Tiếp tục phát nhạc
    }
    // Tắt, bật nhạc nền
    public void ToggleMusic()
    {
        Sound s = Array.Find(sounds, item => item.name == "BackGround");
        if (s == null)
        {
            return;
        }

        if (s.source.isPlaying)
        {
            s.source.Pause(); // Tắt nhạc
            isMusicPlaying = false; // Cập nhật trạng thái
            muteButton.gameObject.SetActive(false); // Ẩn nút tắt nhạc
            playButton.gameObject.SetActive(true);  // Hiện nút bật nhạc
        }
        else
        {
            s.source.Play(); // Bật nhạc
            isMusicPlaying = true; // Cập nhật trạng thái
            muteButton.gameObject.SetActive(true);  // Hiện nút tắt nhạc
            playButton.gameObject.SetActive(false); // Ẩn nút bật nhạc
        }
    }
    // Đồng bộ trạng thái các nút tắt, bật âm thanh khi từ Menu Vào Game
    public void SyncButtons(Button mute, Button play)
    {
        // Gỡ listener cũ (nếu có)
        if (muteButton != null)
        {
            muteButton.onClick.RemoveAllListeners();
        }
        if (playButton != null)
        {
            playButton.onClick.RemoveAllListeners();
        }

        // Cập nhật button mới
        muteButton = mute;
        playButton = play;
        // Gán lại sự kiện click
        if (muteButton != null)
        {
            muteButton.onClick.AddListener(ToggleMusic);
        }
        if (playButton != null)
        {
            playButton.onClick.AddListener(ToggleMusic);
        }

        // Cập nhật trạng thái nút
        UpdateButtonStates();
    }
}