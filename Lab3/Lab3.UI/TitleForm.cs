using Lab3.BookStoreLibrary;

namespace Lab3.UI
{
    public partial class TitleForm : Form
    {
        public TitleForm()
        {
            InitializeComponent();
            btnAboutGame.Click += btnAboutGame_Click;
        }

        private void BtnHard_Click(object sender, EventArgs e)
        {
            ShowConfirmationDialog(Difficulty.Hard);
        }

        private void BtnNormal_Click(object sender, EventArgs e)
        {
            ShowConfirmationDialog(Difficulty.Normal);
        }

        private void BtnEasy_Click(object sender, EventArgs e)
        {
            ShowConfirmationDialog(Difficulty.Easy);
        }

        private void ShowConfirmationDialog(Difficulty difficulty)
        {
            var difficultyName = DifficultyExtensions.ToDisplayString(difficulty);
            var result = MessageBox.Show(
                $"Вы уверены, что хотите начать игру в режиме {difficultyName}?",
                "Подтверждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                MessageBox.Show($"Вы выбрали режим: {difficultyName}. Начинаем игру!",
                              "Успех",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information);

                this.Hide();
                var bibleForm = new BibleForm(difficulty);
                bibleForm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Выбор режима отменён.",
                              "Отмена",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information);
            }
        }

        private void btnAboutGame_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "SellBook: Buisness Strategy\n\n" +
                "Управляйте книжным магазином, заказывайте книги, проверяйте поставки\n" +
                "и обслуживайте покупателей. Следите за балансом и очередью!\n\n" +
                "Режимы сложности:\n" +
                "• Легко — Больше очередь, заполняется медленнее, больше денег в начале, больше возможных недовольных покупателей, меньше дни\n" +
                "• Средне — Сбалансированные условияы\n" +
                "• Сложно — Менньше очередь, заполняется бытрее, меньше денег в начале, меньше возможных недовольных покупателей, больше дни\n\n" +
                "Цель игры — развивать магазин, избегая:\n" +
                "• Превышения лимита неудовлетворённых клиентов\n" +
                "• Переполнения очереди покупателей\n\n" +
                "Удачи в управлении вашим книжным бизнесом!",
                "Об игре",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}