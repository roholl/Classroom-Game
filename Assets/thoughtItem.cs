using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thoughtItem : MonoBehaviour
{


    public SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setImage(Sprite thoughtImage)
    {
        var parent = gameObject.transform;
        this.sr.transform.localScale = new Vector3(0.1f, 0.1f);
        this.sr.sprite = thoughtImage;
    }
}
