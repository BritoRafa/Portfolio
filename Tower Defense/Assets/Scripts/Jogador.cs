using UnityEngine;
using System.Collections;

public class Jogador : MonoBehaviour {

	[SerializeField] private int Vida;
	[SerializeField] private float Creditos;
	private float TempoDeDeposito = 3f;
	private float MomentoDoUltimoDeposito;

	void Update(){
		if (EstaVivo ()) 
		{
			GanhaCredit ();	
		}
	}

	//Controle da vida do jogador
	public int GetVida()
	{
		return Vida;
	}
	public void PerdeVida()
	{
		if (EstaVivo ()) 
		{
			Vida--;
		}
	}
	public bool EstaVivo ()
	{
		return Vida > 0;
	}
	//

	//Controle dos Créditos do jogador
	public float GetCredit()
	{
		return Creditos;
	}
	public void GanhaCredit()
	{
		float TempoAtual = Time.time;
		if (TempoAtual > MomentoDoUltimoDeposito + TempoDeDeposito) 
		{
			MomentoDoUltimoDeposito = TempoAtual;
			Creditos += 100;
		}
	}
	public void PerdeCredit(float valor)
	{
		Creditos -= valor;
	}
	//

}
