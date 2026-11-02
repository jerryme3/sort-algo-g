namespace Final_Project_DSA.builder;

public class FormBuilder {

    private readonly Form _form = new();

    public static FormBuilder Start() {
        return new FormBuilder();
    }
    
    public FormBuilder Add(Control control) {
        _form.Controls.Add(control);
        return this;
    }
        
    public FormBuilder Title(string name) {
        _form.Text = name;
        return this;
    }

    public FormBuilder Size(int width, int length) {
        _form.Size = new Size(width, length);
        return this;
    }

    public FormBuilder Background(Color color) {
        _form.BackColor = color;
        return this;
    }
    
    public FormBuilder Sizable(bool sizable = true) {
        if (!sizable) {
            _form.FormBorderStyle = FormBorderStyle.FixedSingle;
            _form.MaximizeBox = false;
        }

        return this;
    }
    
    public Form GetForm() => _form;
}