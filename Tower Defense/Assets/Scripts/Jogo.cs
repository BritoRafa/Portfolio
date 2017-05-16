using UnityEngine;
using System.Collections;

public class Jogo : MonoBehaviour {
	[SerializeField]private GameObject[] TorrePrefab;
	[SerializeField]private GameObject gameOver;
	[SerializeField]private Jogador jogador;
	private CriadorDeTorre criador;
	public int ID;

	void Start()
	{
		criador = GetComponent <CriadorDeTorre> ();
		gameOver.SetActive (false);
	}
	void Update()
	{
		Torre torre = TorrePrefab[ID].GetComponent<Torre> ();
		//Caso o jogo ainda esteja rolando invoca o metodo para criar torres, se o jogo acabou ativa a tela de game over
		if (JogoAcabou ()) 
		{
			gameOver.SetActive (true);
		} 
		else 
		{		
			if (jogador.GetCredit () >= torre.GetCusto()) 
			{
				if (ClicarBotaoPrimario ()) {
					criador.ConstroiTorre ();
				}
			}
		}
	}
	//Cria torres quando clicar com o mouse
	private bool ClicarBotaoPrimario ()
	{
		return Input.GetMouseButtonDown (0);
	}
	//
	private bool JogoAcabou ()
	{
		return !jogador.EstaVivo ();
	}
	public void reiniciarJogo ()
	{
		Application.LoadLevel (Application.loadedLevel);
	}
	public void SetID(int id)
	{
		this.ID = id;
	}
	public int GetID()
	{
		return ID;
	}

}
