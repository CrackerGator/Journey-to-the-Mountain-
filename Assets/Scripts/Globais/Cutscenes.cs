using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Cutscenes : MonoBehaviour{
    public Image Imagem; 
    public Sprite[] Quadros;

    [System.Serializable]
    public class Animacao{
        public int Inicio;
        public int Frames;
    }
    public Animacao[] QuadrosAnimados;
    public float TempoAnimacao;

    public string ProximaFase;

    public CanvasGroup canvasGroup;
    public float VelocidadeFade;

    private int i = 0;
    private bool Fading = false;

    void Start(){
        MostrarQuadro();
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.Return) && !Fading){
            StartCoroutine(ProximoQuadro());
        }
    }

    void MostrarQuadro(){
        Animacao A = BuscarAnimacao(i);
        if(A != null){
            StartCoroutine(RodarAnimacao(A));
        }
        else
        Imagem.sprite = Quadros[i];
    }
    Animacao BuscarAnimacao(int i){
        foreach(var A in QuadrosAnimados){
            if(A.Inicio == i){return A;}
        }
        return null;
    }

    IEnumerator ProximoQuadro(){
        Fading = true;
        yield return StartCoroutine(FadeOut());

        i++;

        if (i >= Quadros.Length){
            Fade.Instancia.TrocarCena(ProximaFase);
            yield break;
        }

        MostrarQuadro();

        yield return StartCoroutine(FadeIn());
        Fading = false;
    }
    IEnumerator RodarAnimacao(Animacao A){
        Fading = true;
        for (int f = 0; f < A.Frames; f++){
            Imagem.sprite = Quadros[i + f];
            yield return new WaitForSeconds(TempoAnimacao);
        }
        i += A.Frames - 1;
        Fading = false;
    }

    IEnumerator FadeIn(){
        while(canvasGroup.alpha < 1){
            canvasGroup.alpha += Time.deltaTime * VelocidadeFade;
            yield return null;
        }
        canvasGroup.alpha = 1;
    }
    IEnumerator FadeOut(){
        while (canvasGroup.alpha > 0){
            canvasGroup.alpha -= Time.deltaTime * VelocidadeFade;
            yield return null;
        }
        canvasGroup.alpha = 0;
    }
}