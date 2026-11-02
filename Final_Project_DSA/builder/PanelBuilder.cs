namespace Final_Project_DSA.builder;

public class PanelBuilder {

    private Panel _panel = new();

    private PanelBuilder() {}

    public Panel GetPanel() => _panel;
    
    public static PanelBuilder Start() {
        return new PanelBuilder();
    }
    
    public PanelBuilder Size(int width, int length) {
        _panel.Size = new Size(width, length);
        return this;
    }

    public PanelBuilder FlowLayout(FlowDirection direction = FlowDirection.TopDown, DockStyle style = DockStyle.Fill, bool wrapContents = false) {
        FlowLayoutPanel flp = new() {
            Dock = style, FlowDirection = direction, WrapContents = wrapContents
        };
        
        flp.SizeChanged += (s, e) => {
            flp.SuspendLayout();
            foreach (Control ctrl in flp.Controls) {
                if (ctrl is Button btn) {
                    btn.Width = flp.ClientSize.Width - btn.Margin.Horizontal;
                }
            }
            flp.ResumeLayout();
        };
        
        _panel = flp;
        return this;
    }
    
    //Defaults at TableLayoutPanel
    public PanelBuilder TableLayout(
        int col, int row, DockStyle dockStyle, bool putLines = false, int padding = 0
    ) {
        var table = new TableLayoutPanel() {
            Dock = dockStyle, ColumnCount = col, RowCount = row, Padding = new Padding(padding),
            CellBorderStyle = putLines 
                ? TableLayoutPanelCellBorderStyle.Single
                : TableLayoutPanelCellBorderStyle.None
        };
            
        if (col > 0) {
            float colPercentage = 100f / col;
            for (int i = 0; i < col; i++) {
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, colPercentage));
            }
        }

        
        if (row > 0) {
            float rowPercentage = 100f / row;
            for (int i = 0; i < row; i++) {
                table.RowStyles.Add(new RowStyle(SizeType.Percent, rowPercentage));
            }
        }

        table.ColumnStyles.Clear();
        table.RowStyles.Clear();
        
        _panel = table;
        return this;
    }
        
    public PanelBuilder Dock(DockStyle style = DockStyle.Fill) {
        _panel.Dock = style;
        return this;
    }
        
    public PanelBuilder Add(Control control, int row, int col) {
        if (_panel is TableLayoutPanel p) {
            p.Controls.Add(control, col, row);
        }
        return this;
    }

    public PanelBuilder ColumnSpan(Control control, int span, int x, int y) {
        if (_panel is TableLayoutPanel p) {
            p.Controls.Add(control, x, y);
            p.SetColumnSpan(control, span);
        }

        return this;
    }
    
    public PanelBuilder AddColumnStyle(ColumnStyle col) {
        if (_panel is TableLayoutPanel p) {
            if (p.RowStyles.Count == p.RowCount) {
                p.RowStyles.Clear();
            }
            p.ColumnStyles.Add(col);
        }
        return this;
    }

    public PanelBuilder AddRowStyle(RowStyle row) {
        if (_panel is TableLayoutPanel p) {
            if (p.RowStyles.Count == p.RowCount) {
                p.RowStyles.Clear();
            }
            p.RowStyles.Add(row);
        }
        return this;
    }
    
    public PanelBuilder Add(Control control) {
        _panel.Controls.Add(control);
        return this;
    }

    public PanelBuilder Padding(int pad) {
        _panel.Padding = new Padding(2);
        return this;
    }
    
    public PanelBuilder Width(int width) {
        _panel.Width = width;
        return this;
    }

    public PanelBuilder Height(int height) {
        _panel.Height = height;
        return this;
    }
    
    public PanelBuilder Background(Color color) {
        _panel.BackColor = color;
        return this;
    }
    
    
}