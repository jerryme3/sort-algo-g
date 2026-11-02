namespace Final_Project_DSA.builder;

public class ButtonBuilder {
    private readonly Button _button = new();

    private ButtonBuilder() {}
    
    public static ButtonBuilder Start() => new ButtonBuilder();
    
    public ButtonBuilder Background(Color color) {
        _button.BackColor = color;
        return this;
    }

    public ButtonBuilder Foreground(Color color) {
        _button.ForeColor = color;
        return this;
    }
    
    public ButtonBuilder Text(string text) {
        _button.Text = text;
        return this;
    }

    public ButtonBuilder Size(int width, int height) {
        _button.Size = new Size(width, height);
        return this;
    }

    public ButtonBuilder Dock(DockStyle dock = DockStyle.None) {
        _button.Dock = dock;
        return this;
    }

    public ButtonBuilder Margin(int left, int top, int right, int bottom) {
        _button.Margin = new Padding(left, top, right, bottom);
        return this;
    }

    public ButtonBuilder Font(Font font) {
        _button.Font = font;
        return this;
    }
    
    public ButtonBuilder FullWidth(Panel parentPanel) {
        _button.AutoSize = false;
        _button.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        _button.Width = parentPanel.ClientSize.Width - _button.Margin.Horizontal;
        return this;
    }
    
    public ButtonBuilder Padding(int top, int bottom) {
        _button.Padding = new Padding(0, top, 0, bottom);
        return this;
    }

    public ButtonBuilder Height(int height) {
        _button.Height = height;
        return this;
    }
    
    public ButtonBuilder Anchor(AnchorStyles anchor = AnchorStyles.None) {
        _button.Anchor = anchor;
        return this;
    }

    public ButtonBuilder EventHandler(EventHandler handler) {
        _button.Click += handler;
        return this;
    }
    
    public ButtonBuilder Border(Color color, int size = 1) {
        _button.FlatStyle = FlatStyle.Flat;
        _button.FlatAppearance.BorderColor = color;
        _button.FlatAppearance.BorderSize = size;
        return this;
    }

    public Button GetButton() => _button;
}