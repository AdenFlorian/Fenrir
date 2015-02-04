using UnityEngine;
using System.Collections;

public class CampFire : Actor {

	public bool isLit = false;
	public GameObject fx;
	public ParticleSystem[] particleSystems;

	void Awake () {
	}

	void Start() {
		if (isLit) {
			Activate();
		} else {
			Deactivate();
		}
	}
	
	void Update () {
	
	}

	public void Switch() {
		if (isLit) {
			Deactivate();
		} else {
			Activate();
		}
	}

	public void Activate() {
		fx.SetActive(true);
		foreach (ParticleSystem partSys in particleSystems) {
			partSys.enableEmission = true;
		}
		isLit = true;
	}

	public void Deactivate() {
		fx.SetActive(false);
		foreach (ParticleSystem partSys in particleSystems) {
			partSys.enableEmission = false;
		}
		isLit = false;
	}

	public override void Interact() {
		Switch();
	}
}