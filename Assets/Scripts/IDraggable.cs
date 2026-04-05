using UnityEngine;
using UnityEngine.EventSystems;

// interface for draggable objects
// cards will implement this to allow dragging and dropping into card slots
public interface IBeginDragHandler : IEventSystemHandler
{
    void OnBeginDrag(PointerEventData eventData);

}

public interface IDragHandler : IEventSystemHandler
{
    void OnDrag(PointerEventData eventData);
}

public interface IEndDragHandler : IEventSystemHandler
{
    void OnEndDrag(PointerEventData eventData);
}

public interface IDropHandler : IEventSystemHandler
{
    void OnDrop(PointerEventData eventData);
}