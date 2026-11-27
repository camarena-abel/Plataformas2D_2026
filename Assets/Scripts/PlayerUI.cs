using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    TMP_Text contadorMonedas;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ActualizarContadorDeMonedas(int monedas)
    {
        contadorMonedas.text = $"Monedas: {monedas}";
    }
}
