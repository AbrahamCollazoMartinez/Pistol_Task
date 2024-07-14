using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScene : MonoBehaviour
{
	[SerializeField]private string sceneName;
	public void LoadSceneByName()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
	}
}
