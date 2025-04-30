using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3; // Số trái tim tối đa
    private int currentHealth; // Số trái tim hiện tại
    public Image[] hearts; // Mảng chứa các hình ảnh trái tim
    public Sprite fullHeart; // Hình ảnh trái tim đỏ
    public Sprite emptyHeart; // Hình ảnh trái tim xám

    void Awake()
    {
        currentHealth = 1; // Người chơi bắt đầu với 1 trái tim
        maxHealth = 3;
    }

    void Update()
    {
        // Gắn tất cả trái tim với hình ảnh trái tim xám
        foreach (Image img in hearts)
        {
            img.sprite = emptyHeart;
        }
        // Gắn trái tim hiện tại với hình ảnh trái tim đỏ
        for (int i = 0; i < currentHealth; i++)
        {
            hearts[i].sprite = fullHeart;
        }
    }

    public void AddHeart(int amount)
    {
        currentHealth += amount;
        // Nếu quá trái tim max thì gán lại max
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    // Giảm số trái tim hiện tại khi bị dính chưởng
    public void DecreaseHealth(int amount)
    {
        currentHealth -= amount;
    }

    // Kiểm tra xem người chơi đã chết chưa
    public bool IsDead()
    {
        return currentHealth <= 0;
    }
}