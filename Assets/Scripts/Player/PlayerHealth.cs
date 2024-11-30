using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public int _currentHealth;
    [SerializeField] public int _maxHealth;
    [SerializeField] private float _healthDecreaseInterval = 1.0f; 
    [SerializeField] private int _healthDecreaseAmount = 1;
    private PostProcessingManager _postProcessingManager;
    
    private float _timeSinceLastDecrease;
    
    
    private void Start()
    {
        _currentHealth = _maxHealth;
        _timeSinceLastDecrease = 0f;
        _postProcessingManager = FindObjectOfType<PostProcessingManager>();
        UpdatePostProcessing();
    }
    
   
    private void Update()
    {
        _timeSinceLastDecrease += Time.deltaTime;

        if (_timeSinceLastDecrease >= _healthDecreaseInterval)
        {
            DecreaseHealth(_healthDecreaseAmount);
            _timeSinceLastDecrease = 0f;
        }
       
    }
    
    
    private void DecreaseHealth(int amount)
    {
        _currentHealth -= amount;
        if (_currentHealth <= 0)
        {
            _currentHealth = 0;

            Destroy(gameObject);
           
        }

        UpdatePostProcessing();
    }
    public void Heal(int healAmount)
    {
        _currentHealth += healAmount;
        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }

        UpdatePostProcessing();
    }
    
    private void UpdatePostProcessing()
    {
        if (_postProcessingManager != null)
        {
            float healthPercentage = (float)_currentHealth / _maxHealth;
            Debug.Log($"Updating post-processing with health percentage: {healthPercentage}");
            _postProcessingManager.UpdateEffects(healthPercentage);
        }
        else
        {
            Debug.LogError("PostProcessingManager is not assigned.");
        }
    }
    

}
