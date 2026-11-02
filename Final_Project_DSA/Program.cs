using Final_Project_DSA.builder;
using Final_Project_DSA.util;
using static Final_Project_DSA.util.Algorithm;

namespace Final_Project_DSA;

static class Program {

    private static readonly string[] ButtonContent = ["Bubble\nSort", "Selection\nSort", "Merge\nSort", "Insertion\nSort", "Quick\nSort", "Heap\nSort"];

    private static readonly Algorithm[] Algorithms = [BubbleSort, SelectionSort, MergeSort, InsertionSort, QuickSort, HeapSort];
    
    [STAThread]
    static void Main() {
        ApplicationConfiguration.Initialize();

        var title = LabelBuilder
            .Start()
            .Anchor(AnchorStyles.Top)
            .Text("sorting pass viewer")
            .Font(LabelBuilder.JetBrainsMonoFont(13F, FontStyle.Bold))
            .AutoSize();
        
        var midTopPanel = PanelBuilder
            .Start()
            .Add(title.GetLabel())
            .Dock();
        
        var topPanel = PanelBuilder
            .Start()
            .TableLayout(1, 3, DockStyle.Fill, false, 5)
            .AddRowStyle(new RowStyle(SizeType.Percent, 0F))
            .AddRowStyle(new RowStyle(SizeType.Percent, 100F))
            .AddRowStyle(new RowStyle(SizeType.Percent, 0F))
            .Add(midTopPanel.GetPanel(), 1, 0);

        var midSidePanel = PanelBuilder
            .Start()
            .FlowLayout()
            .Dock();

        var inputField = TextBoxBuilder
            .Start()
            .Dock(DockStyle.Fill)
            .Text("Enter elements to sort here (e.g., [5, 7, 1, 3, 0]): ")
            .Font(LabelBuilder.JetBrainsMonoFont(10F, FontStyle.Italic | FontStyle.Bold));

        var inputBorderPanel = PanelBuilder
            .Start()
            .Background(Color.Black)
            .Size(499, 32)
            .Padding(2)
            .Add(inputField.GetTextBox());
        
        var resultField = TextBoxBuilder
            .Start()
            .Dock(DockStyle.Fill)
            .Font(LabelBuilder.JetBrainsMonoFont(13F, FontStyle.Bold))
            .Scroll()
            .ReadOnly()
            .MultiLine(true);
        
        var resultBorderPanel = PanelBuilder
            .Start()
            .Background(Color.Black)
            .Size(499, 500)
            .Padding(2)
            .Add(resultField.GetTextBox());
        
        for (int i = 0; i < ButtonContent.Length; i++) {
            var j = i;
            var button = ButtonBuilder
                .Start()
                .Text(ButtonContent[i])
                .Background(ColorPalette.BrightOrchidPink)
                .Border(Color.Black, 2)
                .Font(LabelBuilder.JetBrainsMonoFont(8F, FontStyle.Bold | FontStyle.Italic))
                .Height(50)
                .Padding(5, 5)
                .EventHandler((_,_) => {
                    resultField.Text(string.Join("", Sorter.Sort(inputField.GetTextBox().Text, Algorithms[j])));
                })
                .Margin(10, 15, 10, 15);
        
            midSidePanel.Add(button.GetButton());
        }

        var sidePanel = PanelBuilder
            .Start()
            .TableLayout(3, 1, DockStyle.Fill, false, 5)
            .AddColumnStyle(new ColumnStyle(SizeType.Percent, 5F))
            .AddColumnStyle(new ColumnStyle(SizeType.Percent, 90F))
            .AddColumnStyle(new ColumnStyle(SizeType.Percent, 5F))
            .Add(midSidePanel.GetPanel(), 0, 1);

        var midPanel = PanelBuilder
            .Start()
            .TableLayout(1, 2, DockStyle.Fill, false, 5)
            .AddRowStyle(new RowStyle(SizeType.Percent, 7F))
            .AddRowStyle(new RowStyle(SizeType.Percent, 93F))
            .Add(inputBorderPanel.GetPanel(), 0, 0)
            .Add(resultBorderPanel.GetPanel(), 1, 0);
        
        var backgroundPanel = PanelBuilder
            .Start()
            .TableLayout(2, 2, DockStyle.Fill, false, 5)
            .AddColumnStyle(new ColumnStyle(SizeType.Percent, 75F))
            .AddColumnStyle(new ColumnStyle(SizeType.Percent, 25F))
            .AddRowStyle(new RowStyle(SizeType.Percent, 10F))
            .AddRowStyle(new RowStyle(SizeType.Percent, 100F))
            .ColumnSpan(topPanel.GetPanel(), 2, 0, 0)
            .Add(sidePanel.GetPanel(), 1, 1)
            .Add(midPanel.GetPanel(), 1, 0);
        
        var form = FormBuilder
            .Start()
            .Title("Data Structures and Algorithms")
            .Size(720, 600)
            .Sizable(false)
            .Add(backgroundPanel.GetPanel())
            .GetForm();
        
        Application.Run(form);
    }
}