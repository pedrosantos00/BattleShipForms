namespace BattleShipForms
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GamePanel panel = new GamePanel();
            panel.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String message = new string
                ("Battleship is a war-themed board game for two players in which the " +
                "opponents try to guess the location of their opponent's warships and sink them. " +
                "\n\nBefore the game starts, each opponent secretly places their own five ships on the ocean grid." +
                "\n\nPlayers take turns firing shots (by calling out a grid coordinate) to attempt to hit the opponent's enemy ships.");



            MessageBox.Show(message);
        }
    }
}