using UnityEngine;
using System.Collections;

public class BotaoTorreBasica : MonoBehaviour {
	[SerializeField]private Jogo jogo;

	void Start()
	{
		jogo.GetComponent<Jogo> ();
	}
	public void SelecionaTorre()
	{
		jogo.SetID (0);
	}
}
