using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContadorMonedasIndividuales : MonoBehaviour
{
    //COPILOT: Variables para contar las monedas individuales
    public int monedasCobre = 0;
    public int monedasPlata = 0;
    public int monedasOro = 0;

    //COPILOT: Método para incrementar monedas individuales según el tipo usando Tags
    public void IncrementarMoneda(string tipoMoneda)
    {
        switch (tipoMoneda)
        {
            case "Cobre":
                monedasCobre++;
                break;
            case "Plata":
                monedasPlata++;
                break;
            case "Oro":
                monedasOro++;
                break;
        }
    }
}

