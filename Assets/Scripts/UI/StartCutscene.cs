using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class StartCutscene : MonoBehaviour
{
    [SerializeField] private GameObject _cutscene;
    private VideoPlayer _vp;

    private void Awake()
    {
        _cutscene.SetActive(true);
        _vp = _cutscene.GetComponentInChildren<VideoPlayer>();
        _vp.Play();
        _vp.loopPointReached += OnVideoEnd;
        
    }



    private void OnVideoEnd(VideoPlayer vp)
    {
        StartCoroutine(LoadNextScene());
    }

    private IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(0);
        SceneManager.LoadSceneAsync(2);
    }
}