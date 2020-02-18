using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{
    // WORKING METHOD - X DIRECTION

    //private float length, startpos;
    //public GameObject cam;
    //public float parallaxEffect;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    startpos = transform.position.x;
    //    length = GetComponent<SpriteRenderer>().bounds.size.x;
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    float temp = (cam.transform.position.x * (1 - parallaxEffect));
    //    float dist = (cam.transform.position.x * parallaxEffect);
    //    transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

    //    Debug.Log("Temp: " + temp + " | Dist: " + dist + " | StartPos: " + startpos + " | Length: " + length);

    //    if (temp > startpos + length)
    //    {
    //        startpos += length;
    //    }
    //    else if (temp < startpos - length)
    //    {
    //        startpos -= length;
    //    }
    //}

    // ALTERNATE METHOD 1

    //private Vector2 length, startpos;
    //public GameObject cam;
    //public float parallaxEffect;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    startpos = transform.position;
    //    length = GetComponent<SpriteRenderer>().bounds.size;
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    Vector2 temp = (cam.transform.position * (1 - parallaxEffect));
    //    Vector2 dist = (cam.transform.position * parallaxEffect);
    //    transform.position = new Vector2((startpos + dist).x, (startpos + dist).y);

    //    Debug.Log("Temp: " + temp + " | Dist: " + dist + " | StartPos: " + startpos + " | Length: " + length);

    //    if (temp.x > (startpos - length).x)
    //    {
    //        startpos += length;
    //    }
    //    else if (temp.x < (startpos - length).x)
    //    {
    //        startpos -= length;
    //    }
    //}

    // ALTERNATE METHOD 2

    private float lengthx, lengthy, startposx, startposy;
    public GameObject cam;
    public float parallaxEffect;

    // Start is called before the first frame update
    void Start()
    {
        startposx = transform.position.x;
        startposy = transform.position.y;

        lengthx = GetComponent<SpriteRenderer>().bounds.size.x;
        lengthy = GetComponent<SpriteRenderer>().bounds.size.y;

        //Debug.Log(gameObject.name + " Position:" + transform.position);
        //Debug.Log("StartPosX: " + startposx + " | StartPosY: " + startposy + " | LengthX: " + lengthx + " | LengthY: " + lengthy);
    }

    // Update is called once per frame
    void Update()
    {
        float tempx = (cam.transform.position.x * (1 - parallaxEffect));
        float tempy = (cam.transform.position.y * (1 - parallaxEffect));
        float distx = (cam.transform.position.x * parallaxEffect);
        float disty = (cam.transform.position.y * parallaxEffect);
        transform.position = new Vector2(startposx + distx, startposy + disty);

        //Debug.Log(gameObject.name + " Position:" + transform.position);
        //Debug.Log("StartPosX: " + startposx + " | StartPosY: " + startposy + " | DistX: " + distx + " | DistY: " + disty + " | TempX: " + tempx + " | TempY: " + tempy);

        if (tempx > startposx + lengthx)
        {
            startposx += lengthx;
        }
        else if (tempx < startposx - lengthx)
        {
            startposx -= lengthx;
        }

        if (tempy > startposy + lengthy)
        {
            startposy += lengthy;
        }
        else if (tempy < startposy - lengthy)
        {
            startposy -= lengthy;
        }
    }
}
