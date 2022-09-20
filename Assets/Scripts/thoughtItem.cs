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
        var factor = 0.3f / thoughtImage.bounds.size.y;
        this.sr.transform.localScale = new Vector3(factor, factor);
     //   this.sr.transform.position = this.sr.transform.position + new Vector3(0, -0.15f, 0);
        this.sr.sprite = thoughtImage;
    }
}
