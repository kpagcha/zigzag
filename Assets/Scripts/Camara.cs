using UnityEngine;
using System.Collections;

public class Camara : MonoBehaviour {

	public GameObject bola;

	private Vector3 offset;

	void Start() {
		bola = GameObject.FindGameObjectWithTag ("Bola");
		offset = transform.position - bola.transform.position;
	}

	void LateUpdate() {
		transform.position = bola.transform.position + offset;
	}
}
