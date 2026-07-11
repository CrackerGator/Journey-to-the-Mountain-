using UnityEngine;

public class Botao_Tipo : MonoBehaviour{
    public TipoAnimal Tipo;
    public GameObject CaixaEscolha;

    public void Escolher(){
        Geral.Instancia.A = Tipo;
        CaixaEscolha.SetActive(false);
    }
}