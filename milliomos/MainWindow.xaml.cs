using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace milliomos
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		List<Kerdes> osszes = new List<Kerdes>();
		List<Kerdes> quiz = new List<Kerdes>();
		Random rnd = new Random();
		int question = 0;
		int score = 0;
		TextBox tb_username = new TextBox();


		public MainWindow()
		{
			InitializeComponent();
			Start();
		}

		private void Beolvas(string file)
		{
			StreamReader sr = new StreamReader(file);
			while (!sr.EndOfStream)
			{
				var data = sr.ReadLine().Split(";");
				Kerdes newKerdes = new Kerdes(data[0], data[1], data[2], data[3], data[4], data[5]);
				osszes.Add(newKerdes);
			}
		}

		private void Start()
		{
			Beolvas("milliomos.txt");
			while (quiz.Count < 10)
			{
				int i = rnd.Next(0, 50);
				if (!quiz.Contains(osszes[i]))
				{
					quiz.Add(osszes[i]);
				}
			}

			MessageBox.Show("Kezdődjön a játék!", "Játék indítása");
			MessageBox.Show("A játék menete: 10 kérdés, minden helyes válasz 1 pontot ér.\nEredmények mentéséhez írja be a nevét a mezőbe!", "Játék menete");
			Game();
		}

		private void Game()
		{
			if (question < 10)
			{
				Kerdes jelenlegi = quiz[question];
				tb_kerdes.Text = jelenlegi.Quiz;
				btn_A.Content = jelenlegi.ValaszA;
				btn_B.Content = jelenlegi.ValaszB;
				btn_C.Content = jelenlegi.ValaszC;
				btn_D.Content = jelenlegi.ValaszD;
				btn_A.Background = Brushes.LightGray;
				btn_B.Background = Brushes.LightGray;
				btn_C.Background = Brushes.LightGray;
				btn_D.Background = Brushes.LightGray;
			}
			else
			{

				if (tb_user.Text != null && tb_user.Text.ToString() != "")
				{
					StreamWriter sw = new StreamWriter("eredmeny.txt", true, Encoding.UTF8);
					sw.WriteLine($"{tb_user.Text.ToString()} - {score}/10 pont\n");
					sw.Close();
				}
				
				string leaderboard = "";

				if (File.Exists("eredmeny.txt"))
				{
					StreamReader sr = new StreamReader("eredmeny.txt");
					while (!sr.EndOfStream)
					{
						string line = sr.ReadLine();
						leaderboard += line + "\n";
					}
				}

				MessageBox.Show(leaderboard);
				win.Close();
			}
		}

		private void btn_Click(object sender, RoutedEventArgs e)
		{
			if (question < 10)
			{
				if (sender is Button btn && btn.Content.ToString().First().ToString() == quiz[question].ValaszHelyes)
				{
					btn.Background = Brushes.Green;
					MessageBox.Show("Helyes válasz");
					question++;
					score++;
					Game();
				}
				else if (sender is Button btnElse)
				{
					btnElse.Background = Brushes.Red;
					MessageBox.Show("Hibás válasz");
					question++;
					Game();
				}
			}

		}
	}
}