using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

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
    public float eventProductionAdd;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        addDelay = 1f;
        clickPower = 1;
        eventProductionAdd = 1f;
        eventObject.SetActive(false);
        StartCoroutine(addFame());
        StartCoroutine(EventCount()); 
    }

    public void listen()
    {
        fameAmount += clickPower;
        listenText.text = fameAmount.ToString("00");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeEventDelay()
    {
        eventScriptRef.ChooseEvent(eventType);
        eventType = Random.Range(0, 3);

        eventDelay = Random.Range(5, 6);

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
}
