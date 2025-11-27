using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class GtoBla_Manager : MonoBehaviour
{
    public int gtoBlaAmount;
    public TextMeshProUGUI gtoBlaText;
    public int gtoDifficultyCount;
    public int gtoBlaPower;
    public ScoreManager scoreManagerRef;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gtoDifficultyCount = 1;
        gtoBlaPower = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void buyListener()
    {
        if (scoreManagerRef.fameAmount > gtoDifficultyCount)
        {
            scoreManagerRef.fameAmount -= gtoDifficultyCount;
            scoreManagerRef.listenText.text = scoreManagerRef.fameAmount.ToString("00");
            gtoBlaAmount += 1;
            gtoBlaText.text = gtoBlaAmount.ToString("00");
            gtoDifficultyCount = Mathf.RoundToInt(gtoDifficultyCount * 2.5f);
            scoreManagerRef.addFameAmount += gtoBlaPower;
        }
    }
}
