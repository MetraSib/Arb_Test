﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuScene : MonoBehaviour
{
    [SerializeField] private GameObject coin;

    [SerializeField] private GameObject panel;

    [SerializeField] private AudioSource audioSource;

    void Start()
    {
        StartCoroutine(Spinner());
    }

    private IEnumerator Spinner()
    {
        yield return new WaitForSeconds(2f);
        audioSource.Play();
        coin.SetActive(false);
        panel.SetActive(false);
    }

    public void QuitGame() 
    {
        Application.Quit();
    }

    public void StartGame() 
    {
        SceneManager.LoadScene(1);
    }
}