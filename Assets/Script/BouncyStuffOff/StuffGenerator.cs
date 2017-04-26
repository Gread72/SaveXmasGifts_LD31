using UnityEngine;
using System.Collections;

public class StuffGenerator : MonoBehaviour {
	// public variable
	public GameObject prefabItem; /// instance of prefab you want to create an instance of
	public int waitTime = 5;

	// private variable
	private Transform currentTransform;
	private bool tableReady = false;
	private GameManager gM;

	// Use this for initialization
	void Start () {
		currentTransform = gameObject.transform; // get transform of gameObject

		gM = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>() as GameManager; 
	}

	public void StartGenerating(){
		NextPrefabInstance();
	}

	void update(){
		currentTransform = gameObject.transform; // get transform of gameObject
	}

	IEnumerator CreateInstanceOfPrefab(){
		yield return new WaitForSeconds(waitTime); // yield set up a pause in execution and WaitForSeconds sets up the amount of seconds

		gM.giftsCount = gM.giftsCount + 1;

		if(gM.giftsCount <= gM.giftsTotal){
			Instantiate( prefabItem, new Vector3(currentTransform.position.x, 
			                                     currentTransform.position.y, currentTransform.position.z), Quaternion.Euler(0, -30, 0)); // create instance

			yield return new WaitForSeconds(waitTime); // yield set up a pause in execution and WaitForSeconds sets up the amount of seconds
			NextPrefabInstance();
		}else{
			gM.EndGame();
			this.gameObject.SetActive(false);
		}
	}

	void NextPrefabInstance(){
		StartCoroutine("CreateInstanceOfPrefab"); // to call a function within a animation or sequence of frames
	}
}
