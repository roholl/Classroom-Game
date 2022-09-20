using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thoughtBubble : MonoBehaviour
{
    // Start is called before the first frame update

    public Sprite wantedItem;
    public thoughtItem thought;
    bool bubbleUpdated;


    void Start()
    {
        bubbleUpdated = false;
        thought = GetComponentInChildren<thoughtItem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(thought != null && !this.bubbleUpdated) 
        {
            this.bubbleUpdated = true;
            thought.setImage(wantedItem);
        }
    }


    public void setWantedItem(Sprite wantedItem)
    {
        this.wantedItem = wantedItem;
    }
}
