using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SanityBar : MonoBehaviour
{
    [SerializeField] private PlayerSanity playerSanity;
    [SerializeField] private Image totalSanityBar;
    [SerializeField] private Image currentSanityBar;

    private void Start()
    {
        totalSanityBar.fillAmount = (float)playerSanity._currentSanity / playerSanity._maxSanity;
    }

    private void Update()
    {
        currentSanityBar.fillAmount = (float)playerSanity._currentSanity / playerSanity._maxSanity;
    }
}
