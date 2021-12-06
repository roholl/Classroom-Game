using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
    float playerSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
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
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    public void MovePlayer()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + playerSpeed * horizontal * Time.deltaTime;
        position.y = position.y + playerSpeed * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }

}
