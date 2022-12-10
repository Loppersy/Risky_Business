using System;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Documents;
using LiveCharts;
using LiveCharts.Wpf;

namespace Risky_Business.Views
{
    public partial class AnalysisView : UserControl
    {
        private static AnalysisView CurrentAnalysisView { get; set; }


        public AnalysisView()
        {
            
            CurrentAnalysisView = this;
            InitializeComponent();
            
            PointLabel = chartPoint =>
                string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);
 
            DataContext = this;

            
        }
        public Func<ChartPoint, string> PointLabel { get; set; }

        public static void DisplayResults(string url)
        {
            if(CurrentAnalysisView == null) return;
            
            CurrentAnalysisView.AnalysedURL.Text = "Analysed URL: ";
            CurrentAnalysisView.AnalysedURL.Inlines.Add(new Italic(new Run(url)));
            
            CurrentAnalysisView.Results.Text = "";
            CurrentAnalysisView.Results.Inlines.Add(new Bold(new Run("Google Safe Browsing: ")));
            CurrentAnalysisView.Results.Inlines.Add("2");
            CurrentAnalysisView.Results.Inlines.Add(new LineBreak());
            CurrentAnalysisView.Results.Inlines.Add(new Bold(new Run("Virus Total: ")));
            CurrentAnalysisView.Results.Inlines.Add("3");
            CurrentAnalysisView.Results.Inlines.Add(new LineBreak());
            CurrentAnalysisView.Results.Inlines.Add(new Bold(new Run("API Number 3: ")));
            CurrentAnalysisView.Results.Inlines.Add("Triangle");
            CurrentAnalysisView.Results.Inlines.Add(new LineBreak());
            CurrentAnalysisView.Results.Inlines.Add(new Bold(new Run("API Number 4: ")));
            CurrentAnalysisView.Results.Inlines.Add("Yes");
            CurrentAnalysisView.Results.Inlines.Add(new LineBreak());
            CurrentAnalysisView.Results.Inlines.Add(new Bold(new Run("API Number 5: ")));
            CurrentAnalysisView.Results.Inlines.Add("Wut");
            CurrentAnalysisView.Results.Inlines.Add(new LineBreak());


        }
        private void Chart_OnDataClick(object sender, ChartPoint chartpoint)
        {
            var chart = (LiveCharts.Wpf.PieChart) chartpoint.ChartView;
            
            //clear selected slice.
            foreach (PieSeries series in chart.Series)
                series.PushOut = 0;
 
            var selectedSeries = (PieSeries) chartpoint.SeriesView;
            selectedSeries.PushOut = 8;
        }
    }
}