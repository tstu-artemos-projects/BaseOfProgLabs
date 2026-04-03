namespace Lab3.UI;

public enum GameOverType
{
    Victory,
    Defeat
}

public class GameOverStats
{
    public int BooksSold;
    public int MismatchCaught;
    public decimal FinalBalance;
    public decimal FinesPaid;
}

public partial class GameOverForm : Form
{
    public GameOverForm()
    {
        InitializeComponent();
    }

    public static void Show(GameOverType gameOverType, GameOverStats stats, string? defeatReason = "пашок ты дебила кусок")
    {
        using var form = new GameOverForm();
        if (gameOverType != GameOverType.Victory)
        {
            form.Text = "Игра окончена...";
            form.titling.Text = "Вы проиграли(";
            form.closeButton.Text = "Хм ну плохо";
            form.labelReason.Text = "Причина: " + defeatReason;
            form.pictureBox1.Image = Properties.Resources.DefeatPig;
        }
        form.statsText.Text = $"- Книг продано: {stats.BooksSold}\n" +
                              $"- Ошибок выявлено: {stats.MismatchCaught}\n" +
                              $"- Финальный баланс: {stats.FinalBalance} руб.\n" +
                              $"- Штрафов выплачено: {stats.FinesPaid} руб.";
        
        form.ShowDialog();
    }

    private void closeButton_Click(object sender, EventArgs e)
    {
        Close();
    }
}