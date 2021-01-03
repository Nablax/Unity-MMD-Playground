using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    Color alpha = new Color();
    bool done;

    public Image img;

    // Start is called before the first frame update
    void Start()
    {
        alpha = new Color(img.GetComponent<Image>().color.r,
                          img.GetComponent<Image>().color.g,
                          img.GetComponent<Image>().color.b,
                          1.0f);

        done = false;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(blink());
    }

    private IEnumerator blink()
    {
        if (done)
        {
            alpha.a = 0.0f;
            img.color = alpha;

            yield return new WaitForSeconds(1.5f);
            done = true;
        }
        else
        {
            alpha.a = 1.0f;
            img.color = alpha;
            yield return new WaitForSeconds(1.5f);
            done = false;
        }
    }
}
