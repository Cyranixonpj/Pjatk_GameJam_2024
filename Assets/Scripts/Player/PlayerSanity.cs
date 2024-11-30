using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSanity : MonoBehaviour
{
    [SerializeField] private int _maxSanity;
    [SerializeField] private int _currentSanity;

    private void Awake()
    {
        _currentSanity = _maxSanity;
    }

    public void SanityDecrease()
    {
        _currentSanity--;
    }
}
