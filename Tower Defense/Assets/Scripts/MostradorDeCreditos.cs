using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MostradorDeCreditos : MonoBehaviour {

	private Text CampoTexto;
	[SerializeField]private Jogador jogador;

	//Captura o componente Text do objeto
	void Start () {
		CampoTexto = GetComponent<Text> ();
	}
	
	//Define o texto do mostrador de créditos
	void Update () {
		CampoTexto.text = "Créditos: " + jogador.GetCredit();
	}
}
