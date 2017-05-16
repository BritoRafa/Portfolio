using UnityEngine;
using System.Collections;

public class Inimigo : MonoBehaviour {
	[SerializeField] private int Vida;

	void Start () {
		NavMeshAgent agente = GetComponent<NavMeshAgent> ();
		GameObject FimDoCaminho = GameObject.Find ("FimDoCaminho");
		agente.SetDestination (FimDoCaminho.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void RecebeDano(int dano)
	{
		Vida -= dano;
		if (Vida <= 0) 
		{
			Destroy (this.gameObject);
		}
	}
}
