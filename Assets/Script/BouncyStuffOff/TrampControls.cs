using UnityEngine;
using System.Collections;

public class TrampControls : MonoBehaviour {

	public float speed = 0.01f;

	private float currentXPos;
	private float currentRotation = 0f;
	private GameManager gM;
	
	// Use this for initialization
	void Start () {
		currentXPos = transform.position.x;
		gM =  GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>() as GameManager; 
	}
	
	// Update is called once per frame
	void Update () {
		float direction;
		if( Input.GetAxis("Horizontal") > 0 ){
			//Debug.Log ("Test Right");
			direction = 1f;
			currentRotation = -10f;
		}else if( Input.GetAxis("Horizontal") < 0 ){
			//Debug.Log ("Test Left");
			direction = -1f;
			currentRotation = 10f;
		}else{
			direction = 0f;
			currentRotation = 0f;
		}

		currentXPos = transform.position.x + (direction * speed);
		transform.position = new Vector3(currentXPos, transform.position.y, transform.position.z);
		transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.z, transform.rotation.y, currentRotation));
	}

	void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.tag == "Gift"){
			gM.PlayBounceAudio();
		}
	}
}
