using System;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    float speed = 10f;
    float turnSpeed = 100f;
    public float mouseSensibility = 1500f;
    float rotationX = 0f;
    public Transform cam;
    public Transform gun;
    public GameObject bulletPrefab;
    public Transform gunTip;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Pega o movimento do mouse nos eixos X (esquerda/direita) e Y (cima/baixo)
        float mouseX = Input.GetAxis("Mouse X") * mouseSensibility * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensibility * Time.deltaTime;

        // Gira o CORPO do jogador para a esquerda/direita (no eixo Y)
        transform.Rotate(Vector3.up * mouseX);

        rotationX -= mouseY;
        // Limita a rotação da câmera
        rotationX = Mathf.Clamp(rotationX, -60f, 60f);

        // Gira a câmera para cima/baixo
        cam.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        gun.localRotation = Quaternion.Euler(rotationX, 0f, 0f);

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, 0, -speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("clicou");
            GameObject b = Instantiate(bulletPrefab, gunTip.position, gunTip.rotation);
        }
    }
}
