using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    float speed = 20f;
    float damage = 35.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, 0.5f); // (0.5f) limita o tempo de existência (distância) do tiro
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision col)
    {
        //Debug.Log(col.gameObject.name);
        if (col.transform.CompareTag("Enemy"))
        {
            //Debug.Log("Acertei o inimigo");
            //Destroy(col.gameObject);
            col.transform.GetComponent<Enemy>().TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
