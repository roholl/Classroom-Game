using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRb;
    float horizontal;
    float vertical;
    float playerSpeed = 5.0f;

    public bool holdingItem = false;
    
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        GetPlayerInput();
        DiscardItem();

    }

    void FixedUpdate()
    {
        MovePlayer();
    }
    public void GetPlayerInput()
    {
        //gets input from the arrow keys to be used in the MovePlayer method
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    public void MovePlayer()
    {
        //uses unity physics to move the attached rigidbody
        Vector2 position = playerRb.position;
        position.x = position.x + playerSpeed * horizontal * Time.deltaTime;
        position.y = position.y + playerSpeed * vertical * Time.deltaTime;

        playerRb.MovePosition(position);
    }
    public void DiscardItem()
    {
        if (Input.GetKeyDown(KeyCode.X) && holdingItem == true)
        {
            Debug.Log("You discarded your item.");
            holdingItem = false;

        }
    }
   
}
