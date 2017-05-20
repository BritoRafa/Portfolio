using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MostradorDeVida : MonoBehaviour {

	private Text CampoTexto;
	[SerializeField]private Jogador jogador;
	//Captura o componente Text do objeto
	void Start () 
	{
		CampoTexto = GetComponent<Text> ();
	}
	//Define o texto do mostrador de vida
	void Update () 
	{
		CampoTexto.text = "Vida: " + jogador.GetVida ();
	}
}
