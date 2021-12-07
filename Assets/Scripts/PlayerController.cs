using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
    float playerSpeed = 5.0f;

    public bool holdingItem;
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        holdingItem = false;
    }

    void Update()
    {
        GetPlayerInput();
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
        Vector2 position = rigidbody2d.position;
        position.x = position.x + playerSpeed * horizontal * Time.deltaTime;
        position.y = position.y + playerSpeed * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }

}
