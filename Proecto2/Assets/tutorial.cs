using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorial : MonoBehaviour
{
    public Text tuto;

    public GameObject PanelUi;
    public GameObject PanelText;
    public GameObject PanelPortal;

    public List<string> text01;

void Awake()
{
    text01 = new List<string>(new string[] {
"Bienvenido al mapa de pruebas competidor, espero que estés preparado para la carrera.",
"¿Los controles? supongo que ya estará familiarizado con las naves de clase rk-173r, pero nunca esta de mal recordarlas.",
"¡Muy bien! aquí van: \n[ <b>W</b>; ] Para mover hacia arriba la nave \n[ <b>A</b> ] Para mover hacia LA IZQUIERDA la nave \n[ <b>S</b> ] Para mover hacia LA DERECHA la nave \n[ <b>D</b> ] Para mover hacia ABAJO la nave \n[ <b>ESPACIO</b> ] Para ACELERAR Y MOVER LA NAVE \n[ <b>SHIFT IZQUIERDO</b> ] Para FRENAR/RETROCEDER",
"¡LA Batería DE LA NAVE SE DAÑA CUANDO ENTRAS AL ESPACIO SIN CARGAS, ASÍ QUE TEN CUIDADO! \n ¡INDICARÁ CUANDO TENGA Protección PARA REALIZAR VIAJES ESPACIALES, CON EL COLOR! ¡PERO TEN CUIDADO NO SE TE TERMINE EL TIEMPO DEL ESCUDO Y Estés EN EL ESPACIO O Perderás Energía! ",
"YA LO Sabrás, PERO SI TE QUEDAS SIN Energía PIERDES, Así QUE ¡TEN CUIDADO!",
    });
        PanelUi.SetActive(false);
        PanelPortal.SetActive(false);

    }
    public int phaseTutorial;

    public float time = 4f;

    public bool stop;

    private void Update()
    {
        if (phaseTutorial < text01.ToArray().Length)
        {
            tuto.text = text01[phaseTutorial];
        }
        else if(phaseTutorial == text01.ToArray().Length)
        {
            PanelUi.SetActive(true);
            PanelText.SetActive(false);
        }
        else if (phaseTutorial == text01.ToArray().Length+1)
        {
            PanelUi.SetActive(false);
            PanelPortal.SetActive(true);
        }
        else
        {
            PanelPortal.SetActive(false);
            stop = false;
        }
    }

}
