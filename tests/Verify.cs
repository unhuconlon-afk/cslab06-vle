using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using CSLab06;

internal static class Verify
{
    private const BindingFlags Private = BindingFlags.Instance | BindingFlags.NonPublic;
    private static int checks;

    private static T Field<T>(object target, string name)
    {
        return (T)target.GetType().GetField(name, Private).GetValue(target);
    }

    private static void Assert(bool condition, string message)
    {
        if (!condition) throw new Exception(message);
        checks++;
        Console.WriteLine("PASS: " + message);
    }

    private static void ShowOffscreen(Form form)
    {
        form.StartPosition = FormStartPosition.Manual;
        form.Location = new Point(-5000, -5000);
        form.ShowInTaskbar = false;
        form.Show();
        Application.DoEvents();
    }

    private static void Capture(Form form, string name)
    {
        using (Bitmap bitmap = new Bitmap(form.Width, form.Height))
        {
            form.DrawToBitmap(bitmap, new Rectangle(Point.Empty, form.Size));
            bitmap.Save(Path.Combine("TestResults", name));
        }
    }

    private static void Matrix(int rows, int columns, string screenshot)
    {
        using (frmXuat form = new frmXuat(rows, columns))
        {
            Panel panel = Field<Panel>(form, "panelContainer");
            Assert(panel.Controls.Count == 0, "Runtime buttons are absent before Load");
            ShowOffscreen(form);
            Button[,] array = Field<Button[,]>(form, "mangButton");
            Assert(array.GetLength(0) == rows && array.GetLength(1) == columns, "Array dimensions: " + rows + " x " + columns);
            Assert(panel.Controls.Count == rows * columns, "Correct number of controls");
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < columns; j++)
                {
                    Button button = array[i, j];
                    if (button.Text != (i * columns + j + 1).ToString() ||
                        button.Left != 5 + 40 * j || button.Top != 5 + 40 * i ||
                        button.Width != 35 || button.Height != 35 ||
                        (string)button.Tag != string.Format("Dòng {0} cột {1}", i, j))
                        throw new Exception("Incorrect value, position, size or Tag at " + i + "," + j);
                }
            Assert(true, "Every button matches the PDF's numbering, coordinates and zero-based Tag");
            Button last = array[rows - 1, columns - 1];
            typeof(Control).GetMethod("OnMouseHover", Private).Invoke(last, new object[] { EventArgs.Empty });
            Assert(form.Text == (string)last.Tag, "MouseHover updates the title");
            Assert(Field<ToolStripStatusLabel>(form, "lblStatus").Text.Contains(last.Text), "Hover status contains the value");
            Assert(panel.AutoScrollMinSize.Width >= last.Right && panel.AutoScrollMinSize.Height >= last.Bottom, "Scroll area includes the last button");
            if (rows == 3 && columns == 4)
                Assert(!panel.HorizontalScroll.Visible && !panel.VerticalScroll.Visible, "PDF 3x4 example fits without scrollbars");
            if (rows == 50 && columns == 50)
                Assert(panel.HorizontalScroll.Visible && panel.VerticalScroll.Visible, "50x50 matrix can scroll in both directions");
            int count = panel.Controls.Count;
            form.Hide();
            form.Show();
            Application.DoEvents();
            Assert(panel.Controls.Count == count, "Showing again does not duplicate controls");
            if (screenshot != null) Capture(form, screenshot);
        }
    }

    private static void Input(string text, bool expectedValid, int expectedValue)
    {
        using (frmNhapLieu form = new frmNhapLieu())
        {
            TextBox input = Field<TextBox>(form, "txtSoDong");
            input.Text = text;
            object[] arguments = { input, "Số dòng", 0 };
            bool valid = (bool)typeof(frmNhapLieu).GetMethod("DocKichThuoc", Private).Invoke(form, arguments);
            Assert(valid == expectedValid, "Input validity: '" + text + "'");
            if (valid) Assert((int)arguments[2] == expectedValue && input.Text == expectedValue.ToString(), "Parsed/default value: " + expectedValue);
            else Assert(Field<ErrorProvider>(form, "errorProvider").GetError(input).Length > 0, "Invalid size is explained beside the input");
        }
    }

    private static void Transfer()
    {
        using (frmNhapLieu input = new frmNhapLieu())
        using (Timer timer = new Timer())
        {
            ShowOffscreen(input);
            Field<TextBox>(input, "txtSoDong").Text = "3";
            Field<TextBox>(input, "txtSoCot").Text = "4";
            frmXuat output = null;
            timer.Interval = 100;
            timer.Tick += delegate
            {
                foreach (Form form in Application.OpenForms)
                {
                    output = form as frmXuat;
                    if (output == null) continue;
                    timer.Stop();
                    Assert(output.SoDong == 3 && output.SoCot == 4, "Create button transfers 3x4 through the constructor");
                    Assert(output.Modal && output.Owner == input, "Output is shown as an owned modal form");
                    output.Close();
                    break;
                }
            };
            timer.Start();
            Field<Button>(input, "btnKhoiTao").PerformClick();
            Assert(output != null && output.IsDisposed, "Closing output returns to input and disposes the form");
            Capture(input, "input.png");
        }
    }

    [STAThread]
    private static int Main()
    {
        try
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Directory.CreateDirectory("TestResults");
            Matrix(1, 1, null);
            Matrix(3, 4, "matrix-3x4.png");
            Matrix(1, 50, null);
            Matrix(50, 1, null);
            Matrix(50, 50, "matrix-50x50.png");
            Input("", true, 1);
            Input("abc", true, 1);
            Input("2147483648", true, 1);
            Input("3", true, 3);
            Input("50", true, 50);
            Input("0", false, 0);
            Input("-1", false, 0);
            Input("51", false, 0);
            bool rejected = false;
            try { using (var invalid = new frmXuat(0, 4)) { } }
            catch (ArgumentOutOfRangeException) { rejected = true; }
            Assert(rejected, "Constructor rejects invalid dimensions");
            using (var defaultForm = new frmXuat())
                Assert(defaultForm.SoDong == 1 && defaultForm.SoCot == 1, "Parameterless constructor defaults to 1x1");
            Transfer();
            Console.WriteLine("All " + checks + " checks passed.");
            return 0;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex);
            return 1;
        }
    }
}
