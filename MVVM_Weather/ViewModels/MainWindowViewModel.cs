namespace MVVM_Weather.ViewModels;

public class MainWindowViewModel : BaseViewModel
{
    #region title

    private readonly string _title = "Погода";
    public string Title => _title;

    #endregion
}