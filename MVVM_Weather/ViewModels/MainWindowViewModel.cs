namespace MVVM_Weather.VIewModels;

public class MainWindowViewModel : BaseViewModel
{
    private string _title;

    public string Title
    {
        get => _title; 
        set => SetField(ref _title, value); 
    }
}