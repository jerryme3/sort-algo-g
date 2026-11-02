namespace Final_Project_DSA.builder;

public class TextBoxBuilder {
    private readonly TextBox _textBox = new();

    private TextBoxBuilder() {}

    public TextBoxBuilder Dock(DockStyle dock) {
        _textBox.Dock = dock;
        return this;
    }

    public TextBoxBuilder ReadOnly(bool value = true) {
        _textBox.ReadOnly = value;
        return this;
    }

    public TextBoxBuilder Foreground(Color color) {
        _textBox.ForeColor = color;
        return this;
    }
    
    public TextBoxBuilder MultiLine(bool multiLine = false) {
        _textBox.Multiline = multiLine;
        return this;
    }

    public static TextBoxBuilder Start() {
        return new TextBoxBuilder();
    }
    
    public TextBoxBuilder Font(Font font) {
        _textBox.Font = font;
        return this;
    }

    public TextBoxBuilder Text(string text) {
        _textBox.Text = text;
        return this;
    }

    public TextBoxBuilder Border() {
        _textBox.BorderStyle = BorderStyle.Fixed3D;
        return this;
    }
    
    public TextBoxBuilder Scroll(bool scroll = true) {
        if (scroll) {
            _textBox.ScrollBars = ScrollBars.Both;
        }

        return this;
    }
    
    public TextBoxBuilder Background(Color color) {
        _textBox.BackColor = color;
        return this;
    }

    public TextBox GetTextBox() => _textBox;

    
}