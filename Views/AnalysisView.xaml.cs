using System;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Documents;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Helpers;
using LiveCharts.Wpf;

namespace Risky_Business.Views
{
    public partial class AnalysisView : UserControl
    {
        public AnalysisView()
        {
            CurrentAnalysisView = this;
            InitializeComponent();

            PointLabel = chartPoint =>
                string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            DataContext = this;
        }

        private static AnalysisView CurrentAnalysisView { get; set; }
        public Func<ChartPoint, string> PointLabel { get; set; }

        /**
         * Update AnalysisView with the results from the analysis.
         *
         * @param url the url that was analysed
         * @param votes an array of integers representing the 3 types of "votes" (index 0:safe,1:harmful,2:unknown)
         * that each API gave. Used in pie chart.
         *  Each index of the array is an API:
         *  1: Google Safe Browsing
         *  2: Virus Total
         *  3:
         *  4:
         *  5:
         *
         *  Example (google said safe, virus total said no...): {0,1,2,0,0}
         * @param notes an array of strings with any extra notes about the above APIs. Displayed on the left hand side.
         */
        public static void DisplayResults(string url, int[] votes, string[] notes)
        {
            if (CurrentAnalysisView == null) return;
            
            //Adding Url
            CurrentAnalysisView.AnalysedURL.Text = "Analysed URL: ";
            CurrentAnalysisView.AnalysedURL.Inlines.Add(new Italic(new Run(url)));

            //Adding votes
          for (int i = 0; i<3; i++)
          {
              int[] temp = {0};
              foreach (var t in votes)
              {
                  temp[0] += t == i ? 1 : 0;
              }
              CurrentAnalysisView.Chart.Series[i].Values = temp.AsChartValues();
          }
            
            
            //Adding notes
            CurrentAnalysisView.Results.Text = "";
            CurrentAnalysisView.Results.Inlines.Add(new Bold(new Run("Google Safe Browsing: ")));
            CurrentAnalysisView.Results.Inlines.Add(new LineBreak());
            CurrentAnalysisView.Results.Inlines.Add(notes[0] == null || notes[0]=="" ? "..." : notes[0]);
            CurrentAnalysisView.Results.Inlines.Add(new LineBreak());
            CurrentAnalysisView.Results.Inlines.Add(new Bold(new Run("Virus Total: ")));
            CurrentAnalysisView.Results.Inlines.Add(new LineBreak());
            CurrentAnalysisView.Results.Inlines.Add(notes[1] == null || notes[1]=="" ? "..." : notes[1]);
            CurrentAnalysisView.Results.Inlines.Add(new LineBreak());
            CurrentAnalysisView.Results.Inlines.Add(new Bold(new Run("API Number 3: ")));
            CurrentAnalysisView.Results.Inlines.Add(new LineBreak());
            CurrentAnalysisView.Results.Inlines.Add(notes[2] == null || notes[2]=="" ? "..." : notes[2]);
            CurrentAnalysisView.Results.Inlines.Add(new LineBreak());
            CurrentAnalysisView.Results.Inlines.Add(new Bold(new Run("API Number 4: ")));
            CurrentAnalysisView.Results.Inlines.Add(new LineBreak());
            CurrentAnalysisView.Results.Inlines.Add(notes[3] == null || notes[3]=="" ? "..." : notes[3]);
            CurrentAnalysisView.Results.Inlines.Add(new LineBreak());
            CurrentAnalysisView.Results.Inlines.Add(new Bold(new Run("API Number 5: ")));
            CurrentAnalysisView.Results.Inlines.Add(new LineBreak());
            CurrentAnalysisView.Results.Inlines.Add(notes[4] == null || notes[4]=="" ? "..." : notes[4]);
            CurrentAnalysisView.Results.Inlines.Add(new LineBreak());

            //Trust Score
            double[] weights = {0.5,0.17,0.17,0.08,0.08};
            double trustScore = 0;
            for (int i = 0; i < votes.Length; i++)
            {
                trustScore += votes[i] == 0 ? weights[i] * 100 : 0;
            }
            CurrentAnalysisView.TrustScore.Text = "";
            CurrentAnalysisView.TrustScore.Inlines.Add(new Bold(new Run("Trust Score: ")));
            CurrentAnalysisView.TrustScore.Inlines.Add(new Run($"{(int)trustScore} %"));
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