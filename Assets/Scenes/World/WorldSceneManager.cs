using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class WorldSceneManager : RiddleSceneManager
{

	private GameObject riddle;
	private AsyncOperation loadScene;

	public override void playerTapped(GameObject player) {

	}

	public override void riddleTapped(GameObject riddle) {
		//SceneManager.LoadScene(RiddleConstant.SCENE_RIDDLE, LoadSceneMode.Additive) 
		List<GameObject> list = new List<GameObject>();
		list.Add(riddle);
		SceneTransitionManager.Instance.GoToScene(RiddleConstant.SCENE_RIDDLE, list);
	}
}
