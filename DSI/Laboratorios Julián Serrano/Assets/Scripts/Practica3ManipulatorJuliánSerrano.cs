using UnityEngine;
using UnityEngine.UIElements;

public class Practica3ManipulatorJuliánSerrano :PointerManipulator
{
    private Vector3 m_Start;
    protected bool m_active;
    private int m_pointerId;
    private Vector2 m_StartSize;

    public Practica3ManipulatorJuliánSerrano()
    {
        m_pointerId = -1;
        activators.Add(new ManipulatorActivationFilter { button = MouseButton.LeftMouse }) ;
        m_active = false;
    }

    protected override void RegisterCallbacksOnTarget()
    {
        target.RegisterCallback<PointerEnterEvent>(OnMouseEnter);
        target.RegisterCallback<PointerLeaveEvent>(OnMouseExit);
        target.RegisterCallback<PointerDownEvent>(OnPointerDown);
        target.RegisterCallback<WheelEvent>(OnPointerMove);
        target.RegisterCallback<PointerUpEvent>(OnPointerUp);
    }

    protected override void UnregisterCallbacksFromTarget()
    {
        target.UnregisterCallback<PointerEnterEvent>(OnMouseEnter);
        target.UnregisterCallback<PointerLeaveEvent>(OnMouseExit);
        target.UnregisterCallback<PointerDownEvent>(OnPointerDown);
        target.UnregisterCallback<WheelEvent>(OnPointerMove);
        target.UnregisterCallback<PointerUpEvent>(OnPointerUp);
    }

    private void OnMouseEnter(PointerEnterEvent mev)
    {
            target .RemoveFromClassList("botones");
            target.AddToClassList("botonesHover");
            mev.StopPropagation();
    }

    private void OnMouseExit(PointerLeaveEvent mev)
    {
        target.RemoveFromClassList("botonesHover");
        target.AddToClassList("botones");
        mev.StopPropagation();
    }

    private void OnPointerDown(PointerDownEvent mev)
    {
        if (m_active)
        {
            mev.StopPropagation();
            return;
        }

        if(CanStartManipulation(mev))
        {
            m_Start = mev.localPosition;
            m_StartSize = target.layout.size;
            m_pointerId = mev.pointerId;
            m_active = true;
            target.CapturePointer(m_pointerId);
            mev.StopPropagation();
        }
    }

    private void OnPointerMove(WheelEvent mev)
    {
        if (!m_active || !target.HasPointerCapture(m_pointerId))
            return;

        Vector2 diff = mev.delta.normalized;

        target.style.width = m_StartSize.x + diff.y;

        target.style.height = m_StartSize.y + diff.y;

        m_StartSize += diff;
        m_StartSize.x += diff.y;

        mev.StopPropagation();
    }

    private void OnPointerUp(PointerUpEvent mev)
    {

        if (!m_active || !target.HasPointerCapture(m_pointerId))
            return;

        m_active = false;
        target.ReleasePointer(m_pointerId);
        m_pointerId = -1;
        mev.StopPropagation();
    }
}
