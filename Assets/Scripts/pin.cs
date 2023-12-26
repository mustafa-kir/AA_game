using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pin : MonoBehaviour
{
    private bool isPanned = false;
    public float speed = 1f;
    public Rigidbody2D rb;
    public gameManager gameManager;
   
    private void Start()
    {
        gameManager = FindObjectOfType<gameManager>();
    }
    private void Update()
    {
        if (!isPanned)
        {
            rb.MovePosition(rb.position + Vector2.up * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Rotator")
        {
            transform.SetParent(collision.transform);
            if (collision.GetComponent<rotator>().changeDirection)
            {
                collision.GetComponent<rotator>().speed *= -1; 
            }
            isPanned = true;
            gameManager.scoreAdd();
        }
        if (collision.tag == "Pin")
        {
            //END Game
            gameManager.EndGame();
        }
    }
}
