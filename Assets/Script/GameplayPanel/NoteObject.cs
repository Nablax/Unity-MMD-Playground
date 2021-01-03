using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{

    public bool pressable;
    public float tempo = 30.0f;

    public KeyCode key;
    public Camera attachedCamera;
    public RectTransform rt;

    // Start is called before the first frame update
    void Start()
    {
        tempo /= 60.0f;
        attachedCamera = attachedCamera.GetComponent<Camera>() as Camera;
        rt = rt.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = camera.WorldToScreenPoint(transform.position);
        transform.position -= new Vector3(0, 
                                          tempo * Time.deltaTime * Mathf.Cos(attachedCamera.transform.rotation.y), 
                                          0);
        transform.position = new Vector3(transform.position.x, transform.position.y, rt.transform.position.z);

        rt.anchoredPosition3D = new Vector3(rt.anchoredPosition3D.x, rt.anchoredPosition3D.y, 0);

        if (Input.GetKeyDown(key))
        {
            if (pressable == true)
            {
                gameObject.SetActive(false);

                GameManager_stage.instance.noteHit();
                Destroy(gameObject);
                GameManager_stage.currentNoteCount--;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Activator")
        {
            pressable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Activator")
        {
            pressable = false;

            GameManager_stage.instance.noteMissed();
            Destroy(gameObject);
            GameManager_stage.currentNoteCount--;
        }
    }
}
