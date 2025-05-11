# 🎮 2D Platformer Adventure Game - Unity

[![Unity Version](https://img.shields.io/badge/Unity-2022.3%2B-blue.svg)](https://unity.com/)
[![Render Pipeline](https://img.shields.io/badge/Render%20Pipeline-URP%202D-brightgreen.svg)](https://unity.com/srp/Universal-Render-Pipeline)
[![License](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

Dự án trò chơi 2D Platformer được phát triển trên nền tảng **Unity** sử dụng **Universal Render Pipeline (URP 2D)**. Trò chơi kết hợp phong cách platforming cổ điển với hệ thống bẫy, kẻ địch tương tác đa dạng, cơ chế thu thập vật phẩm và hệ thống âm thanh sống động.

---

## 📋 Mục lục / Table of Contents
1. [Giới thiệu & Lối chơi (Gameplay Overview)](#-giới-thiệu--lối-chơi-gameplay-overview)
2. [Các tính năng chính (Core Features)](#-các-tính-năng-chính-core-features)
3. [Phím điều khiển (Controls)](#-phím-điều-khiển-controls)
4. [Kiến trúc & Cấu trúc mã nguồn (Project Architecture)](#-kiến-trúc--cấu-trúc-mã-nguồn-project-architecture)
5. [Yêu cầu hệ thống & Hướng dẫn cài đặt (Installation & Setup)](#-yêu-cầu-hệ-thống--hướng-dẫn-cài-đặt-installation--setup)
6. [Tác giả (Author)](#-tác-giả-author)

---

## 🌟 Giới thiệu & Lối chơi (Gameplay Overview)

Người chơi sẽ điều khiển nhân vật vượt qua các địa hình hiểm trở, né tránh hàng loạt bẫy chết người (quả cầu gai chuyển động, cưa xoay, bẫy đá lăn), né tránh hỏa lực từ quái vật bắn tỉa và thu thập tiền vàng (`Coin`) rải rác trên bản đồ. Mục tiêu tối thượng của màn chơi là tìm được chiếc chìa khóa (`Key`) để mở lối chiến thắng!

- **Mục tiêu chiến thắng:** Nhặt được Chìa khóa vàng (`Key`) tại đích màn chơi.
- **Thất bại:** Mất hết máu (`Heart`) khi va chạm vào bẫy gai, đạn của quái vật hoặc rơi xuống hố sâu.

---

## 🚀 Các tính năng chính (Core Features)

### 1. Nhân vật chính (Player Controller)
- Hệ thống vật lý 2D mượt mà (`Rigidbody2D`): di chuyển trái/phải, đảo hướng nhân vật linh hoạt, nhảy vượt địa hình.
- Phát hiện mặt đất thông minh qua `GroundCheck` và `LayerMask`.
- Animator đầy đủ trạng thái: `PlayerIdle`, `PlayerRun`, `PlayerJump`.
- Hệ thống sinh lực (`PlayerHealth`): hỗ trợ nhiều máu/tim (`Heart`), hiệu ứng nhấp nháy/bất tử tạm thời khi dính sát thương.

### 2. Hệ thống bẫy & Chướng ngại vật (Hazards & Traps)
- **Mace Trap (Gai lắc lư):** Dao động tuần hoàn theo trục với vận tốc vật lý.
- **Saw & Chain:** Cưa xoay tròn nguy hiểm cản đường nhảy của người chơi.
- **Ball Trap System (`BallTrigger` + `BallTrapLeft`):** Cơ chế bẫy đá lăn kích hoạt tự động khi người chơi bước vào vùng cảm biến (`Trigger Zone`).
- **Moving Platforms (`MovingPlatform`):** Nền tảng di chuyển qua lại giữa các điểm mốc (Waypoints) giúp người chơi vượt hố sâu.

### 3. Kẻ địch & Hỏa lực (Enemies & Projectiles)
- **ShootEnemy:** Quái vật tầm xa bắn đạn ngang theo chu kỳ định sẵn.
- **ShootDown Enemy:** Ụ súng gắn trần xả đạn dọc xuống bên dưới.
- **BulletManager & Projectile System:** Quản lý đạn bắn, tự động hủy khi va chạm hoặc bay ra khỏi tầm nhìn.

### 4. Vật phẩm & Cơ chế thưởng (Collectibles)
- **Coin (Đồng xu):** Tăng điểm số hiển thị trên giao diện HUD (`GameManger`).
- **Heart (Trái tim):** Hồi phục máu cho nhân vật.
- **Key (Chìa khóa chiến thắng):** Kích hoạt trạng thái `GameWin`.

### 5. Giao diện người dùng & Âm thanh (UI & Audio System)
- **UI Management:** Màn hình Bắt đầu (`BeginPanel`), Tạm dừng (`PausePanel`), Thua cuộc (`GameOverPanel`), Chiến thắng (`GameWinPanel`).
- **TextMesh Pro:** Hiển thị điểm số sắc nét, font chữ pixel art phong cách retro.
- **AudioManager:** Quản lý nhạc nền (`BGM`), hiệu ứng âm thanh nhảy, nhặt xu, sát thương, thắng/thua kèm khả năng bật/tắt âm thanh trực quan qua `SyncButtons`.

---

## ⌨️ Phím điều khiển (Controls)

| Thao tác | Phím bấm (Bàn phím) | Mô tả |
|---|---|---|
| **Di chuyển trái** | `A` hoặc `←` (Mũi tên trái) | Nhân vật chạy sang trái |
| **Di chuyển phải** | `D` hoặc `→` (Mũi tên phải) | Nhân vật chạy sang phải |
| **Nhảy** | `Space` hoặc `W` hoặc `↑` | Nhân vật nhảy lên |
| **Tạm dừng** | Nút `Pause` trên giao diện UI | Mở Menu tạm dừng |

---

## 📂 Kiến trúc & Cấu trúc mã nguồn (Project Architecture)

```
Game_Platform/
├── Assets/
│   ├── Animation/              # Controller & Clip hoạt họa (Player, Traps, Coin, Key)
│   ├── Font/                   # Phông chữ retro và pixel hiển thị UI
│   ├── Material/               # Material tùy chỉnh cho Sprite và ánh sáng 2D
│   ├── Prefab/                 # Prefab mẫu (Player, Enemies, Traps, Bullets, Coins)
│   ├── Scenes/                 # Các Scene chính của trò chơi
│   │   ├── Menu.unity          # Màn hình chính (Start, Settings, Exit)
│   │   └── Game.unity          # Màn chơi chính
│   ├── Scripts/
│   │   ├── Audio/              # Quản lý âm thanh (AudioManager, Sound, SyncButtons)
│   │   ├── Chướng ngại vật/    # Script điều khiển bẫy (Mace1, Mace2)
│   │   ├── Enemy/              # AI kẻ địch (ShootEnemy, ShootDown, BallTrap, Bullet)
│   │   ├── Manager/            # Quản lý game (GameManger, Menu, MovingPlatform)
│   │   ├── Player/             # Logic người chơi (PlayerController, PlayerHealth, ...)
│   │   └── Tile/               # Tilemap Palette và Asset Tiles
│   ├── Settings/               # Cấu hình Universal Render Pipeline (URP 2D)
│   ├── Sprites/                # Hình ảnh đồ họa nhân vật, địa hình, môi trường
│   └── TextMesh Pro/           # Tài nguyên TextMesh Pro essentials
├── Packages/                   # Khai báo Unity Package Dependencies
├── ProjectSettings/            # Cài đặt dự án (Physics2D, Tags, Layers, Input, Quality)
└── README.md                   # Tài liệu hướng dẫn dự án
```

---

## 🛠️ Yêu cầu hệ thống & Hướng dẫn cài đặt (Installation & Setup)

### Yêu cầu tiên quyết:
- **Unity Editor:** Khuyến nghị phiên bản **Unity 2022.3 LTS** (hoặc mới hơn) có hỗ trợ URP.
- **Module:** Universal RP (đã được cấu hình sẵn trong `Packages/manifest.json`).

### Các bước mở dự án:
1. Clone hoặc tải mã nguồn về máy:
   ```bash
   git clone https://github.com/dangngockhieu/Game_Platform.git
   ```
2. Mở ứng dụng **Unity Hub**.
3. Chọn **Add** (Thêm dự án) -> Trỏ tới thư mục `Game_Platform`.
4. Mở dự án bằng phiên bản Unity 2022.3 LTS phù hợp.
5. Sau khi Unity hoàn tất import assets:
   - Vào `Assets/Scenes/Menu.unity` để khởi động từ màn hình bắt đầu.
   - Hoặc vào `Assets/Scenes/Game.unity` để trải nghiệm trực tiếp màn chơi chính.
6. Nhấn nút **Play** ▶ trên Unity Editor để bắt đầu chơi.

---

## 👤 Tác giả (Author)

- **Developer:** Đặng Ngọc Khiêu (`dangngockhieu`)
- **GitHub:** [dangngockhieu](https://github.com/dangngockhieu)

---
*Dự án được xây dựng với mục tiêu học tập và phát triển kỹ năng lập trình game 2D trên nền tảng Unity.*
