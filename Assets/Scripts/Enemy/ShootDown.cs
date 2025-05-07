using UnityEngine;
using System.Collections;
public class ShootDown : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    IEnumerator shootingCoroutine;
    Rigidbody2D enemyRigidbody;
    Shoots[] guns;
    public static ShootEnemy instance;

    [Header("Shooting Settings")]
    public bool facingRight = true; // <-- thêm biến public chọn hướng

    void Awake()
    {
        //EnsureSingletonInstance();
    }

    void Start()
    {
        InitializeComponents();
        StartShootingRoutine();
    }

    private void InitializeComponents()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
        guns = GetComponentsInChildren<Shoots>();
        shootingCoroutine = ShootingRoutine();
    }

    private void StartShootingRoutine()
    {
        StartCoroutine(shootingCoroutine);
    }

    IEnumerator ShootingRoutine()
    {
        while (true)
        {
            ShootFromAllGuns();
            yield return new WaitForSeconds(3f);
        }
    }

    private void ShootFromAllGuns()
    {
        foreach (var gun in guns)
        {
            gun.ShootBullet(facingRight, true); // <-- dùng biến facingRight
        }
    }
}
