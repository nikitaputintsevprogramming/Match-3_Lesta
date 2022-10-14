using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeBoard : MonoBehaviour
{
    public GameObject[] GemsPlaces;

    private SpriteRenderer PlaceRender;
    public static Sprite[] Gems;

    private Sprite CheckGem; 
    private int Choice;
    private int Red;
    private int Green;
    private int Blue;

    void Start()
    {
        GemsPlaces = new GameObject[19];
        Gems = new Sprite[3];

        AddGems();
    }

    void AddGems()
    {
        Gems = Resources.LoadAll<Sprite>("Gems");

        // Заполненные места
        for (int Count = 0; Count < 15; Count++)
        {
            GemsPlaces[Count] = GameObject.Find("Place" + " " + Count);
            CheckGemLimit();
            GemsPlaces[Count].GetComponent<SpriteRenderer>().sprite = CheckGem;
        }   

        // // Незаполненные места
        for (int Count = 15; Count < 19; Count++)
        {
            GemsPlaces[Count] = GameObject.Find("Place" + " " + Count);
        }       
    }

    void CheckGemLimit()
    {
        Choice = Random.Range(0, 3);

        switch (Choice)
            {
                case 0:
                    AddRedGem();
                    break;

                case 1:
                    AddGreenGem();
                    break;

                case 2:
                    AddBlueGem();
                    break;

                default:
                    break;
            }
    }

    void AddRedGem()
    {
        if (Red < 5)
        {
            CheckGem = Gems[4];
            Red++;
        }
        else 
        {
            CheckGemLimit();
        }
        
    }

    void AddGreenGem()
    {
        if(Green < 5)
        {
            CheckGem = Gems[1];
            Green++;
        }
        else
        {
            CheckGemLimit();
        }
    }

    void AddBlueGem()
    {
        if(Blue < 5)
        {
            CheckGem = Gems[0];
            Blue++;
        }
        else 
        {
            CheckGemLimit();
        }
    }
}
