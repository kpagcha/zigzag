﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Juego : MonoBehaviour {

	private int puntuacion;
	private int itemsTotales;
	private bool finJuego;
	private static int puntuacionTotal = 0;

	private GameObject bola;
	private GameObject plataforma;
	private Text textoPuntuacion;
	private GameObject textoGanar;
	private Text textoPuntuacionTotal;

	private Puntuacion puntuacionComponente;

	void Start() {
		puntuacion = 0;
		itemsTotales = GameObject.FindGameObjectsWithTag ("Item").Length;
		bola = GameObject.FindGameObjectWithTag ("Bola");
		plataforma = GameObject.FindGameObjectWithTag ("Plataforma");
		textoPuntuacion = GameObject.FindGameObjectWithTag ("TextoPuntuacion").GetComponent<Text>();
		textoGanar = GameObject.FindGameObjectWithTag ("TextoGanar");
		textoPuntuacionTotal = GameObject.Find ("Total").GetComponent<Text> ();

		textoPuntuacion.text = "Puntos: 0/" + itemsTotales.ToString();
		textoPuntuacionTotal.text = "Total: " + puntuacionTotal.ToString ();

		puntuacionComponente = GetComponent<Puntuacion> ();
		puntuacionComponente.cargarPuntuacionMaxima ();
	}

	void Update() {
		float alturaBola = bola.transform.position.y;
		float alturaPlataforma = plataforma.transform.position.y;
		if (alturaBola < alturaPlataforma && !finJuego) {
			reiniciarNivel();
		}
	}

	public void sumarPunto() {
		puntuacion++;
		textoPuntuacion.text = "Puntos: " + puntuacion.ToString() + "/" + itemsTotales.ToString();
	}

	public void siguienteNivel() {
		string nombreNivel = Application.loadedLevelName;
		int numeroNivel = int.Parse(nombreNivel.Substring (5)) + 1;

		puntuacionTotal += puntuacion;
		textoPuntuacionTotal.text = "Total: " + puntuacionTotal.ToString ();
		
		if (numeroNivel > 3) {
			ganarJuego ();
		} else {
			Application.LoadLevel ("Level" + numeroNivel.ToString ());
		}
	}

	public void reiniciarNivel() {
		Application.LoadLevel (Application.loadedLevelName);
	}

	void ganarJuego() {
		finJuego = true;
		textoGanar.GetComponent<Text>().text = "YOU WIN!!!!!";
		if (puntuacionComponente.recordNotSet() || puntuacionTotal > puntuacionComponente.getPuntuacionMaxima()) {
			puntuacionComponente.guardarPuntuacionMaxima(puntuacionTotal);
		}
	}
}
