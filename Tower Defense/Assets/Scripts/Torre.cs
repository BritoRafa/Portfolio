using UnityEngine;
using System.Collections;

public class Torre : MonoBehaviour {

	public GameObject projetilPrefab;
	[Range (0,3)]
	[SerializeField]protected float TempoDeRecarga = 1f;
	protected float MomentoDoUltimoDisparo;
	[SerializeField] protected float RaioDeAlcance;
	[SerializeField] protected GameObject canhao;
	protected Inimigo alvo;
	[SerializeField] protected float Custo;

	//Método Update é chamado uma vez a cada frame
	void Update () {
		alvo = EscolheAlvo();
		if (alvo != null) 
		{
			Mira ();
			Atira (alvo);
		}
	}
	//Método Responsável por fazer a Torre atirar
	private void Atira(Inimigo inimigo)
	{
		float TempoAtual = Time.time;
		if (TempoAtual > MomentoDoUltimoDisparo + TempoDeRecarga) 
		{
			MomentoDoUltimoDisparo = TempoAtual;
				GameObject PontoDeDisparo = this.transform.Find ("CanhaoDaTorre/PontoDeDisparo").gameObject;
				Vector3 PosicaoDoPontoDeDisparo = PontoDeDisparo.transform.position;
				GameObject ProjetilObject = (GameObject)Instantiate (projetilPrefab, PosicaoDoPontoDeDisparo, Quaternion.identity);
				Missil missil = ProjetilObject.GetComponent<Missil> ();
				missil.DefineAlvo (inimigo);

		}
	}
	//
	//Método responsável por verificar se o objeto inimigo está dentro do raio de alcance da torre
	protected bool EstaNoRaio(GameObject inimigo) 
	{
		float AreaDeAtaque = Vector3.Distance (Vector3.ProjectOnPlane(this.transform.position, Vector3.up), Vector3.ProjectOnPlane(inimigo.transform.position, Vector3.up));
		return AreaDeAtaque <= RaioDeAlcance;
	}
	//
	//Método responsável por definir qual o alvo da torre
	protected Inimigo EscolheAlvo()
	{
		GameObject[] inimigos = GameObject.FindGameObjectsWithTag ("Inimigo");
		foreach (GameObject inimigo in inimigos)
		{
			if (EstaNoRaio (inimigo))
			{
				return inimigo.GetComponent<Inimigo>();
			}
		}
		return null;
	}
	//		
	//Método responsável por girar o canhão da torre em direção ao alvo
	private void Mira()
	{
		canhao.transform.LookAt(alvo.transform.position);
	}
	public float GetCusto()
	{
		return Custo;
	}
	//
}