using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSanity : MonoBehaviour
{
    [SerializeField] public int _maxSanity;
    [SerializeField] public int _currentSanity;

    private void Awake()
    {
        _currentSanity = _maxSanity;
    }

    public void SanityDecrease()
    {
        _currentSanity--;
    }
}
