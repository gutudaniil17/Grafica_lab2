using System.Windows.Forms.DataVisualization.Charting;


namespace Grafica_lab2;

public partial class Form1 : Form
{
    private Chart _chart1;
    private string filePath = "C:\\Users\\Gutu\\RiderProjects\\Grafica_lab2\\data\\data.txt";
    public Form1()
    {
        InitializeComponent();
        _chart1 = new Chart();
        _chart1.Dock = DockStyle.Fill;
        this.Controls.Add(_chart1);
        MainForm_Load();
    }
    
    
    private void MainForm_Load()
    {
        // Define the data
        string[] data = MyService.ReadLinesFromFile(filePath);
        string[] companies = new string[data.Length];
        int[] values = new int[data.Length];
        for(int i = 0 ; i < data.Length; i++)
        {
            string[] value = data[i].Split(" ");
            companies[i] = value[0];
            values[i] = Convert.ToInt32(value[1]);
        }


        // Create a chart area and add it to the chart
        ChartArea chartArea = new ChartArea();
        _chart1.ChartAreas.Add(chartArea);

        // Create a series with the name "Values" and add it to the chart
        Series series = new Series("Values");
        _chart1.Series.Add(series);
        series["PointWidth"] = "0.3";

        // Add data points to the series
        for (int i = 0; i < companies.Length; i++)
        {
            series.Points.AddXY(companies[i], values[i]);
        }

        // Set chart properties
        series.ChartType = SeriesChartType.Column;
        chartArea.Area3DStyle.Enable3D = true;
        
        _chart1.Titles.Add(new Title("Profit $M", Docking.Top, new Font("Arial", 12), Color.Black));

    }
}