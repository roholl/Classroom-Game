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
    private GameObject thought;

    // Start is called before the first frame update
    void Start()
    {
        pCon = GameObject.Find("TeacherSprite").GetComponent<PlayerController>();
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
                Destroy(this.thought);
            }
        }
    }


    private void thoughtCreate()
    {
        var rand = Random.Range(0, 2);
        this.thought = Instantiate(thoughtbubblePrefab, new Vector3(transform.position.x, transform.position.y +1), transform.rotation);
        var spriteToUse = this.paintSprite;
        Debug.Log("Rand:" + rand);
        switch (rand)
        {
            case 0:
                break;
            case 1:
                spriteToUse = this.markerSprite;
                break;
            default:
                break;
        }
           


        this.thought.GetComponent<thoughtBubble>().setWantedItem(spriteToUse);
        this.waitingOnItem = true;
    }
    
}
