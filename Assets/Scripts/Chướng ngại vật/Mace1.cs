using UnityEngine;

public class Mace1 : MonoBehaviour
{
    public float speed = 1f;
    public float range = 3f;
    float staringY; // Vị trí ban đầu của mace
    int dir = 1;
    void Start()
    {
        staringY = transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime * dir);
        if (transform.position.y > staringY + range)
        {
            dir = -1;
        }
        if (transform.position.y < staringY - range)
        {
            dir = 1;
        }
    }
}