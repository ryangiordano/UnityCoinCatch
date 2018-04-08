using System.Collections;
using System.Collections.Generic;
using Coin_Catch.Assets.Scripts.utility;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject coin;
    public GameObject bomb;
    public float startWait;
    public float waveWait;
    public float spawnWait;
    private int score;
    private int wave;
    public Text scoreText;
    public Text roundText;
    public GameObject explosion;
    public LevelManager levelManager;
    public GameObject heartContainer;
    public HeartContainerController heartContainerController;
    public CoinRushController coinRushController;
    public GameObject coinRushContainer;
    private bool levelEnded;
    public Vector3 SpawnValues;

    private bool roundStarted;

    // Use this for initialization
    void Start()
    {
        this.levelManager = new LevelManager(SpawnValues);
        coinRushController=  coinRushContainer.GetComponent<CoinRushController>();
        heartContainerController = heartContainer.GetComponent<HeartContainerController>();
        this.roundStarted = false;
        this.levelEnded = false;
        UpdateWave();
        UpdateScore();
        levelManager.CreateLevel(10);
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
        if (!this.levelEnded && this.levelManager.CurrentWave >= this.levelManager.Level.Count && GameObject.FindGameObjectsWithTag("Coin").Length == 0)
        {
            this.levelEnded = true;
            StartCoroutine(GameEnd());
        }
        if(!this.levelEnded && this.heartContainerController.CurrentHealth <=0){
            this.levelEnded = true;
            StartCoroutine(GameEnd());
        }

    }
    private IEnumerator GameEnd()
    {
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

        for (int i = 0; i < wave.Count; i++)
        {
            var launchable = levelManager.Level[currentWave][i];

            InstantiateItem(launchable);
            yield return new WaitForSeconds(spawnWait);
        }
        this.roundStarted = true;
        yield break;

    }
    private void InstantiateItem(Launchable launchable)
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-launchable.LaunchPoint.x, launchable.LaunchPoint.x), launchable.LaunchPoint.y, launchable.LaunchPoint.z);

        Quaternion spawnRotation = Quaternion.identity;
        switch (launchable.LaunchType)
        {
            case LaunchType.Coin:
                Instantiate(coin, spawnPosition, spawnRotation);
                break;
            case LaunchType.Bomb:
                Instantiate(bomb, spawnPosition, spawnRotation);
                break;
            default:
                Debug.Log("Type not available, defaulting to coin.");
                Instantiate(coin, spawnPosition, spawnRotation);
                break;
        }



    }
    public void IncrementScore(int score)
    {
        
        coinRushController.IncrementMeter();
        this.score += BonusMultiplier.GetScore(score);
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
    //
    // Summary:
    //     Update UI with current wave.
    public void UpdateWave()
    {
        this.roundText.text = "Round: " + this.levelManager.CurrentWave;
    }
    public void SetGlobalScore()
    {
        StateManager.PlayerScore = this.score;
    }
    public void BombTapped(){
        coinRushController.ResetBar();
        heartContainerController.RemoveHeart();

    }
    public int GetGlobalScore()
    {
        return StateManager.PlayerScore;
    }
}
