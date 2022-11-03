namespace Prototype;

internal abstract class FileComponent
{
    public int Position { get; set; }

    // protected member can be accessed within it's class and from instances of derived class
    protected FileComponent()
    {
        
    }

    protected FileComponent(FileComponent fileComponent)
    {
        this.Position = fileComponent.Position;
    }
    public abstract FileComponent Clone();
}

internal class Paragraph : FileComponent
{
    public string Text { get; set; }

    public Paragraph()
    {
        
    }
    
    private Paragraph(Paragraph paragraph):base(paragraph)
    {
        this.Text = paragraph.Text;
    }
    
    public override FileComponent Clone()
    {
        return new Paragraph(this);
    }
}

internal class Image : FileComponent
{
    public string Source { get; set; }

    public Image()
    {
        
    }

    public Image(Image image): base(image)
    {
        this.Source = image.Source;
    }

    public override FileComponent Clone()
    {
        return new Image(this);
    }
}

internal static class Program
{
    static void Main(string[] args)
    {
        var image = new Image() { Position = 1, Source = "C:/Bild.jpg" };
        var image2 = (Image)image.Clone();
        
        Console.WriteLine($"Position: {image2.Position}; Source: {image2.Source}");
    }
}