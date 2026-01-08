using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class ScoreManager : MonoBehaviour
{
    public int fameAmount;
    public int clickPower;
    public TextMeshProUGUI listenText;
    public int addFameAmount;
    public int eventDelay;
    public GameObject eventObject;
    private int eventButtonXPos;
    private int eventButtonYPos;
    public RectTransform eventObjectTransformRef;
    public Event_Button_Comportement eventScriptRef;
    public int eventType;
    public float addDelay;
    public List<Event_List> eventTypeList;
    public Event_List currentEventType;
    public TextMeshProUGUI eventText;
    public Image eventImage;
    public float eventProductionAdd;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        addDelay = 1f;
        clickPower = 1;
        eventObject.SetActive(false);
        StartCoroutine(addFame());
        StartCoroutine(EventCount());
        eventType = Random.Range(0, 3);
        currentEventType = eventTypeList[eventType];
        eventText.text = currentEventType.eventText;
        eventImage.sprite = currentEventType.eventSprite;
        
        
    }

    public void listen()
    {
        fameAmount += clickPower;
        listenText.text = fameAmount.ToString("00");
        if (fameAmount < 0)
        {
            fameAmount = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        eventText.text = currentEventType.eventText;
        eventImage.sprite = currentEventType.eventSprite;
    }

    public void ChangeEventDelay()
    {
        
        ChooseEvent(eventType);
        eventType = Random.Range(0, 3);

        eventDelay = Random.Range(5, 6);
        currentEventType = eventTypeList[eventType];
        eventButtonXPos = Random.Range(-445, 400);
        eventButtonYPos = Random.Range(-230, 200);
        eventObjectTransformRef.anchoredPosition = new Vector2(eventButtonXPos, eventButtonYPos);
        

        StartCoroutine(EventCount());

    }

    public IEnumerator addFame()
    {
        while (true)
        {
            if (addDelay == 10)
            {
                yield return new WaitForSeconds(10);
                addDelay = 1;
            }
            else if (addDelay == 0.5f)
            {
                yield return new WaitForSeconds(0.5f);
            }
            else
            {
                yield return new WaitForSeconds(1);
            }
            fameAmount += addFameAmount;
            listenText.text = fameAmount.ToString("00");
        }
    }

    public IEnumerator EventCount()
    {
        yield return new WaitForSeconds(eventDelay);
        eventObject.SetActive(true);
    }

    public void ChooseEvent(int type)
    {
       

        if (type == 0)
        {
            addDelay = 10;
        }

        if (type == 1)
        {
            fameAmount = Mathf.RoundToInt(fameAmount * 1.5f);
        }

        if (type == 2)
        {
            StartCoroutine(ActiveEvent(0));
        }

        if (type == 3)
        {
            fameAmount += (addFameAmount * 10);
        }

        if (type == 4)
        {
            fameAmount -= (addFameAmount * 6);
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
            addDelay = 0.5f;
            yield return new WaitForSeconds(10);
            addDelay = 1f;
        }

        if (timeType == 1)
        {
            addFameAmount *= 5;
            yield return new WaitForSeconds(10);
            addFameAmount /= 5;
        }

        if (timeType == 2)
        {
            eventProductionAdd = 2f;
            yield return new WaitForSeconds(10);
            eventProductionAdd = 1f;
        }

        if (timeType == 3)
        {
            eventProductionAdd = 0.5f;
            yield return new WaitForSeconds(10);
            eventProductionAdd = 1f;
        }
    }
}
