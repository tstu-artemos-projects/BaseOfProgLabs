using NumberBaseLibs;
using System.ComponentModel; // Там Convertation, который мы будем использовать для конвертации чисел из одной системы счисления в другую

namespace Lab1
{
    public partial class ConvertionForm : Form
    {
        // Системы счисления от 2 до 16 включительно, так как в 16-ричной системе используются цифры от 0 до 9 и буквы от A до F, что позволяет нам конвертировать числа в более широком диапазоне систем счисления, а также алфавит.
        public static readonly int MaxAvailableBase = 16;
        public static readonly int MinAvailableBase = 2;
        public static readonly string[] AvailableBases = Enumerable
            .Range(MinAvailableBase, MaxAvailableBase - MinAvailableBase + 1)
            .Select(x => x.ToString()).ToArray();
        public static readonly char[] MaxNumberAlphabet = "0123456789ABCDEF".ToArray(); 

        public ConvertionForm()
        {
            InitializeComponent();
        }

        // Бесполезными пока что оказались
        //// Текстовое поле для ввода числа
        //private void NumStringTextChanged(object sender, EventArgs e)
        //{

        //}

        //// Комбо боксы (из какой системы и в какую систему, говорится про системы исчесления)

        //private void FromComboBoxChanged(object sender, EventArgs e)
        //{
            
        //}

        //private void IntoComboBoxChanged(object sender, EventArgs e)
        //{

        //}

        // Кнопки (очистить и конвертировать)

        private void ClearClick(object sender, EventArgs e)
        {
            textBoxInput.Clear();
            textBoxResult.Text = "";
            comboBoxFrom.ResetText();
            comboBoxTo.ResetText();
        }

        private void ConvertClick(object sender, EventArgs e) // Тут всё писал Артём Клчоков, ОБРАТИТТЕ ВНИМАНИЕ
        {
            try
            {
                // =Валидация комбобоксов= 
                string formBase = comboBoxFrom.Text.Trim();
                string intoBase = comboBoxTo.Text.Trim();

                if (!AvailableBases.Contains(formBase) || !AvailableBases.Contains(intoBase))
                {
                    throw new Exception("Неверный формат основания системы счисления!");
                }

                int formBaseNum = int.Parse(formBase);
                int intoBaseNum = int.Parse(intoBase);

                // =Валидация текстового поля для ввода числа=
                string avaibleAlphabet = new string(MaxNumberAlphabet.Take(formBaseNum).ToArray());

                if (textBoxInput.Text.Any(c => !avaibleAlphabet.Contains(char.ToUpper(c))))
                {
                    throw new Exception($"Введенное число содержит недопустимые символы для системы счисления с основанием {formBaseNum}!");
                }

                int number = Convertation.ConvertStringNumberToInteger(textBoxInput.Text.Trim(), formBaseNum);

                // Конвертация числа в новую систему счисления и вывод её
                string result = Convertation.ConvertIntegerToStringNumber(number, intoBaseNum);
                textBoxResult.Text = result;
            } catch (Exception ex)
            {
                MessageBox.Show("Ошибка при конвертации: " + ex.Message);
            }
        }
    }
}
