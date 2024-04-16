using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class Practica2JuliánSerrano : MonoBehaviour
{
    private void OnEnable()
    {
        UIDocument uiDoc_ = GetComponent<UIDocument>();
        VisualElement rootve_ = uiDoc_.rootVisualElement;
        UQueryBuilder<VisualElement> builder_ = new(rootve_);
        VisualElement contenedor_ = builder_.Name("Botones"); // Aquí cojo el elemento llamado Bonotes en el uxml
        List<VisualElement> listaBotones_ = contenedor_.Children().ToList(); //Aquí accedo a los elementos hijos de Botones en el uxml
        listaBotones_.ForEach(element => element.AddToClassList("botones")); //Aquí los añado a la clase botones (ya no lo hago en el uxml).

        List<VisualElement> listaRedes_ = rootve_.Query(className: "verde").ToList(); // Aquí cojo los elementos del uxml que contienen la clase verde del uss
        listaRedes_.ForEach(el => {
            el.RemoveFromClassList("verde");
            el.AddToClassList("redes"); }); // Los saco de la clase verde y los añado a redes

        VisualElement mDragger_ = rootve_.Q<VisualElement>("unity-dragger"); // cogemos el rectangulo móvil del slider
        mDragger_.style.backgroundColor = Color.yellow;//lo pintamos de amarillo

        VisualElement mTracker_ = rootve_.Q<VisualElement>("unity-tracker");// cogemos el rectangulo del recorrido del slider
        mTracker_.style.backgroundColor = Color.yellow;//lo pintamos de amarillo


        //Todo esto son pruebas siguiendo los apuntes del enunciado
        //UQueryBuilder<VisualElement> builder_ = new (rootve_); 
        //List<VisualElement> lista_ve = builder_.ToList();
        // VisualElement contenedor_ = builder_.Name("Redes");
        //List<VisualElement> lista_ve = contenedor_.Children().ToList();
        //List<VisualElement> lista_ve = rootve_.Query().ToList(); 
        //List<VisualElement> lista_ve = rootve_.Query(className: "botones").ToList();
        // VisualElement ve = rootve_.Query(className: "redes").First();
        // Debug.Log(ve.name);
        //ve.AddToClassList("verde");
        /* lista_ve.ForEach(element => { Debug.Log(element.name);
             element.AddToClassList("verde");
         });*/
        /*VisualElement ve = rootve_.Query<Button>().AtIndex(0);
        Debug.Log(ve.name);
        ve.AddToClassList("verde");*/
    }
}
