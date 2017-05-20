using UnityEngine;
using System.Collections;

public class BotaoTorreBasica : MonoBehaviour {
	[SerializeField]private Jogo jogo;

	//Define o ID para criação da torre basica
	public void SelecionaTorre()
	{
		jogo.GetComponent<Jogo> ();
		jogo.SetID (0);
	}
}
