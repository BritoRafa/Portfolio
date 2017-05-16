using UnityEngine;
using System.Collections;

public class BotaoMetralhadora : MonoBehaviour {
	[SerializeField]private Jogo jogo;

	public void SelecionaTorre()
	{
		jogo.GetComponent<Jogo> ();
		jogo.SetID (1);
	}
}
