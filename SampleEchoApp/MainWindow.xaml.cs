using System.Net.Cache;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SampleEchoApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        Loaded += GetAddresses;
       
        TextIpAddress.Text = "127.0.0.1";
    }

    private async void GetAddresses(object e, RoutedEventArgs a)
    {
        HttpClient client = new HttpClient();
        var response = await client.GetAsync("http://checkip.dyndns.org");

        //response.EnsureSuccessStatusCode()
        // .WriteRequestToConsole();

        var jsonResponse = await response.Content.ReadAsStringAsync();

        var pattern = new Regex(@"(\d+\.\d+\.\d+\.\d+)");
        var matches = pattern.Matches(jsonResponse);

        TextMessages.Text += $"Received \"{jsonResponse}\"";

        if (matches.Count > 0)
        {
            TextIpAddress.Text = matches[matches.Count - 1].Value;
        }
        else
        {
            TextIpAddress.Text = "Unknown";
        }
    }
}