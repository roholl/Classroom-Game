using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentController : MonoBehaviour
{
    public bool inRange;
    public PlayerController pCon;

    public Sprite paintSprite;
    public Sprite talkSprite;
    public Sprite markerSprite;
    public Sprite coloredPencilSprite;

    private float randomTimerInterval;
    private float timeWaited;

    public int randomRangeHi;
    public int randomRangeLow;

    public GameObject thoughtbubblePrefab;

    private bool waitingOnItem;

    // Start is called before the first frame update
    void Start()
    {
        inRange = false;
        waitingOnItem = false;
        this.timeWaited = 0.0f;
        randomTimerInterval = Random.Range(randomRangeLow, randomRangeHi);
    }

    //Update is called once per frame
    void Update()
    {
        if (!waitingOnItem)
        {
            timeWaited += Time.deltaTime;

            if (timeWaited >= randomTimerInterval)
            {
                timeWaited = 0.0f;
                randomTimerInterval = Random.Range(randomRangeLow, randomRangeHi);
                Debug.Log("The annoying child wants shit");
                this.thoughtCreate();
            }

        }


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
                pCon.itemGiven();
                this.waitingOnItem = false;
            }
        }
    }


    private void thoughtCreate()
    {
        Debug.Log("Position:" + transform.position);
        Debug.Log("Rotation:" + transform.rotation);
        Debug.Log("Name:" + thoughtbubblePrefab.name);
        var thought = Instantiate(thoughtbubblePrefab, new Vector3(transform.position.x, transform.position.y +1), transform.rotation);
        Debug.Log("Thought created:"+thought.name);
        this.waitingOnItem = true;
    }
    
}
