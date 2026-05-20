namespace TicTacToe;

public partial class Form1 : Form
{
    private Button[,] cells = new Button[3, 3];
    private string currentPlayer = "X";
    private string[,] board = new string[3, 3];
    private int scoreX = 0;
    private int scoreO = 0;
    private bool gameOver = false;

    public Form1()
    {
        InitializeComponent();
        InitBoard();
    }

    private void InitBoard()
    {
        currentPlayer = "X";
        gameOver = false;
        board = new string[3, 3];
        lblStatus.Text = "Ход игрока: X";
        lblStatus.ForeColor = Color.Navy;

        for (int row = 0; row < 3; row++)
            for (int col = 0; col < 3; col++)
            {
                cells[row, col].Text = "";
                cells[row, col].ForeColor = Color.Black;
                cells[row, col].BackColor = Color.White;
            }
    }

    private void Cell_Click(object? sender, EventArgs e)
    {
        if (sender is not Button btn || gameOver) return;

        int row = (int)btn.Tag! / 3;
        int col = (int)btn.Tag! % 3;

        if (board[row, col] != null) return;

        board[row, col] = currentPlayer;
        btn.Text = currentPlayer;
        btn.ForeColor = currentPlayer == "X" ? Color.Crimson : Color.RoyalBlue;
        // не отключаем кнопку — disabled перекрашивает текст в серый

        if (CheckWinner(out int[][]? winLine))
        {
            gameOver = true;
            HighlightWin(winLine!);
            if (currentPlayer == "X") scoreX++;
            else scoreO++;
            UpdateScore();
            lblStatus.Text = $"Победил игрок: {currentPlayer}!";
            lblStatus.ForeColor = Color.DarkGreen;
            return;
        }

        if (CheckDraw())
        {
            gameOver = true;
            lblStatus.Text = "Ничья!";
            lblStatus.ForeColor = Color.DarkOrange;
            return;
        }

        currentPlayer = currentPlayer == "X" ? "O" : "X";
        lblStatus.Text = $"Ход игрока: {currentPlayer}";
        lblStatus.ForeColor = Color.Navy;
    }

    private bool CheckWinner(out int[][]? winLine)
    {
        int[][,] lines = new int[][,]
        {
            // строки
            new int[,] {{0,0},{0,1},{0,2}},
            new int[,] {{1,0},{1,1},{1,2}},
            new int[,] {{2,0},{2,1},{2,2}},
            // столбцы
            new int[,] {{0,0},{1,0},{2,0}},
            new int[,] {{0,1},{1,1},{2,1}},
            new int[,] {{0,2},{1,2},{2,2}},
            // диагонали
            new int[,] {{0,0},{1,1},{2,2}},
            new int[,] {{0,2},{1,1},{2,0}},
        };

        foreach (var line in lines)
        {
            int r0 = line[0, 0], c0 = line[0, 1];
            int r1 = line[1, 0], c1 = line[1, 1];
            int r2 = line[2, 0], c2 = line[2, 1];

            if (board[r0, c0] != null &&
                board[r0, c0] == board[r1, c1] &&
                board[r1, c1] == board[r2, c2])
            {
                winLine = new int[][] {
                    new[] { r0, c0 },
                    new[] { r1, c1 },
                    new[] { r2, c2 }
                };
                return true;
            }
        }

        winLine = null;
        return false;
    }

    private bool CheckDraw()
    {
        foreach (var cell in board)
            if (cell == null) return false;
        return true;
    }

    private void HighlightWin(int[][] line)
    {
        foreach (var pos in line)
            cells[pos[0], pos[1]].BackColor = Color.LightGreen;
    }

    private void UpdateScore()
    {
        lblScoreX.Text = scoreX.ToString();
        lblScoreO.Text = scoreO.ToString();
    }

    private void btnNewGame_Click(object sender, EventArgs e)
    {
        InitBoard();
    }

    private void btnReset_Click(object sender, EventArgs e)
    {
        scoreX = 0;
        scoreO = 0;
        UpdateScore();
        InitBoard();
    }
}
