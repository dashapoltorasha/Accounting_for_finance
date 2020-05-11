using Accounting_for_finance.Models;
using Syncfusion.SfChart.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Accounting_for_finance.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Statistic : ContentPage
    {
        public Statistic(int k, DateTime d1, DateTime d2)
        {
            SfChart chart = new SfChart();
            ChartZoomPanBehavior zoomPanBehavior = new ChartZoomPanBehavior();
            zoomPanBehavior.ZoomMode = ZoomMode.X;
            this.BindingContext = new ViewModel(k, d1, d2);
            CategoryAxis primaryAxis = new CategoryAxis();
            primaryAxis.Title.Text = "Дата";
            chart.PrimaryAxis = primaryAxis;
            NumericalAxis secondaryAxis = new NumericalAxis();
            secondaryAxis.Title.Text = "Сумма";
            chart.SecondaryAxis = secondaryAxis;


            for (int i = 0; i < DbService.LoadAllCategory().Count; i++)
            {
                StackingColumnSeries series = new StackingColumnSeries();
                var s = "statistics";
                series.SetBinding(ChartSeries.ItemsSourceProperty, s);
                s = "Amount[" + i + "]";
                series.YBindingPath = s;
                series.XBindingPath = "Date";
                series.Label = DbService.LoadAllCategory()[i].Name;
                //series.DataMarker = new ChartDataMarker();
                series.EnableTooltip = true;
                chart.Legend = new ChartLegend();
                series.EnableDataPointSelection = false;
                chart.Series.Add(series);
            }

            this.Content = chart;
        }
    }
}