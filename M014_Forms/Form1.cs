using System.Linq;
using static System.Windows.Forms.ListBox;

namespace M014_Forms
{
	public partial class Form1 : Form
	{
		int ButtonClicked;

		public Form1()
		{
			InitializeComponent();
			//ComboBox Elemente füllen
			comboBox1.DataSource = new List<string>() { "BMW", "Audi", "VW" };
			listBox1.DataSource = new List<string>() { "BMW", "Audi", "VW" };
		}

		//Button click event
		private void TestClicked(object sender, EventArgs e)
		{
			//label1.Text = $"Test clicked: {++ButtonClicked}";
			//MessageBox.Show(comboBox1.SelectedItem.ToString());

			////Alle ListBox Elemente schön ausgeben
			//MessageBox.Show(listBox1.SelectedItems
			//	.OfType<string>()
			//	.Aggregate("", (agg, str) => $"{str}, {agg}")
			//	.TrimEnd(',', ' '));

			Form2 f2 = new Form2();
			f2.ShowDialog(); //Fenster das das dahinter liegende Fenster blockiert
			if (f2.DialogResult == DialogResult.OK) //DialogResult selber im Code setzen
			{
				if (MessageBox.Show("Einstellung speichern?", "Speichern", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					//...
				}
			}
		}

		//CheckBox event
		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox checkBox = (CheckBox) sender;
			MessageBox.Show($"Test ist jetzt {checkBox.Checked}");
		}
	}
}