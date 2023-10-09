using System.Windows.Forms.DataVisualization.Charting;

namespace Grafica_lab2;

public partial class Form2 : Form
{
    private Chart _chart1;
    private string filePath = "C:\\Users\\Gutu\\RiderProjects\\Grafica_lab2\\data\\data.txt";

    public Form2()
    {
        InitializeComponent();
        _chart1 = new Chart();
        _chart1.Dock = DockStyle.Fill;
        Controls.Add(_chart1);

        MainForm_Load();
    }


    private void MainForm_Load()
    {
        Legend legend = new Legend();
        _chart1.Legends.Add(legend);
        legend.Docking = Docking.Bottom;
        legend.Alignment = StringAlignment.Center;

        // Define the data
        string[] data = MyService.ReadLinesFromFile(filePath);
        string[] companies = new string[data.Length];
        int[] values = new int[data.Length];

        ChartArea chartArea = new ChartArea();
        _chart1.ChartAreas.Add(chartArea);

        Series series = new Series("Values");
        _chart1.Series.Add(series);
        series["PointGap"] = "5";
        series["PieLabelStyle"] = "Disabled";
        series.ChartType = SeriesChartType.Pie;
        
        for (int i = 0; i < data.Length; i++)
        {
            string[] value = data[i].Split(" ");
            companies[i] = value[0];
            values[i] = Convert.ToInt32(value[1]);

            DataPoint dataPoint = new DataPoint();
            dataPoint.SetValueY(value[1]);
            dataPoint.AxisLabel = companies[i];
            _chart1.Series["Values"].Points.Add(dataPoint);
        }

        // Set chart properties
        series.ChartType = SeriesChartType.Pie;


        _chart1.Titles.Add(new Title("Profit $M", Docking.Top, new Font("Arial", 12), Color.Black));
    }
}