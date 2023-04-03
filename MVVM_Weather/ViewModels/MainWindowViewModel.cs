namespace MVVM_Weather.ViewModels;

public class MainWindowViewModel : BaseViewModel
{
    #region title

    public string Title => _title;

    private readonly string _title = "Погода";

    #endregion


}