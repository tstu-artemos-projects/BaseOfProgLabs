namespace TitleForm
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
            ShowConfirmationDialog("Сложно");
        }

        private void BtnNormal_Click(object sender, EventArgs e)
        {
            ShowConfirmationDialog("Средне");
        }

        private void BtnEasy_Click(object sender, EventArgs e)
        {
            ShowConfirmationDialog("Легко");
        }

        private void ShowConfirmationDialog(string difficulty)
        {
            var result = MessageBox.Show(
                $"Вы уверены, что хотите начать игру в режиме {difficulty}?",
                "Подтверждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                MessageBox.Show($"Вы выбрали режим: {difficulty}. Начинаем игру!",
                              "Успех",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information);
                // добавление перехода на игровую форму
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
                "Книжный магазин: Бизнес‑стратегия\n\n" +
                "Управляйте книжным магазином, заказывайте книги, проверяйте поставки\n" +
                "и обслуживайте покупателей. Следите за балансом и очередью!\n\n" +
                "Режимы сложности:\n" +
                "• Легко — больше времени на принятие решений, меньше штрафов\n" +
                "• Средне — сбалансированные условия\n" +
                "• Сложно — жёсткие ограничения по времени, высокие штрафы\n\n" +
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