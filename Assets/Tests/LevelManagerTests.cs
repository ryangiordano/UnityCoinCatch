// using UnityEngine;
// using UnityEngine.TestTools;
// using NUnit.Framework;
// using System.Collections;

// public class LevelManagerTests {
// 	private GameObject gameManager;

// 	[Test]
// 	public void StartsAtWaveZero(){
		

// 	}

// /*
// We want a wave to consist of a list of launchables.
//  */
// 	[Test]
// 	public void CreatesWave(){
// 		//We want the waves to be incremented.
// 		//We want the first entry to be an array of launchable lists.
// 	}
// 	[UnityTest]
// 	public IEnumerator CreatesLevelsByInt(){
// 		Debug.Log("Waiting two seconds");
// 		yield return new WaitForSeconds(2);
// 		var numWaves = 4;
// 		var levelManager = gameManager.GetComponent<LevelManager>();
// 		levelManager.CreateLevel(numWaves);
// 		Assert.AreEqual(numWaves, levelManager.Level.Count);

// 	}
// 	// void SetupScene(){
// 	// 	gameManager = Resources.Load<GameObject>("Assets/Prefabs/GameManager");
// 	// 	Debug.Log(gameManager);
// 	// 	gameManager.AddComponent<LevelManager>();
// 	// 	MonoBehaviour.Instantiate(gameManager);
// 	// }

// }
