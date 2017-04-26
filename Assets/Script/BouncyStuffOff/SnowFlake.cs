using UnityEngine;
using System.Collections;

public class SnowFlake : MonoBehaviour {

	void OnTriggerEnter(Collider target){
		if(target.gameObject.tag == "Ground" ){
			Destroy(gameObject);
		}
	}
}
