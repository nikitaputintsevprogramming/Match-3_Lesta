using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastInColumn : MonoBehaviour
{
    public static float laserLength = 8f;
    public static int Count_Red_GemsInColumn = 0;
    public static int Count_Blue_GemsInColumn = 0;
    public static int Count_Green_GemsInColumn = 0;

    public static GameObject Red;
    public static  GameObject Blue;
    public static  GameObject Green;

    void Start()
    {
        Red = GameObject.Find("Red");
        Blue = GameObject.Find("Blue");
        Green = GameObject.Find("Green");
    }

    void FixedUpdate()
    {           
       RedColumn();
       BlueColumn();
       GreenColumn();  
    }

    public static bool RedColumn()
    {
        bool RedColumnIsReady = false;

        Debug.DrawRay(Red.GetComponent<Transform>().position, Vector2.down * laserLength, Color.white);
        RaycastHit2D[] hitColliders_Red = Physics2D.RaycastAll(Red.GetComponent<Transform>().position, Vector2.down, laserLength);

        for (int i = 0; i < hitColliders_Red.Length; i++)
        {
            Sprite sprite_Red = hitColliders_Red[i].collider.gameObject.GetComponent<SpriteRenderer>().sprite;
            if(sprite_Red == Red.GetComponent<SpriteRenderer>().sprite)
            {
                Count_Red_GemsInColumn++;
                if(Count_Red_GemsInColumn > 5)
                {
                    RedColumnIsReady = true;
                }
            }
            
        }
        Count_Red_GemsInColumn = 0;
        return RedColumnIsReady;
    }

    public static bool BlueColumn()
    {
        bool BlueColumnIsReady = false;

        Debug.DrawRay(Blue.GetComponent<Transform>().position, Vector2.down * laserLength, Color.white);
        RaycastHit2D[] hitColliders_Blue = Physics2D.RaycastAll(Blue.GetComponent<Transform>().position, Vector2.down, laserLength);

        for (int i = 0; i < hitColliders_Blue.Length; i++)
        {
            Sprite sprite_Blue = hitColliders_Blue[i].collider.gameObject.GetComponent<SpriteRenderer>().sprite;
            if(sprite_Blue == Blue.GetComponent<SpriteRenderer>().sprite)
            {
                Count_Blue_GemsInColumn++;
                if(Count_Blue_GemsInColumn > 5)
                {
                    BlueColumnIsReady = true;
                }
            }
            
        }
        Count_Blue_GemsInColumn = 0;
        return BlueColumnIsReady;
    }

    public static bool GreenColumn()
    {
        bool GreenColumnIsReady = false;

        Debug.DrawRay(Green.GetComponent<Transform>().position, Vector2.down * laserLength, Color.white);
        RaycastHit2D[] hitColliders_Green = Physics2D.RaycastAll(Green.GetComponent<Transform>().position, Vector2.down, laserLength);

        for (int i = 0; i < hitColliders_Green.Length; i++)
        {
            Sprite sprite_Green = hitColliders_Green[i].collider.gameObject.GetComponent<SpriteRenderer>().sprite;
            if(sprite_Green == Green.GetComponent<SpriteRenderer>().sprite)
            {
                Count_Green_GemsInColumn++;
                if(Count_Green_GemsInColumn > 5)
                {
                    GreenColumnIsReady = true;
                }
            }
            
        }
        Count_Green_GemsInColumn = 0;
        return GreenColumnIsReady;
    }
}
