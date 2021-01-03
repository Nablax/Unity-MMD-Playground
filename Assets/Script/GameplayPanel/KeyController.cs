using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyController : MonoBehaviour
{

    private Image image;
    public Sprite defaultSprite, pressedSprite;
    public KeyCode key;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>() as Image;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            if (image.sprite != null)
                image.sprite = pressedSprite;
            else
                image.color = new Vector4(image.color.r, image.color.g, image.color.b, image.color.a + 50);
        }
        else if (Input.GetKeyUp(key))
        {
            if (image.sprite != null)
                image.sprite = defaultSprite;
            else
                image.color = new Vector4(image.color.r, image.color.g, image.color.b, image.color.a - 50);
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
