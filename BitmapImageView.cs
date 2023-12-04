namespace Grafica_lab2;

public partial class BitmapImageView : Form
{
    public BitmapImageView()
    {
        InitializeComponent();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        string bmpFilePath = "C:\\Users\\Gutu\\RiderProjects\\Grafica_lab2\\data\\danik.bmp";

        try
        {            
            Bitmap image = new Bitmap(bmpFilePath);
            int newWidth = image.Width * 3;
            int newHeight = image.Height * 3;
            e.Graphics.DrawImage(image, new Rectangle(10, 10, newWidth, newHeight));
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading the image: {ex.Message}\n{ex.StackTrace}");
        }

        base.OnPaint(e);
    }
}