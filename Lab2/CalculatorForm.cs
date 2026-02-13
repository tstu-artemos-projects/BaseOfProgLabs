using CalculateLibrary;
using CalculateLibs;

namespace Lab2
{
    public partial class CalculatorForm : Form
    {
        History history = new(null);

        public CalculatorForm()
        {
            InitializeComponent();

            history.HistoryChanged += SetHistoryOutput;
        }

        private EventHandler AddCharIntoInputTextBox(string Char)
        {
            return (sender, e) =>
            {
                InputMathExpression.Text += Char;
            };
        }

        private void CalculateExpression(object sender, EventArgs e)
        {
            string expression = InputMathExpression.Text;

            try {
                double result = Calculator.Calculate(expression);

                InputMathExpression.Text = "";
                history.AddToHistory(expression, result);
                ResultInput.Text = result.ToString("F2");
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void ValidationKeyPress(object sender, KeyPressEventArgs e)
        {
            // Строка со всеми разрешенными символами
            string allowedSymbols = "0123456789()+-*/.,\b";

            // Если символа нет в списке разрешенных, отменяем ввод
            if (allowedSymbols.IndexOf(e.KeyChar) == -1)
            {
                e.Handled = true;
            }
        }

        private void EnterPress(object sender, KeyEventArgs e)
        {
            if  (e.KeyCode == Keys.Enter)
                CalculateExpression(sender, e);
        }

        private void SetHistoryOutput(IReadOnlyList<HistoryElement> history)
        {
            HistoryOutput.Text = string.Join(
                Environment.NewLine,
                history
                    .Select(h => $"{h.Expression} = {h.Result:F2}")
                    .Reverse() // Разворачиваем порядок, чтобы последние элементы были сверху
            );
        }

        private void Clear(object sender, EventArgs e)
        {
            ResultInput.Text = string.Empty;
            InputMathExpression.Text = string.Empty;
        }

        private void ShowError(Exception ex)
        {
            string message, title;

            switch (ex)
            {
                case DivideByZeroException:
                    message = $"Ошибка: {ex.Message}";
                    title = "Деление на ноль";
                    break;

                case InvalidOperationException:
                    message = $"Некорректное выражение: {ex.Message}";
                    title = "Ошибка выражения";
                    break;

                case ArgumentException:
                    message = $"Ошибка ввода: {ex.Message}";
                    title = "Некорректное выражение";
                    break;

                default:
                    message = $"Неожиданная ошибка: {ex.Message}";
                    title = "Ошибка";
                    break;
            }

            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
