using UnityEngine;
using System.Collections;

public class Inimigo : MonoBehaviour {
	[SerializeField] private int Vida;

	void Start () {
		MoveInimigo ();
	}
	//Controle da vida do inimigo
	public void RecebeDano(int dano)
	{
		Vida -= dano;
		if (Vida <= 0) 
		{
			Destroy (this.gameObject);
		}
	}
	//
	//Método responsável por mover o inimigo pelo caminho
	private void MoveInimigo()
	{
		UnityEngine.AI.NavMeshAgent agente = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		GameObject FimDoCaminho = GameObject.Find ("FimDoCaminho");
		agente.SetDestination (FimDoCaminho.transform.position);
	}
	//
}
