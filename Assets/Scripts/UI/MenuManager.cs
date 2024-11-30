using UnityEditor;
using UnityEngine;


public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _mainView;
    [SerializeField] private GameObject _tutorialView;
    [SerializeField] private GameObject _creditsView;


    private void Awake()
    {
        
        _mainView.SetActive(true);
        _tutorialView.SetActive(false);
        _creditsView.SetActive(false);
    }
    
    public void TutorialClicked()
    {
        _mainView.SetActive(false);
        _tutorialView.SetActive(true);
        _creditsView.SetActive(false);
    }
    public void CreditsClicked()
    {
        _mainView.SetActive(false);
        _tutorialView.SetActive(false);
        _creditsView.SetActive(true);
    }
    
    public void returnClicked()
    {
        _mainView.SetActive(true);
        _tutorialView.SetActive(false);
        _creditsView.SetActive(false);
    }
    
    public void ExitClicked()
    {
        
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
