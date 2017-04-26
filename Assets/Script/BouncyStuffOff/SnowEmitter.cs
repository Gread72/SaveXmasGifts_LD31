using UnityEngine;
using System.Collections;

public class SnowEmitter : MonoBehaviour {
	public GameObject prefabItem; /// instance of prefab you want to create an instance of
	public float waitTime = 1.5f;
	public float zPosition = -2.9f;
	public float speed = 0.01f;

	private Transform currentTransform;

	private bool changeMove = false;
	private float leftEdge = -4.0f; // unit of meters
	private float rightEdge = 4.0f; // unit of meters

	// Use this for initialization
	void Start () {
		currentTransform = gameObject.transform; // get transform of gameObject

		StartCoroutine("Emitter");
	}
	
	// Update is called once per frame
	void Update () {
		if(gameObject.transform.position.x >= leftEdge && changeMove == false){
			gameObject.transform.position = new Vector3(gameObject.transform.position.x - speed,
			                                            gameObject.transform.position.y);
		}else{
			changeMove = true; // if left edge is reached change the direction - right
		}
		
		if(gameObject.transform.position.x <= rightEdge && changeMove == true){
			gameObject.transform.position = new Vector3(gameObject.transform.position.x + speed,
			                                            gameObject.transform.position.y);
		}else{
			changeMove = false; // if right edge is reached change the direction - left
		}
	}

	IEnumerator Emitter (){
		//yield return new WaitForSeconds(waitTime); // yield set up a pause in execution and WaitForSeconds sets up the amount of seconds
		GameObject clone; 
		clone = Instantiate( prefabItem, 
		            new Vector3(currentTransform.position.x, 
		            currentTransform.position.y, zPosition), 
		            Quaternion.Euler(90, 0, 0)) as GameObject; // create instance
		//clone.rigidbody.velocity = new Vector3(1, 2, 0);
		//clone.rigidbody.AddForce(new Vector3(1, 1, 0));
		yield return new WaitForSeconds(waitTime); // yield set up a pause in execution and WaitForSeconds sets up the amount of seconds
		StartCoroutine("Emitter");
	}
}
