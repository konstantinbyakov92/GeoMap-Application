using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfApp6
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const double luy = 55.984732;
        const double lux = 37.370933;
        const double ruy = 55.984739;
        const double rux = 37.455333;
        const double rby = 55.959988;
        const double rbx = 37.455498;
        const double lby = 55.959890;
        const double lbx = 37.370760;

        public class ObjectStatus
        {
            public Int64 pmpVlm { get; set; }
            public string obj_id { get; set; }
            public DateTime point_date { get; set; }
            public Decimal latitude { get; set; }
            public Decimal longitude { get; set; }
            public decimal speed { get; set; }
            public int jobSt { get; set; }
        }

        private static HttpClient client = new HttpClient();

        public MainWindow()
        {
            InitializeComponent();
            can.Background = new SolidColorBrush(Color.FromRgb(212, 254, 222));
            menu.Background = new SolidColorBrush(Color.FromRgb(212, 254, 222));
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(7);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            ConnectionRequest();
        }

        public async void ConnectionRequest()
        {
            try
            {
                string line = "";
                string value = line;
                string result = await client.GetStringAsync("http://195.210.138.202:5229/api/geoobjects/Geo");
                for (int i = can.Children.Count - 1; i >= 0; i--)
                {
                    if (can.Children[i] is Ellipse)
                        can.Children.RemoveAt(i);
                    
                }
                for(int j = can.Children.Count -1; j >=0; j--)
                {
                    if (can.Children[j] is TextBlock)
                        can.Children.RemoveAt(j);
                }

                var os = JsonSerializer.Deserialize<List<ObjectStatus>>(result);
                foreach (ObjectStatus row in os)
                {
                    double yc = Convert.ToDouble(Math.Round(row.latitude, 6));
                    double xc = Convert.ToDouble(Math.Round(row.longitude, 6));
                    string id = row.obj_id;
                    decimal speedTZA = Math.Round(row.speed, 2);
                    double volume = row.pmpVlm;
                    string numberTZA = "0";
                    int status = row.jobSt;

                    
                    SolidColorBrush color = new SolidColorBrush();
                    if (id == "358636085477114" || id == "LKOH.SVO.01")
                    {
                        id = "ТЗА-01";
                        tza01Speed.Content = Convert.ToString(speedTZA);
                        if(volume > 200000)
                        {
                            tza01Volume.Content = "";
                        }
                        else
                        {
                            tza01Volume.Content = Convert.ToString(volume);
                        }                        
                        //color = Brushes.Red;
                        numberTZA = "01";
                        if (status == 4 || status == 5 || status == 21)
                        {
                            color = Brushes.Green;
                        }
                        else if (status == 7)
                        {
                            color = Brushes.Orange;
                        }
                        else if (status == 9 || status == 10 || status == 12 || status == 14)
                        {
                            color = Brushes.Red;
                        }
                        else if (status == 99)
                        {
                            color = Brushes.Black;
                        }
                        else if (status == 98)
                        {
                            color = Brushes.DimGray;
                        }
                        else
                        {
                            color = Brushes.Green;
                        }
                        tza1.Fill = color;

                    }
                    else if (id == "358636085477213" || id == "LKOH.SVO.02")
                    {
                        id = "ТЗА-02";
                        tza02Speed.Content = Convert.ToString(speedTZA);
                        if (volume > 200000)
                        {
                            tza02Volume.Content = "";
                        }
                        else
                        {
                            tza02Volume.Content = Convert.ToString(volume);
                        }
                        //color = Brushes.Yellow;
                        numberTZA = "02";
                        if (status == 4 || status == 5 || status == 21)
                        {
                            color = Brushes.Green;
                        }
                        else if (status == 7)
                        {
                            color = Brushes.Orange;
                        }
                        else if (status == 9 || status == 10 || status == 12 || status == 14)
                        {
                            color = Brushes.Red;
                        }
                        else if (status == 99)
                        {
                            color = Brushes.Black;
                        }
                        else if (status == 98)
                        {
                            color = Brushes.DimGray;
                        }
                        else
                        {
                            color = Brushes.Green;
                        }
                        tza2.Fill = color;
                    }
                    else if(id == "358636085446804" || id == "LKOH.SVO.03")
                    {
                        id = "ТЗА-03";
                        tza03Speed.Content = Convert.ToString(speedTZA);
                        if (volume > 200000)
                        {
                            tza03Volume.Content = "";
                        }
                        else
                        {
                            tza03Volume.Content = Convert.ToString(volume);
                        }
                        //color = Brushes.DeepPink;
                        numberTZA = "03";
                        if (status == 4 || status == 5 || status == 21)
                        {
                            color = Brushes.Green;
                        }
                        else if (status == 7)
                        {
                            color = Brushes.Orange;
                        }
                        else if (status == 9 || status == 10 || status == 12 || status == 14)
                        {
                            color = Brushes.Red;
                        }
                        else if (status == 99)
                        {
                            color = Brushes.Black;
                        }
                        else if (status == 98)
                        {
                            color = Brushes.DimGray;
                        }
                        else
                        {
                            color = Brushes.Green;
                        }
                        tza3.Fill = color;
                    }
                    else if(id == "358636085483724" || id == "LKOH.SVO.04")
                    {
                        id = "ТЗА-04";
                        tza04Speed.Content = Convert.ToString(speedTZA);
                        if (volume > 200000)
                        {
                            tza04Volume.Content = "";
                        }
                        else
                        {
                            tza04Volume.Content = Convert.ToString(volume);
                        }
                        //color = Brushes.Orange;
                        numberTZA = "04";
                        if (status == 4 || status == 5 || status == 21)
                        {
                            color = Brushes.Green;
                        }
                        else if (status == 7)
                        {
                            color = Brushes.Orange;
                        }
                        else if (status == 9 || status == 10 || status == 12 || status == 14)
                        {
                            color = Brushes.Red;
                        }
                        else if (status == 99)
                        {
                            color = Brushes.Black;
                        }
                        else if (status == 98)
                        {
                            color = Brushes.DimGray;
                        }
                        else
                        {
                            color = Brushes.Green;
                        }
                        tza4.Fill = color;
                    }
                    else if(id == "358636085477205" || id == "LKOH.SVO.05")
                    {
                        id = "ТЗА-05";
                        tza05Speed.Content = Convert.ToString(speedTZA);
                        if (volume > 200000)
                        {
                            tza05Volume.Content = "";
                        }
                        else
                        {
                            tza05Volume.Content = Convert.ToString(volume);
                        }
                        //color = Brushes.LightSalmon;
                        numberTZA = "05";
                        if (status == 4 || status == 5 || status == 21)
                        {
                            color = Brushes.Green;
                        }
                        else if (status == 7)
                        {
                            color = Brushes.Orange;
                        }
                        else if (status == 9 || status == 10 || status == 12 || status == 14)
                        {
                            color = Brushes.Red;
                        }
                        else if (status == 99)
                        {
                            color = Brushes.Black;
                        }
                        else if (status == 98)
                        {
                            color = Brushes.DimGray;
                        }
                        else
                        {
                            color = Brushes.Green;
                        }
                        tza5.Fill = color;
                    }
                    else if (id == "358636085446762" || id == "LKOH.SVO.06")
                    {
                        id = "ТЗА-06";
                        tza06Speed.Content = Convert.ToString(speedTZA);
                        if (volume > 200000)
                        {
                            tza06Volume.Content = "";
                        }
                        else
                        {
                            tza06Volume.Content = Convert.ToString(volume);
                        }
                        //color = Brushes.Khaki;
                        numberTZA = "06";
                        if (status == 4 || status == 5 || status == 21)
                        {
                            color = Brushes.Green;
                        }
                        else if (status == 7)
                        {
                            color = Brushes.Orange;
                        }
                        else if (status == 9 || status == 10 || status == 12 || status == 14)
                        {
                            color = Brushes.Red;
                        }
                        else if (status == 99)
                        {
                            color = Brushes.Black;
                        }
                        else if (status == 98)
                        {
                            color = Brushes.DimGray;
                        }
                        else
                        {
                            color = Brushes.Green;
                        }
                        tza6.Fill = color;
                    }
                    else if (id == "358636085401387" || id == "LKOH.SVO.07") //358636085401387
                    {
                        id = "ТЗА-07";
                        tza07Speed.Content = Convert.ToString(speedTZA);
                        if (volume > 200000)
                        {
                            tza07Volume.Content = "";
                        }
                        else
                        {
                            tza07Volume.Content = Convert.ToString(volume);
                        }
                        //color = Brushes.DarkOliveGreen;
                        numberTZA = "07";
                        if (status == 4 || status == 5 || status == 21)
                        {
                            color = Brushes.Green;
                        }
                        else if (status == 7)
                        {
                            color = Brushes.Orange;
                        }
                        else if (status == 9 || status == 10 || status == 12 || status == 14)
                        {
                            color = Brushes.Red;
                        }
                        else if (status == 99)
                        {
                            color = Brushes.Black;
                        }
                        else if (status == 98)
                        {
                            color = Brushes.DimGray;
                        }
                        else
                        {
                            color = Brushes.Green;
                        }
                        tza7.Fill = color;
                    }
                    else if (id == "358636085405883" || id == "LKOH.SVO.08")
                    {
                        id = "ТЗА-08";
                        tza08Speed.Content = Convert.ToString(speedTZA);
                        if (volume > 200000)
                        {
                            tza08Volume.Content = "";
                        }
                        else
                        {
                            tza08Volume.Content = Convert.ToString(volume);
                        }
                        //color = Brushes.GreenYellow;
                        numberTZA = "08";
                        if (status == 4 || status == 5 || status == 21)
                        {
                            color = Brushes.Green;
                        }
                        else if (status == 7)
                        {
                            color = Brushes.Orange;
                        }
                        else if (status == 9 || status == 10 || status == 12 || status == 14)
                        {
                            color = Brushes.Red;
                        }
                        else if (status == 99)
                        {
                            color = Brushes.Black;
                        }
                        else if (status == 98)
                        {
                            color = Brushes.DimGray;
                        }
                        else
                        {
                            color = Brushes.Green;
                        }
                        tza8.Fill = color;
                    }
                    else if (id == "358636085477239" || id == "LKOH.SVO.09")
                    {
                        id = "ТЗА-09";
                        tza09Speed.Content = Convert.ToString(speedTZA);
                        if (volume > 200000)
                        {
                            tza09Volume.Content = "";
                        }
                        else
                        {
                            tza09Volume.Content = Convert.ToString(volume);
                        }
                        //color = Brushes.DarkBlue;
                        numberTZA = "09";
                        if (status == 4 || status == 5 || status == 21)
                        {
                            color = Brushes.Green;
                        }
                        else if (status == 7)
                        {
                            color = Brushes.Orange;
                        }
                        else if (status == 9 || status == 10 || status == 12 || status == 14)
                        {
                            color = Brushes.Red;
                        }
                        else if (status == 99)
                        {
                            color = Brushes.Black;
                        }
                        else if (status == 98)
                        {
                            color = Brushes.DimGray;
                        }
                        else
                        {
                            color = Brushes.Green;
                        }
                        tza9.Fill = color;
                    }
                    else if (id == "358636085477155" || id == "LKOH.SVO.10")
                    {
                        id = "ТЗА-10";
                        tza10Speed.Content = Convert.ToString(speedTZA);
                        if (volume > 200000)
                        {
                            tza10Volume.Content = "";
                        }
                        else
                        {
                            tza10Volume.Content = Convert.ToString(volume);
                        }
                        //color = Brushes.DodgerBlue;
                        numberTZA = "10";
                        if (status == 4 || status == 5 || status == 21)
                        {
                            color = Brushes.Green;
                        }
                        else if (status == 7)
                        {
                            color = Brushes.Orange;
                        }
                        else if (status == 9 || status == 10 || status == 12 || status == 14)
                        {
                            color = Brushes.Red;
                        }
                        else if (status == 99)
                        {
                            color = Brushes.Black;
                        }
                        else if (status == 98)
                        {
                            color = Brushes.DimGray;
                        }
                        else
                        {
                            color = Brushes.Green;
                        }
                        tza10.Fill = color;
                    }
                    else if (id == "358636085483682" || id == "LKOH.SVO.11")
                    {
                        id = "ТЗА-11";
                        tza11Speed.Content = Convert.ToString(speedTZA);
                        if (volume > 200000)
                        {
                            tza11Volume.Content = "";
                        }
                        else
                        {
                            tza11Volume.Content = Convert.ToString(volume);
                        }
                        //color = Brushes.LightBlue;
                        numberTZA = "11";
                        if (status == 4 || status == 5 || status == 21)
                        {
                            color = Brushes.Green;
                        }
                        else if (status == 7)
                        {
                            color = Brushes.Orange;
                        }
                        else if (status == 9 || status == 10 || status == 12 || status == 14)
                        {
                            color = Brushes.Red;
                        }
                        else if (status == 99)
                        {
                            color = Brushes.Black;
                        }
                        else if (status == 98)
                        {
                            color = Brushes.DimGray;
                        }
                        else
                        {
                            color = Brushes.Green;
                        }
                        tza11.Fill = color;
                    }
                    else if (id == "358636085505401" || id == "LKOH.SVO.12")
                    {
                        id = "ТЗА-12";
                        tza12Speed.Content = Convert.ToString(speedTZA);
                        if (volume > 200000)
                        {
                            tza12Volume.Content = "";
                        }
                        else
                        {
                            tza12Volume.Content = Convert.ToString(volume);
                        }
                        //color = Brushes.Violet;
                        numberTZA = "12";
                        if (status == 4 || status == 5 || status == 21)
                        {
                            color = Brushes.Green;
                        }
                        else if (status == 7)
                        {
                            color = Brushes.Orange;
                        }
                        else if (status == 9 || status == 10 || status == 12 || status == 14)
                        {
                            color = Brushes.Red;
                        }
                        else if (status == 99)
                        {
                            color = Brushes.Black;
                        }
                        else if (status == 98)
                        {
                            color = Brushes.DimGray;
                        }
                        else
                        {
                            color = Brushes.Green;
                        }
                        tza12.Fill = color;
                    }
                    else if (id == "358636085446747" || id == "LKOH.SVO.14")
                    {
                        id = "ТЗА-14";
                        tza14Speed.Content = Convert.ToString(speedTZA);
                        if (volume > 200000)
                        {
                            tza14Volume.Content = "";
                        }
                        else
                        {
                            tza14Volume.Content = Convert.ToString(volume);
                        }
                        //color = Brushes.Lavender;
                        numberTZA = "14";
                        if (status == 4 || status == 5 || status == 21)
                        {
                            color = Brushes.Green;
                        }
                        else if (status == 7)
                        {
                            color = Brushes.Orange;
                        }
                        else if (status == 9 || status == 10 || status == 12 || status == 14)
                        {
                            color = Brushes.Red;
                        }
                        else if (status == 99)
                        {
                            color = Brushes.Black;
                        }
                        else if (status == 98)
                        {
                            color = Brushes.DimGray;
                        }
                        else
                        {
                            color = Brushes.Green;
                        }
                        tza14.Fill = color;
                    }
                    else if (id == "358636085483716" || id == "LKOH.SVO.15")
                    {
                        id = "ТЗА-15";
                        tza15Speed.Content = Convert.ToString(speedTZA);
                        if (volume > 200000)
                        {
                            tza15Volume.Content = "";
                        }
                        else
                        {
                            tza15Volume.Content = Convert.ToString(volume);
                        }
                        //color = Brushes.Gray;
                        numberTZA = "15";
                        if (status == 4 || status == 5 || status == 21)
                        {
                            color = Brushes.Green;
                        }
                        else if (status == 7)
                        {
                            color = Brushes.Orange;
                        }
                        else if (status == 9 || status == 10 || status == 12 || status == 14)
                        {
                            color = Brushes.Red;
                        }
                        else if (status == 99)
                        {
                            color = Brushes.Black;
                        }
                        else if (status == 98)
                        {
                            color = Brushes.DimGray;
                        }
                        else
                        {
                            color = Brushes.Green;
                        }
                        tza15.Fill = color;
                    }
                    else if (id == "358636085505153" || id == "LKOH.SVO.16")
                    {
                        id = "ТЗА-16";
                        tza16Speed.Content = Convert.ToString(speedTZA);
                        if (volume > 200000)
                        {
                            tza16Volume.Content = "";
                        }
                        else
                        {
                            tza16Volume.Content = Convert.ToString(volume);
                        }
                        //color = Brushes.DarkTurquoise;
                        numberTZA = "16";
                        if (status == 4 || status == 5 || status == 21)
                        {
                            color = Brushes.Green;
                        }
                        else if (status == 7)
                        {
                            color = Brushes.Orange;
                        }
                        else if (status == 9 || status == 10 || status == 12 || status == 14)
                        {
                            color = Brushes.Red;
                        }
                        else if (status == 99)
                        {
                            color = Brushes.Black;
                        }
                        else if (status == 98)
                        {
                            color = Brushes.DimGray;
                        }
                        else
                        {
                            color = Brushes.Green;
                        }
                        tza16.Fill = color;
                    }
                    else if (id == "358636085483708" || id == "LKOH.SVO.50")
                    {
                        id = "ПЗА-50";
                        pza50Speed.Content = Convert.ToString(speedTZA);
                        //pza50Volume.Content = Convert.ToString(volume);
                        //color = Brushes.Chocolate;
                        numberTZA = "50";
                        if (status == 4 || status == 5 || status == 21)
                        {
                            color = Brushes.Green;
                        }
                        else if (status == 7)
                        {
                            color = Brushes.Orange;
                        }
                        else if (status == 9 || status == 10 || status == 12 || status == 14)
                        {
                            color = Brushes.Red;
                        }
                        else if (status == 99)
                        {
                            color = Brushes.Black;
                        }
                        else if (status == 98)
                        {
                            color = Brushes.DimGray;
                        }
                        else
                        {
                            color = Brushes.Green;
                        }
                        pza50.Fill = color;
                    }
                    else if (id == "358636085477163" || id == "LKOH.SVO.51") //358636085477163
                    {
                        id = "ПЗА-51";
                        pza51Speed.Content = Convert.ToString(speedTZA);
                        //pza51Volume.Content = Convert.ToString(volume);
                        //color = Brushes.DeepSkyBlue;
                        numberTZA = "51";
                        if (status == 4 || status == 5 || status == 21)
                        {
                            color = Brushes.Green;
                        }
                        else if (status == 7)
                        {
                            color = Brushes.Orange;
                        }
                        else if (status == 9 || status == 10 || status == 12 || status == 14)
                        {
                            color = Brushes.Red;
                        }
                        else if (status == 99)
                        {
                            color = Brushes.Black;
                        }
                        else if (status == 98)
                        {
                            color = Brushes.DimGray;
                        }
                        else
                        {
                            color = Brushes.Green;
                        }
                        pza51.Fill = color;
                    }
                    else if (id == "358636085446754" || id == "LKOH.SVO.52")
                    {
                        id = "ПЗА-52";
                        pza52Speed.Content = Convert.ToString(speedTZA);
                        //pza52Volume.Content = Convert.ToString(volume);
                        //color = Brushes.GhostWhite;
                        numberTZA = "52";
                        if (status == 4 || status == 5 || status == 21)
                        {
                            color = Brushes.Green;
                        }
                        else if (status == 7)
                        {
                            color = Brushes.Orange;
                        }
                        else if (status == 9 || status == 10 || status == 12 || status == 14)
                        {
                            color = Brushes.Red;
                        }
                        else if (status == 99)
                        {
                            color = Brushes.Black;
                        }
                        else if (status == 98)
                        {
                            color = Brushes.DimGray;
                        }
                        else
                        {
                            color = Brushes.Green;
                        }
                        pza52.Fill = color;
                    }
                    else if (id == "358636085388998" || id == "LKOH.SVO.53")
                    {
                        id = "ПЗА-53";
                        pza53Speed.Content = Convert.ToString(speedTZA);
                        //pza53Volume.Content = Convert.ToString(volume);
                        //color = Brushes.Fuchsia;
                        numberTZA = "53";
                        if (status == 4 || status == 5 || status == 21)
                        {
                            color = Brushes.Green;
                        }
                        else if (status == 7)
                        {
                            color = Brushes.Orange;
                        }
                        else if (status == 9 || status == 10 || status == 12 || status == 14)
                        {
                            color = Brushes.Red;
                        }
                        else if (status == 99)
                        {
                            color = Brushes.Black;
                        }
                        else if (status == 98)
                        {
                            color = Brushes.DimGray;
                        }
                        else
                        {
                            color = Brushes.Green;
                        }
                        pza53.Fill = color;
                    }
                    else if (id == "LKOH.SVO.54")
                    {
                        id = "ПЗА-54";
                        pza54Speed.Content = Convert.ToString(speedTZA);
                        //pza54Volume.Content = Convert.ToString(volume);
                        //color = Brushes.Gold;
                        numberTZA = "54";
                        if (status == 4 || status == 5 || status == 21)
                        {
                            color = Brushes.Green;
                        }
                        else if (status == 7)
                        {
                            color = Brushes.Orange;
                        }
                        else if (status == 9 || status == 10 || status == 12 || status == 14)
                        {
                            color = Brushes.Red;
                        }
                        else if (status == 99)
                        {
                            color = Brushes.Black;
                        }
                        else if (status == 98)
                        {
                            color = Brushes.DimGray;
                        }
                        else
                        {
                            color = Brushes.Green;
                        }
                        pza54.Fill = color;
                    }
                    else if (id == "358636085477270" || id == "LKOH.SVO.55")
                    {
                        id = "ПЗА-55";
                        pza55Speed.Content = Convert.ToString(speedTZA);
                        //pza55Volume.Content = Convert.ToString(volume);
                        //color = Brushes.DarkViolet;
                        numberTZA = "55";
                        if (status == 4 || status == 5 || status == 21)
                        {
                            color = Brushes.Green;
                        }
                        else if (status == 7)
                        {
                            color = Brushes.Orange;
                        }
                        else if (status == 9 || status == 10 || status == 12 || status == 14)
                        {
                            color = Brushes.Red;
                        }
                        else if (status == 99)
                        {
                            color = Brushes.Black;
                        }
                        else if (status == 98)
                        {
                            color = Brushes.DimGray;
                        }
                        else
                        {
                            color = Brushes.Green;
                        }
                        pza55.Fill = color;
                    }
                    else if (id == "358636085477189" || id == "LKOH.SVO.56")
                    {
                        id = "ПЗА-56";
                        pza56Speed.Content = Convert.ToString(speedTZA);
                        //pza56Volume.Content = Convert.ToString(volume);
                        //color = Brushes.HotPink;
                        numberTZA = "56";
                        if (status == 4 || status == 5 || status == 21)
                        {
                            color = Brushes.Green;
                        }
                        else if (status == 7)
                        {
                            color = Brushes.Orange;
                        }
                        else if (status == 9 || status == 10 || status == 12 || status == 14)
                        {
                            color = Brushes.Red;
                        }
                        else if (status == 99)
                        {
                            color = Brushes.Black;
                        }
                        else if (status == 98)
                        {
                            color = Brushes.DimGray;
                        }
                        else
                        {
                            color = Brushes.Green;
                        }
                        pza56.Fill = color;
                    }
                    else if (id == "358636085505120" || id == "LKOH.SVO.57")
                    {
                        id = "ПЗА-57";
                        pza57Speed.Content = Convert.ToString(speedTZA);
                        //pza57Volume.Content = Convert.ToString(volume);
                        //color = Brushes.Plum;
                        numberTZA = "57";
                        if (status == 4 || status == 5 || status == 21)
                        {
                            color = Brushes.Green;
                        }
                        else if (status == 7)
                        {
                            color = Brushes.Orange;
                        }
                        else if (status == 9 || status == 10 || status == 12 || status == 14)
                        {
                            color = Brushes.Red;
                        }
                        else if (status == 99)
                        {
                            color = Brushes.Black;
                        }
                        else if (status == 98)
                        {
                            color = Brushes.DimGray;
                        }
                        else
                        {
                            color = Brushes.Green;
                        }
                        pza57.Fill = color;
                    }
                    else if (id == "358636085446796" || id == "LKOH.SVO.58")
                    {
                        id = "ПЗА-58";
                        pza58Speed.Content = Convert.ToString(speedTZA);
                        //pza58Volume.Content = Convert.ToString(volume);
                        //color = Brushes.LightCyan;
                        numberTZA = "58";
                        if (status == 4 || status == 5 || status == 21)
                        {
                            color = Brushes.Green;
                        }
                        else if (status == 7)
                        {
                            color = Brushes.Orange;
                        }
                        else if (status == 9 || status == 10 || status == 12 || status == 14)
                        {
                            color = Brushes.Red;
                        }
                        else if (status == 99)
                        {
                            color = Brushes.Black;
                        }
                        else if (status == 98)
                        {
                            color = Brushes.DimGray;
                        }
                        else
                        {
                            color = Brushes.Green;
                        }
                        pza58.Fill = color;
                    }
                    else if (id == "LKOH.SVO.59")
                    {
                        id = "ПЗА-59";
                        pza59Speed.Content = Convert.ToString(speedTZA);
                        //pza58Volume.Content = Convert.ToString(volume);
                        //color = Brushes.LightCyan;
                        numberTZA = "59";
                        if (status == 4 || status == 5 || status == 21)
                        {
                            color = Brushes.Green;
                        }
                        else if (status == 7)
                        {
                            color = Brushes.Orange;
                        }
                        else if (status == 9 || status == 10 || status == 12 || status == 14)
                        {
                            color = Brushes.Red;
                        }
                        else if (status == 99)
                        {
                            color = Brushes.Black;
                        }
                        else if (status == 98)
                        {
                            color = Brushes.DimGray;
                        }
                        else
                        {
                            color = Brushes.Green;
                        }
                        pza59.Fill = color;
                    }
                    else if (id == "LKOH.SVO.60")
                    {
                        id = "ПЗА-60";
                        pza60Speed.Content = Convert.ToString(speedTZA);
                        //pza58Volume.Content = Convert.ToString(volume);
                        //color = Brushes.LightCyan;
                        numberTZA = "60";
                        if (status == 4 || status == 5 || status == 21)
                        {
                            color = Brushes.Green;
                        }
                        else if (status == 7)
                        {
                            color = Brushes.Orange;
                        }
                        else if (status == 9 || status == 10 || status == 12 || status == 14)
                        {
                            color = Brushes.Red;
                        }
                        else if (status == 99)
                        {
                            color = Brushes.Black;
                        }
                        else if (status == 98)
                        {
                            color = Brushes.DimGray;
                        }
                        else
                        {
                            color = Brushes.Green;
                        }
                        pza60.Fill = color;
                    }
                    else if (id == "LKOH.SVO.61")
                    {
                        id = "ПЗА-61";
                        pza61Speed.Content = Convert.ToString(speedTZA);
                        //pza58Volume.Content = Convert.ToString(volume);
                        //color = Brushes.LightCyan;
                        numberTZA = "61";
                        if (status == 4 || status == 5 || status == 21)
                        {
                            color = Brushes.Green;
                        }
                        else if (status == 7)
                        {
                            color = Brushes.Orange;
                        }
                        else if (status == 9 || status == 10 || status == 12 || status == 14)
                        {
                            color = Brushes.Red;
                        }
                        else if (status == 99)
                        {
                            color = Brushes.Black;
                        }
                        else if (status == 98)
                        {
                            color = Brushes.DimGray;
                        }
                        else
                        {
                            color = Brushes.Green;
                        }
                        pza61.Fill = color;
                    }
                    else if (id == "LKOH.SVO.62")
                    {
                        id = "ПЗА-62";
                        pza62Speed.Content = Convert.ToString(speedTZA);
                        //pza58Volume.Content = Convert.ToString(volume);
                        //color = Brushes.LightCyan;
                        numberTZA = "62";
                        if (status == 4 || status == 5 || status == 21)
                        {
                            color = Brushes.Green;
                        }
                        else if (status == 7)
                        {
                            color = Brushes.Orange;
                        }
                        else if (status == 9 || status == 10 || status == 12 || status == 14)
                        {
                            color = Brushes.Red;
                        }
                        else if (status == 99)
                        {
                            color = Brushes.Black;
                        }
                        else if (status == 98)
                        {
                            color = Brushes.DimGray;
                        }
                        else
                        {
                            color = Brushes.Green;
                        }
                        pza62.Fill = color;
                    }
                    else if (id == "LKOH.SVO.63")
                    {
                        id = "ПЗА-63";
                        pza63Speed.Content = Convert.ToString(speedTZA);
                        //pza58Volume.Content = Convert.ToString(volume);
                        //color = Brushes.LightCyan;
                        numberTZA = "63";
                        if (status == 4 || status == 5 || status == 21)
                        {
                            color = Brushes.Green;
                        }
                        else if (status == 7)
                        {
                            color = Brushes.Orange;
                        }
                        else if (status == 9 || status == 10 || status == 12 || status == 14)
                        {
                            color = Brushes.Red;
                        }
                        else if (status == 99)
                        {
                            color = Brushes.Black;
                        }
                        else if (status == 98)
                        {
                            color = Brushes.DimGray;
                        }
                        else
                        {
                            color = Brushes.Green;
                        }
                        pza63.Fill = color;
                    }
                    else if (id == "LKOH.SVO.64")
                    {
                        id = "ПЗА-64";
                        pza64Speed.Content = Convert.ToString(speedTZA);
                        //pza58Volume.Content = Convert.ToString(volume);
                        //color = Brushes.LightCyan;
                        numberTZA = "64";
                        if (status == 4 || status == 5 || status == 21)
                        {
                            color = Brushes.Green;
                        }
                        else if (status == 7)
                        {
                            color = Brushes.Orange;
                        }
                        else if (status == 9 || status == 10 || status == 12 || status == 14)
                        {
                            color = Brushes.Red;
                        }
                        else if (status == 99)
                        {
                            color = Brushes.Black;
                        }
                        else if (status == 98)
                        {
                            color = Brushes.DimGray;
                        }
                        else
                        {
                            color = Brushes.Green;
                        }
                        pza64.Fill = color;
                    }
                    if (yc > 0 && xc > 0)
                    {
                        double top = (luy + ruy) / 2;
                        double bottom = (lby + rby) / 2;
                        double left = (lux + lbx) / 2;
                        double right = (rux + rbx) / 2;
                        double w = right - left;    //ширина в мировых координатах
                        double h = top - bottom;    //высота
                        double scalex = w / picture.Width;  //вычисляем масштаб
                        double scaley = h / picture.Height;
                        double mx = (xc - left) / scalex;   //вычисляем координаты в пикселях на карте
                        double my = (yc - bottom) / scaley;
                        double x = (int)mx;
                        double y = (int)my;
                        if (x >= 0 && x <= picture.Width && y >= 0 && y < picture.Height) //если попадаем на изображение
                        {
                            circle(x, y, 30, 30, (Application.Current.MainWindow as MainWindow).can, id, speedTZA, volume, color, numberTZA);
                        }
                    }
                }
            }
            catch
            {

            }
        }
        
        public static void circle(double x, double y, int width, int height, Canvas cv, string id, decimal speedTZA, double volume, SolidColorBrush color, string numberTZA)
        {
            Ellipse circle = new Ellipse()
            {
                Width = width,
                Height = height,
                Fill = color,
                Stroke = Brushes.Black,               
                StrokeThickness = 5
            };

            cv.Children.Add(circle);

            TextBlock tb = new TextBlock();
            tb.Text = numberTZA;
            tb.Foreground = Brushes.White;
            tb.FontSize = 18;
            cv.Children.Add(tb);

            circle.SetValue(Canvas.LeftProperty,  (double)x + 30);
            circle.SetValue(Canvas.TopProperty, (Application.Current.MainWindow as MainWindow).picture.Height - (double)y);
            tb.SetValue(Canvas.LeftProperty, (double)x + 35.7);
            tb.SetValue(Canvas.TopProperty, (Application.Current.MainWindow as MainWindow).picture.Height - (double)y+2);
            if (id == "ПЗА-50" || id == "ПЗА-51" || id == "ПЗА-52" || id == "ПЗА-53" || id == "ПЗА-54" || id == "ПЗА-55" || id == "ПЗА-56" || id == "ПЗА-57" || id == "ПЗА-58" || id == "ПЗА-59" || id == "ПЗА-60" || id == "ПЗА-61" || id == "ПЗА-62" || id == "ПЗА-63" || id == "ПЗА-64")
            {
                ToolTip toolTip = new ToolTip();
                StackPanel toolTipPanel = new StackPanel();
                toolTip.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#60AA4030"));
                toolTipPanel.Children.Add(new TextBlock { Text = id, FontSize = 34, Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"))});
                toolTipPanel.Children.Add(new TextBlock { Text = "Скорость " + Convert.ToString(speedTZA) + " км/ч.", FontSize = 34, Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF")) });
                toolTip.Content = toolTipPanel;
                tb.ToolTip = toolTip;
            }
            else
            {
                ToolTip toolTip = new ToolTip();
                StackPanel toolTipPanel = new StackPanel();
                toolTip.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#60AA4030"));
                toolTipPanel.Children.Add(new TextBlock { Text = id, FontSize = 34, Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF")) });
                toolTipPanel.Children.Add(new TextBlock { Text = "Скорость " + Convert.ToString(speedTZA) + " км/ч.", FontSize = 34, Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF")) });
                toolTipPanel.Children.Add(new TextBlock { Text = "Объем " + Convert.ToString(volume) + " л.", FontSize = 34, Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF")) });
                toolTip.Content = toolTipPanel;
                tb.ToolTip = toolTip;
            }
        }

        private void EnableMagnifier_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            for (int i = can.Children.Count - 1; i >= 0; i--)
            {
                if (can.Children[i] is Ellipse)
                    can.Children.RemoveAt(i);
            }
        }

        private void EnableMagnifier_Checked(object sender, RoutedEventArgs e)
        {
            MagnifiyingGlass.Visibility = Visibility.Visible;
            MagnifiyingGlass.Radius = (double)RadiusDropDown.Value;
        }

        private void EnableMagnifier_Unchecked(object sender, RoutedEventArgs e)
        {
            MagnifiyingGlass.Visibility = Visibility.Hidden;
        }

        private void RadiusDropDown_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {

        }

        private void EnableMagnifier_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (EnableMagnifier.IsCheckable == true)
                {
                    EnableMagnifier.IsCheckable = false;
                }
                else if (EnableMagnifier.IsCheckable == false)
                    EnableMagnifier.IsCheckable = true;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void btnLeftMenuHide_Click(object sender, RoutedEventArgs e)
        {
            ShowHideMenu("sbHideLeftMenu", btnLeftMenuHide, btnLeftMenuShow, pnlLeftMenu);
        }

        private void btnLeftMenuShow_Click(object sender, RoutedEventArgs e)
        {
            ShowHideMenu("sbShowLeftMenu", btnLeftMenuHide, btnLeftMenuShow, pnlLeftMenu);
        }

        private void ShowHideMenu(string Storyboard, Button btnHide, Button btnShow, StackPanel pnl)
        {
            Storyboard sb = Resources[Storyboard] as Storyboard;
            sb.Begin(pnl);

            if (Storyboard.Contains("Show"))
            {
                btnHide.Visibility = System.Windows.Visibility.Visible;
                btnShow.Visibility = System.Windows.Visibility.Hidden;
            }
            else if (Storyboard.Contains("Hide"))
            {
                btnHide.Visibility = System.Windows.Visibility.Hidden;
                btnShow.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void Picture_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (EnableMagnifier.IsChecked == false)
            {
                EnableMagnifier.IsChecked = true;
            }
            else if (EnableMagnifier.IsChecked == true)
            {
                EnableMagnifier.IsChecked = false;
            }
        }

        private void Picture_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            //MouseWheelEventArgs hme = e as MouseWheelEventArgs;
            //if (hme != null)
            //    hme.Handled = true;

            //if (e.Delta > 0)
            //{
            //    ZoomFactorDropDown.Value -= ZoomFactorDropDown.Increment;
            //}
            //else if (e.Delta < 0)
            //{
            //    ZoomFactorDropDown.Value += ZoomFactorDropDown.Increment;
            //}
        }

        private void ZoomFactorDropDown_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            MagnifiyingGlass.ZoomFactor = (double)ZoomFactorDropDown.Value;
        }

        private void Can_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            MouseWheelEventArgs hme = e as MouseWheelEventArgs;
            if (hme != null)
                hme.Handled = true;

            if (e.Delta > 0)
            {
                ZoomFactorDropDown.Value -= ZoomFactorDropDown.Increment;
            }
            else if (e.Delta < 0)
            {
                ZoomFactorDropDown.Value += ZoomFactorDropDown.Increment;
            }
        }
    }
}
