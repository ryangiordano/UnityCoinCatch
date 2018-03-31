﻿using System.Collections;
using System.Collections.Generic;
using Coin_Catch.Assets.Scripts.utility;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject coin;
    public float startWait;
    public float waveWait;
    public float spawnWait;
    private int score;
    private int wave;
    public Text scoreText;
    public Text roundText;
    public GameObject explosion;
    public LevelManager levelManager;
    private bool levelEnded;
    public Vector3 SpawnValues;

    private bool roundStarted;

    // Use this for initialization
    void Start()
    {
        this.levelManager = new LevelManager(SpawnValues);
        this.roundStarted = false;
        this.levelEnded = false;
        UpdateWave();
        UpdateScore();
        // StartCoroutine(StartLevel());
        
        Debug.Log(levelManager.CurrentWave);
        levelManager.CreateLevel(3);
        
        
        StartCoroutine(StartGame());



    }

    // Update is called once per frame
    void Update()
    {
        if (this.roundStarted && GameObject.FindGameObjectsWithTag("Coin").Length == 0)
        {
            this.roundStarted = false;
            StartCoroutine(NextWave());
        }
        if(!this.levelEnded && this.levelManager.CurrentWave >= this.levelManager.Level.Count && GameObject.FindGameObjectsWithTag("Coin").Length == 0){
            this.levelEnded = true;
            StartCoroutine(GameEnd());
        }

    }
    private IEnumerator GameEnd(){
        yield return new WaitForSeconds(waveWait);
        this.SetGlobalScore();
        SceneManager.LoadScene("End");
        yield break;
    }
    private IEnumerator StartGame()
    {
        yield return new WaitForSeconds(waveWait);
        
        StartCoroutine(NextWave());
        yield break;

    }

    private IEnumerator NextWave()
    {
        yield return new WaitForSeconds(waveWait);
        
        var currentWave = levelManager.CurrentWave;
        var wave = levelManager.Level[currentWave];
        this.levelManager.IncrementWave();
        this.UpdateWave();
        //add game objects t
        for (int i = 0; i < wave.Count; i++)
        {
            var launchable = levelManager.Level[currentWave][i];
            Vector3 spawnPosition = new Vector3(Random.Range(-launchable.LaunchPoint.x, launchable.LaunchPoint.x), launchable.LaunchPoint.y, launchable.LaunchPoint.z);

            Quaternion spawnRotation = Quaternion.identity;

            var item = Instantiate(coin, spawnPosition, spawnRotation);
            yield return new WaitForSeconds(spawnWait);
        }
        this.roundStarted = true;
        yield break;

    }

    public void IncrementScore(int score)
    {

        this.score += score;
        UpdateScore();

    }
    public void IncrementWave()
    {
        UpdateWave();
    }
    public void UpdateScore()
    {
        this.scoreText.text = "Score: " + score;
    }
    public void UpdateWave()
    {
        this.roundText.text = "Round: " + this.levelManager.CurrentWave;
    }
    public void SetGlobalScore(){
        StateManager.PlayerScore = this.score;
    }
    public int GetGlobalScore(){
        return StateManager.PlayerScore;
    }
}