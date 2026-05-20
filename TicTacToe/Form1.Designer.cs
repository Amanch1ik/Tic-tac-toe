namespace TicTacToe;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;

    private Label  lblTitle   = null!;
    private Label  lblScoreX  = null!;
    private Label  lblScoreO  = null!;
    private Label  lblStatus  = null!;
    private Button btnNewGame = null!;
    private Button btnReset   = null!;
    private Panel  pnlGrid    = null!;
    private Panel  pnlScoreX  = null!;
    private Panel  pnlScoreO  = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();

        // ═══════════════════════════════════════════════════════════════════
        //  FW=400  pad=48  inner=304
        //  Сетка: 304×304, ячейка 100×100, зазор 1px ВЕЗДЕ (внутри = снаружи)
        //     3×100 + 4×1 = 304  ✓
        //  Счёт/кнопки: vsW=36, colW=(304-36)/2=134
        //  x_лев=48, x_прав=48+134+36=218, конец=218+134=352, отступ_прав=48 ✓
        // ═══════════════════════════════════════════════════════════════════
        const int FW   = 400;
        const int pad  = 48;
        const int iW   = 304;
        const int vsW  = 36;
        const int colW = (iW - vsW) / 2;   // 134

        const int cell = 100;
        const int gap  = 1;

        const int yT  = 12;   const int hT  = 36;
        const int ySp = yT  + hT  + 6;
        const int yS  = ySp + 2  + 8;
        const int hS  = 64;
        const int yG  = yS  + hS  + 10;
        const int hG  = iW;
        const int ySt = yG  + hG  + 10;
        const int hSt = 26;
        const int yB  = ySt + hSt + 10;
        const int hB  = 34;
        const int FH  = yB  + hB  + 14;

        // ── Форма ─────────────────────────────────────────────────────────
        Text            = "Крестики-нолики";
        ClientSize      = new Size(FW, FH);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox     = false;
        StartPosition   = FormStartPosition.CenterScreen;
        BackColor       = Color.FromArgb(248, 249, 253);
        Font            = new Font("Segoe UI", 9f);

        // ── Заголовок ─────────────────────────────────────────────────────
        lblTitle = new Label
        {
            Text      = "КРЕСТИКИ-НОЛИКИ",
            Font      = new Font("Segoe UI", 17f, FontStyle.Bold),
            ForeColor = Color.FromArgb(34, 42, 60),
            TextAlign = ContentAlignment.MiddleCenter,
            Location  = new Point(0, yT),
            Size      = new Size(FW, hT),
            BackColor = Color.Transparent
        };

        // ── Разделитель ───────────────────────────────────────────────────
        var sep = new Panel
        {
            Location  = new Point(pad, ySp),
            Size      = new Size(iW, 1),
            BackColor = Color.FromArgb(216, 220, 232)
        };

        // ── Счёт X ────────────────────────────────────────────────────────
        pnlScoreX = new Panel
        {
            Location  = new Point(pad, yS),
            Size      = new Size(colW, hS),
            BackColor = Color.Transparent
        };
        pnlScoreX.Controls.Add(new Label
        {
            Text      = "Игрок X",
            Font      = new Font("Segoe UI", 9f, FontStyle.Bold),
            ForeColor = Color.FromArgb(180, 50, 50),
            TextAlign = ContentAlignment.MiddleCenter,
            Location  = new Point(0, 4),
            Size      = new Size(colW, 18),
            BackColor = Color.Transparent
        });
        lblScoreX = new Label
        {
            Text      = "0",
            Font      = new Font("Segoe UI", 22f, FontStyle.Bold),
            ForeColor = Color.Crimson,
            TextAlign = ContentAlignment.MiddleCenter,
            Location  = new Point(0, 22),
            Size      = new Size(colW, 40),
            BackColor = Color.Transparent
        };
        pnlScoreX.Controls.Add(lblScoreX);

        // ── «vs» ──────────────────────────────────────────────────────────
        var lblVs = new Label
        {
            Text      = "vs",
            Font      = new Font("Segoe UI", 10f, FontStyle.Italic),
            ForeColor = Color.FromArgb(170, 175, 195),
            TextAlign = ContentAlignment.MiddleCenter,
            Location  = new Point(pad + colW, yS),
            Size      = new Size(vsW, hS),
            BackColor = Color.Transparent
        };

        // ── Счёт O ────────────────────────────────────────────────────────
        pnlScoreO = new Panel
        {
            Location  = new Point(pad + colW + vsW, yS),
            Size      = new Size(colW, hS),
            BackColor = Color.Transparent
        };
        pnlScoreO.Controls.Add(new Label
        {
            Text      = "Игрок O",
            Font      = new Font("Segoe UI", 9f, FontStyle.Bold),
            ForeColor = Color.FromArgb(40, 85, 180),
            TextAlign = ContentAlignment.MiddleCenter,
            Location  = new Point(0, 4),
            Size      = new Size(colW, 18),
            BackColor = Color.Transparent
        });
        lblScoreO = new Label
        {
            Text      = "0",
            Font      = new Font("Segoe UI", 22f, FontStyle.Bold),
            ForeColor = Color.RoyalBlue,
            TextAlign = ContentAlignment.MiddleCenter,
            Location  = new Point(0, 22),
            Size      = new Size(colW, 40),
            BackColor = Color.Transparent
        };
        pnlScoreO.Controls.Add(lblScoreO);

        // ── Сетка ─────────────────────────────────────────────────────────
        //  Простой Panel, кнопки 100×100 расставлены руками
        //  Фон панели = цвет линий сетки (видно через 1px зазоры)
        pnlGrid = new Panel
        {
            Location  = new Point(pad, yG),
            Size      = new Size(iW, hG),
            BackColor = Color.FromArgb(120, 130, 155)
        };
        for (int r = 0; r < 3; r++)
        {
            for (int c = 0; c < 3; c++)
            {
                var btn = new Button
                {
                    Size      = new Size(cell, cell),
                    Location  = new Point(gap + c * (cell + gap),
                                          gap + r * (cell + gap)),
                    Font      = new Font("Segoe UI", 38f, FontStyle.Bold),
                    BackColor = Color.White,
                    ForeColor = Color.Black,
                    FlatStyle = FlatStyle.Flat,
                    Tag       = r * 3 + c,
                    Cursor    = Cursors.Hand,
                    TabStop   = false
                };
                btn.FlatAppearance.BorderSize         = 0;
                btn.FlatAppearance.BorderColor        = Color.White;
                btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(245, 247, 255);
                btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(228, 233, 252);
                btn.Click += Cell_Click;
                cells[r, c] = btn;
                pnlGrid.Controls.Add(btn);
            }
        }

        // ── Статус ────────────────────────────────────────────────────────
        lblStatus = new Label
        {
            Text      = "Ход игрока:  X",
            Font      = new Font("Segoe UI", 11f, FontStyle.Bold),
            ForeColor = Color.FromArgb(36, 46, 88),
            TextAlign = ContentAlignment.MiddleCenter,
            Location  = new Point(0, ySt),
            Size      = new Size(FW, hSt),
            BackColor = Color.Transparent
        };

        // ── Кнопки ────────────────────────────────────────────────────────
        btnNewGame = MakeBtn("Новая игра",
            new Point(pad, yB), new Size(colW, hB),
            Color.FromArgb(45, 110, 195));
        btnReset = MakeBtn("Сброс счёта",
            new Point(pad + colW + vsW, yB), new Size(colW, hB),
            Color.FromArgb(95, 105, 125));
        btnNewGame.Click += btnNewGame_Click;
        btnReset.Click   += btnReset_Click;

        Controls.AddRange(new Control[]
        {
            lblTitle, sep,
            pnlScoreX, lblVs, pnlScoreO,
            pnlGrid,
            lblStatus, btnNewGame, btnReset
        });
    }

    private static Button MakeBtn(string text, Point loc, Size sz, Color back)
    {
        var b = new Button
        {
            Text      = text,
            Font      = new Font("Segoe UI", 9.5f, FontStyle.Bold),
            ForeColor = Color.White,
            BackColor = back,
            FlatStyle = FlatStyle.Flat,
            Size      = sz,
            Location  = loc,
            Cursor    = Cursors.Hand,
            TabStop   = false
        };
        b.FlatAppearance.BorderSize         = 0;
        b.FlatAppearance.MouseOverBackColor = ControlPaint.Light(back, 0.25f);
        return b;
    }
}
