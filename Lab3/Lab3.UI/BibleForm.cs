using System;
using System.ComponentModel;
using System.Windows.Forms;
using static System.Runtime.InteropServices.Marshalling.IIUnknownCacheStrategy;

namespace Lab3.UI;
    
public partial class BibleForm : Form
{
    private bool _isProgrammaticChange = false;//�������� ��������� �� ����������
    public BibleForm()
    {
        InitializeComponent();
    }

    private void btnNewBook_Click(object sender, EventArgs e)
    {
        tabControlNewBook.SelectedTab = tabNewBook;
    }

    private void btnSupport_Click(object sender, EventArgs e)
    {
        tabControlNewBook.SelectedTab = tabPageSupport;
    }

    private void btnMarket_Click(object sender, EventArgs e)
    {
        tabControlNewBook.SelectedTab = tabPageMarket;
    }

    private void tabPageMain_Click(object sender, EventArgs e)
    {

    }
    private void tabControlNewBook_Selecting(object sender, TabControlCancelEventArgs e)
    {
        if (!_isProgrammaticChange)
        {
            e.Cancel = true;
        }
    }

    private void buttonClearNewBook_Click(object sender, EventArgs e)
    {
        textBoxTitleBook.Clear();
        textBoxAutor.Clear();//������� ��������� ����

        if (comboBoxType.Items.Count > 0)
            comboBoxType.SelectedIndex = -1; // ������� ����������

        numericUpDownPages.Value = numericUpDownPages.Minimum;
        numericUpDownPrice.Value = numericUpDownPrice.Minimum;//������� ���� � ��������            
        labelIDforUsing.Text = "(����� �������� �������������)";// ���������� label � ID

        textBoxTitleBook.Focus();// ��� ������� ���������� ����� �� ������ ����
    }

    private void btnAddNewBook_Click(object sender, EventArgs e)
    {

        try
        {
            ValidateInput(); // ��������� ��������

        }
        catch (Exception ex)
        {
            ShowError(ex);
        }

    }

    private void ShowError(Exception ex)
    {
        string message, title;

        switch (ex)
        {
            case ArgumentException argEx:
                message = $"������ � ���� {argEx.ParamName}: {argEx.Message}";
                title = "������ ���������";
                break;

            case FormatException:
                message = "�������� ������ �������� ������.";
                title = "������ �������";
                break;

            default:
                message = $"�������������� ������: {ex.Message}";
                title = "����������� ������";
                break;
        }

        MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    private void ValidateInput()
    {
        // �������� �������� ��� ������
        if (string.IsNullOrWhiteSpace(textBoxSearchTitle.Text))
            throw new ArgumentException("���� '����� �� ��������' �� ����� ���� ������", "SearchTitle");

        // �������� ID (������ ���� ������)
        if (!int.TryParse(textBoxSearchID.Text, out int id) || id <= 0)
            throw new ArgumentException("ID ������ ���� ������������� ����� ������", "SearchID");

        // �������� �������� �����
        if (string.IsNullOrWhiteSpace(textBoxTitleBook.Text))
            throw new ArgumentException("�������� ����� ����������� ��� ����������", "TitleBook");

        // �������� ������
        if (string.IsNullOrWhiteSpace(textBoxAutor.Text))
            throw new ArgumentException("������� ������ �����", "Author");

        // �������� ���������� ������� (�� NumericUpDown)
        if (numericUpDownPages.Value <= 0)
            throw new ArgumentException("���������� ������� ������ ���� ������ 0", "Pages");

        // �������� ����
        if (numericUpDownPages.Value < 0) // �����������, ���� � ������ numeric, ��� ���������� ���� ��� �������
            throw new ArgumentException("���� �� ����� ���� �������������", "Price");
    }

    private void buttonReturn1_Click(object sender, EventArgs e)
    {
        tabControlNewBook.SelectedTab = tabPageMain;
    }

    private void buttonReturn2_Click(object sender, EventArgs e)
    {
        tabControlNewBook.SelectedTab = tabPageMain;
    }

    private void buttonReturn3_Click(object sender, EventArgs e)
    {
        tabControlNewBook.SelectedTab = tabPageMain;
    }

    private void FormManager_Load(object sender, EventArgs e)
    {

    }

    private void buttonSearch1_Click(object sender, EventArgs e)
    {
        try
        {
            ValidateInput(); // ��������� ��������

        }
        catch (Exception ex)
        {
            ShowError(ex);
        }
    }

    private void button1_Click(object sender, EventArgs e)
    {

    }

    private void listViewBooks_SelectedIndexChanged(object sender, EventArgs e)
    {
        // ���� � ������ ������� ���� �� ���� �����
        if (listViewBooks.SelectedItems.Count > 0)
        {
            // �������� ������ ������
            groupBoxSearch.Visible = false;

            // ���������� ������ � ����������� � ������� �������
            groupBoxDetails.Visible = true;

            // ������� ������ ��������� ����� (�����������, ��� � Tag ��������)
            // ���� ����������� ������ �����, ����� ����� �� SubItems
            var title = listViewBooks.SelectedItems[0].Text;
            var author = "����� �����"; // ��� ���������� ������ ��������� ������
            var price = 500; // ��� ���� �� ������ �������

            labelInfo.Text = $"�����: {title}\n�����: {author}\n����: {price} ���.";

            // ���������� ������ ������� �� ����� ������ (�� ������ ������)
            groupBoxDetails.Location = groupBoxSearch.Location;
            groupBoxDetails.Size = groupBoxSearch.Size;
        }
        else
        {
            // ���� ����� ���� � ���������� �����
            groupBoxSearch.Visible = true;
            groupBoxDetails.Visible = false;
        }
    }

    private void btnBackToSearch_Click(object sender, EventArgs e)
    {
        listViewBooks.SelectedIndices.Clear(); // ������� ���������, ��� ���� ������� ������� ������
    }

    private void btnSell_Click(object sender, EventArgs e)
    {
        if (listViewBooks.SelectedItems.Count > 0)
        {
            var selectedItem = listViewBooks.SelectedItems[0];
            
            listViewBooks.Items.Remove(selectedItem);// ������� ����� �� ������
            
            groupBoxDetails.Visible = false;// ���������� ������ ������, ��� ��� ����� ������
            groupBoxSearch.Visible = true;

            MessageBox.Show("����� ������� �������!", "�������");
        }
    }
}
