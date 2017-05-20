using UnityEngine;
using System.Collections;

public class CriadorDeTorre : MonoBehaviour {
	[SerializeField]private GameObject[] TorrePrefab;
	[SerializeField]private Jogador jogador;
	[SerializeField]private Jogo jogo;
	private int ID;
	//cria torres no ponto clicado pelo mouse
	public void ConstroiTorre()
	{
		jogo.GetComponent<Jogo> ();
		ID = jogo.GetID ();
		Torre torre = TorrePrefab[ID].GetComponent<Torre> ();
		Vector3 PosicaoDoClique = Input.mousePosition;
		RaycastHit elementoAtingido = DisparaRaioDaCameraAteUmPonto (PosicaoDoClique);
		if (elementoAtingido.collider != null) 
		{
			Vector3 PosicaoDeCriacaoDaTorre = elementoAtingido.point;
			Instantiate (TorrePrefab [ID], PosicaoDeCriacaoDaTorre, Quaternion.identity);
			jogador.PerdeCredit (torre.GetCusto());
		}
	}
	private RaycastHit DisparaRaioDaCameraAteUmPonto(Vector3 pontoInicial)
	{
		Ray raio = Camera.main.ScreenPointToRay (pontoInicial);
		float comprimentoMaximoDoRaio = 100.0f;
		RaycastHit elementoAtingidoPeloRaio;
		Physics.Raycast (raio, out elementoAtingidoPeloRaio, comprimentoMaximoDoRaio);
		return elementoAtingidoPeloRaio;
	}
	//
}
