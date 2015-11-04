using UnityEngine;
using System.Collections;

public class MovimientoBola : MonoBehaviour {
	
	public float velocidad = 5f;
	private Vector3 direccion = Vector3.left;
	private bool empezarJuego = false;

	private Rigidbody rb;
	private Juego juego;

	void Start() {
		rb = GetComponent<Rigidbody> ();
		juego = GameObject.FindGameObjectWithTag("Juego").GetComponent<Juego> ();
	}

	void Update () {
		if (!empezarJuego && Input.GetMouseButtonDown (0)) {
			empezarJuego = true;
		}
		if (empezarJuego) {
			//if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) {
			//if (Input.GetMouseButtonDown (0)) {
			if (Input.GetMouseButtonDown (0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)) {
				cambiarDireccionMovimiento ();
				if (direccion.Equals(Vector3.left)) {
					transform.localEulerAngles = new Vector3(0f, -90f, 0f);
				} else {
					transform.localEulerAngles = new Vector3(0f, 0f, 0f);
				}
			}
			rb.MovePosition (transform.position + direccion * velocidad * Time.deltaTime);
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Item"))
		{
			other.gameObject.SetActive (false);
			juego.sumarPunto();
		}
		if (other.gameObject.CompareTag ("FinNivel"))
		{
			juego.siguienteNivel();
		}
	}

	private void cambiarDireccionMovimiento() {
		if (direccion.Equals (Vector3.forward)) {
			direccion = Vector3.left;
		} else {
			direccion = Vector3.forward;
		}
	}
}
