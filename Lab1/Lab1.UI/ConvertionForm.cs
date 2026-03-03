using Lab1.NumberBaseLibs;
using System.ComponentModel; // ��� Convertation, ������� �� ����� ������������ ��� ����������� ����� �� ����� ������� ��������� � ������

namespace Lab1.UI
{
    public partial class ConvertionForm : Form
    {
        // ������� ��������� �� 2 �� 16 ������������, ��� ��� � 16-������ ������� ������������ ����� �� 0 �� 9 � ����� �� A �� F, ��� ��������� ��� �������������� ����� � ����� ������� ��������� ������ ���������, � ����� �������.
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

        // ������������ ���� ��� ���������
        //// ��������� ���� ��� ����� �����
        //private void NumStringTextChanged(object sender, EventArgs e)
        //{

        //}

        //// ����� ����� (�� ����� ������� � � ����� �������, ��������� ��� ������� ����������)

        //private void FromComboBoxChanged(object sender, EventArgs e)
        //{
            
        //}

        //private void IntoComboBoxChanged(object sender, EventArgs e)
        //{

        //}

        // ������ (�������� � ��������������)

        private void ClearClick(object sender, EventArgs e)
        {
            textBoxInput.Clear();
            textBoxResult.Text = "";
            comboBoxFrom.ResetText();
            comboBoxTo.ResetText();
        }

        private void ConvertClick(object sender, EventArgs e) // ��� �� ����� ���� �������, ��������� ��������
        {
            try
            {
                // =��������� �����������= 
                string formBase = comboBoxFrom.Text.Trim();
                string intoBase = comboBoxTo.Text.Trim();

                if (!AvailableBases.Contains(formBase) || !AvailableBases.Contains(intoBase))
                {
                    throw new Exception("�������� ������ ��������� ������� ���������!");
                }

                int formBaseNum = int.Parse(formBase);
                int intoBaseNum = int.Parse(intoBase);

                // =��������� ���������� ���� ��� ����� �����=
                string avaibleAlphabet = new string(MaxNumberAlphabet.Take(formBaseNum).ToArray());

                if (textBoxInput.Text.Any(c => !avaibleAlphabet.Contains(char.ToUpper(c))))
                {
                    throw new Exception($"��������� ����� �������� ������������ ������� ��� ������� ��������� � ���������� {formBaseNum}!");
                }

                int number = Convertation.ConvertStringNumberToInteger(textBoxInput.Text.Trim(), formBaseNum);

                // ����������� ����� � ����� ������� ��������� � ����� �
                string result = Convertation.ConvertIntegerToStringNumber(number, intoBaseNum);
                textBoxResult.Text = result;
            } catch (Exception ex)
            {
                MessageBox.Show("������ ��� �����������: " + ex.Message);
            }
        }
    }
}
