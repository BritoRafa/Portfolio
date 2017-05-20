using UnityEngine;
using System.Collections;

public class TorreMetralhadora : Torre {
	[Range(0,4)]
	[SerializeField]private float Velocidade = 3.0f;
	// Método Update é chamado uma vez a cada frame
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
			GameObject PontoDeDisparo1 = this.transform.Find ("CorpoDaTorre/CanhoesDaTorre/MetralhaDir/PontoDeDisparoDir").gameObject;
			GameObject PontoDeDisparo2 = this.transform.Find ("CorpoDaTorre/CanhoesDaTorre/MetralhaEsq/PontoDeDisparoEsq").gameObject;
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
	//
	//Método responsável por fazer a Torre girar em direção ao alvo
	private void Mira()
	{
		var lookPos = alvo.transform.position - transform.position;
		lookPos.y = 0;
		var rotation = Quaternion.LookRotation(lookPos);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime*Velocidade);
	}
}
