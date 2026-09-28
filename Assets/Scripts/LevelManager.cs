using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    float enemySpawnTime = 3.0f;
    float enemySpawnCooldown = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        enemySpawnCooldown += Time.deltaTime;
        if (enemySpawnCooldown >= enemySpawnTime)
        {
            enemySpawnCooldown = 0.0f; // reseta o cronometro
            float posX = Random.Range(-20f, 20f);
            float posZ = Random.Range(-20f, 20f);
            Vector3 pos = new Vector3(posX, 1f, posZ);
            Instantiate(enemyPrefab, pos, Quaternion.Euler(0f, 0f, 0f));
        }
        
    }
}
