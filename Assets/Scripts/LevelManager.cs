using System.Collections;
using System.Collections.Generic;
using Coin_Catch.Assets.Scripts.utility;
using UnityEngine;

public class LevelManager
{
    private BombFactory bombFactory;
    private CoinFactory coinFactory;
    public Vector3 SpawnValues;
    public int CurrentWave;
    public IList<IList<Launchable>> Level;
    // Use this for initialization
    public LevelManager(Vector3 spawnValues)
    {
        this.SpawnValues = spawnValues;
        Level = new List<IList<Launchable>>();
        bombFactory = new BombFactory();
        coinFactory = new CoinFactory();
    }

    public void IncrementWave()
    {
        this.CurrentWave++;
    }

    public IList<Launchable> GetWave(int index)
    {
        return this.Level[index];
    }

    public void CreateLevel(int waveNumber)
    {
        for (int i = 0; i < waveNumber; i++)
        {
            this.CreateWave();
        }
    }
    /**
    This method needs to change when we start generating levels from actual data and not randomly.
     */
    public void CreateWave()
    {
        var wave = new List<Launchable>();
        for (int i = 0; i < 10; i++)
        {
            var item = i % 2 == 0 ? this.CreateCoin(100, this.RandomSpawnPoint()) : this.CreateBomb(100, this.RandomSpawnPoint());

            wave.Add(item);
        }
        this.Level.Add(wave);
    }

    private Launchable CreateCoin(int score, Vector3 spawnValues)
    {
        var coin = coinFactory.CreateLaunchable(score, spawnValues);
        return coin;
    }
    private Launchable CreateBomb(int score, Vector3 spawnValues)
    {
        var bomb = bombFactory.CreateLaunchable(score, spawnValues);
        return bomb;
    }
    private Vector3 RandomSpawnPoint()
    {
        return new Vector3(Random.Range(-SpawnValues.x, SpawnValues.x), SpawnValues.y, SpawnValues.z);
    }
}
