using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    float speed = 20f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, 0.5f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision col)
    {
        Destroy(gameObject);
    }
}
