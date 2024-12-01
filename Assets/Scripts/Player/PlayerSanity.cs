using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSanity : MonoBehaviour
{
    [SerializeField] public int _maxSanity;
    [SerializeField] public int _currentSanity;
    [SerializeField] private GameObject overdoseCanvas;

    private void Awake()
    {
        _currentSanity = _maxSanity;
    }

    public void SanityDecrease()
    {
        _currentSanity--;
        if (_currentSanity <= 0)
        {
            _currentSanity = 0;
            overdoseCanvas.GetComponent<OverdoseCanvas>().Show();
        }
    }
}
