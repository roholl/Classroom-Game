using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartHealth : MonoBehaviour
{
    
    public Sprite heart;
    Image heartImage;
    int health = 1;
    int maxHealth = 1;
    public int heartSpacing = 5;

    List<GameObject> images = new List<GameObject>();
    RectTransform rt;

    public void Start()
    {
       // heartRenderer = gameObject.AddComponent<CanvasRenderer>();
       // heartRenderer.cullTransparentMesh = true;
    //    heartImage = gameObject.AddComponent<Image>();
    //    heartImage.sprite = this.heart;
/*

        Canvas parentCanvas = gameObject.GetComponentInParent<Canvas>();


        RectTransform rectangleTransform = gameObject.GetComponent<RectTransform>();

        rectangleTransform.transform.localScale = new Vector2(.5f, .5f);
        rectangleTransform.transform.position = new Vector2(0f + (rectangleTransform.rect.width / 2f), parentCanvas.renderingDisplaySize.y - (rectangleTransform.rect.height / 2f));

        //rectangleTransform.anchoredPosition = new Vector2(0f + (rectangleTransform.rect.width / 2f), 0f - (rectangleTransform.rect.height / 2f));
*/
        rt = this.gameObject.GetComponent<RectTransform>();


        for (int i = 0; i < health; i++)
        {
            GameObject go = new GameObject("gameobject");
            RectTransform rectTransform = go.AddComponent<RectTransform>();
            rectTransform.anchorMin = new Vector2(0, 0);
            rectTransform.anchorMax = new Vector2(0, 0);
            rectTransform.pivot = new Vector2(0.0f, 0.5f);
            rectTransform.localScale = new Vector2(1.0f, 1.0f);
            rectTransform.sizeDelta = new Vector2(this.heart.bounds.size.x * 100, this.heart.bounds.size.y * 100);


            Image image = go.gameObject.AddComponent<Image>();
            image.sprite = this.heart;
            images.Add(go);

            Debug.Log("width " + rectTransform.rect.width + "height " + rectTransform.rect.height);

            go.transform.SetParent(rt, false);

            go.GetComponent<RectTransform>().anchoredPosition = new Vector3(rectTransform.rect.width * i, gameObject.GetComponentInParent<RectTransform>().rect.height - (rectTransform.rect.height/2), 0);

        }


    }

    public void SetHealth(int health)
    {
        this.health = health;
        Debug.Log("yo yo yo yo");
        Debug.Log("Size:" + images.Count);
        foreach (GameObject goImage in images)
        {
            Debug.Log("we destroy");
            Destroy(goImage);
        }
        Debug.Log("Size after:" + images.Count);
       
       
        for (int i = 0; i < health; i++)
        {
            GameObject go = new GameObject("gameobject");
            RectTransform rectTransform = go.AddComponent<RectTransform>();
            rectTransform.anchorMin = new Vector2(0, 0);
            rectTransform.anchorMax = new Vector2(0, 0);
            rectTransform.pivot = new Vector2(0.0f, 0.5f);
            rectTransform.localScale = new Vector2(1.0f, 1.0f);
            rectTransform.sizeDelta = new Vector2(this.heart.bounds.size.x * 100, this.heart.bounds.size.y * 100);


            Image image = go.gameObject.AddComponent<Image>();
            image.sprite = this.heart;
            images.Add(go);

            Debug.Log("width " + rectTransform.rect.width + "height " + rectTransform.rect.height);

            go.transform.SetParent(rt, false);

            go.GetComponent<RectTransform>().anchoredPosition = new Vector3(rectTransform.rect.width * i, gameObject.GetComponentInParent<RectTransform>().rect.height - (rectTransform.rect.height / 2), 0);

        }
        


    }

    public void SetMaxhealth(int health)
    {
        this.maxHealth = health;
        this.health = health;
    }

    private void Update()
    {
     //   RectTransform rt = this.gameObject.GetComponent<RectTransform>();

       // images.Clear();
      //  images = new List<GameObject>();
        /*

                for (int i = 0; i < health; i++)
                {
                    GameObject go = new GameObject("gameobject");
                    RectTransform rectTransform = go.AddComponent<RectTransform>();
                    rectTransform.anchorMin = new Vector2(0, 0);
                    rectTransform.anchorMax = new Vector2(0, 0);
                    rectTransform.pivot = new Vector2(0.0f, 0.5f);
                    rectTransform.localScale = new Vector2(1.0f, 1.0f);
                    rectTransform.sizeDelta = new Vector2(this.heart.bounds.size.x * 100, this.heart.bounds.size.y * 100);


                    Image image = go.gameObject.AddComponent<Image>();
                    image.sprite = this.heart;
                    images.Add(go);

                    Debug.Log("width " + rectTransform.rect.width + "height " + rectTransform.rect.height);

                    go.transform.SetParent(rt, false);

                    go.GetComponent<RectTransform>().anchoredPosition = new Vector3(rectTransform.rect.width * i, gameObject.GetComponentInParent<RectTransform>().rect.height - (rectTransform.rect.height / 2), 0);

                }
            
            */
    }

}
