namespace Final_Project_DSA.builder;

public class LabelBuilder {
    
    private readonly Label _label = new();
    
    private LabelBuilder() {}

    public Label GetLabel() => _label;
    
    public static LabelBuilder Start() {
        return new LabelBuilder();
    }

    public LabelBuilder Anchor(AnchorStyles anchor = AnchorStyles.None) {
        _label.Anchor = anchor; 
        return this;
    }

    public LabelBuilder Text(string text) {
        _label.Text = text;
        return this;
    }

    public LabelBuilder Size(int width, int length) {
        _label.Size = new Size(width, length);
        return this;
    }
    
    public LabelBuilder Font(Font font) {
        _label.Font = font;
        return this;
    }
    
    public LabelBuilder Foreground(Color color) {
        _label.ForeColor = color;
        return this;
    }

    public LabelBuilder AutoSize(bool autoSize = true) {
        _label.AutoSize = autoSize;
        return this;
    }

    public static Font JetBrainsMonoFont(float size, FontStyle style = FontStyle.Regular) {
        return new Font("JetBrains Mono", size, style);
    }
    
}