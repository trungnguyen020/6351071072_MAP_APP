using System.Drawing;
using System.Windows.Forms;

namespace thuchanh.Helpers;

public static class Ui
{
    public static readonly Color Sidebar = Color.FromArgb(30, 41, 59);
    public static readonly Color SidebarHover = Color.FromArgb(51, 65, 85);
    public static readonly Color Accent = Color.FromArgb(14, 165, 233);
    public static readonly Color PageBackground = Color.FromArgb(241, 245, 249);
    public static readonly Color TextDark = Color.FromArgb(15, 23, 42);
    public static readonly Color TextMuted = Color.FromArgb(100, 116, 139);
    public static readonly Font FontNormal = new("Segoe UI", 10F);
    public static readonly Font FontBold = new("Segoe UI", 10F, FontStyle.Bold);
    public static readonly Font FontTitle = new("Segoe UI", 16F, FontStyle.Bold);
    public static readonly Font FontSubtitle = new("Segoe UI", 10F, FontStyle.Regular);

    public static Label Label(string text, Font? font = null, Color? color = null)
    {
        return new Label
        {
            Text = text,
            AutoSize = true,
            Font = font ?? FontNormal,
            ForeColor = color ?? TextDark
        };
    }

    public static TextBox TextBox(string placeholder = "")
    {
        return new TextBox
        {
            Font = FontNormal,
            BorderStyle = BorderStyle.FixedSingle,
            PlaceholderText = placeholder,
            Height = 30
        };
    }

    public static Button PrimaryButton(string text, Image? icon = null)
    {
        var button = new Button
        {
            Text = text,
            Font = FontBold,
            BackColor = Accent,
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Height = 38,
            AutoSize = true,
            Padding = new Padding(12, 0, 12, 0),
            Image = ResizeIcon(icon),
            ImageAlign = ContentAlignment.MiddleLeft,
            TextImageRelation = TextImageRelation.ImageBeforeText,
            Cursor = Cursors.Hand
        };
        button.FlatAppearance.BorderSize = 0;
        return button;
    }

    private static Image? ResizeIcon(Image? icon)
    {
        if (icon == null) return null;
        return new Bitmap(icon, new Size(20, 20));
    }

    public static Button SecondaryButton(string text, Image? icon = null)
    {
        var button = new Button
        {
            Text = text,
            Font = FontBold,
            BackColor = Color.White,
            ForeColor = TextDark,
            FlatStyle = FlatStyle.Flat,
            Height = 38,
            AutoSize = true,
            Padding = new Padding(12, 0, 12, 0),
            Image = ResizeIcon(icon),
            ImageAlign = ContentAlignment.MiddleLeft,
            TextImageRelation = TextImageRelation.ImageBeforeText,
            Cursor = Cursors.Hand
        };
        button.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
        return button;
    }

    public static void StyleGrid(DataGridView grid)
    {
        grid.BackgroundColor = Color.White;
        grid.BorderStyle = BorderStyle.None;
        grid.GridColor = Color.FromArgb(226, 232, 240);
        grid.EnableHeadersVisualStyles = false;
        grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
        grid.ColumnHeadersDefaultCellStyle.ForeColor = TextDark;
        grid.ColumnHeadersDefaultCellStyle.Font = FontBold;
        grid.ColumnHeadersDefaultCellStyle.Padding = new Padding(6);
        grid.ColumnHeadersHeight = 44;
        grid.DefaultCellStyle.Font = FontNormal;
        grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 242, 254);
        grid.DefaultCellStyle.SelectionForeColor = TextDark;
        grid.DefaultCellStyle.Padding = new Padding(6, 0, 6, 0);
        grid.RowTemplate.Height = 40;
        grid.ReadOnly = true;
        grid.AllowUserToAddRows = false;
        grid.AllowUserToDeleteRows = false;
        grid.AllowUserToResizeRows = false;
        grid.MultiSelect = false;
        grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        grid.RowHeadersVisible = false;
        grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    }

    public static DataGridViewImageColumn ImageColumn(string name, string header, Image? image, int width = 50)
    {
        return new DataGridViewImageColumn
        {
            Name = name,
            HeaderText = header,
            Image = image,
            ImageLayout = DataGridViewImageCellLayout.Zoom,
            AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
            Width = width,
            Resizable = DataGridViewTriState.False,
            SortMode = DataGridViewColumnSortMode.NotSortable
        };
    }

    public static Panel Card(Control content, int padding = 20)
    {
        var panel = new Panel
        {
            BackColor = Color.White,
            Padding = new Padding(padding)
        };
        panel.Controls.Add(content);
        return panel;
    }
}
