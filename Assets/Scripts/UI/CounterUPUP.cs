using UnityEngine;
using TMPro;

public class CounterUPUP : MonoBehaviour
{
    public TMP_Text counterText;
    public int collectedItems = 0;

    void Start()
    {
        UpdateCounterText();
    }

    public void AddItem()
    {
        collectedItems++;
        UpdateCounterText();
    }

    private void UpdateCounterText()
    {
        counterText.text =collectedItems + " / 11";
    }
}
