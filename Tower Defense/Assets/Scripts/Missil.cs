using UnityEngine;
using System.Collections;

public class Missil : MonoBehaviour {
	private float Velocidade = 10;
	private Inimigo Alvo;
	[SerializeField] private int Dano;

	// Chama o método AutoDestruicao e define o tempo como 2
	void Start () {
		AutoDestruicao (2);
	}
	
	// Chama o método AlteraDirecao
	void Update () {
		Anda ();
		if(Alvo != null)
		{
			AlteraDirecao ();
		}
	}
	//Método responsável por fazer o míssil se mover
	private void Anda()
	{
		Vector3 PosicaoAtual = transform.position;
		Vector3 Deslocamento = transform.forward * Time.deltaTime * Velocidade;
		transform.position = PosicaoAtual + Deslocamento;
	}
	//
	//Método responsável por definir o alvo do míssil
	public void DefineAlvo(Inimigo inimigo)
	{
		Alvo = inimigo;
	}
	//
	//Método responsável por controlar o míssil em direção ao alvo
	private void AlteraDirecao()
	{
		Vector3 PosicaoAtual = transform.position;
		Vector3 PosicaoDoAlvo = Alvo.transform.position;
		Vector3 DirecaoDoAlvo = PosicaoDoAlvo - PosicaoAtual;
		transform.rotation = Quaternion.LookRotation (DirecaoDoAlvo);
	}
	//
	//Método responsável por causar dano ao objeto inimigo e destruir o objeto míssil quando eles colidirem
	void OnTriggerEnter (Collider ElementoColidido)
	{
		if (ElementoColidido.CompareTag ("Inimigo")) 
		{
			Destroy (this.gameObject);
			Inimigo inimigo = ElementoColidido.GetComponent<Inimigo>();
			inimigo.RecebeDano (Dano);
		}
	}
	//
	//Método responsável por destruir automaticamente o míssil após um tempo 
	//(método criado para destruir misseis que não atingiram nenhum alvo evitando assim o excesso de Gameobjects)
	private void AutoDestruicao (float segundos)
	{
		Destroy (this.gameObject, segundos);
	}
	//

}
