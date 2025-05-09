using OxyPlot;
using OxyPlot.Series;
using RootFinder.EventArg;
using ScottPlot;
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

namespace RootFinder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();           
        }

        public void DrawButtonPressed(object source, FunctionEventArgs args)
        {
            var model = new PlotModel() { Title = "Function for Investigation:" };

            model.Series.Add(new FunctionSeries(args.Function, args.Xmin, 
                args.Xmax, args.Dx, args.Name));

            this.Plot.Model = model;

            this.Plot.InvalidatePlot(true);
        }
    }
}
