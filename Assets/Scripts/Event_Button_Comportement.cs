using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Event_Button_Comportement : MonoBehaviour
{

    public List<Sprite> eventButtonSpriteList;
    public Image eventButtonSprite;
    public string eventButtonTypeName;
    public ScoreManager scoreManaRef;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChooseEvent(int type)
    {
        eventButtonSprite.sprite = eventButtonSpriteList[type];

        if (type == 0)
        {
            scoreManaRef.addDelay = 10;
        }

        if (type == 1)
        {
            scoreManaRef.fameAmount = Mathf.RoundToInt(scoreManaRef.fameAmount * 1.5f);
        }

        if (type == 2)
        {
            StartCoroutine(ActiveEvent(0));
        }

        if (type == 3)
        {
            scoreManaRef.fameAmount += (scoreManaRef.addFameAmount / 6);
        }

        if (type == 4)
        {
            scoreManaRef.fameAmount -= (scoreManaRef.addFameAmount / 10);
        }

        if (type == 5)
        {
            StartCoroutine(ActiveEvent(1));
        }

        if (type == 6)
        {
            StartCoroutine(ActiveEvent(2));
        }

        if (type == 7)
        {
            StartCoroutine(ActiveEvent(3));
        }


    }

    public IEnumerator ActiveEvent(int timeType)
    {
        if (timeType == 0)
        {
            scoreManaRef.addDelay = 0.5f;
            yield return new WaitForSeconds(10);
            scoreManaRef.addDelay = 1f;
        }

        if (timeType == 1)
        {
            scoreManaRef.addFameAmount *= 5;
            yield return new WaitForSeconds(10);
            scoreManaRef.addFameAmount /= 5;
        }

        if (timeType == 2)
        {
            scoreManaRef.eventProductionAdd = 2f;
            yield return new WaitForSeconds(10);
            scoreManaRef.eventProductionAdd = 1f;
        }

        if (timeType == 3)
        {
            scoreManaRef.eventProductionAdd = 0.5f;
            yield return new WaitForSeconds(10);
            scoreManaRef.eventProductionAdd = 1f;
        }
    }

}
