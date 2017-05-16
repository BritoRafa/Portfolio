using UnityEngine;
using System.Collections;

public class TorreMetralhadora : Torre {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		alvo = EscolheAlvo();
		if (alvo != null) 
		{
			Atira (alvo);
		}
	}
	private void Atira(Inimigo inimigo)
	{
		float TempoAtual = Time.time;
		if (TempoAtual > MomentoDoUltimoDisparo + TempoDeRecarga) 
		{
			MomentoDoUltimoDisparo = TempoAtual;
			GameObject PontoDeDisparo1 = this.transform.Find ("CanhoesDaTorre/MetralhaDir/PontoDeDisparoDir").gameObject;
			GameObject PontoDeDisparo2 = this.transform.Find ("CanhoesDaTorre/MetralhaEsq/PontoDeDisparoEsq").gameObject;
			Vector3 PosicaoDoPontoDeDisparo1 = PontoDeDisparo1.transform.position;
			Vector3 PosicaoDoPontoDeDisparo2 = PontoDeDisparo2.transform.position;
			GameObject ProjetilObject = (GameObject)Instantiate (projetilPrefab, PosicaoDoPontoDeDisparo1, Quaternion.identity);
			GameObject ProjetilObject2 = (GameObject)Instantiate (projetilPrefab, PosicaoDoPontoDeDisparo2, Quaternion.identity);
			Missil missil = ProjetilObject.GetComponent<Missil> ();
			missil.DefineAlvo (inimigo);
			missil = ProjetilObject2.GetComponent<Missil> ();
			missil.DefineAlvo (inimigo);
		}
	}


}
