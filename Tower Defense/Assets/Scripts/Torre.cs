using UnityEngine;
using System.Collections;

public class Torre : MonoBehaviour {

	public GameObject projetilPrefab;
	[Range (0,3)]
	[SerializeField]protected float TempoDeRecarga = 1f;
	protected float MomentoDoUltimoDisparo;
	[SerializeField] protected float RaioDeAlcance;
	[SerializeField] private GameObject canhao;
	protected Inimigo alvo;
	[SerializeField] protected float Custo;
	void Update () {
		alvo = EscolheAlvo();
		if (alvo != null) 
		{
			Mira ();
			Atira (alvo);
		}
	}
	
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

	protected bool EstaNoRaio(GameObject inimigo) 
	{
		float AreaDeAtaque = Vector3.Distance (Vector3.ProjectOnPlane(this.transform.position, Vector3.up), Vector3.ProjectOnPlane(inimigo.transform.position, Vector3.up));
		return AreaDeAtaque <= RaioDeAlcance;
	}
		
//arrumar bug de mudança de tamanho quando executa a mira
	private void Mira()
	{
		canhao.transform.Rotate (0.0f,alvo.transform.position.y,0.0f);
	}
	public float GetCusto()
	{
		return Custo;
	}
}