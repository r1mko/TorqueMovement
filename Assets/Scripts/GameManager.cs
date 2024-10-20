using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int targetsCount;
    public Transform Targets;
    public GameObject vehicle;
    [SerializeField] private LevelChanger levelChanger;
    [SerializeField] private AudioSource popSound;
    [SerializeField] private GameObject vehicleParticle;
    [SerializeField] private AudioSource vehicleSound;

    private void Start()
    {
        targetsCount = Targets.transform.childCount;
    }

    private void Update()
    {
        if (targetsCount == 0)
        {
            levelChanger.FadeToNextLevel();
            vehicle.gameObject.SetActive(false);
        }
    }

    public void PlayPopSound()
    {
        popSound.Play();
    }

    public void PlayerDeath()
    {
        vehicleSound.Play();
        GameObject particle = Instantiate(vehicleParticle, vehicle.transform.position, vehicle.transform.rotation);
        Destroy(vehicle);
        Destroy(particle, 0.75f);
        StartCoroutine(ReloadScene());
    }


    IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
