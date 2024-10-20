using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProgressController : MonoBehaviour
{
    public int CurrentLevel;


    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Level"))
        {
            PlayerPrefs.SetInt("Level", 1);
        }
    }

    private void Start()
    {
        CurrentLevel = PlayerPrefs.GetInt("Level");
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(CurrentLevel);
    }

    public void DeleteAllLevel()
    {
        PlayerPrefs.DeleteKey("Level");
    }
}
