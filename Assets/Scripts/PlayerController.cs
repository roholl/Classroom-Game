using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRb;
    float horizontal;
    float vertical;
    float playerSpeed = 5.0f;

    public bool holdingItem = false;
    public Sprite heldItem;
    public string itemHeldName;

    private Inventory userInterface;
    public Text scoreText;
    public Canvas userInterfaceCanvas;

    private int playerScore = 0;
    
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        userInterface = userInterfaceCanvas.GetComponentInChildren<Inventory>();
        itemHeldName = "none";
        
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
            this.removeItem();

        }
    }
    
    public void itemObtained(Sprite itemToHold, string itemName)
    {
        Debug.Log("Player: spite update.");
        this.heldItem = itemToHold;
        this.itemHeldName = itemName;
        userInterface.updateInventory(itemToHold);
    }

    public void itemGiven()
    {
        this.removeItem();
    }

    private void removeItem()
    {
        Debug.Log("You discarded your item.");
        userInterface.updateInventory(null);
        holdingItem = false;
        itemHeldName = "none";

    }

    public void updateScore(int points)
    {
        this.playerScore += points;
        this.scoreText.text = this.playerScore.ToString();
    }
   
}
