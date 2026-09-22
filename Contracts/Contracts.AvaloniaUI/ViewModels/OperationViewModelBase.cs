using System;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Contracts.AvaloniaUI.Infrastructure;

namespace Contracts.AvaloniaUI.ViewModels;

public abstract partial class OperationViewModelBase : ObservableObject, IOperation
{
    public abstract string Title { get; }
    public abstract string Description { get; }
    public abstract string PreConditionDescription { get; }
    public abstract string PostConditionDescription { get; }
    public abstract string SideEffectsDescription { get; }
    public abstract string ValidExample { get; }
    public abstract string InvalidExample { get; }

    [ObservableProperty]
    private string _inputText = "5, -2, 8, 1, 0";

    [ObservableProperty]
    private bool _isPreMet;

    [ObservableProperty]
    private bool? _isPostMet = null;

    protected int[]? ParsedVector { get; private set; }

    partial void OnInputTextChanged(string value)
    {
        EvaluatePreconditions();
        IsPostMet = null;
    }

    public virtual void EvaluatePreconditions()
    {
        if (string.IsNullOrWhiteSpace(InputText))
        {
            ParsedVector = null;
            IsPreMet = false;
            ExecuteCommand.NotifyCanExecuteChanged();
            return;
        }

        var parts = InputText.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        if (parts.Length > 0 && parts.All(p => int.TryParse(p, out _)))
        {
            ParsedVector = parts.Select(int.Parse).ToArray();
            IsPreMet = ParsedVector.Length > 0;
        }
        else
        {
            ParsedVector = null;
            IsPreMet = false;
        }

        ExecuteCommand.NotifyCanExecuteChanged();
    }

    [RelayCommand(CanExecute = nameof(IsPreMet))]
    public void Execute()
    {
        if (!IsPreMet || ParsedVector == null)
            return;

        try
        {
            ExecuteCore(ParsedVector);
            IsPostMet = true;
        }
        catch (Exception)
        {
            IsPostMet = false;
        }
    }

    protected abstract void ExecuteCore(int[] vector);
}
