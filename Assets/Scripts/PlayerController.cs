using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private int count;
    private int lives;
    public Text countText;
    public Text winText;
    public Text livesText;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        lives = 3;
        SetCountText();
        winText.text = "";
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive (false);
            count = count + 1;
            SetCountText();
            
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive (false);
            lives = lives - 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString ();
        livesText.text = "Lives: " + lives.ToString ();
        if (count == 6)
        {
            transform.position = new Vector3(60f, 0.5f, -30f);
        }
        
        if (count >= 14)
        {
            winText.text = "You Win! Game created by Casey Temple";
        }

        if (lives <= 0)
        {
            winText.text = "You Lost.";
            gameObject.SetActive (false);
        }
    }
}