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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        clickPower = 1;
        StartCoroutine(addFame());
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

    public IEnumerator addFame()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            fameAmount += addFameAmount;
            listenText.text = fameAmount.ToString("00");
        }
    }
}
