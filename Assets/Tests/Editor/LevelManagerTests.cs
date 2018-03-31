using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using Coin_Catch.Assets.Scripts.utility;

public class LevelManagerTests {
    public LevelManagerTests(){
        levelManager = new LevelManager(MockSpawnValues());
    }
	private LevelManager levelManager;

	[Test]
	public void StartsAtWaveZero(){
        var levelManager = new LevelManager(MockSpawnValues());
		Assert.AreEqual(0, levelManager.CurrentWave);

	}

/*
We want a wave to consist of a list of launchables.
 */
	[Test]
	public void CreatesWave(){

		//We want the first entry to be an list of launchables.
        levelManager.CreateWave();
        var wave = levelManager.Level[0];
        var list = new List<Launchable>();
        Assert.AreEqual(wave.GetType(),list.GetType());
        Assert.AreEqual(1, wave.Count);
        
	}
	[Test]
	public void CreatesLevelsByInt(){
		Debug.Log("Waiting two seconds");

		var numWaves = 4;
		levelManager.CreateLevel(numWaves);
		Assert.AreEqual(numWaves, levelManager.Level.Count);

	}
    private Vector3 MockSpawnValues(){
        return new Vector3(6,-10,0);
    }
	// void SetupScene(){
	// 	gameManager = Resources.Load<GameObject>("Assets/Prefabs/GameManager");
	// 	Debug.Log(gameManager);
	// 	gameManager.AddComponent<LevelManager>();
	// 	MonoBehaviour.Instantiate(gameManager);
	// }

}