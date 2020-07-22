using System.Drawing;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TimerEvents
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Private Members
        private MarkType[] board;
        private bool Player1Turn;
        private bool isGameEnded;
        

        #endregion

        #region Construktor
        public MainWindow()
        {
            InitializeComponent();

            newGame();
            
        }

        #endregion

        private void newGame()
        {
            board = new MarkType[9];
            for (var i=0; i < board.Length; i++)
            {
                board[i] = MarkType.FREE;
            }
            Player1Turn = true;

            Container.Children.Cast<Button>().ToList().ForEach(button =>
            {
                button.Content = string.Empty;
                button.Background = Brushes.Aqua;
                button.Foreground = Brushes.Black;

            });

            isGameEnded = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (isGameEnded) { newGame(); return; }

            var button = (Button)sender;

            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);

            var index = column + (row * 3);

            if(board[index] == MarkType.FREE)
            {
                board[index] = Player1Turn ? MarkType.CROSSED : MarkType.NOUGHT;
                button.Content = Player1Turn ? "X" : "O";
                Player1Turn ^= true;
                checkForWinner();
            }
        }

        private void checkForWinner()
        {
         if (board[0] != MarkType.FREE && (board[0] & board[1] & board[2]) == board[0])
            {
                isGameEnded = true;
                if (board[0] == MarkType.CROSSED) MessageBox.Show("Player1 Won!");
                else MessageBox.Show("Player2 Won!");
            }
         else if (board[3] != MarkType.FREE && (board[3] & board[4] & board[5]) == board[3])
            {
                isGameEnded = true;
                if (board[3] == MarkType.CROSSED) MessageBox.Show("Player1 Won!");
                else MessageBox.Show("Player2 Won!");
            }
            else if (board[6] != MarkType.FREE && (board[6] & board[7] & board[8]) == board[6])
            {
                isGameEnded = true;
                if (board[6] == MarkType.CROSSED) MessageBox.Show("Player1 Won!");
                else MessageBox.Show("Player2 Won!");
            }
            else if (board[0] != MarkType.FREE && (board[0] & board[3] & board[6]) == board[0])
            {
                isGameEnded = true;
                if (board[0] == MarkType.CROSSED) MessageBox.Show("Player1 Won!");
                else MessageBox.Show("Player2 Won!");
            }
            else if (board[1] != MarkType.FREE && (board[1] & board[4] & board[7]) == board[1])
            {
                isGameEnded = true;
                if (board[1] == MarkType.CROSSED) MessageBox.Show("Player1 Won!");
                else MessageBox.Show("Player2 Won!");
            }
            else if (board[2] != MarkType.FREE && (board[2] & board[5] & board[8]) == board[2])
            {
                isGameEnded = true;
                if (board[2] == MarkType.CROSSED) MessageBox.Show("Player1 Won!");
                else MessageBox.Show("Player2 Won!");
            }
            else if (board[0] != MarkType.FREE && (board[0] & board[4] & board[8]) == board[0])
            {
                isGameEnded = true;
                if (board[0] == MarkType.CROSSED) MessageBox.Show("Player1 Won!");
                else MessageBox.Show("Player2 Won!");
            }
            else if (board[2] != MarkType.FREE && (board[2] & board[4] & board[6]) == board[2])
            {
                isGameEnded = true;
                if (board[2] == MarkType.CROSSED) MessageBox.Show("Player1 Won!");
                else MessageBox.Show("Player2 Won!");
            }

            if (!board.Any(field => field == MarkType.FREE))
            {
                isGameEnded = true;
                MessageBox.Show("Tie nibba.", "Tie");
            }
        }
    }
}
