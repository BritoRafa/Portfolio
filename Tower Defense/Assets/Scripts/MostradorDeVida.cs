using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MostradorDeVida : MonoBehaviour {

	private Text CampoTexto;
	[SerializeField]private Jogador jogador;
	void Start () 
	{
		CampoTexto = GetComponent<Text> ();
	}
	

	void Update () 
	{
		CampoTexto.text = "Vida: " + jogador.GetVida ();
	}
}
