using UnityEngine;
using System.Collections;

public class Interactor : MonoBehaviour {

	public float rayLength = 3.5f;
	Actor focusedObject;

	void Awake () {
	
	}
	
	void Start () {
	
	}
	
	void Update () {
		Ray ray = new Ray(transform.position, transform.forward);
		RaycastHit hitInfo;
		if (Physics.Raycast(ray, out hitInfo, rayLength)) {
			focusedObject = hitInfo.collider.GetComponent<Actor>();
		} else {
			focusedObject = null;
		}
		if (ActionMaster.GetActionDown(ActionCode.Interact)) {
			if (focusedObject) {
				focusedObject.Interact();
			}
		}
	}
}
