using System.Collections.Generic;
using UnityEngine;

public class Sequencia_Dialogos : MonoBehaviour{

    [System.Serializable]
    public class CaixaDialogo{
        public GameObject Caixa;
    }

    public List<CaixaDialogo> ListaCaixas;
    private int Indice = 0;

    private void OnEnable(){
        Interagir();
    }

    public void Interagir(){
        ListaCaixas[Indice].Caixa.SetActive(true);

        if(Indice < ListaCaixas.Count - 1){Indice++;}
    }
}