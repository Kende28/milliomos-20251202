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
                int i = rnd.Next(0,50);
				if (!quiz.Contains(osszes[i]))
				{
					quiz.Add(osszes[i]);
				}
			}

			MessageBox.Show("Kezdődjön a játék!","Játék indítása");
            Game();
        }

        private void Game()
        {
            Kerdes jelenlegi = quiz[question];
            tb_kerdes.Text = jelenlegi.Quiz;
            btn_A.Content = jelenlegi.ValaszA;
            btn_B.Content = jelenlegi.ValaszB;
			btn_C.Content = jelenlegi.ValaszC;
			btn_D.Content = jelenlegi.ValaszD;
		}

		private void btn_Click(object sender, RoutedEventArgs e)
		{
            if (sender is Button btn && btn.Content.ToString().First().ToString() == quiz[question].ValaszHelyes)
            {
                btn.Background = Brushes.Green;
            }
            else if (sender is Button btnElse)
			{
                btnElse.Background = Brushes.Red;
                MessageBox.Show("Vesztettél!");
                MessageBox.Show("");
            }
		}
	}
}