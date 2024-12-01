using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class EndCutscens : MonoBehaviour
{
    [SerializeField] public GameObject _endCutscene;
    [SerializeField] public CounterUPUP _counterUPUP;
    private VideoPlayer _vp;

    private void Awake()
    {
        _endCutscene.SetActive(false);
        _vp = _endCutscene.GetComponentInChildren<VideoPlayer>();
        _vp.loopPointReached += OnVideoEnd;
    }

    private void StartEndCutscene()
    {
        _endCutscene.SetActive(true);
        _vp.Play();
    }

    private void Update()
    {
        if (_counterUPUP.collectedItems == 12)
        {
            StartEndCutscene();
        }
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        StartCoroutine(ReturnToMainMenu());
    }

    private IEnumerator ReturnToMainMenu()
    {
        yield return new WaitForSeconds(0); 
        SceneManager.LoadScene("MainMenu"); 
    }
}