using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DañoPj : MonoBehaviour
{
    // Start is called before the first frame update
    public float vida = 100;
    public float tasaDeDisminucion = 1.0f;
    public float danoFuego = 5.0f;
    public Image Vida;
    public Canvas pantallaFinal;
    public Button botonVolver;

    private void Start()
    {
        pantallaFinal.gameObject.SetActive(false);

        if (botonVolver != null)
        {
            botonVolver.onClick.AddListener(VolverJuego);
        }

    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == "policia")
        {
            vida -= danoFuego * Time.deltaTime;
            vida = Mathf.Clamp(vida, 0, 100);
            Vida.fillAmount = vida / 100;
        }
        if (vida <= 0)
        {
            pantallaFinal.gameObject.SetActive(true);
            CerrarCanva();
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "policia")
        {
            vida -= tasaDeDisminucion;
            vida = Mathf.Clamp(vida, 0, 100);
            Vida.fillAmount = vida / 100;

            if (vida <= 0)
            {
                pantallaFinal.gameObject.SetActive(true);
                CerrarCanva();
            }
        }
    }

    private void VolverJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }



    private void CerrarCanva()
    {
        Vida.gameObject.SetActive(false);
    }
}