using UnityEngine;

public interface IDraggable
{
    // interface for draggable objects
    // cards will implement this to allow dragging and dropping into card slots
    void OnDrag();
    void OnDrop();
    
}