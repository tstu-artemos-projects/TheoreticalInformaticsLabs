using System.ComponentModel;

namespace Contracts.AvaloniaUI.Infrastructure;

public interface IOperation : INotifyPropertyChanged
{
    string Title { get; }
    string Description { get; }

    string PreConditionDescription { get; }
    string PostConditionDescription { get; }
    string SideEffectsDescription { get; }
    string ValidExample { get; }
    string InvalidExample { get; }

    bool IsPreMet { get; }
    bool? IsPostMet { get; } // Если null - то значит ничего не запускали

    void EvaluatePreconditions();
    void Execute();
}
