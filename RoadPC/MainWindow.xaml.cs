using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RoadPC
{
    public partial class MainWindow : Window
    {
        float lenght;
        float averageSpeed = 60;
        float timeOnRoad;
        float fuelSize;
        float averageFuelExpence;
        float stopsCount = 0;
        float stopsTime;
        float fuelExpect;
        float plannedStopsCount = 0;
        float plannedStopsTime;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumberBoxPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key != Key.D0 && e.Key != Key.D1 && e.Key != Key.D2 && e.Key != Key.D3 && e.Key != Key.D4 && e.Key != Key.D5 && e.Key != Key.D6 && e.Key != Key.D7 && e.Key != Key.D8 && e.Key != Key.D9 && e.Key != Key.Back)
            {
                e.Handled = true;
            }
        }

        private void ConfirmBTN_Click(object sender, RoutedEventArgs e)
        {
            if (LengthBox.Text.Length >= 1)
            {
                LengthBox.Background = Brushes.LightGreen;

                if (FuelBox.Text.Length >= 1)
                {
                    FuelBox.Background = Brushes.LightGreen;

                    if (FuelOnRoadBox.Text.Length >= 1)
                    {
                        FuelOnRoadBox.Background = Brushes.LightGreen;

                        lenght = 0;
                        averageSpeed = 60;
                        timeOnRoad = 0;
                        fuelSize = 0;
                        averageFuelExpence = 0;
                        stopsCount = 0;
                        stopsTime = 0;
                        fuelExpect = 0;
                        plannedStopsCount = 0;
                        plannedStopsTime = 0;

                        lenght = int.Parse(LengthBox.Text);
                        fuelSize = int.Parse(FuelBox.Text);
                        averageFuelExpence = int.Parse(FuelOnRoadBox.Text);

                        timeOnRoad = lenght / averageSpeed;

                        float lenghtOnCalculations = lenght - 100;
                        for (int i = 0; lenghtOnCalculations > 0; i++)
                        {
                            lenghtOnCalculations = lenghtOnCalculations - 100;

                            plannedStopsCount++;
                        }

                        fuelExpect = lenght * averageFuelExpence / 100;

                        float fuelExpectOnCalculations = fuelExpect - fuelSize;
                        for (int i = 0; fuelExpectOnCalculations > 0; i++)
                        {
                            fuelExpectOnCalculations = fuelExpectOnCalculations - fuelSize;

                            stopsCount++;
                        }

                        stopsTime = stopsCount * 20;
                        plannedStopsTime = plannedStopsCount * 20;

                        HoursLabel.Content = timeOnRoad + " ч.";
                        FuelLabel.Content = fuelExpect + " л.";
                        StopCountLabel.Content = stopsCount;
                        TimeOnStopLabel.Content = stopsTime + " м.";
                        PlannedStopCountLabel.Content = plannedStopsCount;
                        TimeOnPlannedStopLabel.Content = plannedStopsTime + " м.";
                    }
                    else
                    {
                        FuelOnRoadBox.Background = Brushes.LightPink;
                        MessageBox.Show("Вы не указали расход топлива вашего автомобиля(учтите, он должен быть в литрах / 100 километров)", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Stop);
                    }
                }
                else
                {
                    FuelBox.Background = Brushes.LightPink;
                    MessageBox.Show("Вы не указали ёмкость бензобака(учтите, она должна быть в литрах)", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Stop);
                }
            }
            else
            {
                LengthBox.Background = Brushes.LightPink;
                MessageBox.Show("Вы не указали длинну вашего путешествия(учтите, она должна быть в километрах)", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }
    }
}
