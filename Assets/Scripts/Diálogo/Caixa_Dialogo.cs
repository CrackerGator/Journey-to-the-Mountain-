using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using TMPro;

public class Caixa_Dialogo : MonoBehaviour{

    [System.Serializable]
    public class FalaDialogo{
        [TextArea(2, 4)]
        public string Texto;
        public string NomePersonagem;
        public Sprite ImagemPersonagem;
        public bool Jogador;
        public AudioClip Som;
    }

    [Header("UI")]
    public TextMeshProUGUI TextoUI;
    public TextMeshProUGUI NomeUI;
    public Image ImagemUI;
    public TMP_FontAsset Fonte;
    private AudioSource Audio;

    [Header("Configurações")]
    public List<FalaDialogo> ListaFalas;
    public float Velocidade = 0.03f;
    private int Indice;
    public static bool Ativa = false;
    private Jogador J;

    public void Awake(){
        Audio = GetComponent<AudioSource>();
        
        GameObject G = GameObject.FindWithTag("Jogador");
        if (G != null){J = G.GetComponent<Jogador>();}
    }

    private void OnEnable(){
        TextoUI.font = Fonte;
        NomeUI.font = Fonte;

        Indice = 0;
        StartCoroutine(Sequencia());
    }

    private IEnumerator Sequencia(){
        Ativa = true;
        if(J != null){J.enabled = false;}

        while(Indice < ListaFalas.Count){
            FalaDialogo F = ListaFalas[Indice];
            
            ImagemUI.sprite = F.ImagemPersonagem;
            if(F.Jogador == true){
                NomeUI.text = Geral.Instancia.NomeJogador;
            }
            else
            NomeUI.text = F.NomePersonagem;

            yield return StartCoroutine(EscreverLinha(F.Texto));
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));

            Indice++;
        }
        
        Ativa = false;
        if(J != null){J.enabled = true;}
        
        Sequencia_Caixas S = transform.parent.GetComponent<Sequencia_Caixas>();

        if(S != null){S.Fechar();}
        gameObject.SetActive(false);
    }

    private IEnumerator EscreverLinha(string Texto){
        FalaDialogo F = ListaFalas[Indice];

        TextoUI.text = "";

        Texto = Texto.Replace("{Nome}", Geral.Instancia.NomeJogador);
        
        foreach (char Letra in Texto){
            TextoUI.text += Letra;
            Audio.PlayOneShot(F.Som);
            yield return new WaitForSeconds(Velocidade);

            if (Input.GetKeyDown(KeyCode.Return)){
                TextoUI.text = Texto;
                break;
            }
        }
    }
}