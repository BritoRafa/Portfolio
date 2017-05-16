using UnityEngine;
using System.Collections;

public class GeradorDeInimigo : MonoBehaviour {
	[SerializeField] private GameObject[] Inimigo;
	private float TempoDeSpawn = 2f;
	private float UltimoGerado;
	private int n;

	// Update is called once per frame
	void Update () {
		GeraInimigo ();
	}
	private void GeraInimigo()
	{
		Vector3 PosicaoDeSpawn = this.transform.position;
		float TempoAtual = Time.time;
		if (TempoAtual > UltimoGerado + TempoDeSpawn)
		{
			UltimoGerado = TempoAtual;
			n = Random.Range (0,10);
			Instantiate (Inimigo[n], PosicaoDeSpawn, Quaternion.identity);
		}
	}
}
