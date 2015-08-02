using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySQLClass;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Tic_Tac_Toe
{

    public partial class Form1 : MetroForm
    {
        //hostname,database,username,password,port
        MySQLClient sqlClient = new MySQLClient("localhost", "tic", "root", "root", 3306);

        bool turn = true;                   //turn is true when x turn
        bool computer = true;               //default game is single player
        bool isNetwork = false;                     //set networking
        bool isClient = false;
        bool receive = false;
        bool playerSet = false;
        int turnCount = 0;
        String p, p1, p2;
        int[] board;                        //for score board
        int ComWon = 0;
        int youWon = 0;

        //////////////
        int i;
        TcpListener server = new TcpListener(IPAddress.Any, 1980); // Creates a TCP Listener To Listen to Any IPAddress trying to connect to the program with port 1980
        NetworkStream stream; //Creats a NetworkStream (used for sending and receiving data)
        TcpClient client; // Creates a TCP Client
        byte[] datalength = new byte[4]; // creates a new byte with length 4 ( used for receivng data's lenght)
        //////////////



        //check
        public Form1()
        {
            InitializeComponent();
            p = "You";
            p1 = "Player 1";
            p2 = "Player 2";
            rServer.Checked = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By jayan Vidanapathirana & Chamal Kuruppu", "Abot tic tac toe");
        }

        //Button click method
        private void btnClick(object sender, EventArgs e)
        {
            btnClickFunction(sender);
        }

        private void btnClickFunction(object sender)
        {
            if (isNetwork)
            {          
                Button b = (Button)sender;
                if (turn == true && (!isClient)&&(turnCount == 0 || turnCount == 2 || turnCount == 4 || turnCount == 8 || turnCount == 6))
                {              //change button image  
                
                    b.Text = "X";

                    Button[] btns = new Button[9] { A1, A2, A3, B1, B2, B3, C1, C2, C3 };
                    string[] check = new string[9] { "A1", "A2", "A3", "B1", "B2", "B3", "C1", "C2", "C3" };
                    for (int j = 0; j < 9; j++)
                    {
                        try
                        {
                            if (check[j] == b.Name)
                            {
                                ServerSend(check[j]);
                            }
                        }
                        catch { }
                    }
                    turn = !turn;                    //change turn
                    b.Enabled = false;
                    turnCount++;
                    checkWinner();
                    
                }
                else if (turn == false && (isClient) && (turnCount == 1 || turnCount == 3 || turnCount == 5 || turnCount == 7))
                {
                   // if (isClient) { btnEnable(false); }
                    b.Text = "O";
                    Button[] btns = new Button[9] { A1, A2, A3, B1, B2, B3, C1, C2, C3 };
                    string[] check = new string[9] { "A1", "A2", "A3", "B1", "B2", "B3", "C1", "C2", "C3" };
                    for (int j = 0; j < 9; j++)
                    {
                        try
                        {
                            if (check[j] == b.Name)
                            {
                               ClientSend(check[j]);
                            }
                        }
                        catch { }
                    }
                    turn = !turn;                    //change turn
                    b.Enabled = false;
                    turnCount++;
                    checkWinner();
                    
                }
                else if (turn == true && (isClient) && (receive == true) && (turnCount == 0 || turnCount == 2 || turnCount == 4 || turnCount == 8 || turnCount == 6))
                {
                    b.Text = "X";
                    turn = !turn;                    //change turn
                    b.Enabled = false;
                    turnCount++;
                    receive =false;
                    checkWinner();
                }
                else if (turn == false && (!isClient)&& (receive ==true) && (turnCount == 1 || turnCount == 3 || turnCount ==5 || turnCount == 7))
                {
                    b.Text = "O";
                    turn = !turn;                    //change turn
                    b.Enabled = false;
                    turnCount++;
                    receive = false;
                    checkWinner();
                }
               
              
               
            }
            else
            {
                Button b = (Button)sender;
                if (turn == true)
                {              //change button image
                    b.Text = "X";

                }
                else
                {
                    b.Text = "O";
                }
                turn = !turn;                    //change turn
                b.Enabled = false;
                turnCount++;
                checkWinner();
                if ((!turn) && (computer) && (turnCount < 9))
                {
                    computer_make_move();
                }

            }
        }
        //check manually possible places
        private void checkWinner()
        {
            bool theWin = false;
            if (A1.Text == A2.Text && A2.Text == A3.Text && (!A1.Enabled))
                theWin = true;
            if (B1.Text == B2.Text && B2.Text == B3.Text && (!B1.Enabled))
                theWin = true;
            if (C1.Text == C2.Text && C2.Text == C3.Text && (!C1.Enabled))
                theWin = true;
            if (A1.Text == B1.Text && B1.Text == C1.Text && (!A1.Enabled))
                theWin = true;
            if (A2.Text == B2.Text && B2.Text == C2.Text && (!A2.Enabled))
                theWin = true;
            if (A3.Text == B3.Text && B3.Text == C3.Text && (!A3.Enabled))
                theWin = true;
            if (A1.Text == B2.Text && B2.Text == C3.Text && (!A1.Enabled))
                theWin = true;
            if (A3.Text == B2.Text && B2.Text == C1.Text && (!A3.Enabled))
                theWin = true;

            if (theWin)
            {
                btnEnable(false);
                String winner;
                if (turn)
                    winner = "O";
                else
                    winner = "X";

                if (computer && (winner == "O"))
                {                       //if computer won (Single palyer)
                    int defP = sqlClient.getScour("score", p, "defeat1");
                    defP = defP + 1;
                    sqlClient.Update(" score ", " defeat1=", defP, p);
                    if (playerSet)
                    {
                        setScoreBoard(p);
                    }
                    else
                    {
                        ComWon++;
                        setScoreBoard(p, ComWon, youWon);
                    }


                    MessageBox.Show("Computer won the game !", "Winner");
                }
                else
                {
                    if (computer)                                            //check single player or not
                    {
                        //single player Playe1/You won
                        int wonP = sqlClient.getScour("score", p, "won1");
                        wonP = wonP + 1;
                        sqlClient.Update("score", "won1=", wonP, p);
                        if (playerSet)
                        {
                            setScoreBoard(p);
                        }
                        else
                        {
                            youWon++;
                            setScoreBoard(p, ComWon, youWon);
                        }


                        MessageBox.Show(p + " won the game !", "Winner");

                    }
                    else                                                      //Multiplayer  mode win
                    {

                        if (winner == "X")
                        {
                            int wonP1 = sqlClient.getScour("score", p1, "won2");
                            wonP1 = wonP1 + 1;
                            sqlClient.Update("score", "won2=", wonP1, p1);
                            int defP2 = sqlClient.getScour("score", p2, "defeat2");
                            defP2 = defP2 + 1;
                            sqlClient.Update("score", "defeat2=", defP2, p2);

                            MessageBox.Show(p1 + " won the game !", "Winner");
                        }
                        else
                        {
                            int wonP2 = sqlClient.getScour("score", p2, "won2");
                            wonP2 = wonP2 + 1;
                            sqlClient.Update("score", "won2=", wonP2, p2);
                            int defP1 = sqlClient.getScour("score", p1, "defeat2");
                            defP1 = defP1 + 1;
                            sqlClient.Update("score", "defeat2=", defP1, p1);

                            MessageBox.Show(p2 + " won the game !", "Winner");
                        }
                        setScoreBoard(p1, p2);


                    }
                }

            }
            else
            {                                         //no winners then,
                if (turnCount == 9)
                {                      //check turn Count, if it equals to 9 then game over & draw
                    if (computer)
                    {                       //Single player mode
                        int drwP = sqlClient.getScour("score", p, "draw1");
                        drwP = drwP + 1;
                        sqlClient.Update("score", "draw1=", drwP, p);
                    }
                    else
                    {                                                       //multiplayer mode, change socres
                        int drwP1 = sqlClient.getScour("score", p1, "draw2");
                        drwP1 = drwP1 + 1;
                        sqlClient.Update("score", "draw2=", drwP1, p1);
                        int drwP2 = sqlClient.getScour("score", p2, "draw2");
                        drwP2 = drwP2 + 1;
                        sqlClient.Update("score", "draw2=", drwP2, p2);
                    }
                    MessageBox.Show("game Over Draw!", "Loose");

                }
            }

        }
        //set score Board values for single player
        private void setScoreBoard(string name1)
        {
            board = sqlClient.Get("score", name1);
            p1Won.Text = board[0].ToString();
            p1Def.Text = board[2].ToString();
            p2Won.Text = board[2].ToString();
            p2Def.Text = board[0].ToString();

        }
        private void setScoreBoard(string name1, int com, int you)
        {
            p1Won.Text = you.ToString();
            p1Def.Text = com.ToString();
            p2Won.Text = com.ToString();
            p2Def.Text = you.ToString();

        }

        //set score board values for multiplayer 
        private void setScoreBoard(string name1, string name2)
        {
            board = sqlClient.Get("score", name1);        //get player 1 scores and update score board
            p1Won.Text = board[1].ToString();
            p1Def.Text = board[3].ToString();
            board = sqlClient.Get("score", name2);        //get player 1 scores and update score board
            p2Won.Text = board[1].ToString();
            p2Def.Text = board[3].ToString();

        }



        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newGame_Click(sender, e);

        }


        private void mouse_Enter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                if (turn)
                    b.Text = "X";
                else
                    b.Text = "O";
            }
        }

        private void mouse_leave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                if (turn)
                    b.Text = "";
                else
                    b.Text = "";
            }
        }

        private void single(object sender, EventArgs e)
        {
            computer = true;
            btnEnable(false);
            panel2.Visible = true;
            turn = true;
        }

        private void multi(object sender, EventArgs e)
        {


        }

        //Enable and disable buttons
        private void btnEnable(bool arg)
        {
            Button[] btns = new Button[9] { A1, A2, A3, B1, B2, B3, C1, C2, C3 };
            foreach (Button c in btns)
            {
                try
                {
                    Button b = (Button)c;
                    b.Enabled = arg;
                }
                catch { }
            }

        }

        private void computer_make_move()
        {
            //priority 1:  get tick tac toe
            //priority 2:  block x tic tac toe
            //priority 3:  go for corner space
            //priority 4:  pick open space

            Button move = null;

            move = look_for_win_or_block("O");
            if (move == null)
            {
                move = look_for_win_or_block("X");
                if (move == null)
                {
                    move = look_for_corner();
                    if (move == null)
                    {
                        move = look_for_open_space();
                    }
                }
            }

            move.PerformClick();
        }

        private Button look_for_open_space()
        {
            Console.WriteLine("Looking for open space");
            Button b = null;
            Button[] btns = new Button[9] { A1, A2, A3, B1, B2, B3, C1, C2, C3 };
            foreach (Button c in btns)
            {
                b = c as Button;
                if (b != null)
                {
                    if (b.Text == "")
                        return b;
                }
            }

            return null;
        }

        private Button look_for_corner()
        {
            Console.WriteLine("Looking for corner");
            if (A1.Text == "O")
            {
                if (A3.Text == "")
                    return A3;
                if (C3.Text == "")
                    return C3;
                if (C1.Text == "")
                    return C1;
            }

            if (A3.Text == "O")
            {
                if (A1.Text == "")
                    return A1;
                if (C3.Text == "")
                    return C3;
                if (C1.Text == "")
                    return C1;
            }

            if (C3.Text == "O")
            {
                if (A1.Text == "")
                    return A3;
                if (A3.Text == "")
                    return A3;
                if (C1.Text == "")
                    return C1;
            }

            if (C1.Text == "O")
            {
                if (A1.Text == "")
                    return A3;
                if (A3.Text == "")
                    return A3;
                if (C3.Text == "")
                    return C3;
            }

            if (A1.Text == "")
                return A1;
            if (A3.Text == "")
                return A3;
            if (C1.Text == "")
                return C1;
            if (C3.Text == "")
                return C3;

            return null;
        }

        private Button look_for_win_or_block(string mark)
        {
            Console.WriteLine("Looking for win or block:  " + mark);
            //HORIZONTAL TESTS
            if ((A1.Text == mark) && (A2.Text == mark) && (A3.Text == ""))
                return A3;
            if ((A2.Text == mark) && (A3.Text == mark) && (A1.Text == ""))
                return A1;
            if ((A1.Text == mark) && (A3.Text == mark) && (A2.Text == ""))
                return A2;

            if ((B1.Text == mark) && (B2.Text == mark) && (B3.Text == ""))
                return B3;
            if ((B2.Text == mark) && (B3.Text == mark) && (B1.Text == ""))
                return B1;
            if ((B1.Text == mark) && (B3.Text == mark) && (B2.Text == ""))
                return B2;

            if ((C1.Text == mark) && (C2.Text == mark) && (C3.Text == ""))
                return C3;
            if ((C2.Text == mark) && (C3.Text == mark) && (C1.Text == ""))
                return C1;
            if ((C1.Text == mark) && (C3.Text == mark) && (C2.Text == ""))
                return C2;

            //VERTICAL TESTS
            if ((A1.Text == mark) && (B1.Text == mark) && (C1.Text == ""))
                return C1;
            if ((B1.Text == mark) && (C1.Text == mark) && (A1.Text == ""))
                return A1;
            if ((A1.Text == mark) && (C1.Text == mark) && (B1.Text == ""))
                return B1;
            Console.WriteLine("skip ");

            if ((A2.Text == mark) && (B2.Text == mark) && (C2.Text == ""))
                return C2;
            if ((B2.Text == mark) && (C2.Text == mark) && (A2.Text == ""))
                return A2;
            if ((A2.Text == mark) && (C2.Text == mark) && (B2.Text == ""))
                return B2;

            if ((A3.Text == mark) && (B3.Text == mark) && (C3.Text == ""))
                return C3;
            if ((B3.Text == mark) && (C3.Text == mark) && (A3.Text == ""))
                return A3;
            if ((A3.Text == mark) && (C3.Text == mark) && (B3.Text == ""))
                return B3;

            //DIAGONAL TESTS
            if ((A1.Text == mark) && (B2.Text == mark) && (C3.Text == ""))
                return C3;
            if ((B2.Text == mark) && (C3.Text == mark) && (A1.Text == ""))
                return A1;
            if ((A1.Text == mark) && (C3.Text == mark) && (B2.Text == ""))
                return B2;

            if ((A3.Text == mark) && (B2.Text == mark) && (C1.Text == ""))
                return C1;
            if ((B2.Text == mark) && (C1.Text == mark) && (A3.Text == ""))
                return A3;
            if ((A3.Text == mark) && (C1.Text == mark) && (B2.Text == ""))
                return B2;

            return null;
        }

        private void check()
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void newGame_Click(object sender, EventArgs e)
        {
            newGame_ClickFuntion();
        }

        private void newGame_ClickFuntion()
        {
            turn = true;
            turnCount = 0;
            Button[] btns = new Button[9] { A1, A2, A3, B1, B2, B3, C1, C2, C3 };
            if (playerSet)
            {
                if (computer)
                {
                    boardS.Text = p;
                    boardM.Text = "Computer";
                    setScoreBoard(p);
                }
                else
                {
                    boardS.Text = p1;
                    boardM.Text = p2;
                    setScoreBoard(p1, p2);
                }
            }

            foreach (Button c in btns)
            {
                try
                {
                    Button b = (Button)c;
                    b.Text = "";
                }
                catch { }
            }
            //setScoreBoard(p);
            btnEnable(true);
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void save_Click(object sender, EventArgs e)
        {
            if (player1.Text.Equals("") || player2.Text.Equals(""))
            {
                panel1.Visible = true;
            }
            else
            {
                p1 = player1.Text;
                p2 = player2.Text;
                bool exist1 = sqlClient.Exist("score", p1);
                bool exist2 = sqlClient.Exist("score", p2);
                if (!exist1)
                {                                   //if player 1 not exist in database then insert to database

                    sqlClient.Insert("score", "name", p1);
                }
                if (!exist2)
                {                                    //if player 2 not exist in database then insert to database

                    sqlClient.Insert("score", "name", p2);
                }
                panel1.Visible = false;
                playerSet = true;
                newGame_Click(sender, e);

            }
        }

        private void submitP1_Click(object sender, EventArgs e)
        {
            if (singlePlayer.Text.Equals(""))
            {
                panel2.Visible = true;
            }
            else
            {
                p = singlePlayer.Text;
                bool exist = sqlClient.Exist("score", p);

                if (!exist)
                {                   //if player 1 not exist in database then insert to database
                    sqlClient.Insert("score", "name", p);
                }
                panel2.Visible = false;
                playerSet = true;
                newGame_Click(sender, e);
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            panel2.Visible = false;
            btnEnable(true);
        }

        private void btnCancelP2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            btnEnable(true);
        }

        private void scoreToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void fontDialog1_Apply(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void boardS_Click(object sender, EventArgs e)
        {

        }

        private void networkToolStripMenuItem_Click(object sender, EventArgs e)
        {


            btnEnable(false);
            panel4.Visible = true;                   //visible player panel

        }

        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            computer = false;
            btnEnable(false);
            panel1.Visible = true;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e) // networking cancel
        {
            panel4.Visible = false;
            btnEnable(true);
        }

        private void button1_Click_2(object sender, EventArgs e)  //networking start
        {
            if (TxtNetName.Text != "")
            {
                isNetwork = true;                       //To know this is a networking game
                computer = false;
                panel4.Visible = false;
                //btnEnable(true);
                if (rServer.Checked == true)
                {
                    turn = true;
                    isClient = false;
                    newGame_ClickFuntion();
                    btnListen_Click(sender, e);

                }
                else
                {
                   turn = false;
                    isClient = true;
                    clientConect();
                }


            }
        }


        private void btnListen_Click(object sender, EventArgs e)
        {

            server.Start(); // Starts Listening to Any IPAddress trying to connect to the program with port 1980
            MessageBox.Show("Waiting For Connection");
            new Thread(() => // Creates a New Thread (like a timer)
            {
                client = server.AcceptTcpClient(); //Waits for the Client To Connect
               
                MessageBox.Show("Connected To Client");
                if (client.Connected) // If you are connected
                {
                    
                    ServerReceive(); //Start Receiving
                }
            }).Start();
        }

        public void ServerReceive()
        {
            stream = client.GetStream(); //Gets The Stream of The Connection
            new Thread(() => // Thread (like Timer)
            {
                while ((i = stream.Read(datalength, 0, 4)) != 0)//Keeps Trying to Receive the Size of the Message or Data
                {
                    // how to make a byte E.X byte[] examlpe = new byte[the size of the byte here] , i used BitConverter.ToInt32(datalength,0) cuz i received the length of the data in byte called datalength :D
                    byte[] data = new byte[BitConverter.ToInt32(datalength, 0)]; // Creates a Byte for the data to be Received On
                    stream.Read(data, 0, data.Length); //Receives The Real Data not the Size
                    this.Invoke((MethodInvoker)delegate // To Write the Received data
                    {
                        receive = true;
                        string btnTxt = Encoding.Default.GetString(data); // Encoding.Default.GetString(data); Converts Bytes Received to String
                        Button[] btns = new Button[9] { A1, A2, A3, B1, B2, B3, C1, C2, C3 };
                        string[] check = new string[9] { "A1", "A2", "A3", "B1", "B2", "B3", "C1", "C2", "C3" };
                        for (int j = 0; j < 9; j++)
                        {
                            try
                            {
                                if (check[j] == btnTxt)
                                {
                                    btnClickFunction(btns[j]);
                                }
                            }
                            catch { }
                        }

                    });
                }
            }).Start(); // Start the Thread

        }



        public void ServerSend(string msg)
        {
            stream = client.GetStream(); //Gets The Stream of The Connection
            byte[] data; // creates a new byte without mentioning the size of it cuz its a byte used for sending
            data = Encoding.Default.GetBytes(msg); // put the msg in the byte ( it automaticly uses the size of the msg )
            int length = data.Length; // Gets the length of the byte data
            byte[] datalength = new byte[4]; // Creates a new byte with length of 4
            datalength = BitConverter.GetBytes(length); //put the length in a byte to send it
            stream.Write(datalength, 0, 4); // sends the data's length
            stream.Write(data, 0, data.Length); //Sends the real data
        }


        private void clientConect()
        {
            try
            {
                client = new TcpClient("127.0.0.1", 1980); //Trys to Connect
                newGame_ClickFuntion();
                ClientReceive(); //Starts Receiving When Connected
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); // Error handler :D
            }
        }


        public void ClientReceive()
        {

            stream = client.GetStream(); //Gets The Stream of The Connection
            new Thread(() => // Thread (like Timer)
            {
                while ((i = stream.Read(datalength, 0, 4)) != 0)//Keeps Trying to Receive the Size of the Message or Data
                {
                    // how to make a byte E.X byte[] examlpe = new byte[the size of the byte here] , i used BitConverter.ToInt32(datalength,0) cuz i received the length of the data in byte called datalength :D
                    byte[] data = new byte[BitConverter.ToInt32(datalength, 0)]; // Creates a Byte for the data to be Received On
                    stream.Read(data, 0, data.Length); //Receives The Real Data not the Size
                    this.Invoke((MethodInvoker)delegate // To Write the Received data
                    {
                        receive = true;
                        string btntxt = Encoding.Default.GetString(data); // Encoding.Default.GetString(data); Converts Bytes Received to String
                        Button[] btns = new Button[9] { A1, A2, A3, B1, B2, B3, C1, C2, C3 };
                        string[] check = new string[9] { "A1", "A2", "A3", "B1", "B2", "B3", "C1", "C2", "C3" };
                        for (int j = 0; j < 9; j++)
                        {
                            try
                            {
                                if (check[j] == btntxt)
                                {
                                    btnClickFunction(btns[j]);
                                }
                            }
                            catch { }
                        }
                    
                    });
                }
            }).Start(); // Start the Thread
        }

        public void ClientSend(string msg)
        {
            stream = client.GetStream(); //Gets The Stream of The Connection
            byte[] data; // creates a new byte without mentioning the size of it cuz its a byte used for sending
            data = Encoding.Default.GetBytes(msg); // put the msg in the byte ( it automaticly uses the size of the msg )
            int length = data.Length; // Gets the length of the byte data
            byte[] datalength = new byte[4]; // Creates a new byte with length of 4
            datalength = BitConverter.GetBytes(length); //put the length in a byte to send it
            stream.Write(datalength, 0, 4); // sends the data's length
            stream.Write(data, 0, data.Length); //Sends the real data
        }








        private void modeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newGame_Click(sender, e);
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void hihgestScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] array1 = new string[2];
            string[] array2 = new string[2];
            array1 = sqlClient.Max("score", "won1");
            array2 = sqlClient.Max("score", "won2");
            labSinName.Text = array1[0];
            labSinScore.Text = array1[1];
            labMulName.Text = array2[0];
            labMulScore.Text = array2[1];
            highScore.Visible = true;
            btnEnable(false);

        }

        private void highScore_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnScoureClose_Click(object sender, EventArgs e)
        {
            highScore.Visible = false;
            // btnEnable(true);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }



    }



}
