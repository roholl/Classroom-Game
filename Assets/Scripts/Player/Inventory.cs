using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    public Sprite item;
    RectTransform rt;


    List<GameObject> images = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {

        rt = this.gameObject.GetComponent<RectTransform>();

        Canvas parentCanvas = gameObject.GetComponentInParent<Canvas>();



        GameObject go = new GameObject("gameobject");
        RectTransform rectTransform = go.AddComponent<RectTransform>();
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        rectTransform.pivot = new Vector2(0.0f, 0.5f);
        rectTransform.localScale = new Vector2(1.0f, 1.0f);
        rectTransform.sizeDelta = new Vector2(this.item.bounds.size.x * 100, this.item.bounds.size.y * 100);


        Image image = go.gameObject.AddComponent<Image>();
        image.sprite = this.item;
        images.Add(go);

        Debug.Log("width " + rectTransform.rect.width + "height " + rectTransform.rect.height);

        go.transform.SetParent(rt, false);

        go.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, (rectTransform.rect.height / 2), 0);// - (rectTransform.rect.height / 2), 0);


    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void updateInventory(Sprite itemSprite)
    {
        foreach (GameObject goImage in images)
        {
            Debug.Log("we destroy");
            Destroy(goImage);
        }

        
        if (itemSprite != null)
        {
            this.item = itemSprite;
            rt = this.gameObject.GetComponent<RectTransform>();

            Canvas parentCanvas = gameObject.GetComponentInParent<Canvas>();



            GameObject go = new GameObject("gameobject");
            RectTransform rectTransform = go.AddComponent<RectTransform>();
            rectTransform.anchorMin = new Vector2(0, 0);
            rectTransform.anchorMax = new Vector2(0, 0);
            rectTransform.pivot = new Vector2(0.0f, 0.5f);
            rectTransform.localScale = new Vector2(1.0f, 1.0f);
            rectTransform.sizeDelta = new Vector2(75,  75);


            Image image = go.gameObject.AddComponent<Image>();
            image.sprite = this.item;
            images.Add(go);

            Debug.Log("width " + rectTransform.rect.width + "height " + rectTransform.rect.height);

            go.transform.SetParent(rt, false);

            go.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, (rectTransform.rect.height / 2), 0);// - (rectTransform.rect.height / 2), 0);
        }

    }
}
