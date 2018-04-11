using BandsInTownSharp.Client;
using BandsInTownSharp.ValueObject.Bit;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Windows;

namespace BandsInTownTest
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BitClient bitClient = new BitClient("MyBitAPIKey");

        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonFetchData_Click(object sender, RoutedEventArgs e)
        {
            textBoxOutput.Text = "";

            string artist = textBoxArtistSearch.Text;

            if (radioButtonArist.IsChecked == true)
            {
                ArtistVo artistVo = bitClient.GetArtist(artist);

                PrintProperties(artistVo);
            }
            else
            {
                List<EventVo> eventList = bitClient.GetArtistEvents(artist);

                PrintProperties(eventList);
            }
        }

        public void PrintProperties(object obj)
        {
            var json = JsonConvert.SerializeObject(obj,
                    Formatting.Indented,
                    new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        Formatting = Formatting.Indented
                    });

            textBoxOutput.Text = json;
        }
        
    }
}
