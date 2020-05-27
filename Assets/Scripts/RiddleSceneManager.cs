using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RiddleSceneManager : MonoBehaviour
{

	public abstract void playerTapped(GameObject player);
	public abstract void riddleTapped(GameObject riddle);
}
