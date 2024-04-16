using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class Práctica3JuliánSerrano : MonoBehaviour
{

    private void OnEnable()
    {
        UIDocument uiDoc_ = GetComponent<UIDocument>();
        VisualElement rootve_ = uiDoc_.rootVisualElement;
        UQueryBuilder<VisualElement> builder_ = new(rootve_);
        VisualElement contenedor_ = builder_.Name("Botones"); // Aquí cojo el elemento llamado Bonotes en el uxml
        List<VisualElement> listaBotones_ = contenedor_.Children().ToList(); //Aquí accedo a los elementos hijos de Botones en el uxml
        listaBotones_.ForEach(element => element.AddManipulator(new Practica3ManipulatorJuliánSerrano())); //Aquí los añado a la clase botones (ya no lo hago en el uxml).
    }
}
