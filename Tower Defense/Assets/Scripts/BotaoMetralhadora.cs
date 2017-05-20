using UnityEngine;
using System.Collections;

public class BotaoMetralhadora : MonoBehaviour {
	[SerializeField]private Jogo jogo;

	//Define o ID para criação da torre com metralhadora
	public void SelecionaTorre()
	{
		jogo.GetComponent<Jogo> ();
		jogo.SetID (1);
	}
}
