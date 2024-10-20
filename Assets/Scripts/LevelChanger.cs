using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;
    private int levelToLoad;
    [SerializeField] private int numberOfScenes;
    public ProgressController ProgressController;

    private void Start()
    {
        numberOfScenes = SceneManager.sceneCountInBuildSettings;
        //ProgressController.CurrentLevel = SceneManager.GetActiveScene().buildIndex;
    }
    public void FadeToNextLevel()
    {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

   /* public void RestartLevels()
    {
        SceneManager.LoadScene(0);
    }*/

    public void OnFadeComplete()
    {
        ProgressController.CurrentLevel++;
        PlayerPrefs.SetInt("Level", ProgressController.CurrentLevel);
        if (levelToLoad == numberOfScenes)
        {
            levelToLoad = 0;
            PlayerPrefs.SetInt("Level", 1);
        }
        SceneManager.LoadScene(levelToLoad);
    }
}
