using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DeathUI : MonoBehaviour {

	public void NewGame(){
		SceneManager.LoadScene ("Main");
	}
}
