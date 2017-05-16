using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MostradorDeCreditos : MonoBehaviour {

	private Text CampoTexto;
	[SerializeField]private Jogador jogador;
	void Start () {
		CampoTexto = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		CampoTexto.text = "Créditos: " + jogador.GetCredit();
	}
}
