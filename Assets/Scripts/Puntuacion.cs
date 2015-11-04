using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Puntuacion : MonoBehaviour {

	private static Text record;

	void Start()
	{
		record = GameObject.Find ("Record").GetComponent<Text> ();
		cargarPuntuacionMaxima ();
	}

	public void guardarPuntuacionMaxima(int puntuacion)
	{
		PlayerPrefs.SetString ("record", puntuacion.ToString());
	}

	public void cargarPuntuacionMaxima()
	{
		if (!recordNotSet()) {
			record.text = "Record: " + PlayerPrefs.GetString ("record");
		}
	}

	public int getPuntuacionMaxima()
	{
		return int.Parse (PlayerPrefs.GetString ("record"));
	}

	public bool recordNotSet()
	{
		return !PlayerPrefs.HasKey ("record");
	}
}
