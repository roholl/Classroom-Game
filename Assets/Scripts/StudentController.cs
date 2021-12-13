using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentController : MonoBehaviour
{
    public bool inRange;
    public PlayerController pCon;
    // Start is called before the first frame update
    void Start()
    {
        inRange = false;
    }

    //Update is called once per frame
    void Update()
    {
        SpaceToInteract();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        inRange = true;
        Debug.Log("You are in range to talk.");
        
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        inRange = false;
        Debug.Log("You are out of range to talk.");
    }
    private void SpaceToInteract()
    {
        if (Input.GetKeyDown(KeyCode.Space) && inRange == true)
        {
            Debug.Log("You pressed space in range of a student.");
            if (pCon.holdingItem == true)
            {
                Debug.Log("You gave an item to the student.");
                pCon.holdingItem = false;
            }
        }
    }
    
}
