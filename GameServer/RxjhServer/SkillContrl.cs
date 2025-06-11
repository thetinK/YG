using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace RxjhServer
{
	public class SkillContrl : Form
	{
		private readonly ConcurrentDictionary<int, 属性> qglist = new ConcurrentDictionary<int, 属性>();

		private readonly ConcurrentDictionary<int, 属性> stqglist = new ConcurrentDictionary<int, 属性>();

		private ComboBox comboBox1;

		private GroupBox groupBox1;

		private TextBox textBox21;

		private TextBox textBox22;

		private TextBox textBox19;

		private TextBox textBox20;

		private TextBox textBox17;

		private TextBox textBox18;

		private TextBox textBox15;

		private TextBox textBox16;

		private TextBox textBox13;

		private TextBox textBox14;

		private TextBox textBox11;

		private TextBox textBox12;

		private TextBox textBox9;

		private TextBox textBox10;

		private TextBox textBox7;

		private TextBox textBox8;

		private TextBox textBox5;

		private TextBox textBox6;

		private TextBox textBox3;

		private TextBox textBox4;

		private TextBox textBox2;

		private TextBox textBox1;

		private Label label11;

		private Label label10;

		private Label label9;

		private Label label8;

		private Label label7;

		private Label label6;

		private Label label5;

		private Label label4;

		private Label label3;

		private Label label2;

		private Label label1;

		private GroupBox groupBox2;

		private Button button1;

		private TextBox textBox37;

		private TextBox textBox36;

		private TextBox textBox35;

		private TextBox textBox34;

		private TextBox textBox33;

		private TextBox textBox32;

		private TextBox textBox31;

		private TextBox textBox30;

		private TextBox textBox29;

		private TextBox textBox28;

		private TextBox textBox27;

		private TextBox textBox26;

		private TextBox textBox25;

		private TextBox textBox24;

		private TextBox textBox23;

		private Label label26;

		private Label label19;

		private Label label20;

		private Label label21;

		private Label label22;

		private Label label23;

		private Label label24;

		private Label label25;

		private Label label18;

		private Label label17;

		private Label label16;

		private Label label15;

		private Label label14;

		private Label label13;

		private Label label12;

		private Label label28;

		private Label label27;

		private Label label29;

		public SkillContrl()
		{
			InitializeComponent();
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			select(comboBox1.SelectedIndex);
		}

		private void SkillContrl_Load(object sender, EventArgs e)
		{
			comboBox1.SelectedIndex = 0;
		}

		private void 初始化()
		{
			label12.Text = string.Empty;
			label13.Text = string.Empty;
			label14.Text = string.Empty;
			label15.Text = string.Empty;
			label16.Text = string.Empty;
			label17.Text = string.Empty;
			label18.Text = string.Empty;
			label19.Text = string.Empty;
			label20.Text = string.Empty;
			label21.Text = string.Empty;
			label22.Text = string.Empty;
			label23.Text = string.Empty;
			label24.Text = string.Empty;
			label25.Text = string.Empty;
			label26.Text = string.Empty;
			label12.Show();
			label13.Show();
			label14.Show();
			label15.Show();
			label16.Show();
			label17.Show();
			label18.Show();
			label19.Show();
			label20.Show();
			label21.Show();
			label22.Show();
			label23.Show();
			label24.Show();
			label25.Show();
			label26.Show();
			textBox23.Show();
			textBox24.Show();
			textBox25.Show();
			textBox26.Show();
			textBox27.Show();
			textBox28.Show();
			textBox29.Show();
			textBox30.Show();
			textBox31.Show();
			textBox32.Show();
			textBox33.Show();
			textBox34.Show();
			textBox35.Show();
			textBox36.Show();
			textBox37.Show();
		}

		private void select(int index)
		{
			try
			{
				index++;
				int num = index;
				qglist.Clear();
				stqglist.Clear();
				初始化();
				foreach (气功加成属性 value3 in World.气功加成.Values)
				{
					if (value3.FLD_JOB == num)
					{
						string fLD_NAME = value3.FLD_NAME;
						string text = value3.FLD_每点加成比率值1.ToString();
						string text2 = value3.FLD_每点加成比率值2.ToString();
						属性 value = new 属性(double.Parse(text), double.Parse(text2));
						qglist.TryAdd(value3.FLD_INDEX, value);
						switch (value3.FLD_INDEX)
						{
						case 0:
							label1.Text = fLD_NAME;
							textBox1.Text = text;
							textBox2.Text = text2;
							break;
						case 1:
							label2.Text = fLD_NAME;
							textBox4.Text = text;
							textBox3.Text = text2;
							break;
						case 2:
							label3.Text = fLD_NAME;
							textBox6.Text = text;
							textBox5.Text = text2;
							break;
						case 3:
							label4.Text = fLD_NAME;
							textBox8.Text = text;
							textBox7.Text = text2;
							break;
						case 4:
							label5.Text = fLD_NAME;
							textBox10.Text = text;
							textBox9.Text = text2;
							break;
						case 5:
							label6.Text = fLD_NAME;
							textBox12.Text = text;
							textBox11.Text = text2;
							break;
						case 6:
							label7.Text = fLD_NAME;
							textBox14.Text = text;
							textBox13.Text = text2;
							break;
						case 7:
							label8.Text = fLD_NAME;
							textBox16.Text = text;
							textBox15.Text = text2;
							break;
						case 8:
							label9.Text = fLD_NAME;
							textBox18.Text = text;
							textBox17.Text = text2;
							break;
						case 9:
							label10.Text = fLD_NAME;
							textBox20.Text = text;
							textBox19.Text = text2;
							break;
						case 10:
							label11.Text = fLD_NAME;
							textBox22.Text = text;
							textBox21.Text = text2;
							break;
						}
					}
				}
				foreach (升天气功总类 value4 in World.升天气功List.Values)
				{
					switch (num)
					{
					case 1:
						if (value4.人物职业1 == 1)
						{
							属性 value2 = new 属性(value4.FLD_每点加成比率值, 0.0);
							stqglist.TryAdd(value4.气功ID, value2);
							label22.Show();
							textBox33.Show();
							if (label12.Text.Length <= 7)
							{
								label12.Text = value4.气功名;
								textBox23.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label13.Text.Length <= 7)
							{
								label13.Text = value4.气功名;
								textBox24.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label14.Text.Length <= 7)
							{
								label14.Text = value4.气功名;
								textBox25.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label15.Text.Length <= 7)
							{
								label15.Text = value4.气功名;
								textBox26.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label16.Text.Length <= 7)
							{
								label16.Text = value4.气功名;
								textBox27.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label17.Text.Length <= 7)
							{
								label17.Text = value4.气功名;
								textBox28.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label18.Text.Length <= 7)
							{
								label18.Text = value4.气功名;
								textBox29.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label19.Text.Length <= 7)
							{
								label19.Text = value4.气功名;
								textBox30.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label20.Text.Length <= 7)
							{
								label20.Text = value4.气功名;
								textBox31.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label21.Text.Length <= 7)
							{
								label21.Text = value4.气功名;
								textBox32.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label22.Text.Length <= 7)
							{
								label22.Text = value4.气功名;
								textBox33.Text = value4.FLD_每点加成比率值.ToString();
								label23.Hide();
								label24.Hide();
								label25.Hide();
								label26.Hide();
								textBox34.Hide();
								textBox35.Hide();
								textBox36.Hide();
								textBox37.Hide();
							}
							else if (label23.Text.Length <= 7)
							{
								label23.Text = value4.气功名;
								textBox34.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label24.Text.Length <= 7)
							{
								label24.Text = value4.气功名;
								textBox35.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label25.Text.Length <= 7)
							{
								label25.Text = value4.气功名;
								textBox36.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label26.Text.Length <= 7)
							{
								label26.Text = value4.气功名;
								textBox37.Text = value4.FLD_每点加成比率值.ToString();
							}
						}
						break;
					case 2:
						if (value4.人物职业2 == 1)
						{
							if (label12.Text.Length <= 7)
							{
								label12.Text = value4.气功名;
								textBox23.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label13.Text.Length <= 7)
							{
								label13.Text = value4.气功名;
								textBox24.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label14.Text.Length <= 7)
							{
								label14.Text = value4.气功名;
								textBox25.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label15.Text.Length <= 7)
							{
								label15.Text = value4.气功名;
								textBox26.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label16.Text.Length <= 7)
							{
								label16.Text = value4.气功名;
								textBox27.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label17.Text.Length <= 7)
							{
								label17.Text = value4.气功名;
								textBox28.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label18.Text.Length <= 7)
							{
								label18.Text = value4.气功名;
								textBox29.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label19.Text.Length <= 7)
							{
								label19.Text = value4.气功名;
								textBox30.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label20.Text.Length <= 7)
							{
								label20.Text = value4.气功名;
								textBox31.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label21.Text.Length <= 7)
							{
								label21.Text = value4.气功名;
								textBox32.Text = value4.FLD_每点加成比率值.ToString();
								label22.Hide();
								label23.Hide();
								label24.Hide();
								label25.Hide();
								label26.Hide();
								textBox33.Hide();
								textBox34.Hide();
								textBox35.Hide();
								textBox36.Hide();
								textBox37.Hide();
							}
							else if (label22.Text.Length <= 7)
							{
								label22.Text = value4.气功名;
								textBox33.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label23.Text.Length <= 7)
							{
								label23.Text = value4.气功名;
								textBox34.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label24.Text.Length <= 7)
							{
								label24.Text = value4.气功名;
								textBox35.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label25.Text.Length <= 7)
							{
								label25.Text = value4.气功名;
								textBox36.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label26.Text.Length <= 7)
							{
								label26.Text = value4.气功名;
								textBox37.Text = value4.FLD_每点加成比率值.ToString();
							}
						}
						break;
					case 3:
						if (value4.人物职业3 == 1)
						{
							if (label12.Text.Length <= 7)
							{
								label12.Text = value4.气功名;
								textBox23.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label13.Text.Length <= 7)
							{
								label13.Text = value4.气功名;
								textBox24.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label14.Text.Length <= 7)
							{
								label14.Text = value4.气功名;
								textBox25.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label15.Text.Length <= 7)
							{
								label15.Text = value4.气功名;
								textBox26.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label16.Text.Length <= 7)
							{
								label16.Text = value4.气功名;
								textBox27.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label17.Text.Length <= 7)
							{
								label17.Text = value4.气功名;
								textBox28.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label18.Text.Length <= 7)
							{
								label18.Text = value4.气功名;
								textBox29.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label19.Text.Length <= 7)
							{
								label19.Text = value4.气功名;
								textBox30.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label20.Text.Length <= 7)
							{
								label20.Text = value4.气功名;
								textBox31.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label21.Text.Length <= 7)
							{
								label21.Text = value4.气功名;
								textBox32.Text = value4.FLD_每点加成比率值.ToString();
								label22.Hide();
								label23.Hide();
								label24.Hide();
								label25.Hide();
								label26.Hide();
								textBox33.Hide();
								textBox34.Hide();
								textBox35.Hide();
								textBox36.Hide();
								textBox37.Hide();
							}
							else if (label22.Text.Length <= 7)
							{
								label22.Text = value4.气功名;
								textBox33.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label23.Text.Length <= 7)
							{
								label23.Text = value4.气功名;
								textBox34.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label24.Text.Length <= 7)
							{
								label24.Text = value4.气功名;
								textBox35.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label25.Text.Length <= 7)
							{
								label25.Text = value4.气功名;
								textBox36.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label26.Text.Length <= 7)
							{
								label26.Text = value4.气功名;
								textBox37.Text = value4.FLD_每点加成比率值.ToString();
							}
						}
						break;
					case 4:
						if (value4.人物职业4 == 1)
						{
							if (label12.Text.Length <= 7)
							{
								label12.Text = value4.气功名;
								textBox23.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label13.Text.Length <= 7)
							{
								label13.Text = value4.气功名;
								textBox24.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label14.Text.Length <= 7)
							{
								label14.Text = value4.气功名;
								textBox25.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label15.Text.Length <= 7)
							{
								label15.Text = value4.气功名;
								textBox26.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label16.Text.Length <= 7)
							{
								label16.Text = value4.气功名;
								textBox27.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label17.Text.Length <= 7)
							{
								label17.Text = value4.气功名;
								textBox28.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label18.Text.Length <= 7)
							{
								label18.Text = value4.气功名;
								textBox29.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label19.Text.Length <= 7)
							{
								label19.Text = value4.气功名;
								textBox30.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label20.Text.Length <= 7)
							{
								label20.Text = value4.气功名;
								textBox31.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label21.Text.Length <= 7)
							{
								label21.Text = value4.气功名;
								textBox32.Text = value4.FLD_每点加成比率值.ToString();
								label22.Hide();
								label23.Hide();
								label24.Hide();
								label25.Hide();
								label26.Hide();
								textBox33.Hide();
								textBox34.Hide();
								textBox35.Hide();
								textBox36.Hide();
								textBox37.Hide();
							}
							else if (label22.Text.Length <= 7)
							{
								label22.Text = value4.气功名;
								textBox33.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label23.Text.Length <= 7)
							{
								label23.Text = value4.气功名;
								textBox34.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label24.Text.Length <= 7)
							{
								label24.Text = value4.气功名;
								textBox35.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label25.Text.Length <= 7)
							{
								label25.Text = value4.气功名;
								textBox36.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label26.Text.Length <= 7)
							{
								label26.Text = value4.气功名;
								textBox37.Text = value4.FLD_每点加成比率值.ToString();
							}
						}
						break;
					case 5:
						if (value4.人物职业5 == 1)
						{
							if (label12.Text.Length <= 7)
							{
								label12.Text = value4.气功名;
								textBox23.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label13.Text.Length <= 7)
							{
								label13.Text = value4.气功名;
								textBox24.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label14.Text.Length <= 7)
							{
								label14.Text = value4.气功名;
								textBox25.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label15.Text.Length <= 7)
							{
								label15.Text = value4.气功名;
								textBox26.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label16.Text.Length <= 7)
							{
								label16.Text = value4.气功名;
								textBox27.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label17.Text.Length <= 7)
							{
								label17.Text = value4.气功名;
								textBox28.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label18.Text.Length <= 7)
							{
								label18.Text = value4.气功名;
								textBox29.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label19.Text.Length <= 7)
							{
								label19.Text = value4.气功名;
								textBox30.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label20.Text.Length <= 7)
							{
								label20.Text = value4.气功名;
								textBox31.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label21.Text.Length <= 7)
							{
								label21.Text = value4.气功名;
								textBox32.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label22.Text.Length <= 7)
							{
								label22.Text = value4.气功名;
								textBox33.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label23.Text.Length <= 7)
							{
								label23.Text = value4.气功名;
								textBox34.Text = value4.FLD_每点加成比率值.ToString();
								label24.Hide();
								label25.Hide();
								label26.Hide();
								textBox35.Hide();
								textBox36.Hide();
								textBox37.Hide();
							}
							else if (label24.Text.Length <= 7)
							{
								label24.Text = value4.气功名;
								textBox35.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label25.Text.Length <= 7)
							{
								label25.Text = value4.气功名;
								textBox36.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label26.Text.Length <= 7)
							{
								label26.Text = value4.气功名;
								textBox37.Text = value4.FLD_每点加成比率值.ToString();
							}
						}
						break;
					case 6:
						if (value4.人物职业6 == 1)
						{
							if (label12.Text.Length <= 7)
							{
								label12.Text = value4.气功名;
								textBox23.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label13.Text.Length <= 7)
							{
								label13.Text = value4.气功名;
								textBox24.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label14.Text.Length <= 7)
							{
								label14.Text = value4.气功名;
								textBox25.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label15.Text.Length <= 7)
							{
								label15.Text = value4.气功名;
								textBox26.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label16.Text.Length <= 7)
							{
								label16.Text = value4.气功名;
								textBox27.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label17.Text.Length <= 7)
							{
								label17.Text = value4.气功名;
								textBox28.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label18.Text.Length <= 7)
							{
								label18.Text = value4.气功名;
								textBox29.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label19.Text.Length <= 7)
							{
								label19.Text = value4.气功名;
								textBox30.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label20.Text.Length <= 7)
							{
								label20.Text = value4.气功名;
								textBox31.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label21.Text.Length <= 7)
							{
								label21.Text = value4.气功名;
								textBox32.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label22.Text.Length <= 7)
							{
								label22.Text = value4.气功名;
								textBox33.Text = value4.FLD_每点加成比率值.ToString();
								label23.Hide();
								label24.Hide();
								label25.Hide();
								label26.Hide();
								textBox34.Hide();
								textBox35.Hide();
								textBox36.Hide();
								textBox37.Hide();
							}
							else if (label23.Text.Length <= 7)
							{
								label23.Text = value4.气功名;
								textBox34.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label24.Text.Length <= 7)
							{
								label24.Text = value4.气功名;
								textBox35.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label25.Text.Length <= 7)
							{
								label25.Text = value4.气功名;
								textBox36.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label26.Text.Length <= 7)
							{
								label26.Text = value4.气功名;
								textBox37.Text = value4.FLD_每点加成比率值.ToString();
							}
						}
						break;
					case 7:
						if (value4.人物职业7 == 1)
						{
							if (label12.Text.Length <= 7)
							{
								label12.Text = value4.气功名;
								textBox23.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label13.Text.Length <= 7)
							{
								label13.Text = value4.气功名;
								textBox24.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label14.Text.Length <= 7)
							{
								label14.Text = value4.气功名;
								textBox25.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label15.Text.Length <= 7)
							{
								label15.Text = value4.气功名;
								textBox26.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label16.Text.Length <= 7)
							{
								label16.Text = value4.气功名;
								textBox27.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label17.Text.Length <= 7)
							{
								label17.Text = value4.气功名;
								textBox28.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label18.Text.Length <= 7)
							{
								label18.Text = value4.气功名;
								textBox29.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label19.Text.Length <= 7)
							{
								label19.Text = value4.气功名;
								textBox30.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label20.Text.Length <= 7)
							{
								label20.Text = value4.气功名;
								textBox31.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label21.Text.Length <= 7)
							{
								label21.Text = value4.气功名;
								textBox32.Text = value4.FLD_每点加成比率值.ToString();
								label22.Hide();
								label23.Hide();
								label24.Hide();
								label25.Hide();
								label26.Hide();
								textBox33.Hide();
								textBox34.Hide();
								textBox35.Hide();
								textBox36.Hide();
								textBox37.Hide();
							}
							else if (label22.Text.Length <= 7)
							{
								label22.Text = value4.气功名;
								textBox33.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label23.Text.Length <= 7)
							{
								label23.Text = value4.气功名;
								textBox34.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label24.Text.Length <= 7)
							{
								label24.Text = value4.气功名;
								textBox35.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label25.Text.Length <= 7)
							{
								label25.Text = value4.气功名;
								textBox36.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label26.Text.Length <= 7)
							{
								label26.Text = value4.气功名;
								textBox37.Text = value4.FLD_每点加成比率值.ToString();
							}
						}
						break;
					case 8:
						if (value4.人物职业8 == 1)
						{
							if (label12.Text.Length <= 7)
							{
								label12.Text = value4.气功名;
								textBox23.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label13.Text.Length <= 7)
							{
								label13.Text = value4.气功名;
								textBox24.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label14.Text.Length <= 7)
							{
								label14.Text = value4.气功名;
								textBox25.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label15.Text.Length <= 7)
							{
								label15.Text = value4.气功名;
								textBox26.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label16.Text.Length <= 7)
							{
								label16.Text = value4.气功名;
								textBox27.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label17.Text.Length <= 7)
							{
								label17.Text = value4.气功名;
								textBox28.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label18.Text.Length <= 7)
							{
								label18.Text = value4.气功名;
								textBox29.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label19.Text.Length <= 7)
							{
								label19.Text = value4.气功名;
								textBox30.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label20.Text.Length <= 7)
							{
								label20.Text = value4.气功名;
								textBox31.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label21.Text.Length <= 7)
							{
								label21.Text = value4.气功名;
								textBox32.Text = value4.FLD_每点加成比率值.ToString();
								label22.Hide();
								label23.Hide();
								label24.Hide();
								label25.Hide();
								label26.Hide();
								textBox33.Hide();
								textBox34.Hide();
								textBox35.Hide();
								textBox36.Hide();
								textBox37.Hide();
							}
							else if (label22.Text.Length <= 7)
							{
								label22.Text = value4.气功名;
								textBox33.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label23.Text.Length <= 7)
							{
								label23.Text = value4.气功名;
								textBox34.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label24.Text.Length <= 7)
							{
								label24.Text = value4.气功名;
								textBox35.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label25.Text.Length <= 7)
							{
								label25.Text = value4.气功名;
								textBox36.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label26.Text.Length <= 7)
							{
								label26.Text = value4.气功名;
								textBox37.Text = value4.FLD_每点加成比率值.ToString();
							}
						}
						break;
					case 9:
						if (value4.人物职业9 == 1)
						{
							if (label12.Text.Length <= 7)
							{
								label12.Text = value4.气功名;
								textBox23.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label13.Text.Length <= 7)
							{
								label13.Text = value4.气功名;
								textBox24.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label14.Text.Length <= 7)
							{
								label14.Text = value4.气功名;
								textBox25.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label15.Text.Length <= 7)
							{
								label15.Text = value4.气功名;
								textBox26.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label16.Text.Length <= 7)
							{
								label16.Text = value4.气功名;
								textBox27.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label17.Text.Length <= 7)
							{
								label17.Text = value4.气功名;
								textBox28.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label18.Text.Length <= 7)
							{
								label18.Text = value4.气功名;
								textBox29.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label19.Text.Length <= 7)
							{
								label19.Text = value4.气功名;
								textBox30.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label20.Text.Length <= 7)
							{
								label20.Text = value4.气功名;
								textBox31.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label21.Text.Length <= 7)
							{
								label21.Text = value4.气功名;
								textBox32.Text = value4.FLD_每点加成比率值.ToString();
								label22.Hide();
								label23.Hide();
								label24.Hide();
								label25.Hide();
								label26.Hide();
								textBox33.Hide();
								textBox34.Hide();
								textBox35.Hide();
								textBox36.Hide();
								textBox37.Hide();
							}
							else if (label22.Text.Length <= 7)
							{
								label22.Text = value4.气功名;
								textBox33.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label23.Text.Length <= 7)
							{
								label23.Text = value4.气功名;
								textBox34.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label24.Text.Length <= 7)
							{
								label24.Text = value4.气功名;
								textBox35.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label25.Text.Length <= 7)
							{
								label25.Text = value4.气功名;
								textBox36.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label26.Text.Length <= 7)
							{
								label26.Text = value4.气功名;
								textBox37.Text = value4.FLD_每点加成比率值.ToString();
							}
						}
						break;
					case 10:
						if (value4.人物职业10 == 1)
						{
							if (label12.Text.Length <= 7)
							{
								label12.Text = value4.气功名;
								textBox23.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label13.Text.Length <= 7)
							{
								label13.Text = value4.气功名;
								textBox24.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label14.Text.Length <= 7)
							{
								label14.Text = value4.气功名;
								textBox25.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label15.Text.Length <= 7)
							{
								label15.Text = value4.气功名;
								textBox26.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label16.Text.Length <= 7)
							{
								label16.Text = value4.气功名;
								textBox27.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label17.Text.Length <= 7)
							{
								label17.Text = value4.气功名;
								textBox28.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label18.Text.Length <= 7)
							{
								label18.Text = value4.气功名;
								textBox29.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label19.Text.Length <= 7)
							{
								label19.Text = value4.气功名;
								textBox30.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label20.Text.Length <= 7)
							{
								label20.Text = value4.气功名;
								textBox31.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label21.Text.Length <= 7)
							{
								label21.Text = value4.气功名;
								textBox32.Text = value4.FLD_每点加成比率值.ToString();
								label22.Hide();
								label23.Hide();
								label24.Hide();
								label25.Hide();
								label26.Hide();
								textBox33.Hide();
								textBox34.Hide();
								textBox35.Hide();
								textBox36.Hide();
								textBox37.Hide();
							}
							else if (label22.Text.Length <= 7)
							{
								label22.Text = value4.气功名;
								textBox33.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label23.Text.Length <= 7)
							{
								label23.Text = value4.气功名;
								textBox34.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label24.Text.Length <= 7)
							{
								label24.Text = value4.气功名;
								textBox35.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label25.Text.Length <= 7)
							{
								label25.Text = value4.气功名;
								textBox36.Text = value4.FLD_每点加成比率值.ToString();
							}
							else if (label26.Text.Length <= 7)
							{
								label26.Text = value4.气功名;
								textBox37.Text = value4.FLD_每点加成比率值.ToString();
							}
						}
						break;
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("加载气功数据出错 " + ex.Message);
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			int num = comboBox1.SelectedIndex + 1;
			qglist.OrderByDescending((KeyValuePair<int, 属性> i) => i.Key);
			foreach (气功加成属性 value2 in World.气功加成.Values)
			{
				if (value2.FLD_JOB == num && qglist.TryGetValue(value2.FLD_INDEX, out var _))
				{
					if (value2.FLD_每点加成比率值1 != qglist[value2.FLD_INDEX].FLD_加成1)
					{
						value2.FLD_每点加成比率值1 = qglist[value2.FLD_INDEX].FLD_加成1;
					}
					if (value2.FLD_每点加成比率值2 != qglist[value2.FLD_INDEX].FLD_加成2)
					{
						value2.FLD_每点加成比率值2 = qglist[value2.FLD_INDEX].FLD_加成2;
					}
				}
			}
		}

		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SkillContrl));
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.textBox21 = new System.Windows.Forms.TextBox();
            this.textBox22 = new System.Windows.Forms.TextBox();
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.textBox20 = new System.Windows.Forms.TextBox();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label29 = new System.Windows.Forms.Label();
            this.textBox37 = new System.Windows.Forms.TextBox();
            this.textBox36 = new System.Windows.Forms.TextBox();
            this.textBox35 = new System.Windows.Forms.TextBox();
            this.textBox34 = new System.Windows.Forms.TextBox();
            this.textBox33 = new System.Windows.Forms.TextBox();
            this.textBox32 = new System.Windows.Forms.TextBox();
            this.textBox31 = new System.Windows.Forms.TextBox();
            this.textBox30 = new System.Windows.Forms.TextBox();
            this.textBox29 = new System.Windows.Forms.TextBox();
            this.textBox28 = new System.Windows.Forms.TextBox();
            this.textBox27 = new System.Windows.Forms.TextBox();
            this.textBox26 = new System.Windows.Forms.TextBox();
            this.textBox25 = new System.Windows.Forms.TextBox();
            this.textBox24 = new System.Windows.Forms.TextBox();
            this.textBox23 = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "刀客",
            "剑客",
            "枪客",
            "弓箭手",
            "医生",
            "刺客",
            "乐师",
            "韩飞官",
            "谭花玲",
            "格斗家"});
            this.comboBox1.Location = new System.Drawing.Point(14, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label28);
            this.groupBox1.Controls.Add(this.label27);
            this.groupBox1.Controls.Add(this.textBox21);
            this.groupBox1.Controls.Add(this.textBox22);
            this.groupBox1.Controls.Add(this.textBox19);
            this.groupBox1.Controls.Add(this.textBox20);
            this.groupBox1.Controls.Add(this.textBox17);
            this.groupBox1.Controls.Add(this.textBox18);
            this.groupBox1.Controls.Add(this.textBox15);
            this.groupBox1.Controls.Add(this.textBox16);
            this.groupBox1.Controls.Add(this.textBox13);
            this.groupBox1.Controls.Add(this.textBox14);
            this.groupBox1.Controls.Add(this.textBox11);
            this.groupBox1.Controls.Add(this.textBox12);
            this.groupBox1.Controls.Add(this.textBox9);
            this.groupBox1.Controls.Add(this.textBox10);
            this.groupBox1.Controls.Add(this.textBox7);
            this.groupBox1.Controls.Add(this.textBox8);
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Controls.Add(this.textBox6);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(14, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(287, 455);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "职业气功";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(195, 29);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(35, 12);
            this.label28.TabIndex = 34;
            this.label28.Text = "加成2";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(92, 29);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(35, 12);
            this.label27.TabIndex = 33;
            this.label27.Text = "加成1";
            // 
            // textBox21
            // 
            this.textBox21.Location = new System.Drawing.Point(197, 385);
            this.textBox21.Name = "textBox21";
            this.textBox21.Size = new System.Drawing.Size(71, 21);
            this.textBox21.TabIndex = 32;
            // 
            // textBox22
            // 
            this.textBox22.Location = new System.Drawing.Point(94, 382);
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new System.Drawing.Size(68, 21);
            this.textBox22.TabIndex = 31;
            // 
            // textBox19
            // 
            this.textBox19.Location = new System.Drawing.Point(197, 352);
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new System.Drawing.Size(71, 21);
            this.textBox19.TabIndex = 30;
            // 
            // textBox20
            // 
            this.textBox20.Location = new System.Drawing.Point(94, 349);
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new System.Drawing.Size(68, 21);
            this.textBox20.TabIndex = 29;
            // 
            // textBox17
            // 
            this.textBox17.Location = new System.Drawing.Point(197, 319);
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new System.Drawing.Size(71, 21);
            this.textBox17.TabIndex = 28;
            // 
            // textBox18
            // 
            this.textBox18.Location = new System.Drawing.Point(94, 316);
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new System.Drawing.Size(68, 21);
            this.textBox18.TabIndex = 27;
            // 
            // textBox15
            // 
            this.textBox15.Location = new System.Drawing.Point(197, 286);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(71, 21);
            this.textBox15.TabIndex = 26;
            // 
            // textBox16
            // 
            this.textBox16.Location = new System.Drawing.Point(94, 283);
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new System.Drawing.Size(68, 21);
            this.textBox16.TabIndex = 25;
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(197, 253);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(71, 21);
            this.textBox13.TabIndex = 24;
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(94, 250);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(68, 21);
            this.textBox14.TabIndex = 23;
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(197, 220);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(71, 21);
            this.textBox11.TabIndex = 22;
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(94, 217);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(68, 21);
            this.textBox12.TabIndex = 21;
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(197, 187);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(71, 21);
            this.textBox9.TabIndex = 20;
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(94, 184);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(68, 21);
            this.textBox10.TabIndex = 19;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(197, 154);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(71, 21);
            this.textBox7.TabIndex = 18;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(94, 151);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(68, 21);
            this.textBox8.TabIndex = 17;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(197, 121);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(71, 21);
            this.textBox5.TabIndex = 16;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(94, 118);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(68, 21);
            this.textBox6.TabIndex = 15;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(197, 85);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(71, 21);
            this.textBox3.TabIndex = 14;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(94, 85);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(68, 21);
            this.textBox4.TabIndex = 13;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(197, 52);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(71, 21);
            this.textBox2.TabIndex = 12;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(94, 52);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(68, 21);
            this.textBox1.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(34, 385);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 12);
            this.label11.TabIndex = 10;
            this.label11.Text = "label11";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(34, 352);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 12);
            this.label10.TabIndex = 9;
            this.label10.Text = "label10";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(34, 319);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 8;
            this.label9.Text = "label9";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(34, 286);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 7;
            this.label8.Text = "label8";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(34, 253);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "label7";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 220);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "label6";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "label5";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "label4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label29);
            this.groupBox2.Controls.Add(this.textBox37);
            this.groupBox2.Controls.Add(this.textBox36);
            this.groupBox2.Controls.Add(this.textBox35);
            this.groupBox2.Controls.Add(this.textBox34);
            this.groupBox2.Controls.Add(this.textBox33);
            this.groupBox2.Controls.Add(this.textBox32);
            this.groupBox2.Controls.Add(this.textBox31);
            this.groupBox2.Controls.Add(this.textBox30);
            this.groupBox2.Controls.Add(this.textBox29);
            this.groupBox2.Controls.Add(this.textBox28);
            this.groupBox2.Controls.Add(this.textBox27);
            this.groupBox2.Controls.Add(this.textBox26);
            this.groupBox2.Controls.Add(this.textBox25);
            this.groupBox2.Controls.Add(this.textBox24);
            this.groupBox2.Controls.Add(this.textBox23);
            this.groupBox2.Controls.Add(this.label26);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Location = new System.Drawing.Point(307, 38);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(306, 455);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "升天气功";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(158, 29);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(29, 12);
            this.label29.TabIndex = 30;
            this.label29.Text = "加成";
            // 
            // textBox37
            // 
            this.textBox37.Location = new System.Drawing.Point(160, 416);
            this.textBox37.Name = "textBox37";
            this.textBox37.Size = new System.Drawing.Size(100, 21);
            this.textBox37.TabIndex = 29;
            // 
            // textBox36
            // 
            this.textBox36.Location = new System.Drawing.Point(160, 390);
            this.textBox36.Name = "textBox36";
            this.textBox36.Size = new System.Drawing.Size(100, 21);
            this.textBox36.TabIndex = 28;
            // 
            // textBox35
            // 
            this.textBox35.Location = new System.Drawing.Point(160, 364);
            this.textBox35.Name = "textBox35";
            this.textBox35.Size = new System.Drawing.Size(100, 21);
            this.textBox35.TabIndex = 27;
            // 
            // textBox34
            // 
            this.textBox34.Location = new System.Drawing.Point(160, 338);
            this.textBox34.Name = "textBox34";
            this.textBox34.Size = new System.Drawing.Size(100, 21);
            this.textBox34.TabIndex = 26;
            // 
            // textBox33
            // 
            this.textBox33.Location = new System.Drawing.Point(160, 312);
            this.textBox33.Name = "textBox33";
            this.textBox33.Size = new System.Drawing.Size(100, 21);
            this.textBox33.TabIndex = 25;
            // 
            // textBox32
            // 
            this.textBox32.Location = new System.Drawing.Point(160, 286);
            this.textBox32.Name = "textBox32";
            this.textBox32.Size = new System.Drawing.Size(100, 21);
            this.textBox32.TabIndex = 24;
            // 
            // textBox31
            // 
            this.textBox31.Location = new System.Drawing.Point(160, 260);
            this.textBox31.Name = "textBox31";
            this.textBox31.Size = new System.Drawing.Size(100, 21);
            this.textBox31.TabIndex = 23;
            // 
            // textBox30
            // 
            this.textBox30.Location = new System.Drawing.Point(160, 234);
            this.textBox30.Name = "textBox30";
            this.textBox30.Size = new System.Drawing.Size(100, 21);
            this.textBox30.TabIndex = 22;
            // 
            // textBox29
            // 
            this.textBox29.Location = new System.Drawing.Point(160, 208);
            this.textBox29.Name = "textBox29";
            this.textBox29.Size = new System.Drawing.Size(100, 21);
            this.textBox29.TabIndex = 21;
            // 
            // textBox28
            // 
            this.textBox28.Location = new System.Drawing.Point(160, 182);
            this.textBox28.Name = "textBox28";
            this.textBox28.Size = new System.Drawing.Size(100, 21);
            this.textBox28.TabIndex = 20;
            // 
            // textBox27
            // 
            this.textBox27.Location = new System.Drawing.Point(160, 156);
            this.textBox27.Name = "textBox27";
            this.textBox27.Size = new System.Drawing.Size(100, 21);
            this.textBox27.TabIndex = 19;
            // 
            // textBox26
            // 
            this.textBox26.Location = new System.Drawing.Point(160, 130);
            this.textBox26.Name = "textBox26";
            this.textBox26.Size = new System.Drawing.Size(100, 21);
            this.textBox26.TabIndex = 18;
            // 
            // textBox25
            // 
            this.textBox25.Location = new System.Drawing.Point(160, 104);
            this.textBox25.Name = "textBox25";
            this.textBox25.Size = new System.Drawing.Size(100, 21);
            this.textBox25.TabIndex = 17;
            // 
            // textBox24
            // 
            this.textBox24.Location = new System.Drawing.Point(160, 78);
            this.textBox24.Name = "textBox24";
            this.textBox24.Size = new System.Drawing.Size(100, 21);
            this.textBox24.TabIndex = 16;
            // 
            // textBox23
            // 
            this.textBox23.Location = new System.Drawing.Point(160, 52);
            this.textBox23.Name = "textBox23";
            this.textBox23.Size = new System.Drawing.Size(100, 21);
            this.textBox23.TabIndex = 15;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(45, 419);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(47, 12);
            this.label26.TabIndex = 14;
            this.label26.Text = "label26";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(45, 237);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(47, 12);
            this.label19.TabIndex = 13;
            this.label19.Text = "label19";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(45, 263);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(47, 12);
            this.label20.TabIndex = 12;
            this.label20.Text = "label20";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(45, 289);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(47, 12);
            this.label21.TabIndex = 11;
            this.label21.Text = "label21";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(45, 315);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(47, 12);
            this.label22.TabIndex = 10;
            this.label22.Text = "label22";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(45, 341);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(47, 12);
            this.label23.TabIndex = 9;
            this.label23.Text = "label23";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(45, 367);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(47, 12);
            this.label24.TabIndex = 8;
            this.label24.Text = "label24";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(45, 393);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(47, 12);
            this.label25.TabIndex = 7;
            this.label25.Text = "label25";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(45, 211);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(47, 12);
            this.label18.TabIndex = 6;
            this.label18.Text = "label18";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(45, 185);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(47, 12);
            this.label17.TabIndex = 5;
            this.label17.Text = "label17";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(45, 159);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(47, 12);
            this.label16.TabIndex = 4;
            this.label16.Text = "label16";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(45, 133);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(47, 12);
            this.label15.TabIndex = 3;
            this.label15.Text = "label15";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(45, 107);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 12);
            this.label14.TabIndex = 2;
            this.label14.Text = "label14";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(45, 81);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 12);
            this.label13.TabIndex = 1;
            this.label13.Text = "label13";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(45, 55);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 12);
            this.label12.TabIndex = 0;
            this.label12.Text = "label12";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(159, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "保存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SkillContrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 515);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.comboBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SkillContrl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "气功设置-源多多资源网-yuandd.Net";
            this.Load += new System.EventHandler(this.SkillContrl_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

		}
	}
}
