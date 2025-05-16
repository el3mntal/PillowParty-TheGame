using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using static UnityEditor.ShaderData;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public GameObject CuadroPausa;
    public bool Pausa;

    //metodo para que se active el cuadro pausa
    public void BotonPausa()
    {
        Pausa = true;
        CuadroPausa.SetActive(true);
        Time.timeScale = 0.1f;
    }

    //metodo para que se desactive el cuadro pausa
    public void BotonReanudar()
    {
        Pausa = false;
        CuadroPausa.SetActive(false);
        Time.timeScale = 1.0f;
    }

    //metodo para vovler al menu
    public void VolverMenu()
    {
	    SceneManager.LoadScene(0);

    }
}
