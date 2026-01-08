using UnityEngine;

[CreateAssetMenu(fileName = "Event", menuName = "Scriptable Objects/Event")]
public class Event_List : ScriptableObject
{
    public int eventType;
    public string eventText;
    public Sprite eventSprite;
}
