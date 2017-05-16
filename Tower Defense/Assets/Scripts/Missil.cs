using UnityEngine;
using System.Collections;

public class Missil : MonoBehaviour {
	private float Velocidade = 10;
	private Inimigo Alvo;
	[SerializeField] private int Dano;

	// Use this for initialization
	void Start () {
		AutoDestruicao (2);
	}
	
	// Update is called once per frame
	void Update () {
		Anda ();
		if(Alvo != null)
		{
			AlteraDirecao ();
		}
	}
	private void Anda()
	{
		Vector3 PosicaoAtual = transform.position;
		Vector3 Deslocamento = transform.forward * Time.deltaTime * Velocidade;
		transform.position = PosicaoAtual + Deslocamento;
	}
	public void DefineAlvo(Inimigo inimigo)
	{
		Alvo = inimigo;
	}
	private void AlteraDirecao()
	{
		Vector3 PosicaoAtual = transform.position;
		Vector3 PosicaoDoAlvo = Alvo.transform.position;
		Vector3 DirecaoDoAlvo = PosicaoDoAlvo - PosicaoAtual;
		transform.rotation = Quaternion.LookRotation (DirecaoDoAlvo);
	}
	private void AutoDestruicao (float segundos)
	{
		Destroy (this.gameObject, segundos);
	}
	void OnTriggerEnter (Collider ElementoColidido)
	{
		if (ElementoColidido.CompareTag ("Inimigo")) 
		{
			Destroy (this.gameObject);
			Inimigo inimigo = ElementoColidido.GetComponent<Inimigo>();
			inimigo.RecebeDano (Dano);
		}
	}

}
