using UnityEngine.Events;

public interface IStoppable {
    bool Stopped { get; }

    UnityEvent OnStop { get; set; }

    void Stop ( bool callEvent = true );
}
