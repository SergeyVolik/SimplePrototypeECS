using UnityEngine.Events;

namespace SerV112.UtilityAI.Game
{
    public interface IEvent
    {
        UnityEvent OnEvent { get; }
    }
}
