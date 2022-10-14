using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerGems : InitializeBoard
{
    public static SpriteRenderer GemPlace1;
    public static SpriteRenderer GemPlace2;
    public static int ClickCount {get; set;}
    public static GameObject[] GemsAround = new GameObject[4];

    void FixedUpdate()
    {
        if(ClickCount == 1)
        {
            Debug.DrawRay(GemPlace1.GetComponent<Transform>().position, Vector2.down * 1f, Color.red);
            RaycastHit2D[] hitDown = Physics2D.RaycastAll(GemPlace1.GetComponent<Transform>().position, Vector2.down, 1f);
            if(hitDown.Length > 1)
            {                
                GemsAround[0] = hitDown[1].collider.gameObject;
            }  
            else
            {
                GemsAround[0] = null;
            }          

            Debug.DrawRay(GemPlace1.GetComponent<Transform>().position, Vector2.up * 1f, Color.red);
            RaycastHit2D[] hitUp = Physics2D.RaycastAll(GemPlace1.GetComponent<Transform>().position, Vector2.up, 1f);
            if(hitUp.Length > 1)
            {                
                GemsAround[1] = hitUp[1].collider.gameObject;
            }  
            else
            {
                GemsAround[1] = null;
            } 

            Debug.DrawRay(GemPlace1.GetComponent<Transform>().position, Vector2.left * 1f, Color.red);
            RaycastHit2D[] hitLeft = Physics2D.RaycastAll(GemPlace1.GetComponent<Transform>().position, Vector2.left, 1f);
            if(hitLeft.Length > 1)
            {                
                GemsAround[2] = hitLeft[1].collider.gameObject;
            } 
            else
            {
                GemsAround[2] = null;
            } 

            Debug.DrawRay(GemPlace1.GetComponent<Transform>().position, Vector2.right * 1f, Color.red);
            RaycastHit2D[] hitRight = Physics2D.RaycastAll(GemPlace1.GetComponent<Transform>().position, Vector2.right, 1f);
            if(hitRight.Length > 1)
            {                
                GemsAround[3] = hitRight[1].collider.gameObject;
                
            }  
            else
            {
                GemsAround[3] = null;
            }                         
        }        
    }

    public static void ClickCountControl(GameObject Gem)
    {
        switch (ClickCount)
		{
			case 0:

                SelectGem1(Gem);
				ClickCount = 1;                
				break;

			case 1:
				
                SelectGem2(Gem);
                ClickCount = 2;        
				break;

			default:
				break;
		}
        if (ClickCount == 2)
        {
            SwapGems();
            Deselect();
            ClickCount = 0;
        }
    }

    public static void SelectGem1(GameObject Gem1)
    {
        GemPlace1 = Gem1.GetComponent<SpriteRenderer>();
        if (GemPlace1.sprite == Gems[5])
        {
            GemPlace1.color = ViewGems.EmptyColor;
        }
        else
        {
            GemPlace1.color = ViewGems.SelectedColor; 
        }  
    }

    public static void SelectGem2(GameObject Gem2)
    {
        GemPlace2 = Gem2.GetComponent<SpriteRenderer>();
        if (GemPlace2.sprite == Gems[5])
        {
            GemPlace2.color = ViewGems.EmptyColor; 
        }  
        else
        {
            GemPlace2.color = ViewGems.SelectedColor; 
        }  

        CheckGemAround();    
    }

    public static bool CheckGemAround()
    {
        // cheat-code part enabled
        // bool PlaceIsNear = false;
        // foreach(GameObject item in GemsAround)
        // {
        //     if(item == GemPlace2.gameObject)
        //     {
        //         PlaceIsNear = true;
        //     }
        // }
        // return PlaceIsNear;

        // cheat-code part disabled
        bool PlaceIsNear = false;
        foreach(GameObject item in GemsAround)
        {
            if(item == GemPlace2.gameObject)
            {
                if(GemPlace2.GetComponent<SpriteRenderer>().sprite == Gems[5])
                {
                    PlaceIsNear = true;
                }                
            }
        }
        return PlaceIsNear;        
    }

    public static void SwapGems()
    {
        if(CheckGemAround() == true)
        {
            Sprite tempSprite = GemPlace2.sprite; 
            GemPlace2.sprite = GemPlace1.sprite;
            GemPlace1.sprite = tempSprite;
        }   
    }

    public static void Deselect()
    {
        if(GemPlace1.sprite == Gems[5] && GemPlace2.sprite == Gems[5])
        {
            GemPlace1.GetComponent<SpriteRenderer>().color = ViewGems.EmptyColor; 
            GemPlace2.GetComponent<SpriteRenderer>().color = ViewGems.EmptyColor;           
        } 
        else if(GemPlace1.sprite == Gems[5] && GemPlace2.sprite != Gems[5])
        {            
            GemPlace1.GetComponent<SpriteRenderer>().color = ViewGems.EmptyColor;
            GemPlace2.GetComponent<SpriteRenderer>().color = ViewGems.NotSelectedColor;
        }
        else if(GemPlace1.sprite != Gems[5] && GemPlace2.sprite == Gems[5])
        {            
            GemPlace1.GetComponent<SpriteRenderer>().color = ViewGems.NotSelectedColor;
            GemPlace2.GetComponent<SpriteRenderer>().color = ViewGems.EmptyColor;
        }
        else
        {
            GemPlace1.GetComponent<SpriteRenderer>().color = ViewGems.NotSelectedColor;
            GemPlace2.GetComponent<SpriteRenderer>().color = ViewGems.NotSelectedColor;
        }
        
    }
}
    
    

