using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public bool inRange;
    public PlayerController pCon;
    public SpriteRenderer itemRenderer;
    public string itemName;
    // Start is called before the first frame update
    void Start()
    {
        itemRenderer = gameObject.GetComponent<SpriteRenderer>();
        inRange = false; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && inRange == true)
        {
            
            pCon.holdingItem = true;
            pCon.itemObtained(itemRenderer.sprite, itemName);
            Debug.Log("You are now holding an item.");

        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        inRange = true;
        Debug.Log("You are in range to pick up an item.");

    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        inRange = false;
        Debug.Log("You are out of range to pick up an item.");
    }
    
}
