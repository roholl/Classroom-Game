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
    public Sprite crayons;
    public Sprite scissors;

    private float randomTimerInterval;
    private float timeWaited;

    public int randomRangeHi;
    public int randomRangeLow;

    public GameObject thoughtbubblePrefab;

    private bool noItemWanted;
    private GameObject thought;
    private string itemWantedName;

    private float waitTimeForItem = 0;
    public float maxWaitTimeForItem = 10f;
    public int scoreFactor;

    private bool crying = false;

    private SpriteRenderer studentRenderer;



    // Start is called before the first frame update
    void Start()
    {
        this.studentRenderer = GetComponent<SpriteRenderer>();
        pCon = GameObject.Find("TeacherSprite").GetComponent<PlayerController>();
        inRange = false;
        noItemWanted = false;
        this.timeWaited = 0.0f;
        randomTimerInterval = Random.Range(randomRangeLow, randomRangeHi);
    }

    //Update is called once per frame
    void Update()
    {
        if(!crying)
        {

            var timePercent = 0f;
            if (!noItemWanted)
            {
                timeWaited += Time.deltaTime;
                this.studentRenderer.color = Color.white;
                if (timeWaited >= randomTimerInterval)
                {
                    timeWaited = 0.0f;
                    randomTimerInterval = Random.Range(randomRangeLow, randomRangeHi);
                    Debug.Log("The annoying child wants shit");
                    this.thoughtCreate();
                }
            }
            else
            {

                timePercent = waitTimeForItem / maxWaitTimeForItem;

                if (timePercent >= .75)
                {
                    this.studentRenderer.color = Color.red;
                }
                else if (timePercent >= .5)
                {
                    this.studentRenderer.color = Color.yellow;
                }
                else
                {
                    this.studentRenderer.color = Color.white;
                }
                

                waitTimeForItem += Time.deltaTime;
                if (waitTimeForItem >= maxWaitTimeForItem)
                {
                    this.itemReset(0);
                    this.studentRenderer.color = Color.blue;
                    this.crying = true;
                }
            }
            SpaceToInteract(timePercent);

        }
        else
        {
            pCon.updateScore(-1);
            this.SpaceToInteractCrying();
        }
        

        
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
    private void SpaceToInteract(float percentPoints)
    {
        if (Input.GetKeyDown(KeyCode.Space) && inRange == true)
        {
            Debug.Log("You pressed space in range of a student.");
            if ((pCon.holdingItem == true) && (pCon.itemHeldName == this.itemWantedName))
            {
                Debug.Log("You gave an item to the student.");
                pCon.itemGiven();

                var points = ((int)((1 - percentPoints) * 1000));
                this.itemReset(points);

            }
        }
    }

    private void SpaceToInteractCrying()
    {
        if (Input.GetKeyDown(KeyCode.Space) && inRange == true)
        {
            Debug.Log("You cheered up a student");

            this.crying = false;
            this.studentRenderer.color = Color.white;

        }
    }


    private void thoughtCreate()
    {
        var rand = Random.Range(0, 4);
        this.thought = Instantiate(thoughtbubblePrefab, new Vector3(transform.position.x, transform.position.y +1), transform.rotation);
        var spriteToUse = this.paintSprite;
        Debug.Log("Rand:" + rand);
        switch (rand)
        {
            case 0:
                itemWantedName = "Paint";
                break;
            case 1:
                itemWantedName = "Marker";
                spriteToUse = this.markerSprite;
                break;
            case 2:
                itemWantedName = "Crayons";
                spriteToUse = this.crayons;
                break;
            case 3:
                itemWantedName = "Scissors";
                spriteToUse = this.scissors;
                break;
            default:
                break;
        }
           


        this.thought.GetComponent<thoughtBubble>().setWantedItem(spriteToUse);
        this.noItemWanted = true;
    }


    private void itemReset(float points)
    {
        this.noItemWanted = false;
        Destroy(this.thought);
        waitTimeForItem = 0.0f;
        itemWantedName = "none";
        pCon.updateScore((int)points);
    }
    
}
