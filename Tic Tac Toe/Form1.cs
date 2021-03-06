﻿using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Tic_Tac_Toe
{

    public partial class Form1 : MetroForm
    {

        // Create a logger for use in this class
        private static log4net.ILog log = log4net.LogManager.GetLogger(typeof(Form1));

        

        bool turn = true;                   //turn is true when x turn
        bool computer = true;               //play against computer when computer  true ; default game is single player
        bool isNetwork = false;             //set networking then is networking true
        bool isClient = false;              //to identifing client and server
        bool receive = false;               //If client or server recevied data then receive true
        bool playerSet = false;             //if player names set
        int turnCount = 0;                  //trun count 
        String p, p1, p2;                   //player names
        int[] board;                        //for score board
        int ComWon = 0;                     //store win count without setting player names
        int youWon = 0;

        //////////////
        int i;
        TcpListener server = new TcpListener(IPAddress.Any, 1980); // Creates a TCP Listener To Listen to Any IPAddress trying to connect to the program with port 1980
        NetworkStream stream;                                      //Creats a NetworkStream (used for sending and receiving data)
        TcpClient client;                                          // Creates a TCP Client
        byte[] datalength = new byte[4];                           // creates a new byte with length 4 ( used for receivng data's lenght)
        //////////////

        MySQLClient sqlClient = new MySQLClient();                  // for connect to data base

        //check
        public Form1()
        {
            //Initiate logging based on XML configuration
            log4net.Config.XmlConfigurator.Configure();



            InitializeComponent();

            //Call the logger
            log.Info("Started...");
            Console.Read();

            p = "You";
            p1 = "Player 1";
            p2 = "Player 2";
            rServer.Checked = true;
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //help button
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By jayan Vidanapathirana & Chamal Kuruppu \n If you have any issue please contact us Mail : jayancv.13@cse.mrt.ac.lk", "Abot tic tac toe");
        }

        //Button click event (for Tic tac toe board 9 buttons )
        private void btnClick(object sender, EventArgs e)
        {
            btnClickFunction(sender);
        }

        //button click function
        private void btnClickFunction(object sender)
        {
            if (isNetwork)                   //if its connected with network
            {
                Button b = (Button)sender;
                if (turn == true && (!isClient) && (turnCount == 0 || turnCount == 2 || turnCount == 4 || turnCount == 8 || turnCount == 6))
                {
                    b.Text = "X";               //change button image  

                    ////////  Send clicked button //////////
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
                    ///////////
                    turn = !turn;                    //change turn
                    b.Enabled = false;               //disable button
                    turnCount++;                     //increment trun count
                    checkWinner();                   //check winner

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
                ////////////// Change button accoding to recevied data only ///////////// 
                else if (turn == true && (isClient) && (receive == true) && (turnCount == 0 || turnCount == 2 || turnCount == 4 || turnCount == 8 || turnCount == 6))
                {
                    b.Text = "X";
                    turn = !turn;                    //change turn
                    b.Enabled = false;
                    turnCount++;
                    receive = false;
                    checkWinner();
                }
                else if (turn == false && (!isClient) && (receive == true) && (turnCount == 1 || turnCount == 3 || turnCount == 5 || turnCount == 7))
                {
                    b.Text = "O";
                    turn = !turn;                    //change turn
                    b.Enabled = false;
                    turnCount++;
                    receive = false;
                    checkWinner();
                }



            }
            else       //local game
            {
                Button b = (Button)sender;
                if (turn == true)
                {
                    b.Text = "X";        //change button image

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
            //rows
            if (A1.Text == A2.Text && A2.Text == A3.Text && (!A1.Enabled))
                theWin = true;
            if (B1.Text == B2.Text && B2.Text == B3.Text && (!B1.Enabled))
                theWin = true;
            if (C1.Text == C2.Text && C2.Text == C3.Text && (!C1.Enabled))
                theWin = true;
            //columns
            if (A1.Text == B1.Text && B1.Text == C1.Text && (!A1.Enabled))
                theWin = true;
            if (A2.Text == B2.Text && B2.Text == C2.Text && (!A2.Enabled))
                theWin = true;
            if (A3.Text == B3.Text && B3.Text == C3.Text && (!A3.Enabled))
                theWin = true;
            //diagonal
            if (A1.Text == B2.Text && B2.Text == C3.Text && (!A1.Enabled))
                theWin = true;
            if (A3.Text == B2.Text && B2.Text == C1.Text && (!A3.Enabled))
                theWin = true;

            if (theWin)                          //if someone won the game
            {
                btnEnable(false);                //disable buttons
                String winner;
                if (turn)
                    winner = "O";
                else
                    winner = "X";

                if (computer && (winner == "O"))
                {                       //if computer won (Single palyer)
                    int defP = sqlClient.getScour( p, "defeat1");    //get pasr records
                    defP = defP + 1;                                         //increment records
                    sqlClient.Update( " defeat1=", defP, p);       //Update database
                    if (playerSet)                                           //if players already set then update score board
                    {
                        setScoreBoard(p);
                    }
                    else
                    {
                        ComWon++;
                        setScoreBoard(p, ComWon, youWon);
                    }
                    log.Info("Computer won the game !");
                    MessageBox.Show("Computer won the game !", "Winner");
                }
                else
                {
                    if (computer)                                            //check single player or not
                    {
                        //single player Playe1/You won
                        int wonP = sqlClient.getScour( p, "won1");
                        wonP = wonP + 1;
                        sqlClient.Update( "won1=", wonP, p);
                        if (playerSet)
                        {
                            setScoreBoard(p);
                        }
                        else
                        {
                            youWon++;
                            setScoreBoard(p, ComWon, youWon);
                        }

                        log.Info(p + " won the game !");
                        MessageBox.Show(p + " won the game !", "Winner");

                    }
                    else if (!isNetwork)                                                      //Multiplayer  mode win
                    {

                        if (winner == "X")
                        {
                            int wonP1 = sqlClient.getScour( p1, "won2");
                            wonP1 = wonP1 + 1;
                            sqlClient.Update( "won2=", wonP1, p1);
                            int defP2 = sqlClient.getScour( p2, "defeat2");
                            defP2 = defP2 + 1;
                            sqlClient.Update( "defeat2=", defP2, p2);
                            log.Info(p1 + " won the game !");
                            MessageBox.Show(p1 + " won the game !", "Winner");
                        }
                        else
                        {
                            int wonP2 = sqlClient.getScour( p2, "won2");
                            wonP2 = wonP2 + 1;
                            sqlClient.Update( "won2=", wonP2, p2);
                            int defP1 = sqlClient.getScour(p1, "defeat2");
                            defP1 = defP1 + 1;
                            sqlClient.Update("defeat2=", defP1, p1);
                            log.Info(p2 + " won the game !");
                            MessageBox.Show(p2 + " won the game !", "Winner");
                        }
                        setScoreBoard(p1, p2);


                    }
                    else if (isNetwork)                       //network mode
                    {
                        if (winner == "X")
                        {
                            if (!isClient)                    //player is server
                            {
                                int wonP1 = sqlClient.getScour( p1, "won2");
                                wonP1 = wonP1 + 1;
                                sqlClient.Update( "won2=", wonP1, p1);
                                int defP2 = sqlClient.getScour( p2, "defeat2");
                                defP2 = defP2 + 1;
                                sqlClient.Update( "defeat2=", defP2, p2);
                            }
                            log.Info(p1 + " won the game !");
                            MessageBox.Show(p1 + " won the game !", "Winner");
                        }
                        else
                        {
                            if (isClient)                       //player is client
                            {
                                int wonP2 = sqlClient.getScour( p2, "won2");
                                wonP2 = wonP2 + 1;
                                sqlClient.Update( "won2=", wonP2, p2);
                                int defP1 = sqlClient.getScour( p1, "defeat2");
                                defP1 = defP1 + 1;
                                sqlClient.Update( "defeat2=", defP1, p1);
                            }
                            log.Info(p2 + " won the game !");
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
                        int drwP = sqlClient.getScour( p, "draw1");
                        drwP = drwP + 1;
                        sqlClient.Update( "draw1=", drwP, p);
                       
                    }
                    else
                    {                                                       //multiplayer mode, change socres
                        int drwP1 = sqlClient.getScour( p1, "draw2");
                        drwP1 = drwP1 + 1;
                        sqlClient.Update("draw2=", drwP1, p1);
                        int drwP2 = sqlClient.getScour(p2, "draw2");
                        drwP2 = drwP2 + 1;
                        sqlClient.Update("draw2=", drwP2, p2);
                    }
                    log.Info("game Over Draw!");
                    MessageBox.Show("game Over Draw!", "Loose");

                }
            }

        }
        //set score Board values for single player
        private void setScoreBoard(string name1)
        {
            board = sqlClient.Get( name1);
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
            board = sqlClient.Get( name1);        //get player 1 scores and update score board
            p1Won.Text = board[1].ToString();
            p1Def.Text = board[3].ToString();
            board = sqlClient.Get( name2);        //get player 1 scores and update score board
            p2Won.Text = board[1].ToString();
            p2Def.Text = board[3].ToString();

        }


        // new game menu button
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //newGame_Click(sender, e);

        }

        // Change button text when mous enter the button
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

        //select single player mode
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

        private Button look_for_win_or_block(string mark)
        {
           
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

        private Button look_for_open_space()
        {
          
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
            if (isNetwork && turnCount >0)                     //for update both sides
            {
                if (isClient)
                {
                    ClientSend("X0");
                }
                else
                {
                    ServerSend("X0");
                }
            }
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
                newGame_Click(sender, e);
                panel1.Visible = true;
            }
            else
            {
                p1 = player1.Text;
                p2 = player2.Text;
                bool exist1 = sqlClient.Exist( p1);
                bool exist2 = sqlClient.Exist( p2);
                if (!exist1)
                {                                   //if player 1 not exist in database then insert to database
                    sqlClient.Insert( "name", p1);
                }
                if (!exist2)
                {                                    //if player 2 not exist in database then insert to database
                    sqlClient.Insert( "name", p2);
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
                newGame_Click(sender, e);
                panel2.Visible = true;
            }
            else
            {
                p = singlePlayer.Text;
                bool exist = sqlClient.Exist( p);

                if (!exist)
                {                   //if player 1 not exist in database then insert to database
                    sqlClient.Insert( "name", p);
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
                playerSet = true;
                panel4.Visible = false;
                //btnEnable(true);
                if (rServer.Checked == true)
                {
                    turn = true;
                    isClient = false;
                    p1 = TxtNetName.Text;
                    bool exist1 = sqlClient.Exist( p1);
                    if (!exist1)
                    {                                   //if player 1 not exist in database then insert to database
                        sqlClient.Insert( "name", p1);
                    }
                    newGame_ClickFuntion();
                    btnListen_Click(sender, e);

                }
                else
                {
                    turn = false;
                    isClient = true;
                    playerSet = true;
                    bool exist1 = sqlClient.Exist( p1);
                    if (!exist1)
                    {                                   //if player 1 not exist in database then insert to database
                        sqlClient.Insert( "name", p1);
                    }
                    p2 = TxtNetName.Text;
                    clientConect();
                }


            }
        }

        // create server
        private void btnListen_Click(object sender, EventArgs e)
        {
            try {
            server.Start();                         // Starts Listening to Any IPAddress trying to connect to the program with port 1980
            }catch(Exception en){
                MessageBox.Show("Server already started ! Error :  "+en);
                panel4.Visible = true;
                return;
            
            }
                MessageBox.Show("Waiting For Connection");
            new Thread(() =>                       // Creates a New Thread 
            {
                client = server.AcceptTcpClient(); //Waits for the Client To Connect

                MessageBox.Show("Connected To Client");
                if (client.Connected)             // If you are connected
                {

                    ServerReceive(); //Start Receiving

                }
            }).Start();

        }

        //server receiving data
        public void ServerReceive()
        {
            bool isBtn = false;
            stream = client.GetStream();            //Gets The Stream of The Connection
            new Thread(() =>                        // new receiving Thread
            {
                try
                {
                    while ((i = stream.Read(datalength, 0, 4)) != 0)//Keeps Trying to Receive the Size of the Message (Data)
                    {
                        byte[] data = new byte[BitConverter.ToInt32(datalength, 0)]; // Creates a Byte for the data to be Received On
                        stream.Read(data, 0, data.Length);                           //Receives The Real Data not the Size
                        this.Invoke((MethodInvoker)delegate                          // To Write the Received data
                        {

                            string btnTxt = Encoding.Default.GetString(data); // Encoding.Default.GetString(data); Converts Bytes Received to String
                            Button[] btns = new Button[9] { A1, A2, A3, B1, B2, B3, C1, C2, C3 };  //buttons array
                            string[] check = new string[9] { "A1", "A2", "A3", "B1", "B2", "B3", "C1", "C2", "C3" };
                            for (int j = 0; j < 9; j++)                                   //check that received msg & check array identify the button
                            {
                                try
                                {
                                    if (check[j] == btnTxt)
                                    {
                                        isBtn = true;
                                        receive = true;
                                        btnClickFunction(btns[j]);

                                    }
                                }
                                catch { }
                            }
                            if (!isBtn)
                            {
                                if (btnTxt == "X0")
                                {
                                    newGame_ClickFuntion();
                                }
                                else { 
                                p2 = btnTxt;
                                ServerSend(p1);
                                newGame_ClickFuntion();
                                }
                            }

                        });
                    }
                }
                catch (System.IO.IOException x) { }
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



                ClientReceive(); //Starts Receiving When Connected
                ClientSend(p2);

                //setScoreBoard(p1, p2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); // Error handler :D
            }
        }


        public void ClientReceive()
        {
            bool isBtn = false;
            stream = client.GetStream(); //Gets The Stream of The Connection
            new Thread(() => // Thread (like Timer)
            {
                try
                {
                    while ((i = stream.Read(datalength, 0, 4)) != 0)//Keeps Trying to Receive the Size of the Message or Data
                    {
                        // how to make a byte E.X byte[] examlpe = new byte[the size of the byte here] , i used BitConverter.ToInt32(datalength,0) cuz i received the length of the data in byte called datalength :D
                        byte[] data = new byte[BitConverter.ToInt32(datalength, 0)]; // Creates a Byte for the data to be Received On
                        stream.Read(data, 0, data.Length); //Receives The Real Data not the Size
                        this.Invoke((MethodInvoker)delegate // To Write the Received data
                        {

                            string btntxt = Encoding.Default.GetString(data); // Encoding.Default.GetString(data); Converts Bytes Received to String
                            Button[] btns = new Button[9] { A1, A2, A3, B1, B2, B3, C1, C2, C3 };
                            string[] check = new string[9] { "A1", "A2", "A3", "B1", "B2", "B3", "C1", "C2", "C3" };
                            for (int j = 0; j < 9; j++)
                            {
                                try
                                {
                                    if (check[j] == btntxt)
                                    {
                                        isBtn = true;
                                        receive = true;
                                        btnClickFunction(btns[j]);

                                    }
                                }
                                catch { }
                            } if (!isBtn)
                            {
                                if (btntxt == "X0")
                                {
                                    newGame_ClickFuntion();
                                }
                                else { 
                                p1 = btntxt;
                                newGame_ClickFuntion();
                                }
                            }

                        });
                    }
                }
                catch (System.IO.IOException x) { }
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

        private void hihgestScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] array1 = new string[2];
            string[] array2 = new string[2];
            array1 = sqlClient.Max( "won1");
            array2 = sqlClient.Max( "won2");
            labSinName.Text = array1[0];
            labSinScore.Text = array1[1];
            labMulName.Text = array2[0];
            labMulScore.Text = array2[1];
            highScore.Visible = true;
            btnEnable(false);

        }

        private void BtnScoureClose_Click(object sender, EventArgs e)
        {
            highScore.Visible = false;
            // btnEnable(true);
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            // Confirm user wants to close
            switch (MessageBox.Show(this, "Are you sure you want to close?", "Closing", MessageBoxButtons.YesNo))
            {
                case DialogResult.No:
                    e.Cancel = true;
                    break;
                default:
                    if (isNetwork)
                    {
                        server.Stop();
                        client.Close();
                        MessageBox.Show("Connection will close");
                    }
                    else { }

                    break;
            }
        }

    }



}
