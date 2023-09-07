namespace AppNotas;

public partial class EjemploFlyoutPage : FlyoutPage
{
	public EjemploFlyoutPage()
	{
		InitializeComponent();
        flyoutPage.collectionView.SelectionChanged += OnSelectionChanged;
    }
    void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var item = e.CurrentSelection.FirstOrDefault() as FlyoutPageItem;
        if (item != null)
        {
            Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
            IsPresented = false;
        }
    }
}