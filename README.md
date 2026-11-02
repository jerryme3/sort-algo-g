# Sorting Pass Viewer — Classes and Methods

This project uses Windows Forms to build a sorting-visualization window. It also demonstrates the **Builder design pattern**.

## Project entry point

### `Program`

Defined in `Program.cs`.

| Member | What it does |
|---|---|
| `ButtonContent` | Array of the text shown on the six sorting buttons. |
| `Algorithms` | Array matching each button to an `Algorithm` enum value. |
| `Main()` | Creates the window, controls, layout, event handlers, and starts the application. |

`Main()` builds the UI in this order:

1. Creates the title label and top panel.
2. Creates the input text box and result text box.
3. Creates six sorting buttons.
4. Places controls inside table and flow layouts.
5. Creates the main form.
6. Calls `Application.Run(form)` to display the window.

Each button stores a lambda event handler. The click handler calls:

```csharp
Sorter.Sort(inputText, selectedAlgorithm)
```

The returned list of strings is joined with `string.Join("", ...)` and placed in the result text box.

---

## Builder classes

Builder classes use fluent methods: calling a method changes the control and then returns the builder with `return this`. This lets multiple methods be chained together.

### `ButtonBuilder`

File: `builder/ButtonBuilder.cs`

Creates and configures Windows Forms `Button` objects.

| Method | Parameters | Description |
|---|---|---|
| `Start()` | None | Creates a new `ButtonBuilder`. |
| `Background(Color)` | Color | Sets the background color. |
| `Foreground(Color)` | Color | Sets the text color. |
| `Text(string)` | Text | Sets the text displayed on the button. |
| `Size(int, int)` | Width, height | Sets both dimensions. |
| `Dock(DockStyle)` | Dock style; default is `DockStyle.None` | Controls how the button attaches to its container. |
| `Margin(int, int, int, int)` | Left, top, right, bottom | Sets outside spacing. |
| `Font(Font)` | Font | Sets the button font. |
| `FullWidth(Panel)` | Parent panel | Makes the button fit the parent width. |
| `Padding(int, int)` | Top, bottom | Sets vertical inner spacing. |
| `Height(int)` | Height | Sets only the height. |
| `Anchor(AnchorStyles)` | Anchor style; default is `AnchorStyles.None` | Keeps the button attached to selected edges when its parent is resized. |
| `EventHandler(EventHandler)` | Handler | Adds the method called by a button click. |
| `Border(Color, int)` | Color and border size; default size is 1 | Applies a flat border style. |
| `GetButton()` | None | Returns the configured `Button`. |

Private fields: `_button`.

---

### `FormBuilder`

File: `builder/FormBuilder.cs`

Creates and configures a Windows Forms `Form`.

| Method | Parameters | Description |
|---|---|---|
| `Start()` | None | Creates a new `FormBuilder`. |
| `Add(Control)` | Control | Adds a control to the form. |
| `Title(string)` | Title | Sets the window title. |
| `Size(int, int)` | Width, height | Sets the window size. |
| `Background(Color)` | Color | Sets the form background color. |
| `Sizable(bool)` | Default value is `true` | When passed `false`, removes resizing and maximize behavior. |
| `GetForm()` | None | Returns the configured `Form`. |

Private fields: `_form`.

---

### `LabelBuilder`

File: `builder/LabelBuilder.cs`

Creates and configures a read-only Windows Forms `Label`.

| Method | Parameters | Description |
|---|---|---|
| `Start()` | None | Creates a new `LabelBuilder`. |
| `GetLabel()` | None | Returns the configured `Label`. |
| `Anchor(AnchorStyles)` | Anchor style; default is `AnchorStyles.None` | Controls which edges stay attached when resized. |
| `Text(string)` | Text | Sets the displayed text. |
| `Size(int, int)` | Width, height | Sets an explicit size. |
| `Font(Font)` | Font | Sets the text font. |
| `Foreground(Color)` | Color | Sets the text color. |
| `AutoSize(bool)` | Default value is `true` | Automatically changes the label size to fit the text. |
| `JetBrainsMonoFont(float, FontStyle)` | Font size and style | Static method that creates a JetBrains Mono `Font`. The style defaults to regular. |

Private fields: `_label`.

---

### `PanelBuilder`

File: `builder/PanelBuilder.cs`

Creates and configures panels used to contain and arrange controls. It can produce a regular panel, `FlowLayoutPanel`, or `TableLayoutPanel`.

| Method | Parameters | Description |
|---|---|---|
| `Start()` | None | Creates a new `PanelBuilder`. |
| `GetPanel()` | None | Returns the configured panel. |
| `Size(int, int)` | Width, height | Sets the panel dimensions. |
| `FlowLayout(FlowDirection, DockStyle, bool)` | Direction, docking, wrapping | Converts the panel to a `FlowLayoutPanel`. Defaults: top-down, fill, and no wrapping. |
| `TableLayout(int, int, DockStyle, bool, int)` | Columns, rows, docking, cell borders, padding | Converts the panel to a `TableLayoutPanel`. |
| `Dock(DockStyle)` | Dock style; default is fill | Makes the panel fill or attach to its parent. |
| `Add(Control, int, int)` | Control, row, column | Adds a control to an exact table-layout cell. |
| `ColumnSpan(Control, int, int, int)` | Control, column span, x, y | Adds a control and makes it span multiple table columns. |
| `AddColumnStyle(ColumnStyle)` | Column style | Adds a column width rule. |
| `AddRowStyle(RowStyle)` | Row style | Adds a row height rule. |
| `Add(Control)` | Control | Adds a control to a normal or flow layout panel. |
| `Padding(int)` | Padding value | Sets inner spacing. The implementation currently always creates padding of 2. |
| `Width(int)` | Width | Sets the panel width. |
| `Height(int)` | Height | Sets the panel height. |
| `Background(Color)` | Color | Sets the panel background color. |

Private fields: `_panel`.

Important layout types:

- `FlowLayoutPanel` arranges controls in sequence.
- `TableLayoutPanel` arranges controls by rows and columns.
- `SizeType.Percent` allows a row or column to use a percentage of available space.

---

### `TextBoxBuilder`

File: `builder/TextBoxBuilder.cs`

Creates and configures Windows Forms `TextBox` controls.

| Method | Parameters | Description |
|---|---|---|
| `Start()` | None | Creates a new `TextBoxBuilder`. |
| `Dock(DockStyle)` | Dock style | Controls how the text box fills or attaches to its parent. |
| `ReadOnly(bool)` | Default value is `true` | Prevents user editing when enabled. |
| `Foreground(Color)` | Color | Sets text color. |
| `MultiLine(bool)` | Default value is `false` | Allows or disables multiple lines. |
| `Font(Font)` | Font | Sets the text font. |
| `Text(string)` | Text | Sets the text box content. |
| `Border()` | None | Applies `BorderStyle.Fixed3D`. |
| `Scroll(bool)` | Default value is `true` | Adds horizontal and vertical scrollbars. |
| `Background(Color)` | Color | Sets the text-box background color. |
| `GetTextBox()` | None | Returns the configured `TextBox`. |

Private fields: `_textBox`.

---

## Sorting classes and types

### `Algorithm`

File: `util/Algorithm.cs`

Public enum containing the algorithm choices:

```csharp
public enum Algorithm {
    BubbleSort,
    SelectionSort,
    MergeSort,
    InsertionSort,
    QuickSort,
    HeapSort
}
```

An enum stores fixed named options rather than requiring raw numeric values.

---

### `Sorter`

File: `util/Sorter.cs`

A static class containing the input parser and sorting operations.

| Method | Access | Parameters | Returns | Description |
|---|---|---|---|---|
| `ParseInput(string)` | Private | Input text | `int[]` | Removes square brackets, splits on commas, converts each value to an integer, and handles invalid or blank input. |
| `BubbleSort(string)` | Private | Input text | `List<string>` | Parses the input and records the algorithm name, original array, and each Bubble Sort pass. |
| `Sort(string, Algorithm)` | Public | Input text and algorithm | `List<string>` | Dispatches supported algorithms. |

#### `ParseInput(string)` behavior

- Removes every `[` and `]` character.
- Splits text on commas.
- Trims spaces around each item.
- Calls `int.Parse()` on each item.
- Returns `['#']` when parsing fails.
- Returns `['@']` for whitespace-only input.

The `#` and `@` values act as internal error or blank-input markers inside the integer array.

#### `BubbleSort(string)` behavior

- Calls `ParseInput()`.
- Reports an invalid-input message if the first parsed value is `#`.
- Reports a blank-array message if the first parsed value is `@`.
- Stores the original array and the array state after every pass in a `List<string>`.
- Swaps neighboring values with tuple assignment when they are in the wrong order.
- Returns the collected output lines.

#### `Sort(string, Algorithm)` behavior

The switch currently implements only:

```csharp
case Algorithm.BubbleSort:
    return BubbleSort(input);
```

Other enum values enter the default branch and throw `RuntimeBinderException`, because the corresponding sorting methods have not yet been implemented.

---

## Color class

### `ColorPalette`

File: `util/ColorPalette.cs`

A static class containing reusable immutable color fields.

| Field | Hex value |
|---|---|
| `LightSoftPink` | `#FCD6F9` |
| `SoftMagenta` | `#FFC6FE` |
| `BrightOrchidPink` | `#F6B2FF` |
| `PaleLavender` | `#CEAFFF` |
| `RichSoftViolet` | `#C19BFF` |

Every field is created using `ColorTranslator.FromHtml(...)`.

---

## Designer-generated form

### `Form1`

Defined through the partial class declarations in `Form1.cs` and `Form1.Designer.cs`.

The `partial` keyword joins both portions into one class.

#### Public/instance members

| Member | Description |
|---|---|
| `Form1()` | Constructor. It currently contains no UI setup code. |
| `Form1_Load(object, EventArgs)` | Reserved load event; it is currently empty. |
| `checkBox1_CheckedChanged(object, EventArgs)` | Event handler that currently throws `NotImplementedException`. |
| `checkBox3_CheckedChanged(object, EventArgs)` | Event handler that currently throws `NotImplementedException`. |
| `panel1_Paint(object, PaintEventArgs)` | Panel paint handler that currently throws `NotImplementedException`. |

#### Designer members

| Member | Description |
|---|---|
| `InitializeComponent()` | Creates designer-generated controls and sets their properties. |
| `Dispose(bool)` | Releases managed components. |
| `panel1` | Private `Panel` field. |
| `checkBox2` | Private `CheckBox` field. |
| `components` | Stores designer-managed components for disposal. |

This class is not created by the current `Program.Main()` and is separate from the builder-generated main window.

---

## Class relationships

```text
Program
├── FormBuilder ── creates Form
├── PanelBuilder ── creates Panel / FlowLayoutPanel / TableLayoutPanel
├── LabelBuilder ── creates Label
├── TextBoxBuilder ── creates TextBox
├── ButtonBuilder ── creates Button
├── ColorPalette ── supplies colors
├── Algorithm ── supplies named choices
└── Sorter
    ├── ParseInput()
    ├── BubbleSort()
    ├── SelectionSort()
    ├── MergeSort()
    ├── InsertionSort()
    ├── QuickSort()
    ├── HeapSort()
    └── Sort()
```

The builders are responsible for constructing controls. `Program` is responsible for arranging the controls. `Sorter` is responsible for converting input and producing sorting output.
