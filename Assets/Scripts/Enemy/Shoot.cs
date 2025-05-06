using UnityEngine;

public class Shoots : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;

    void Start()
    {

    }

    public void ShootBullet(bool isFacingRight, bool isFacingDown)
    {
        if (isFacingRight)// bắn sang phải
        {
            transform.localPosition = new Vector3(-transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        }
        else // bắn sang trái 
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        }

        GameObject bulletInstance = Instantiate(bulletPrefab, this.transform.position, Quaternion.identity);
        if (isFacingDown) // bắn xuốngxuống
        {
            bulletInstance.GetComponent<Rigidbody2D>().AddForce(Vector2.down * 500 * (isFacingDown ? 1 : -1));
            return;
        }
        bulletInstance.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 500 * (isFacingRight ? 1 : -1));
    }
}