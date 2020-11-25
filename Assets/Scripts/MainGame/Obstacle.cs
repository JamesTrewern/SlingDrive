using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public bool EnteredScreen = false;
    public Vector2 ScreenBounds;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.Rotate(new Vector3(0,0, Random.Range(0, 360)));
        ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        if (EnteredScreen)
        {
            CheckToDestroy();
        }
        CheckEnteredScreen();
    }

    void CheckToDestroy()
    {
        if (transform.position.x > ScreenBounds.x || transform.position.x < -ScreenBounds.x)
        {
            Destroy(this.gameObject);
        }
        if (transform.position.y > ScreenBounds.x || transform.position.y < -ScreenBounds.x)
        {
            Destroy(this.gameObject);
        }
    }

    void CheckEnteredScreen()
    {
        if (transform.position.x < ScreenBounds.x && transform.position.x > -ScreenBounds.x)
        {
            if (transform.position.y < ScreenBounds.y && transform.position.y > -ScreenBounds.y)
            {
                EnteredScreen = true;
            }
           
        }
    }
}

