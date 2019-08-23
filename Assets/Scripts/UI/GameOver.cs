using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }
    public void ExitButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
