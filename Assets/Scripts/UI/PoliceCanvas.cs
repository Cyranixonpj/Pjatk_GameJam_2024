using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PoliceCanvas : MonoBehaviour
{
    [SerializeField] private GameObject hud;
    public void Show()
    {
        hud.SetActive(false);
        gameObject.SetActive(true);
        StartCoroutine(WaitAndBackToMenu());
    }

    private IEnumerator WaitAndBackToMenu()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("MainMenu");
    }
}
