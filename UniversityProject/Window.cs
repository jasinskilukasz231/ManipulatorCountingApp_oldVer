using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accord.Math;
using System.IO;

namespace ProjectApp
{
    //TODO THINGS
    //numbers 0,00000000123 are not shown properly bcs e^-5 thing
    public partial class window : Form
    {
        //real size of the window
        int win_x = 1540;
        int win_y = 800;
        //files
        //string folderPath = "C:/Users/jasin/Desktop/programy/C#/ProjectApp/images/";
        OpenFileDialog openFileDialog = new OpenFileDialog();

        //drawing
        PictureBox pb1 = new PictureBox();

        public window()
        {
            InitializeComponent();
            InitObjects();
            StartingScreen(true);
        }
        //varibales
        int size = 0; // number of rows in createGrid function

        bool mobilityScreen2Visible = false;

        //exception variables, prevents working on uncreated objects
        bool mobilityScreen2Created = false;
        bool speedScreenTextBoxGroupCreated = false;
        bool speedScreenLabelGroupCreated = false;
        bool speedScreen4CheckBoxGroupCreated = false;
        bool speedScreen5CheckBoxGroupCreated = false;
        bool speedScreen6LabelGroupCreated = false;
        bool sdtScreen2Created = false;

        //creating objects
        Label newScreenInfoLabel1 = new Label();
        Label newScreenInfoLabel3 = new Label();
        Label newScreenInfoLabel4 = new Label();
        Label newScreenInfoLabel9 = new Label();
        Label newScreenInfoLabel10 = new Label();
        Label newScreenInfoLabel11 = new Label();
        Label newScreenInfoLabel13 = new Label();
        Label newScreenInfoLabel14 = new Label();
        Label newScreen3Label1 = new Label();
        TextBox newScreenTextBox1 = new TextBox();
        Label[] newScreenLabelGroup = new Label[10];
        
        CheckBox[] mobilityScreenCheckBoxGroup = new CheckBox[21];
        CheckBox newScreenCheckBox1 = new CheckBox();
        CheckBox newScreenCheckBox2 = new CheckBox();
        Button nextButton = new Button();
        Button nextButton2 = new Button();

        TextBox[] speedScreenTextBoxGroup = new TextBox[64];
        Label[] speedScreenLabelGroup = new Label[8];
        Label[] speedScreenLabelGroup2 = new Label[8];

        PictureBox drawingField = new PictureBox();
        PictureBox backgroundBox = new PictureBox();

        FontFamily arial = new FontFamily("Arial");

        TextBox speedScreen1TextBox = new TextBox();
        Label speedScreen1Label = new Label();
        Button speedScreen1Button1 = new Button();
        Label speedScreen2Label = new Label();
        Label speedScreen2Label1 = new Label();
        Label speedScreen2Label2 = new Label();
        Label speedScreen2Label3 = new Label();
        Label speedScreen2Label4 = new Label();
        Button speedScreen2Button1 = new Button();
        Button speedScreen2Button2 = new Button();
        Label speedScreen2Label5 = new Label();
        CheckBox speedScreen2CheckBox = new CheckBox();

        Label speedScreen3Label1 = new Label();
        Label speedScreen3Label2 = new Label();
        Button speedScreen3Button1 = new Button();
        Button speedScreen3Button2 = new Button();
        string finalMatrixString = "";

        Button speedScreen3Button3 = new Button();
        //speed screen4
        TextBox[] speedScreen4TextBoxGroup = new TextBox[12];
        CheckBox[] speedScreen4CheckBoxGroup = new CheckBox[24];
        Label[] speedScreen4LabelGroup = new Label[12];
        Label speedScreen4Label1 = new Label();
        Label speedScreen4Label3 = new Label();
        Label speedScreen4Label4 = new Label();
        Button speedScreen4Button1 = new Button();
        Label speedScreen4Label5 = new Label();
        Label speedScreen4Label6 = new Label();
        Label speedScreen4Label7 = new Label();
        Label speedScreen4Label8 = new Label();

        Label speedScreen4Label9 = new Label();
        Label speedScreen4Label10 = new Label();
        Label speedScreen4Label11 = new Label();

        CheckBox speedScreen4CheckBox1 = new CheckBox();
        CheckBox speedScreen4CheckBox2 = new CheckBox();

        //speed screen5
        TextBox[] speedScreen5TextBoxGroup = new TextBox[12];
        CheckBox[] speedScreen5CheckBoxGroup = new CheckBox[24];
        Label[] speedScreen5LabelGroup = new Label[12];
        Label speedScreen5Label1 = new Label();
        Label speedScreen5Label3 = new Label();
        Label speedScreen5Label4 = new Label();
        Button speedScreen5Button1 = new Button();
        Label speedScreen5Label5 = new Label();
        Label speedScreen5Label6 = new Label();
        Label speedScreen5Label7 = new Label();
        Label speedScreen5Label8 = new Label();

        Label speedScreen5Label9 = new Label();
        Label speedScreen5Label10 = new Label();
        Label speedScreen5Label11 = new Label();

        CheckBox speedScreen5CheckBox1 = new CheckBox();
        CheckBox speedScreen5CheckBox2 = new CheckBox();

        //speed screen 6
        Label[] speedScreen6LabelGroup = new Label[20];
        Label[] speedScreen6LabelGroup1 = new Label[10];
        Label[] speedScreen6LabelGroup3 = new Label[10];
        Label[] speedScreen6LabelGroup2 = new Label[10];
        Label[] speedScreen6LabelGroup4 = new Label[10];
        Label[] speedScreen6LabelGroup5 = new Label[10];
        Label speedScreen6Label1 = new Label();
        Label speedScreen6Label2 = new Label();
        Label speedScreen6Label3 = new Label();
        Button speedScreen6Button1 = new Button();
        Button speedScreen6Button2 = new Button();
        Button speedScreen6Button3 = new Button();
        Button speedScreen6Button4 = new Button();
        Button speedScreen6Button5 = new Button();
        Button speedScreen6Button6 = new Button();
        Button speedScreen6Button7 = new Button();

        //First dinamics task
        Label fdtLabel1 = new Label();
        Label fdtLabel2 = new Label();
        Button fdtButton1 = new Button();
        Button fdtButton2 = new Button();
        TextBox[] fdtTextBoxGroup = new TextBox[16];

        //Secound dinamics task
        TextBox[] sdtScreen1TextBoxGroup1 = new TextBox[8];
        Button sdtScreen1Button1 = new Button();
        Label sdtScreen1Label1 = new Label();
        Label sdtScreen1Label2 = new Label();
        Label[] sdtScreen1LabelGroup1 = new Label[8];
        Label sdtScreen1Label3 = new Label();

        List<double[,]> rotationMatrixList = new List<double[,]>();
        List<double[]> omegaVectorList = new List<double[]>();
        List<double[]> pVectorList = new List<double[]>();
        List<double[]> speedVectorList = new List<double[]>();
        List<double[]> epsilonVectorList = new List<double[]>();
        List<double[]> accelVectorList = new List<double[]>();

        //sdt screen 3
        Button[] sdtScreen3ButtonGroup = new Button[10];
        Label[] sdtScreen3LabelGroup = new Label[15];
        Label[] sdtScreen3LabelGroup1 = new Label[15];
        Label[] sdtScreen3LabelGroup2 = new Label[15];
        Label[] sdtScreen3LabelGroup3 = new Label[15];
        Label[] sdtScreen3LabelGroup4 = new Label[15];
        Label[] sdtScreen3LabelGroup5 = new Label[15];
        Label[] sdtScreen3LabelGroup6 = new Label[15];
        Label[] sdtScreen3LabelGroup7 = new Label[15];
        Label[] sdtScreen3LabelGroup8 = new Label[15];
        Label[] sdtScreen3LabelGroup9 = new Label[15];

        //calculating variables
        List<double[,]> matrixList = new List<double[,]>();

        List<double> massList = new List<double>();
        List<double[]> massCenterPvect = new List<double[]>();
        List<double[,]> MassCenterMatrixList = new List<double[,]>();
        List<double[]> LinearAccelWithG = new List<double[]>();
        List<double[]> massCenterLinearAccel = new List<double[]>();
        List<double[]> Fvect = new List<double[]>();
        List<double[]> Nvect = new List<double[]>();
        List<double[]> maleFvect = new List<double[]>();
        List<double[]> nVectList = new List<double[]>();

        private void InitObjects()
        {
            Font font1 = new Font( arial, 16, FontStyle.Regular);   
            Font font2 = new Font( arial, 12, FontStyle.Bold);

            //drawing
            CreatePictureBox(pb1, 50, 50, 200, 200);
            try
            {
                //pb1.Image = Image.FromFile(folderPath + "podpora_stala.png");

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }


            CreateLabel(newScreenInfoLabel1, 350, 40, win_x/3+20, win_y/3+20, "Podaj ilość par kinematycznych");
            newScreenInfoLabel1.Font = font1;
            CreateLabel(newScreenInfoLabel9, 300, 40, win_x / 3 + 20, win_y / 3 + 70, "Manipulator przestrzenny");
            newScreenInfoLabel9.Font = font1;
            CreateLabel(newScreenInfoLabel10, 50, 30, win_x / 3 + 40, win_y / 3 + 120, "Tak");
            newScreenInfoLabel10.Font = font1;
            CreateLabel(newScreenInfoLabel11, 50, 30, win_x / 3 + 200, win_y / 3 + 120, "Nie");
            newScreenInfoLabel11.Font = font1;

            CreateLabel(newScreenInfoLabel13, 110, 40, win_x/3+15, win_y/3-50, "Lp.");
            newScreenInfoLabel13.Font = font2;
            CreateLabel(newScreenInfoLabel3, 100, 40, win_x / 3 + 100, win_y / 3 - 50, "Klasa 3");
            newScreenInfoLabel3.Font = font2;
            CreateLabel(newScreenInfoLabel4, 100, 40, win_x / 3 + 220, win_y / 3 - 50, "Klasa 4");
            newScreenInfoLabel4.Font = font2;
            CreateLabel(newScreenInfoLabel14, 80, 40, win_x / 3 + 340, win_y / 3 - 50, "Klasa 5");
            newScreenInfoLabel14.Font = font2;

            CreateLabel(newScreen3Label1, 400, 40, win_x/2-200, win_y/2 - 20, "");
            newScreen3Label1.Font = font1;
            CreateTextBox(newScreenTextBox1, 80, 40, win_x / 3 +  + 380, win_y / 3 + 20);
            newScreenTextBox1.Font = font1;  

            CreateButton(nextButton, 100, 50, win_x/2+145, win_y/2+70, "Dalej");
            CreateButton(nextButton2, 100, 50, win_x/2-100, win_y/2+220, "Dalej");
            nextButton.Click += new EventHandler(NextButtonClick);
            nextButton2.Click += new EventHandler(NextButton2Click);

            CreateCheckBox(newScreenCheckBox1, win_x / 3 + 55, win_y / 3 + 150);
            CreateCheckBox(newScreenCheckBox2, win_x / 3 + 215, win_y / 3 + 150);

            //drawing function
            drawingField.Left = 0;
            drawingField.Top = 0;
            drawingField.Width = 800;
            drawingField.Height = 800;
            Controls.Add(drawingField);

            //
            backgroundBox.Visible = false;
            backgroundBox.BackColor = Color.White;
            Controls.Add(backgroundBox);

            //speed screen1
            CreateTextBox(speedScreen1TextBox, 80, 40, win_x / 3 + +380, win_y / 3 + 20);
            speedScreen1TextBox.Font = font1;
            CreateButton(speedScreen1Button1, 100, 50, win_x / 2 + 145, win_y / 2 + 70, "Dalej");
            speedScreen1Button1.Click += new EventHandler(speedScreen1Button1Click);
            CreateLabel(speedScreen1Label, 350, 40, win_x / 3 + 20, win_y / 3 + 20, "Podaj rozmiar tabeli D-H");
            speedScreen1Label.Font = font1;
            CreateLabel(speedScreen2Label, 350, 40, win_x / 3 - 40, win_y / 3 + 20, "Tabela D-H");
            speedScreen2Label.Font = font1;

            CreateLabel(speedScreen2Label5, 120, 40, win_x / 2 + 200, win_y / 2 + 100, "Pokaż poszczególne macierze");
            CreateCheckBox(speedScreen2CheckBox, win_x / 2 + 170, win_y / 2 + 100);

            CreateLabel(speedScreen2Label1, 250, 200, win_x / 2 + 100, win_y / 2 - 100, "α(i-1) - kąt obrotu wokół osi xi-1\n" +
                "ai-1 - przesunięcie wzdłuż osi xi-1\ndi - przesunięcie wzdłuż osi zi\nθi - kąt obrotu wokół osi zi");

            CreateButton(speedScreen2Button1, 100, 50, win_x / 2 + 145, win_y / 2 + 150, "Dalej");
            speedScreen2Button1.Click += new EventHandler(speedScreen2Button1Click);
            CreateLabel(speedScreen2Label2, 100, 20, win_x / 2 + 100, win_y / 2, "Jednostki:");
            CreateLabel(speedScreen2Label3, 100, 20, win_x / 2 + 100, win_y / 2 + 20, "Kąty: °");
            CreateLabel(speedScreen2Label4, 100, 20, win_x / 2 + 100, win_y / 2 + 40, "Długości: m");

            CreateButton(speedScreen2Button2, 100, 50, win_x / 2 + 145, win_y / 2 + 220, "Załaduj dane z pliku");
            speedScreen2Button2.Click += new EventHandler(speedScreen2Button2Click);
            //speed screen 3
            CreateLabel(speedScreen3Label1, 500, 50, win_x / 3, win_y / 3 + 50, "");
            speedScreen3Label1.Font = font1;
            CreateLabel(speedScreen3Label2, 530, 50, win_x / 3, win_y / 3 + 150, "Obliczanie prędkości i przyspieszeń punktów charakterystycznych");
            speedScreen3Label2.Font = font1;

            CreateButton(speedScreen3Button1, 100, 50, win_x / 3, win_y / 3 + 200, "Powrót");
            speedScreen3Button1.Click += new EventHandler(speedScreen3Button1Click);
            CreateButton(speedScreen3Button2, 100, 50, win_x / 3 + 400, win_y / 3 + 200, "Dalej");
            speedScreen3Button2.Click += new EventHandler(speedScreen3Button2Click);

            CreateButton(speedScreen3Button3, 100, 50, win_x / 3 + 400, win_y / 3 + 100, "Pokaż macierz końcową");
            speedScreen3Button3.Click += new EventHandler(przyciskClick);

            //speed screen 4
            CreateLabel(speedScreen4Label1, 400, 50, win_x / 3, win_y / 3 - 120, "Podaj dodatkowe informacje");
            speedScreen4Label1.Font = font1; 
            CreateLabel(speedScreen4Label3, 120, 50, win_x / 3 + 210, win_y / 3 - 70, "Para przesuwna");
            speedScreen4Label3.Font = font1;
            CreateLabel(speedScreen4Label4, 160, 50, win_x / 3 + 30, win_y / 3 - 70, "Prędkość kątowa/liniowa");
            speedScreen4Label4.Font = font1;
            CreateButton(speedScreen4Button1, 100, 50, win_x / 2 +150, win_y / 3 + 200, "Dalej");
            speedScreen4Button1.Click += new EventHandler(speedScreen4Button1Click);

            CreateLabel(speedScreen4Label8, 450, 200, win_x / 3, win_y / 2 + 300, "Podaj wartości prędkości kątowej działającej w danym punkcie" +
                " (uwzględniając znaki). \nPodaj wartość prędkości liniowej jeżeli występuje");

            CreateLabel(speedScreen4Label9, 100, 20, win_x / 2 + 100, win_y / 2 - 100, "Jednostki:");
            CreateLabel(speedScreen4Label10, 150, 20, win_x / 2 + 100, win_y / 2 + 20 - 100, "Prędkość kątowa: m/s");
            CreateLabel(speedScreen4Label11, 150, 20, win_x / 2 + 100, win_y / 2 + 40 - 100, "Prędkość liniowa: m/s");

            //speed screen 5
            CreateLabel(speedScreen5Label1, 400, 50, win_x / 3, win_y / 3 - 120, "Podaj dodatkowe informacje");
            speedScreen5Label1.Font = font1;
            CreateLabel(speedScreen5Label3, 120, 50, win_x / 3 + 210, win_y / 3 - 70, "Para przesuwna");
            speedScreen5Label3.Font = font1;
            CreateLabel(speedScreen5Label4, 160, 50, win_x / 3 + 30, win_y / 3 - 70, "Przyspieszenie kątowe/liniowe");
            speedScreen5Label4.Font = font1;
            CreateButton(speedScreen5Button1, 100, 50, win_x / 2 + 150, win_y / 3 + 200, "Dalej");
            speedScreen5Button1.Click += new EventHandler(speedScreen5Button1Click);

            CreateLabel(speedScreen5Label8, 450, 200, win_x / 3, win_y / 2 + 300, "Podaj wartości przyspieszenia kątowego działającego w danym punkcie" +
                " (uwzględniając znaki). \nPodaj wartość przyspieszenia liniowego jeżeli występuje");

            CreateLabel(speedScreen5Label9, 100, 20, win_x / 2 + 100, win_y / 2 - 100, "Jednostki:");
            CreateLabel(speedScreen5Label10, 150, 20, win_x / 2 + 100, win_y / 2 + 20 - 100, "Przyspieszenie kątowe m/s^2");
            CreateLabel(speedScreen5Label11, 155, 20, win_x / 2 + 100, win_y / 2 + 40 - 100, "Przyspieszenie liniowe m/s^2");

            //speed screen 6
            CreateLabel(speedScreen6Label1, 50, 40, win_x / 3 - 10, win_y / 3 - 65, "Lp");
            speedScreen6Label1.Font = font2;
            CreateLabel(speedScreen6Label2, 420, 40, win_x / 3 + 110, win_y / 3 - 65, "Prędkość");
            speedScreen6Label2.Font = font2;
            CreateLabel(speedScreen6Label3, 200, 40, win_x / 3 + 130 + 140, win_y / 3 - 65, "Przyspieszenie");
            speedScreen6Label3.Font = font2;

            CreateButton(speedScreen6Button1, 100, 50, win_x / 3 - 40, win_y / 3 - 125, "Prędkości kątowe");
            speedScreen6Button1.Click += new EventHandler(speedScreen6Button1Click);
            CreateButton(speedScreen6Button2, 100, 50, win_x / 3 + 80, win_y / 3 - 125, "Przyspieszenia kątowe");
            speedScreen6Button2.Click += new EventHandler(speedScreen6Button2Click);
            CreateButton(speedScreen6Button3, 100, 50, win_x / 3 + 200, win_y / 3 - 125, "Prędkości punktów");
            speedScreen6Button3.Click += new EventHandler(speedScreen6Button3Click);
            CreateButton(speedScreen6Button4, 100, 50, win_x / 3 + 320, win_y / 3 -125, "Przyspieszenia punktów");
            speedScreen6Button4.Click += new EventHandler(speedScreen6Button4Click);
            CreateButton(speedScreen6Button5, 100, 50, win_x / 3 + 440, win_y / 3 -125, "Wartości");
            speedScreen6Button5.Click += new EventHandler(speedScreen6Button5Click);

            CreateButton(speedScreen6Button6, 100, 50, win_x / 2 + 150, win_y / 2 + 350, "Dalej");
            speedScreen6Button6.Click += new EventHandler(speedScreen6Button6Click);
            CreateButton(speedScreen6Button7, 100, 50, win_x / 2 - 250, win_y / 2 + 350, "Powrót");
            speedScreen6Button7.Click += new EventHandler(speedScreen6Button7Click);

            //2DT
            CreateButton(sdtScreen1Button1, 100, 50, win_x / 2 - 250, win_y / 2 + 350, "Dalej");
            sdtScreen1Button1.Click += new EventHandler(sdtScreen1Button1Click);
            CreateLabel(sdtScreen1Label1, 50, 40, win_x / 3 - 10, win_y / 3 - 65, "Lp");
            sdtScreen1Label1.Font = font2;
            CreateLabel(sdtScreen1Label3, 300, 70, win_x / 3 - 10, win_y / 3- 120, "Podaj masy poszczególnych członów\nJeżeli masa nie występuje wpisz 0"); ;
            sdtScreen1Label3.Font = font2;
            CreateLabel(sdtScreen1Label2, 420, 40, win_x / 3 + 50, win_y / 3 - 65, "Masa członu");
            sdtScreen1Label2.Font = font2;

            //FDT
            CreateButton(fdtButton1, 100, 50, win_x / 3 + 200, win_y / 3 + 200, "Kolejna macierz");
            CreateButton(fdtButton2, 100, 50, win_x / 3 + 200, win_y / 3 + 260, "Koniec");

        }
        void CreateButton(Button obj, int width, int height, int pos_x, int pos_y, string text)
        {
            obj.Width = width;
            obj.Height = height;
            obj.Left = pos_x;
            obj.Top = pos_y;
            obj.Visible = false;
            obj.Text = text;
            Controls.Add(obj);
        }
        private void CreateLinkLabel(LinkLabel obj, int pos_x, int pos_y)
        {
            obj.Left = pos_x;
            obj.Top = pos_y;
            obj.Visible = false;
            Controls.Add(obj);
        }
        private void CreateCheckBox(CheckBox obj, int pos_x, int pos_y)
        {
            obj.Width = 30;
            obj.Height = 30;
            obj.Left = pos_x;
            obj.Top = pos_y;
            obj.Visible = false;
            Controls.Add(obj);
            obj.BackColor = Color.White;
        }
        private void CreateTextBox(TextBox obj, int width, int height, int pos_x, int pos_y)
        {
            obj.Width = width;
            obj.Height = height;
            obj.Left = pos_x;
            obj.Top = pos_y;
            obj.Visible = false;
            obj.BringToFront();
            Controls.Add(obj);
        }
        private void CreateLabel(Label obj, int width, int height, int pos_x, int pos_y, string text)
        {
            obj.Width = width;
            obj.Height = height;
            obj.Left = pos_x;
            obj.Top = pos_y;
            obj.Visible = false;
            obj.Text = text;
            obj.BackColor = Color.White;
            Controls.Add(obj);
        }
        private void CreatePictureBox(PictureBox obj, int width, int height, int pos_x, int pos_y)
        {
            obj.Width = width;
            obj.Height = height;
            obj.Left = pos_x;
            obj.Top = pos_y;
            obj.Visible = false;
            obj.BackColor = Color.White;
            obj.SizeMode = PictureBoxSizeMode.StretchImage;
            
            Controls.Add(obj);
        }
        private void CreateMobilityScreen()
        {
            int labelStarting_pos_x = win_x/3+20;
            int labelStarting_pos_y = win_y/3;

            int textBoxGap = 20;
            int textBoxHeight = 30;

            for (int i = 0; i < size; i++)
            {
                newScreenLabelGroup[i] = new Label();
                newScreenLabelGroup[i].Left = labelStarting_pos_x;
                newScreenLabelGroup[i].Top = labelStarting_pos_y + (i * (textBoxGap + textBoxHeight));
                newScreenLabelGroup[i].Width = 25;
                newScreenLabelGroup[i].Height = 25;
                newScreenLabelGroup[i].Font = new Font(arial, 12);
                newScreenLabelGroup[i].BackColor = Color.White; 
                Controls.Add(newScreenLabelGroup[i]);
            }
            for (int i = 0; i < size; i++)
            {
                newScreenLabelGroup[i].Text = i.ToString();
            }

            int CBpos_x, CBpos_y;
            int CBstartingPosX = win_x  /3 + 120, CBstartingPosY = win_y / 3;
            int CBsize = 0;

            for (int j = 0; j < 3; j++)
            {
                for (int i = 0; i < size; i++)
                {
                    CBpos_x = CBstartingPosX + (j * 120);    //gaps between
                    CBpos_y = CBstartingPosY + (i * 50);
                    mobilityScreenCheckBoxGroup[CBsize] = new CheckBox();
                    mobilityScreenCheckBoxGroup[CBsize].Left = CBpos_x;
                    mobilityScreenCheckBoxGroup[CBsize].Top = CBpos_y;
                    mobilityScreenCheckBoxGroup[CBsize].Width = 30;
                    mobilityScreenCheckBoxGroup[CBsize].BackColor = Color.White;    
                    Controls.Add(mobilityScreenCheckBoxGroup[CBsize]);
                    CBsize++;
                }
            }

            mobilityScreen2Created = true;
           
        }
        private void CreateBackgroundPictureBox(int width, int height, int x, int y)
        {
            backgroundBox.Visible = false;
            backgroundBox.Width = width;
            backgroundBox.Height= height;
            backgroundBox.Left = x;
            backgroundBox.Top = y;
            backgroundBox.BorderStyle = BorderStyle.FixedSingle;
            backgroundBox.SendToBack();

        }
        private void CreateSpeedScreen4()
        {
            //text boxes
            int Tpos_x, Tpos_y;
            int TstartingPosX = win_x / 3 + 70, TstartingPosY = win_y / 3;
            int textBoxWidth = 60;
            int textBoxHeight = 30;

            speedScreen4Button1.Top = TstartingPosY + 20 + size * 40;
            speedScreen4Label5.Top = TstartingPosY + size * 40;
            speedScreen4Label6.Top = TstartingPosY + size * 40 + 50;
            speedScreen4Label7.Top = TstartingPosY + size * 40 + 50;
            speedScreen4CheckBox1.Top = TstartingPosY + size * 40 + 100;
            speedScreen4CheckBox2.Top = TstartingPosY + size * 40 + 100;


            for (int i = 0; i < size; i++)
            {
                Tpos_x = TstartingPosX;
                Tpos_y = TstartingPosY + (i * 40);
                speedScreen4TextBoxGroup[i] = new TextBox();
                speedScreen4TextBoxGroup[i].Width = textBoxWidth;
                speedScreen4TextBoxGroup[i].Height = textBoxHeight;
                speedScreen4TextBoxGroup[i].Left = Tpos_x;
                speedScreen4TextBoxGroup[i].Top = Tpos_y;
                speedScreen4TextBoxGroup[i].Text = "";
                speedScreen4TextBoxGroup[i].Visible = false;
                speedScreen4TextBoxGroup[i].BorderStyle = BorderStyle.FixedSingle;
                Controls.Add(speedScreen4TextBoxGroup[i]);
                speedScreen4TextBoxGroup[i].BringToFront(); 
            }
            //iterate labels
            int labelStarting_pos_x = win_x / 3;
            int labelStarting_pos_y = win_y / 3;

            Font font = new Font(arial, 12, FontStyle.Bold);

            for (int i = 0; i < size; i++)
            {
                speedScreen4LabelGroup[i] = new Label();
                speedScreen4LabelGroup[i].Left = labelStarting_pos_x;
                speedScreen4LabelGroup[i].Top = labelStarting_pos_y + (i * 40);
                speedScreen4LabelGroup[i].Width = 25;
                speedScreen4LabelGroup[i].Height = 25;
                speedScreen4LabelGroup[i].Visible = false;
                speedScreen4LabelGroup[i].BackColor = Color.White;
                Controls.Add(speedScreen4LabelGroup[i]);
                speedScreen4LabelGroup[i].BringToFront();
                speedScreen4LabelGroup[i].Font = font;
            }

            for (int i = 0; i < size; i++)
            {
                speedScreen4LabelGroup[i].Text = i.ToString();
            }

            //check boxes
            int CBpos_y;
            int CBstartingPosX = win_x / 3 + 230, CBstartingPosY = win_y / 3 - 5;
            int CBWidth = 30;
            int CBHeight = 30;
            int CBsize = 0;

            for (int i = 0; i < size; i++)
            {

                CBpos_y = CBstartingPosY + (i * 40);
                speedScreen4CheckBoxGroup[CBsize] = new CheckBox();
                speedScreen4CheckBoxGroup[CBsize].Width = CBWidth;
                speedScreen4CheckBoxGroup[CBsize].Height = CBHeight;
                speedScreen4CheckBoxGroup[CBsize].Left = CBstartingPosX;
                speedScreen4CheckBoxGroup[CBsize].Top = CBpos_y;
                speedScreen4CheckBoxGroup[CBsize].Visible = false;
                speedScreen4CheckBoxGroup[CBsize].BackColor = Color.White;
                Controls.Add(speedScreen4CheckBoxGroup[CBsize]);
                speedScreen4CheckBoxGroup[CBsize].BringToFront();

                CBsize++;
            }

            speedScreen4CheckBoxGroupCreated = true;
        }
        private void CreateSpeedScreen5()
        {
            //text boxes
            int Tpos_x, Tpos_y;
            int TstartingPosX = win_x / 3 + 70, TstartingPosY = win_y / 3;
            int textBoxWidth = 60;
            int textBoxHeight = 30;

            speedScreen5Button1.Top = TstartingPosY + 20 + size * 40;
            speedScreen5Label5.Top = TstartingPosY + size * 40;
            speedScreen5Label6.Top = TstartingPosY + size * 40 + 50;
            speedScreen5Label7.Top = TstartingPosY + size * 40 + 50;
            speedScreen5CheckBox1.Top = TstartingPosY + size * 40 + 100;
            speedScreen5CheckBox2.Top = TstartingPosY + size * 40 + 100;


            for (int i = 0; i < size; i++)
            {
                Tpos_x = TstartingPosX;
                Tpos_y = TstartingPosY + (i * 40);
                speedScreen5TextBoxGroup[i] = new TextBox();
                speedScreen5TextBoxGroup[i].Width = textBoxWidth;
                speedScreen5TextBoxGroup[i].Height = textBoxHeight;
                speedScreen5TextBoxGroup[i].Left = Tpos_x;
                speedScreen5TextBoxGroup[i].Top = Tpos_y;
                speedScreen5TextBoxGroup[i].Text = "";
                speedScreen5TextBoxGroup[i].Visible = false;
                speedScreen5TextBoxGroup[i].BorderStyle = BorderStyle.FixedSingle;
                Controls.Add(speedScreen5TextBoxGroup[i]);
                speedScreen5TextBoxGroup[i].BringToFront();
            }
            //iterate labels
            int labelStarting_pos_x = win_x / 3;
            int labelStarting_pos_y = win_y / 3;

            Font font = new Font(arial, 12, FontStyle.Bold);

            for (int i = 0; i < size; i++)
            {
                speedScreen5LabelGroup[i] = new Label();
                speedScreen5LabelGroup[i].Left = labelStarting_pos_x;
                speedScreen5LabelGroup[i].Top = labelStarting_pos_y + (i * 40);
                speedScreen5LabelGroup[i].Width = 25;
                speedScreen5LabelGroup[i].Height = 25;
                speedScreen5LabelGroup[i].Visible = false;
                speedScreen5LabelGroup[i].BackColor = Color.White;
                Controls.Add(speedScreen5LabelGroup[i]);
                speedScreen5LabelGroup[i].BringToFront();
                speedScreen5LabelGroup[i].Font = font;
            }

            for (int i = 0; i < size; i++)
            {
                speedScreen5LabelGroup[i].Text = i.ToString();
            }

            //check boxes
            int CBpos_y;
            int CBstartingPosX = win_x / 3 + 230, CBstartingPosY = win_y / 3 - 5;
            int CBWidth = 30;
            int CBHeight = 30;
            int CBsize = 0;

            for (int i = 0; i < size; i++)
            {

                CBpos_y = CBstartingPosY + (i * 40);
                speedScreen5CheckBoxGroup[CBsize] = new CheckBox();
                speedScreen5CheckBoxGroup[CBsize].Width = CBWidth;
                speedScreen5CheckBoxGroup[CBsize].Height = CBHeight;
                speedScreen5CheckBoxGroup[CBsize].Left = CBstartingPosX;
                speedScreen5CheckBoxGroup[CBsize].Top = CBpos_y;
                speedScreen5CheckBoxGroup[CBsize].Visible = false;
                speedScreen5CheckBoxGroup[CBsize].BackColor = Color.White;
                Controls.Add(speedScreen5CheckBoxGroup[CBsize]);
                speedScreen5CheckBoxGroup[CBsize].BringToFront();

                CBsize++;
            }

            speedScreen5CheckBoxGroupCreated = true;
        }
        private void CreateSpeedScreen6()
        {
            int labelStarting_pos_x_2 = win_x / 3 + 150;
            int labelStarting_pos_y_2 = win_y / 3;

            Font font = new Font(arial, 12, FontStyle.Bold);
            int Lsize = 0;

            for (int j = 0; j < 2; j++)
            {
                for (int i = 0; i < size + 1; i++)
                {
                    speedScreen6LabelGroup[Lsize] = new Label();
                    speedScreen6LabelGroup[Lsize].Left = labelStarting_pos_x_2 + (j * 160);
                    speedScreen6LabelGroup[Lsize].Top = labelStarting_pos_y_2 + (i * 60);
                    speedScreen6LabelGroup[Lsize].Width = 230;
                    speedScreen6LabelGroup[Lsize].Height = 50;
                    speedScreen6LabelGroup[Lsize].BackColor = Color.White;
                    Controls.Add(speedScreen6LabelGroup[Lsize]);
                    speedScreen6LabelGroup[Lsize].BringToFront();
                    speedScreen6LabelGroup[Lsize].Font = font;
                    speedScreen6LabelGroup[Lsize].Visible = false;
                    Lsize++;
                }
            }

            int labelStarting_pos_x = win_x / 3;
            int labelStarting_pos_y = win_y / 3;

            for (int i = 0; i < size + 1; i++)
            {
                speedScreen6LabelGroup2[i] = new Label();
                speedScreen6LabelGroup2[i].Left = labelStarting_pos_x;
                speedScreen6LabelGroup2[i].Top = labelStarting_pos_y + (i * 60);
                speedScreen6LabelGroup2[i].Width = 25;
                speedScreen6LabelGroup2[i].Height = 25;
                speedScreen6LabelGroup2[i].BackColor = Color.White;
                Controls.Add(speedScreen6LabelGroup2[i]);
                speedScreen6LabelGroup2[i].BringToFront();
                speedScreen6LabelGroup2[i].Font = font;
                speedScreen6LabelGroup2[i].Visible = false;
                speedScreen6LabelGroup2[i].Text = (i).ToString();
            }
            Lsize = 0;
            for (int i = 0; i < size; i++)
            {
                speedScreen6LabelGroup1[Lsize] = new Label();
                speedScreen6LabelGroup1[Lsize].Left = labelStarting_pos_x_2;
                speedScreen6LabelGroup1[Lsize].Top = labelStarting_pos_y_2 + (i * 60);
                speedScreen6LabelGroup1[Lsize].Width = 230;
                speedScreen6LabelGroup1[Lsize].Height = 50;
                speedScreen6LabelGroup1[Lsize].BackColor = Color.White;
                Controls.Add(speedScreen6LabelGroup1[Lsize]);
                speedScreen6LabelGroup1[Lsize].BringToFront();
                speedScreen6LabelGroup1[Lsize].Font = font;
                speedScreen6LabelGroup1[Lsize].Visible = false;
                Lsize++;
            }
            Lsize = 0;
            for (int i = 0; i < size; i++)
            {
                speedScreen6LabelGroup3[Lsize] = new Label();
                speedScreen6LabelGroup3[Lsize].Left = labelStarting_pos_x_2;
                speedScreen6LabelGroup3[Lsize].Top = labelStarting_pos_y_2 + (i * 60);
                speedScreen6LabelGroup3[Lsize].Width = 230;
                speedScreen6LabelGroup3[Lsize].Height = 50;
                speedScreen6LabelGroup3[Lsize].BackColor = Color.White;
                Controls.Add(speedScreen6LabelGroup3[Lsize]);
                speedScreen6LabelGroup3[Lsize].BringToFront();
                speedScreen6LabelGroup3[Lsize].Font = font;
                speedScreen6LabelGroup3[Lsize].Visible = false;
                Lsize++;
            }
            Lsize = 0;
            for (int i = 0; i < size + 1; i++)
            {
                speedScreen6LabelGroup4[Lsize] = new Label();
                speedScreen6LabelGroup4[Lsize].Left = labelStarting_pos_x_2;
                speedScreen6LabelGroup4[Lsize].Top = labelStarting_pos_y_2 + (i * 60);
                speedScreen6LabelGroup4[Lsize].Width = 230;
                speedScreen6LabelGroup4[Lsize].Height = 50;
                speedScreen6LabelGroup4[Lsize].BackColor = Color.White;
                Controls.Add(speedScreen6LabelGroup4[Lsize]);
                speedScreen6LabelGroup4[Lsize].BringToFront();
                speedScreen6LabelGroup4[Lsize].Font = font;
                speedScreen6LabelGroup4[Lsize].Visible = false;
                Lsize++;
            }
            Lsize = 0;
            for (int i = 0; i < size + 1; i++)
            {
                speedScreen6LabelGroup5[Lsize] = new Label();
                speedScreen6LabelGroup5[Lsize].Left = labelStarting_pos_x_2;
                speedScreen6LabelGroup5[Lsize].Top = labelStarting_pos_y_2 + (i * 60);
                speedScreen6LabelGroup5[Lsize].Width = 230;
                speedScreen6LabelGroup5[Lsize].Height = 50;
                speedScreen6LabelGroup5[Lsize].BackColor = Color.White;
                Controls.Add(speedScreen6LabelGroup5[Lsize]);
                speedScreen6LabelGroup5[Lsize].BringToFront();
                speedScreen6LabelGroup5[Lsize].Font = font;
                speedScreen6LabelGroup5[Lsize].Visible = false;
                Lsize++;
            }
            speedScreen6LabelGroupCreated = true;
        }
        private void CreateSDTScreen1()
        {
            //text boxes
            int Tpos_x, Tpos_y;
            int TstartingPosX = win_x / 3 + 70, TstartingPosY = win_y / 3;
            int textBoxWidth = 60;
            int textBoxHeight = 30;

            sdtScreen1Button1.Top = TstartingPosY + 20 + size * 40;


            for (int i = 0; i < size; i++)
            {
                Tpos_x = TstartingPosX;
                Tpos_y = TstartingPosY + (i * 40);
                sdtScreen1TextBoxGroup1[i] = new TextBox();
                sdtScreen1TextBoxGroup1[i].Width = textBoxWidth;
                sdtScreen1TextBoxGroup1[i].Height = textBoxHeight;
                sdtScreen1TextBoxGroup1[i].Left = Tpos_x;
                sdtScreen1TextBoxGroup1[i].Top = Tpos_y;
                sdtScreen1TextBoxGroup1[i].Text = "";
                sdtScreen1TextBoxGroup1[i].Visible = false;
                sdtScreen1TextBoxGroup1[i].BorderStyle = BorderStyle.FixedSingle;
                Controls.Add(sdtScreen1TextBoxGroup1[i]);
                sdtScreen1TextBoxGroup1[i].BringToFront();
            }
            //iterate labels
            int labelStarting_pos_x = win_x / 3;
            int labelStarting_pos_y = win_y / 3;

            Font font = new Font(arial, 12, FontStyle.Bold);

            for (int i = 0; i < size; i++)
            {
                sdtScreen1LabelGroup1[i] = new Label();
                sdtScreen1LabelGroup1[i].Left = labelStarting_pos_x;
                sdtScreen1LabelGroup1[i].Top = labelStarting_pos_y + (i * 40);
                sdtScreen1LabelGroup1[i].Width = 25;
                sdtScreen1LabelGroup1[i].Height = 25;
                sdtScreen1LabelGroup1[i].Visible = false;
                sdtScreen1LabelGroup1[i].BackColor = Color.White;
                Controls.Add(sdtScreen1LabelGroup1[i]);
                sdtScreen1LabelGroup1[i].BringToFront();
                sdtScreen1LabelGroup1[i].Font = font;
            }

            for (int i = 0; i < size; i++)
            {
                sdtScreen1LabelGroup1[i].Text = i.ToString();
            }
        }
        private void CreateSDTScreen2()
        {
            Font font = new Font(arial, 12, FontStyle.Bold);

            //iterate labels
            int labelStarting_pos_x = win_x / 3;
            int labelStarting_pos_y = win_y / 3;

            for (int i = 0; i < size + 1; i++)
            {
                sdtScreen3LabelGroup[i] = new Label();
                sdtScreen3LabelGroup[i].Left = labelStarting_pos_x;
                sdtScreen3LabelGroup[i].Top = labelStarting_pos_y + (i * 60);
                sdtScreen3LabelGroup[i].Width = 25;
                sdtScreen3LabelGroup[i].Height = 25;
                sdtScreen3LabelGroup[i].BackColor = Color.White;
                Controls.Add(sdtScreen3LabelGroup[i]);
                sdtScreen3LabelGroup[i].BringToFront();
                sdtScreen3LabelGroup[i].Font = font;
                sdtScreen3LabelGroup[i].Visible = false;
                sdtScreen3LabelGroup[i].Text = (i).ToString();

            }
            int buttonStartingPosX = win_x / 3 - 20;
            int buttonStartingPosY = 110;

            int buttonSize = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    sdtScreen3ButtonGroup[buttonSize] = new Button();
                    sdtScreen3ButtonGroup[buttonSize].Width = 100;
                    sdtScreen3ButtonGroup[buttonSize].Height = 50;
                    sdtScreen3ButtonGroup[buttonSize].Left = buttonStartingPosX + (i * 110);
                    sdtScreen3ButtonGroup[buttonSize].Top = buttonStartingPosY + (j * 60);
                    sdtScreen3ButtonGroup[buttonSize].BringToFront();
                    sdtScreen3ButtonGroup[buttonSize].Visible = false;
                    Controls.Add(sdtScreen3ButtonGroup[buttonSize]);    
                    buttonSize++;
                }
                    
            }
            sdtScreen3ButtonGroup[0].Text = "Wektory przemieszczeń środków masy";
            sdtScreen3ButtonGroup[1].Text = "Przyspieszenie liniowe z uwzględnieniem przyspieszenia ziemskiego";
            sdtScreen3ButtonGroup[2].Text = "Przyspieszenie liniowe środków ciężkości";
            sdtScreen3ButtonGroup[3].Text = "Siły bezwładności względem środka masy członu";
            sdtScreen3ButtonGroup[4].Text = "Momenty sił względem środka masy członu";
            sdtScreen3ButtonGroup[5].Text = "Siły oddziaływania członów";
            sdtScreen3ButtonGroup[6].Text = "Momenty sił oddziaływania członów";
            sdtScreen3ButtonGroup[7].Text = "Siły napędowe";
            sdtScreen3ButtonGroup[8].Text = "Momenty napędowe";
            sdtScreen3ButtonGroup[9].Text = "Powrót";

            sdtScreen3ButtonGroup[0].Click += new EventHandler(sdtScreen3ButtonGroupB0Click);
            sdtScreen3ButtonGroup[1].Click += new EventHandler(sdtScreen3ButtonGroupB1Click);
            sdtScreen3ButtonGroup[2].Click += new EventHandler(sdtScreen3ButtonGroupB2Click);
            sdtScreen3ButtonGroup[3].Click += new EventHandler(sdtScreen3ButtonGroupB3Click);
            sdtScreen3ButtonGroup[4].Click += new EventHandler(sdtScreen3ButtonGroupB4Click);
            sdtScreen3ButtonGroup[5].Click += new EventHandler(sdtScreen3ButtonGroupB5Click);
            sdtScreen3ButtonGroup[6].Click += new EventHandler(sdtScreen3ButtonGroupB6Click);
            sdtScreen3ButtonGroup[7].Click += new EventHandler(sdtScreen3ButtonGroupB7Click);
            sdtScreen3ButtonGroup[8].Click += new EventHandler(sdtScreen3ButtonGroupB8Click);
            sdtScreen3ButtonGroup[9].Click += new EventHandler(sdtScreen3ButtonGroupB9Click);

            CreateLabelGroup(sdtScreen3LabelGroup1, size, labelStarting_pos_x, labelStarting_pos_y);
            CreateLabelGroup(sdtScreen3LabelGroup2, size + 1, labelStarting_pos_x, labelStarting_pos_y);
            CreateLabelGroup(sdtScreen3LabelGroup3, size, labelStarting_pos_x, labelStarting_pos_y);
            CreateLabelGroup(sdtScreen3LabelGroup4, size, labelStarting_pos_x, labelStarting_pos_y);
            CreateLabelGroup(sdtScreen3LabelGroup5, size, labelStarting_pos_x, labelStarting_pos_y);
            CreateLabelGroup(sdtScreen3LabelGroup6, size + 1, labelStarting_pos_x, labelStarting_pos_y);
            CreateLabelGroup(sdtScreen3LabelGroup7, size + 1, labelStarting_pos_x, labelStarting_pos_y);
            CreateLabelGroup(sdtScreen3LabelGroup8, size + 1, labelStarting_pos_x, labelStarting_pos_y);
            CreateLabelGroup(sdtScreen3LabelGroup9, size + 1, labelStarting_pos_x, labelStarting_pos_y);


            sdtScreen2Created = true;
        }
        private void CreateLabelGroup(Label[] labels, int s, int pos_x, int pos_y)
        {
            Font font = new Font(arial, 12, FontStyle.Bold);

            for (int i = 0; i < s; i++)
            {
                labels[i] = new Label();
                labels[i].Left = pos_x + 100;
                labels[i].Top = pos_y + (i * 60);
                labels[i].Width = 300;
                labels[i].Height = 50;
                labels[i].BackColor = Color.White;
                Controls.Add(labels[i]);
                labels[i].BringToFront();
                labels[i].Font = font;
                labels[i].Visible = false;
            }
        }
        private void SendToLabel(List<double[]> dataList, Label[] labelGroup)
        {
            for (int i = 0; i < dataList.Count; i++)
            {
                labelGroup[i].Text = "";
                double[] v = dataList[i];
                for (int j = 0; j < 3; j++)
                {
                    string s = ChangeSep(v[j].ToString());
                    string new_s = "";
                    bool sep = false;
                    int var1 = 0;
                    for (int x = 0; x < s.Length; x++)
                    {
                        if (s[x] == ',')
                        {
                            sep = true;
                        }

                        if (sep == true)
                        {
                            var1++;
                        }

                        if (var1 <= 5 || sep == false)
                        {
                            new_s += s[x];
                        }

                    }

                    if (j == 0)
                    {
                        labelGroup[i].Text += "[" + new_s;
                    }
                    else if (j == 1)
                    {
                        labelGroup[i].Text += " " + new_s;
                    }
                    else if (j == 2)
                    {
                        labelGroup[i].Text += " " + new_s + "]";
                    }
                }

            }
        }
        private void sdtScreen3ButtonGroupB0Click(object sender, EventArgs e)
        {
            for (int i = 0; i < size + 1; i++)
            {
                sdtScreen3LabelGroup[i].Visible = false;
                sdtScreen3LabelGroup2[i].Visible = false;
                sdtScreen3LabelGroup6[i].Visible = false;
                sdtScreen3LabelGroup7[i].Visible = false;
            }
            for (int i = 0; i < size; i++)
            {
                sdtScreen3LabelGroup[i].Visible = true;
                sdtScreen3LabelGroup1[i].Visible = true;
                sdtScreen3LabelGroup3[i].Visible = false;
                sdtScreen3LabelGroup4[i].Visible = false;
                sdtScreen3LabelGroup5[i].Visible = false;
                sdtScreen3LabelGroup8[i].Visible = false;
                sdtScreen3LabelGroup9[i].Visible = false;
            }
        }
        private void sdtScreen3ButtonGroupB1Click(object sender, EventArgs e)
        {
            for (int i = 0; i < size + 1; i++)
            {
                sdtScreen3LabelGroup[i].Visible = true;
                sdtScreen3LabelGroup2[i].Visible = true;
                sdtScreen3LabelGroup6[i].Visible = false;
                sdtScreen3LabelGroup7[i].Visible = false;
            }
            for (int i = 0; i < size; i++)
            {
                sdtScreen3LabelGroup1[i].Visible = false;
                sdtScreen3LabelGroup3[i].Visible = false;
                sdtScreen3LabelGroup4[i].Visible = false;
                sdtScreen3LabelGroup5[i].Visible = false;
                sdtScreen3LabelGroup8[i].Visible = false;
                sdtScreen3LabelGroup9[i].Visible = false;
            }
        }
        private void sdtScreen3ButtonGroupB2Click(object sender, EventArgs e)
        {
            for (int i = 0; i < size + 1; i++)
            {
                sdtScreen3LabelGroup[i].Visible = false;
                sdtScreen3LabelGroup2[i].Visible = false;
                sdtScreen3LabelGroup6[i].Visible = false;
                sdtScreen3LabelGroup7[i].Visible = false;
            }
            for (int i = 0; i < size; i++)
            {
                sdtScreen3LabelGroup[i].Visible = true;
                sdtScreen3LabelGroup1[i].Visible = false;
                sdtScreen3LabelGroup3[i].Visible = true;
                sdtScreen3LabelGroup4[i].Visible = false;
                sdtScreen3LabelGroup5[i].Visible = false;
                sdtScreen3LabelGroup8[i].Visible = false;
                sdtScreen3LabelGroup9[i].Visible = false;
            }
        }
        private void sdtScreen3ButtonGroupB3Click(object sender, EventArgs e)
        {
            for (int i = 0; i < size + 1; i++)
            {
                sdtScreen3LabelGroup[i].Visible = false;
                sdtScreen3LabelGroup2[i].Visible = false;
                sdtScreen3LabelGroup6[i].Visible = false;
                sdtScreen3LabelGroup7[i].Visible = false;
            }
            for (int i = 0; i < size; i++)
            {
                sdtScreen3LabelGroup[i].Visible = true;
                sdtScreen3LabelGroup1[i].Visible = false;
                sdtScreen3LabelGroup3[i].Visible = false;
                sdtScreen3LabelGroup4[i].Visible = true;
                sdtScreen3LabelGroup5[i].Visible = false;
                sdtScreen3LabelGroup8[i].Visible = false;
                sdtScreen3LabelGroup9[i].Visible = false;

            }
        }
        private void sdtScreen3ButtonGroupB4Click(object sender, EventArgs e)
        {
            for (int i = 0; i < size + 1; i++)
            {
                sdtScreen3LabelGroup[i].Visible = false;
                sdtScreen3LabelGroup2[i].Visible = false;
                sdtScreen3LabelGroup6[i].Visible = false;
                sdtScreen3LabelGroup7[i].Visible = false;
            }
            for (int i = 0; i < size; i++)
            {
                sdtScreen3LabelGroup[i].Visible = true;
                sdtScreen3LabelGroup1[i].Visible = false;
                sdtScreen3LabelGroup3[i].Visible = false;
                sdtScreen3LabelGroup4[i].Visible = false;
                sdtScreen3LabelGroup5[i].Visible = true;
                sdtScreen3LabelGroup8[i].Visible = false;
                sdtScreen3LabelGroup9[i].Visible = false;

            }
        }
        private void sdtScreen3ButtonGroupB5Click(object sender, EventArgs e)
        {
            for (int i = 0; i < size + 1; i++)
            {
                sdtScreen3LabelGroup[i].Visible = true;
                sdtScreen3LabelGroup2[i].Visible = false;
                sdtScreen3LabelGroup6[i].Visible = true;
                sdtScreen3LabelGroup7[i].Visible = false;
            }
            for (int i = 0; i < size; i++)
            {
                sdtScreen3LabelGroup1[i].Visible = false;
                sdtScreen3LabelGroup3[i].Visible = false;
                sdtScreen3LabelGroup4[i].Visible = false;
                sdtScreen3LabelGroup5[i].Visible = false;
                sdtScreen3LabelGroup8[i].Visible = false;
                sdtScreen3LabelGroup9[i].Visible = false;
            }
        }
        private void sdtScreen3ButtonGroupB6Click(object sender, EventArgs e)
        {
            for (int i = 0; i < size + 1; i++)
            {
                sdtScreen3LabelGroup[i].Visible = true;
                sdtScreen3LabelGroup2[i].Visible = false;
                sdtScreen3LabelGroup6[i].Visible = false;
                sdtScreen3LabelGroup7[i].Visible = true;
            }
            for (int i = 0; i < size; i++)
            {
                sdtScreen3LabelGroup1[i].Visible = false;
                sdtScreen3LabelGroup3[i].Visible = false;
                sdtScreen3LabelGroup4[i].Visible = false;
                sdtScreen3LabelGroup5[i].Visible = false;
                sdtScreen3LabelGroup8[i].Visible = false;
                sdtScreen3LabelGroup9[i].Visible = false;
            }
        }
        private void sdtScreen3ButtonGroupB7Click(object sender, EventArgs e)
        {
            for (int i = 0; i < size + 1; i++)
            {
                sdtScreen3LabelGroup[i].Visible = false;
                sdtScreen3LabelGroup2[i].Visible = false;
                sdtScreen3LabelGroup6[i].Visible = false;
                sdtScreen3LabelGroup7[i].Visible = false;
            }
            for (int i = 0; i < size; i++)
            {
                sdtScreen3LabelGroup[i].Visible = true;
                sdtScreen3LabelGroup1[i].Visible = false;
                sdtScreen3LabelGroup3[i].Visible = false;
                sdtScreen3LabelGroup4[i].Visible = false;
                sdtScreen3LabelGroup5[i].Visible = false;
                sdtScreen3LabelGroup8[i].Visible = true;
                sdtScreen3LabelGroup9[i].Visible = false;
            }
        }
        private void sdtScreen3ButtonGroupB8Click(object sender, EventArgs e)
        {
            for (int i = 0; i < size + 1; i++)
            {
                sdtScreen3LabelGroup[i].Visible = false;
                sdtScreen3LabelGroup2[i].Visible = false;
                sdtScreen3LabelGroup6[i].Visible = false;
                sdtScreen3LabelGroup7[i].Visible = false;
            }
            for (int i = 0; i < size; i++)
            {
                sdtScreen3LabelGroup[i].Visible = true;
                sdtScreen3LabelGroup1[i].Visible = false;
                sdtScreen3LabelGroup3[i].Visible = false;
                sdtScreen3LabelGroup4[i].Visible = false;
                sdtScreen3LabelGroup5[i].Visible = false;
                sdtScreen3LabelGroup8[i].Visible = false;
                sdtScreen3LabelGroup9[i].Visible = true;
            }
        }
        private void sdtScreen3ButtonGroupB9Click(object sender, EventArgs e)
        {
            StartingScreen(true);
            MobilityScreen1(false);
            MobilityScreen2(false);
            MobilityScreen3(false);
            SpeedScreen1(false);
            SpeedScreen2(false);
            SpeedScreen3(false);
            SpeedScreen4(false);
            SpeedScreen5(false);
            SpeedScreen6(false);
            SDTScreen1(false);
            SDTScreen2(false);
        }
        //funkcja tworząca macierze T
        private double[,] CreateMatrixT(double tabCol1, double tabCol2, double tabCol3, double tabCol4)
        {
            //tabCol1 - kolumna pierwsza z tabeli D-H
            //tabCol2 - kolumna druga z tabeli D-H
            //tabCol3 - kolumna trzecia z tabeli D-H
            //tabCol4 - kolumna czwarta z tabeli D-H

            double[,] matrix = new double[4, 4];


            //zabezpieczenia 
            if(tabCol4 == Rad(90) || tabCol4 == -Rad(90)) //cos 90 = 0
            {
                matrix[0, 0] = 0;
                matrix[1, 1] = 0;
                matrix[1, 2] = 0;
            }
            else
            {
                matrix[0, 0] = Math.Cos(tabCol4);
                matrix[1, 1] = Math.Cos(tabCol4) * Math.Cos(tabCol1);
                matrix[1, 2] = Math.Cos(tabCol4) * Math.Sin(tabCol1);
            }

            if (tabCol1 == Rad(90) || tabCol1 == -Rad(90)) //cos 90 = 0
            {
                matrix[0, 1] = 0;
                matrix[2, 2] = 0;
                matrix[3, 2] = 0;
                matrix[1, 1] = 0;
            }
            else
            {
                matrix[0, 1] = Math.Sin(tabCol4) * Math.Cos(tabCol1); 
                matrix[2, 2] = Math.Cos(tabCol1);
                matrix[3, 2] = tabCol3 * Math.Cos(tabCol1);
            }

            if (tabCol4 == 0) //sin 0 = 0
            {
                matrix[1, 0] = 0;
                matrix[0, 2] = 0;
            }
            else
            {
                matrix[1, 0] = -Math.Sin(tabCol4);
                matrix[0, 2] = Math.Sin(tabCol4) * Math.Sin(tabCol1);
            }

            if (tabCol1 == 0) //sin 0 = 0
            {
                matrix[2, 1] = 0;
                matrix[3, 1] = 0;
            }
            else
            {
                matrix[2, 1] = -Math.Sin(tabCol1);
                matrix[3, 1] = -tabCol3 * Math.Sin(tabCol1);
            }

            //dodanie pozostałych wartości
            matrix[2, 0] = 0; 
            matrix[3, 0] = tabCol2;
            matrix[0, 3] = 0;
            matrix[1, 3] = 0;
            matrix[2, 3] = 0;
            matrix[3, 3] = 1;


            return matrix;
        }
        private void CreateGrid()
        {
            //text boxes
            int Tpos_x, Tpos_y;
            int TstartingPosX = win_x/3+ 40, TstartingPosY = win_y/3+50+60;
            int Tsize = 0;
            int textBoxGap = 10;
            int textBoxWidth = 60;
            int textBoxHeight = 30;

            for (int j = 0; j < size; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    Tpos_x = TstartingPosX + (70 * i);
                    Tpos_y = TstartingPosY + (j * 40);
                    speedScreenTextBoxGroup[Tsize] = new TextBox();
                    speedScreenTextBoxGroup[Tsize].Width = textBoxWidth;
                    speedScreenTextBoxGroup[Tsize].Height = textBoxHeight;
                    speedScreenTextBoxGroup[Tsize].Left = Tpos_x;
                    speedScreenTextBoxGroup[Tsize].Top = Tpos_y;
                    speedScreenTextBoxGroup[Tsize].Text = "";
                    speedScreenTextBoxGroup[Tsize].BorderStyle = BorderStyle.FixedSingle;
                    Controls.Add(speedScreenTextBoxGroup[Tsize]);
                    speedScreenTextBoxGroup[Tsize].BringToFront();
                    Tsize++;
                }
            }
            //iterate labels
            int labelStarting_pos_x = win_x / 3 -30;
            int labelStarting_pos_y = win_y / 3 + 50+60;

            int labelStarting_pos_x_2 = win_x / 3 + 55;
            int labelStarting_pos_y_2 = win_y / 3 + 10+60;

            Font font = new Font(arial, 12, FontStyle.Bold);

            for (int i = 0; i < size; i++)
            {
                speedScreenLabelGroup[i] = new Label();
                speedScreenLabelGroup[i].Left = labelStarting_pos_x;
                speedScreenLabelGroup[i].Top = labelStarting_pos_y + (i * (textBoxGap + textBoxHeight));
                speedScreenLabelGroup[i].Width = 25;
                speedScreenLabelGroup[i].Height = 25;
                speedScreenLabelGroup[i].BackColor = Color.White;   
                Controls.Add(speedScreenLabelGroup[i]);
                speedScreenLabelGroup[i].BringToFront();
                speedScreenLabelGroup[i].Font = font;
                speedScreenLabelGroup[i].Text = (i+1).ToString();
            }

            //header labels
            
            for (int i = 0; i < 4; i++)
            {
                speedScreenLabelGroup2[i] = new Label();
                speedScreenLabelGroup2[i].Left = labelStarting_pos_x_2 + (i * 70);
                speedScreenLabelGroup2[i].Top = labelStarting_pos_y_2;
                speedScreenLabelGroup2[i].Width = 70;
                speedScreenLabelGroup2[i].Height = 30;
                speedScreenLabelGroup2[i].BackColor = Color.White;
                speedScreenLabelGroup2[i].Font = font;  
                Controls.Add(speedScreenLabelGroup2[i]);
                speedScreenLabelGroup2[i].BringToFront();
            }

            speedScreenLabelGroup2[0].Text = "α(i-1)";
            speedScreenLabelGroup2[1].Text = "ai-1";
            speedScreenLabelGroup2[2].Text = "di";
            speedScreenLabelGroup2[3].Text = "θi";

            speedScreenTextBoxGroupCreated = true;
            speedScreenLabelGroupCreated = true;
        }
        //objects funtions
        private void Mobility_Click(object sender, EventArgs e)
        {
            size = 0;
            StartingScreen(false);
            MobilityScreen1(true);
            MobilityScreen2(false);
            MobilityScreen3(false);
            SpeedScreen2(false);
            SpeedScreen1(false);
            SpeedScreen3(false);
            SpeedScreen4(false);
            SpeedScreen6(false);
        }
        private void speedCountItem_Click(object sender, EventArgs e)
        {
            size = 0;
            StartingScreen(false);
            MobilityScreen1(false);
            MobilityScreen2(false);
            MobilityScreen3(false);
            SpeedScreen2(false);
            SpeedScreen1(true);
            SpeedScreen3(false);
            SpeedScreen4(false);
            SpeedScreen6(false);
        }
        private void NextButtonClick(object sender, EventArgs e)
        {
            if (newScreenTextBox1.Text.Length != 0)
            {
                bool number_ok = true;
                bool go_next = false;
                for (int i = 0; i < newScreenTextBox1.Text.Length; i++)
                {
                    if (Char.IsDigit(newScreenTextBox1.Text[i]) == false)
                    {
                        number_ok = false;
                    }
                }

                if (number_ok == true)
                {
                    if (newScreenTextBox1.Text.Length > 3)
                    {
                        MessageBox.Show("Nieprawidłowa wartość", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        if (int.Parse(newScreenTextBox1.Text) > 0 && int.Parse(newScreenTextBox1.Text) < 8)
                        {
                            if (newScreenCheckBox1.Checked == false && newScreenCheckBox2.Checked == false)
                            {
                                MessageBox.Show("Zaznacz jedną z opcji", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else if(newScreenCheckBox1.Checked == true && newScreenCheckBox2.Checked == true)
                            {
                                MessageBox.Show("Zaznacz jedną z opcji", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else
                            {
                                go_next = true;
                            }

                        }
                        else
                        {
                            MessageBox.Show("Nieprawidłowa wartość", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Nieprawidłowa wartość", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                if (go_next == true)
                {
                    size = int.Parse(newScreenTextBox1.Text.ToString());

                    SpeedScreen1(false);
                    StartingScreen(false);
                    MobilityScreen1(false);
                    CreateMobilityScreen();
                    MobilityScreen2(true);
                    MobilityScreen3(false);
                    SpeedScreen2(false);
                    SpeedScreen3(false);
                    SpeedScreen4(false);
                    SpeedScreen6(false);
                    runTime.Enabled = true;


                }
            }
        }
        private void NextButton2Click(object sender, EventArgs e)
        {
            bool checkBoxGood = true;
            bool go_next = false;

            
            //if check boxes are checked
            for (int i = 0; i < size; i++)
            {
                if (mobilityScreenCheckBoxGroup[i].Checked == false && mobilityScreenCheckBoxGroup[i + size].Checked == false &&
                    mobilityScreenCheckBoxGroup[i + size * 2].Checked == false)
                {
                    checkBoxGood = false;
                }
            }

            if(checkBoxGood == true)
            {
                go_next = true;
            }

            if (go_next == true)
            {
                StartingScreen(false);
                MobilityScreen1(false);
                MobilityScreen2(false);
                MobilityScreen3(true);
                SpeedScreen2(false);
                SpeedScreen1(false);
                SpeedScreen3(false);
                SpeedScreen4(false);
                SpeedScreen6(false);

                runTime.Enabled = false;
            }
            else
            {
                MessageBox.Show("Uzupełnij potrzebne dane", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            

        }
        private void speedScreen1Button1Click(object sender, EventArgs e)
        {
            bool number_ok = true;
            bool go_next = false;
            for (int i = 0; i < speedScreen1TextBox.Text.Length; i++)
            {
                if (Char.IsDigit(speedScreen1TextBox.Text[i]) == false)
                {
                    number_ok = false;
                }
            }

            if (number_ok == true)
            {
                if (speedScreen1TextBox.Text.Length > 3)
                {
                    MessageBox.Show("Nieprawidłowa wartość", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    if (int.Parse(speedScreen1TextBox.Text) > 0 && int.Parse(speedScreen1TextBox.Text) < 8)
                    {
                        go_next = true;
                    }
                }
            }

            if (go_next == true)
            {
                size = int.Parse(speedScreen1TextBox.Text.ToString());

                StartingScreen(false);
                MobilityScreen1(false);
                MobilityScreen2(false);
                MobilityScreen3(false);
                SpeedScreen2(true);
                SpeedScreen1(false);
                SpeedScreen3(false);
                SpeedScreen4(false);
                SpeedScreen6(false);

                CreateSpeedScreen4();
                CreateSpeedScreen5();
                CreateSDTScreen1();

            }
        }
        private void speedScreen2Button1Click(object sender, EventArgs e)
        {
            CountManPos();

            SpeedScreen1(false);
            StartingScreen(false);
            MobilityScreen1(false);
            MobilityScreen2(false);
            MobilityScreen3(false);
            SpeedScreen1(false);
            SpeedScreen2(false);
            SpeedScreen3(true);
            SpeedScreen6(false);
            SpeedScreen4(false);



        }
        private void speedScreen2Button2Click(object sender, EventArgs e)
        {
            int sizeTB = 0;
            bool readM = false;
            bool readS = false;
            bool readA = false;
            bool readSi = false;
            bool readAi = false;
            bool readMass = false;

            string[] lines = new string[14];
            if (openFileDialog.ShowDialog()==DialogResult.OK)
            {
                var file = openFileDialog.OpenFile();
                StreamReader reader = new StreamReader(file);
                int i = 0;
                while (reader.EndOfStream == false)
                {
                    lines[i] = reader.ReadLine();
                    i++;
                }
                
            }
            for (int i = 0; i < lines.Length; i++) 
            {
                string s = lines[i];

                if (readM == true)
                {
                    for (int j = 0; j < s.Length; j++)
                    {
                        if (s[j] == ',')
                        {
                            sizeTB++;
                        }
                        else
                        {
                            speedScreenTextBoxGroup[sizeTB].Text += s[j];
                        }
                    }
                }
                else if (readS == true)
                {
                    for (int j = 0; j < s.Length; j++)
                    {
                        if (s[j] == ',')
                        {
                            sizeTB++;
                        }
                        else
                        {
                            speedScreen4TextBoxGroup[sizeTB].Text += s[j];
                        }
                    }
                }
                else if (readA == true)
                {
                    for (int j = 0; j < s.Length; j++)
                    {
                        if (s[j] == ',')
                        {
                            sizeTB++;
                        }
                        else
                        {
                            speedScreen5TextBoxGroup[sizeTB].Text += s[j];
                        }
                    }
                }
                else if (readSi == true)
                {
                    for (int j = 0; j < s.Length; j++)
                    {
                        if (s[j] == ',')
                        {
                            sizeTB++;
                        }
                        else
                        {
                            speedScreen4CheckBoxGroup[int.Parse(s) - 1].Checked = true;
                        }
                    }
                }
                else if (readAi == true)
                {
                    for (int j = 0; j < s.Length; j++)
                    {
                        if (s[j] == ',')
                        {
                            sizeTB++;
                        }
                        else
                        {
                            speedScreen5CheckBoxGroup[int.Parse(s) - 1].Checked = true;
                        }
                    }
                }
                else if (readMass == true)
                {
                    for (int j = 0; j < s.Length; j++)
                    {
                        if (s[j] == ',')
                        {
                            sizeTB++;
                        }
                        else
                        {
                            sdtScreen1TextBoxGroup1[sizeTB].Text += s[j];
                        }
                    }
                }

                if (s=="m")
                {
                    readM = true;
                    readS = false;
                    readA = false;
                    readSi = false;
                    readAi = false;
                    sizeTB = 0;
                    readMass = false;
                }
                else if(s=="s")
                {
                    readM = false;
                    readS = true;
                    readA = false;
                    readSi= false;
                    readAi = false;
                    sizeTB = 0;
                    readMass = false;
                }
                else if (s == "a")
                {
                    readM = false;
                    readS = false;
                    readSi = false;
                    readAi = false;
                    readA = true;
                    sizeTB = 0;
                    readMass = false;
                }
                else if (s == "si")
                {
                    readM = false;
                    readS = false;
                    readA = false;
                    readSi = true;
                    readAi = false;
                    sizeTB = 0;
                    readMass = false;
                }
                else if (s == "ai")
                {
                    readM = false;
                    readS = false;
                    readA = false;
                    readSi = false;
                    readAi = true;
                    sizeTB = 0;
                    readMass = false;
                }
                else if (s == "z")
                {
                    readM = false;
                    readS = false;
                    readA = false;
                    readSi = false;
                    readAi = false;
                    readMass = true;
                    sizeTB = 0;
                }
            }

            //removing last char of the string
            string str = speedScreenTextBoxGroup[size * 4 - 1].Text;
            string str_n = str.Remove(str.Length - 1);
            speedScreenTextBoxGroup[size * 4 - 1].Text = str_n;

            str = speedScreen4TextBoxGroup[size - 1].Text;
            str_n = str.Remove(str.Length - 1);
            speedScreen4TextBoxGroup[size - 1].Text = str_n;

            str = speedScreen5TextBoxGroup[size - 1].Text;
            str_n = str.Remove(str.Length - 1);
            speedScreen5TextBoxGroup[size - 1].Text = str_n;

        }
        private void speedScreen3Button1Click(object sender, EventArgs e)
        {
            StartingScreen(true);
            MobilityScreen1(false);
            MobilityScreen2(false);
            MobilityScreen3(false);
            SpeedScreen1(false);
            SpeedScreen2(false);
            SpeedScreen3(false);
            SpeedScreen4(false);
            SpeedScreen6(false);

        }
        private void speedScreen3Button2Click(object sender, EventArgs e)
        {
            StartingScreen(false);
            MobilityScreen1(false);
            MobilityScreen2(false);
            MobilityScreen3(false);
            SpeedScreen1(false);
            SpeedScreen2(false);
            SpeedScreen3(false);
            SpeedScreen4(true);
            SpeedScreen5(false);
            SpeedScreen6(false);
            runTime.Enabled = true;
        }
        private void przyciskClick(object sender, EventArgs e)
        {
            MessageBox.Show(finalMatrixString);
        }
        private void speedScreen4Button1Click(object sender, EventArgs e)
        {
            StartingScreen(false);
            MobilityScreen1(false);
            MobilityScreen2(false);
            MobilityScreen3(false);
            SpeedScreen1(false);
            SpeedScreen2(false);
            SpeedScreen3(false);
            SpeedScreen4(false);
            SpeedScreen5(true);
            SpeedScreen6(false);
            runTime.Enabled = false;
        }
        private void speedScreen5Button1Click(object sender, EventArgs e)
        {
            StartingScreen(false);
            MobilityScreen1(false);
            MobilityScreen2(false);
            MobilityScreen3(false);
            SpeedScreen1(false);
            SpeedScreen2(false);
            SpeedScreen3(false);
            SpeedScreen4(false);
            SpeedScreen5(false);
            CreateSpeedScreen6();
            CountFKT();
            SpeedScreen6(true);
        }
        private void speedScreen6Button1Click(object sender, EventArgs e)
        {
            for (int i = 0; i < size; i++)
            {
                speedScreen6LabelGroup1[i].Visible = true;
                speedScreen6LabelGroup3[i].Visible = false;
                speedScreen6LabelGroup2[i].Visible = true;

            }
            for (int i = 0; i < size + 1; i++)
            {
                speedScreen6LabelGroup4[i].Visible = false;
                speedScreen6LabelGroup5[i].Visible = false;
            }
            for (int i = 0; i < (size + 1) * 2; i++)
            {
                speedScreen6LabelGroup[i].Visible = false;
            }
            speedScreen6LabelGroup2[size].Visible = false;

            speedScreen6Label2.Text = "Wektory prędkości kątowych";
            speedScreen6Label2.Width = 420;
            speedScreen6Label1.Visible = true;
            speedScreen6Label2.Visible = true;
            speedScreen6Label3.Visible = false;
        }
        private void speedScreen6Button2Click(object sender, EventArgs e)
        {
            for (int i = 0; i < size; i++)
            {
                speedScreen6LabelGroup1[i].Visible = false;
                speedScreen6LabelGroup3[i].Visible = true;
                speedScreen6LabelGroup2[i].Visible = true;

            }
            for (int i = 0; i < size + 1; i++)
            {
                speedScreen6LabelGroup4[i].Visible = false;
                speedScreen6LabelGroup5[i].Visible = false;
            }
            for (int i = 0; i < (size + 1) * 2; i++)
            {
                speedScreen6LabelGroup[i].Visible = false;
            }
            speedScreen6LabelGroup2[size].Visible = false;

            speedScreen6Label2.Text = "Wektory przyspieszeń kątowych";
            speedScreen6Label2.Width = 420;
            speedScreen6Label1.Visible = true;
            speedScreen6Label2.Visible = true;
            speedScreen6Label3.Visible = false;
        }
        private void speedScreen6Button3Click(object sender, EventArgs e)
        {
            for (int i = 0; i < size; i++)
            {
                speedScreen6LabelGroup1[i].Visible = false;
                speedScreen6LabelGroup3[i].Visible = false;

            }
            for (int i = 0; i < size + 1; i++)
            {
                speedScreen6LabelGroup4[i].Visible = true;
                speedScreen6LabelGroup5[i].Visible = false;
                speedScreen6LabelGroup2[i].Visible = true;
            }
            for (int i = 0; i < (size + 1) * 2; i++)
            {
                speedScreen6LabelGroup[i].Visible = false;
            }

            speedScreen6Label2.Text = "Wektory prędkości punktów charakterystycznych";
            speedScreen6Label2.Width = 420;
            speedScreen6Label1.Visible = true;
            speedScreen6Label2.Visible = true;
            speedScreen6Label3.Visible = false;
        }
        private void speedScreen6Button4Click(object sender, EventArgs e)
        {
            for (int i = 0; i < size; i++)
            {
                speedScreen6LabelGroup1[i].Visible = false;
                speedScreen6LabelGroup3[i].Visible = false;

            }
            for (int i = 0; i < size + 1; i++)
            {
                speedScreen6LabelGroup4[i].Visible = false;
                speedScreen6LabelGroup5[i].Visible = true;
                speedScreen6LabelGroup2[i].Visible = true;
            }
            for (int i = 0; i < (size + 1) * 2; i++)
            {
                speedScreen6LabelGroup[i].Visible = false;
            }

            speedScreen6Label2.Text = "Wektory przyspieszeń punktów charakterystycznych";
            speedScreen6Label2.Width = 420;
            speedScreen6Label1.Visible = true;
            speedScreen6Label2.Visible = true;
            speedScreen6Label3.Visible = false;
        }
        private void speedScreen6Button5Click(object sender, EventArgs e)
        {
            for (int i = 0; i < size; i++)
            {
                speedScreen6LabelGroup1[i].Visible = false;
                speedScreen6LabelGroup3[i].Visible = false;

            }
            for (int i = 0; i < size + 1; i++)
            {
                speedScreen6LabelGroup4[i].Visible = false;
                speedScreen6LabelGroup5[i].Visible = false;
                speedScreen6LabelGroup2[i].Visible = true;
            }
            for (int i = 0; i < (size + 1) * 2; i++)
            {
                speedScreen6LabelGroup[i].Visible = true;
            }

            speedScreen6Label2.Text = "Prędkości";
            speedScreen6Label2.Width = 150;
            speedScreen6Label3.Text = "Przyspieszenia";
            speedScreen6Label1.Visible = true;
            speedScreen6Label2.Visible = true;
            speedScreen6Label3.Visible = true;

        }
        private void speedScreen6Button6Click(object sender, EventArgs e)
        {
            StartingScreen(false);
            MobilityScreen1(false);
            MobilityScreen2(false);
            MobilityScreen3(false);
            SpeedScreen1(false);
            SpeedScreen2(false);
            SpeedScreen3(false);
            SpeedScreen4(false);
            SpeedScreen5(false);
            SpeedScreen6(false);
            SDTScreen1(true);
            SDTScreen2(false);
        }
        private void speedScreen6Button7Click(object sender, EventArgs e)
        {
            StartingScreen(false);
            MobilityScreen1(false);
            MobilityScreen2(false);
            MobilityScreen3(false);
            SpeedScreen1(false);
            SpeedScreen2(false);
            SpeedScreen3(false);
            SpeedScreen4(false);
            SpeedScreen5(false);
            SpeedScreen6(false);
            SDTScreen1(true);
            SDTScreen2(false);
            SDTScreen2(false);
        }
        private void sdtScreen1Button1Click(object sender, EventArgs e)
        {
            bool go_next = true;
            for (int i = 0; i < size; i++)
            {
                if(sdtScreen1TextBoxGroup1[i].Text.Length==0)
                {
                    go_next = false;
                }
            }

            if(go_next==true)
            {
                StartingScreen(false);
                MobilityScreen1(false);
                MobilityScreen2(false);
                MobilityScreen3(false);
                SpeedScreen1(false);
                SpeedScreen2(false);
                SpeedScreen3(false);
                SpeedScreen4(false);
                SpeedScreen5(false);
                SpeedScreen6(false);
                SDTScreen1(false);
                CreateSDTScreen2();
                SDTScreen2(true);
                CountFDT();
            }
            else
            {
                MessageBox.Show("Uzupełnij dane!", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void obliczPrędkościIPrzyspieszeniaPunktówCharakterystycznychToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void SecoundDinamicsTask_Click(object sender, EventArgs e)
        {

        }
        private void runTime_Tick(object sender, EventArgs e)
        {

            /*
            //dissabling text boxes
            for (int i = 0; i < size; i++)
            {
                if (newScreenCheckBoxes[i].Checked == true && newScreenCheckBoxes[size + i].Checked == false) 
                {
                    //4 and 5 column
                    newScreenTextBoxGroup[size * 3 + i].Enabled = false;
                    newScreenTextBoxGroup[size * 3 + i].Text = "";
                    newScreenTextBoxGroup[size * 4 + i].Enabled = false;
                    newScreenTextBoxGroup[size * 4 + i].Text = "";
                }

                if (newScreenCheckBoxes[i].Checked == false)
                {
                    //4 and 5
                    newScreenTextBoxGroup[size * 3 + i].Enabled = true;
                    newScreenTextBoxGroup[size * 4 + i].Enabled = true;
                }
            }*/

            if (mobilityScreen2Visible == true)
            {
                for (int i = 0; i < size; i++)
                {
                    if (mobilityScreenCheckBoxGroup[i].Checked == true)
                    {
                        mobilityScreenCheckBoxGroup[i + size].Enabled = false;
                        mobilityScreenCheckBoxGroup[i + size * 2].Enabled = false;
                    }
                    else if (mobilityScreenCheckBoxGroup[i + size].Checked == true)
                    {
                        mobilityScreenCheckBoxGroup[i].Enabled = false;
                        mobilityScreenCheckBoxGroup[i + size * 2].Enabled = false;
                    }
                    else if (mobilityScreenCheckBoxGroup[i + size * 2].Checked == true)
                    {
                        mobilityScreenCheckBoxGroup[i].Enabled = false;
                        mobilityScreenCheckBoxGroup[i + size].Enabled = false;
                    }
                    else
                    {
                        mobilityScreenCheckBoxGroup[i].Enabled = true;
                        mobilityScreenCheckBoxGroup[i + size].Enabled = true;
                        mobilityScreenCheckBoxGroup[i + size * 2].Enabled = true;
                    }

                }
            }

            

        }
        //what to render
        private void StartingScreen(bool show)
        {
            if (show == true)
            {
                //pb1.Visible = true;
            }
            else
            {
                //pb1.Visible = false;
            }
        }
        private void MobilityScreen1(bool show)
        {
            newScreenTextBox1.Text = "";
            newScreenCheckBox1.Checked = false;
            newScreenCheckBox2.Checked = false;

            if (show == true)
            {
                newScreenInfoLabel1.Visible = true;
                newScreenTextBox1.Visible = true;
                nextButton.Visible = true;
                newScreenInfoLabel9.Visible = true;
                newScreenInfoLabel10.Visible = true;
                newScreenInfoLabel11.Visible = true;
                newScreenCheckBox1.Visible = true;
                newScreenCheckBox2.Visible = true;

                CreateBackgroundPictureBox(win_x/3, win_y/3, win_x/3, win_y/3);
                backgroundBox.Visible = true;
            }
            else
            {
                newScreenInfoLabel1.Visible = false;
                newScreenTextBox1.Visible = false;
                nextButton.Visible = false;
                newScreenInfoLabel9.Visible = false;
                newScreenInfoLabel10.Visible = false;
                newScreenInfoLabel11.Visible = false;
                newScreenCheckBox1.Visible = false;
                newScreenCheckBox2.Visible = false;

                backgroundBox.Visible = false;
            }
        }
        private void MobilityScreen2(bool show)
        {
            if(show==true)
            {
                mobilityScreen2Visible = true;

                nextButton2.Visible = true;

                newScreenInfoLabel3.Visible = true;
                newScreenInfoLabel4.Visible = true;
                newScreenInfoLabel14.Visible = true;
                
                newScreenInfoLabel13.Visible = true;

                CreateBackgroundPictureBox(win_x / 3-60, win_y / 3 + 220, win_x / 3 - 20, win_y / 3 - 75);
                backgroundBox.Visible = true;

                for (int i = 0; i < size; i++)
                {
                    newScreenLabelGroup[i].Visible = true;
                }
                for (int i = 0; i < size * 3; i++)
                {
                    mobilityScreenCheckBoxGroup[i].Visible = true;
                }

                
            }
            else
            {
                if (mobilityScreen2Created == true)
                { 
                    mobilityScreen2Visible = false;

                    nextButton2.Visible = false;

                    newScreenInfoLabel3.Visible = false;
                    newScreenInfoLabel4.Visible = false;
                    newScreenInfoLabel14.Visible = false;
                    newScreenInfoLabel13.Visible = false;
                    backgroundBox.Visible = true;


                    for (int i = 0; i < size; i++)
                    {
                        newScreenLabelGroup[i].Visible = false;
                    }

                    for (int i = 0; i < size * 3; i++)
                    {
                        mobilityScreenCheckBoxGroup[i].Visible = false;
                    }


                }
            }
        }
        private void MobilityScreen3(bool show)
        {
            if (show == true)
            {
                newScreen3Label1.Text = "Ruchliwość manipulatora wynosi " + CountMobility();
                newScreen3Label1.Visible = true;
                CreateBackgroundPictureBox(win_x / 3, 150, win_x / 3, win_y / 3 + 80); ;
               // drawingField.Visible = true;
               // drawingField.Paint += new PaintEventHandler(DrawRobot);
               backgroundBox.Visible = true;
            }
            else
            {
                newScreen3Label1.Visible = false;
                drawingField.Visible = false;
            }
        }
        private void SpeedScreen1(bool show)
        {
            if(show==true)
            {
                CreateBackgroundPictureBox(win_x / 3, win_y / 3, win_x / 3, win_y / 3);
                backgroundBox.Visible = true;
                speedScreen1Label.Visible = true;
                speedScreen1TextBox.Visible = true;
                speedScreen1Button1.Visible = true;
            }
            else
            {
                speedScreen1Label.Visible = false;
                speedScreen1TextBox.Visible = false;
                speedScreen1Button1.Visible = false;
            }
        }
        private void SpeedScreen2(bool show)
        {
            if(show==true)
            {
                CreateBackgroundPictureBox(670, 500, win_x / 3 - 50, win_y / 3);
                backgroundBox.Visible = true;
                CreateGrid();
                speedScreen2Label.Visible = true;
                speedScreen2Button1.Visible = true;
                speedScreen2Button2.Visible = true;
                speedScreen2Label2.Visible = true;
                speedScreen2Label3.Visible = true;
                speedScreen2Label4.Visible = true;
                speedScreen2Label5.Visible = true;
                speedScreen2Label1.Visible = true;
                speedScreen2CheckBox.Visible = true;
                for (int i = 0; i < size * 4; i++)
                {
                    speedScreenTextBoxGroup[i].Visible = true;
                }

                for (int i = 0; i < 4; i++)
                {
                    speedScreenLabelGroup2[i].Visible = true;
                }

                for(int i = 0; i < size; i++)
                {
                    speedScreenLabelGroup[i].Visible = true;
                }
               
            }
            else
            {
                speedScreen2CheckBox.Visible = false;
                speedScreen2Label.Visible = false;
                speedScreen2Button1.Visible = false;
                speedScreen2Button2.Visible = false;
                speedScreen2Label2.Visible = false;
                speedScreen2Label3.Visible = false;
                speedScreen2Label4.Visible = false;
                speedScreen2Label5.Visible = false;
                speedScreen2Label1.Visible = false;
                if (speedScreenTextBoxGroupCreated == true)
                {
                    
                    for (int i = 0; i < size * 4; i++)
                    {
                        speedScreenTextBoxGroup[i].Visible = false;
                    }
                }
                if(speedScreenLabelGroupCreated == true)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        speedScreenLabelGroup2[i].Visible = false;
                    }
                    for (int i = 0; i < size; i++)
                    {
                        speedScreenLabelGroup[i].Visible = false;
                    }
                }
            }
        }
        private void SpeedScreen3(bool show)
        {
            if(show==true)
            {
                CreateBackgroundPictureBox(600, 350, win_x / 3 - 50, win_y / 3);
                backgroundBox.Visible = true;   
                speedScreen3Button1.Visible = true;
                speedScreen3Button2.Visible = true;
                speedScreen3Label1.Visible = true;
                speedScreen3Label2.Visible = true;
                speedScreen3Button3.Visible = true;
            }
            else
            {
                speedScreen3Button1.Visible = false;
                speedScreen3Button2.Visible = false;
                speedScreen3Label1.Visible = false;
                speedScreen3Label2.Visible = false;
                speedScreen3Button3.Visible = false;
            }

        }
        private void SpeedScreen4(bool show)
        {
            if(show==true)
            {
                CreateBackgroundPictureBox(600, 800, win_x / 3 - 50, win_y / 3 - 150);
                backgroundBox.Visible = true;
                

                for (int i = 0; i < size; i++)
                {
                    speedScreen4CheckBoxGroup[i].Visible = true;
                }
                for (int i = 0; i < size; i++)
                {
                    speedScreen4LabelGroup[i].Visible = true;
                    speedScreen4TextBoxGroup[i].Visible = true;
                }
                speedScreen4Label1.Visible = true;
                speedScreen4Label3.Visible = true;
                speedScreen4Label4.Visible = true;
                speedScreen4Button1.Visible = true;
                speedScreen4Label9.Visible = true;
                speedScreen4Label10.Visible = true;
                speedScreen4Label11.Visible = true;
                speedScreen4Label8.Visible = true;

                //speedScreen4CheckBox1.Visible = true;
                //speedScreen4CheckBox2.Visible = true;
            }
            else
            {
                if (speedScreen4CheckBoxGroupCreated == true)
                {

                    for (int i = 0; i < size; i++)
                    {
                        speedScreen4CheckBoxGroup[i].Visible = false;
                    }
                    for (int i = 0; i < size; i++)
                    {
                        speedScreen4LabelGroup[i].Visible = false;
                        speedScreen4TextBoxGroup[i].Visible = false;
                    }
                    speedScreen4Label1.Visible = false;
                    speedScreen4Label3.Visible = false;
                    speedScreen4Label4.Visible = false;
                    speedScreen4Button1.Visible = false;
                    speedScreen4Label9.Visible = false;
                    speedScreen4Label10.Visible = false;
                    speedScreen4Label11.Visible = false;
                    speedScreen4Label8.Visible = false;
                    //speedScreen4CheckBox1.Visible = false;
                    //speedScreen4CheckBox2.Visible = false;
                }
            }
        }
        private void SpeedScreen5(bool show)
        {
            if (show == true)
            {
                CreateBackgroundPictureBox(600, 800, win_x / 3 - 50, win_y / 3 - 150);
                backgroundBox.Visible = true;


                for (int i = 0; i < size; i++)
                {
                    speedScreen5CheckBoxGroup[i].Visible = true;
                }
                for (int i = 0; i < size; i++)
                {
                    speedScreen5LabelGroup[i].Visible = true;
                    speedScreen5TextBoxGroup[i].Visible = true;
                }
                speedScreen5Label1.Visible = true;
                speedScreen5Label3.Visible = true;
                speedScreen5Label4.Visible = true;
                speedScreen5Button1.Visible = true;
                speedScreen5Label9.Visible = true;
                speedScreen5Label10.Visible = true;
                speedScreen5Label11.Visible = true;
                speedScreen5Label8.Visible = true;

                //speedScreen4CheckBox1.Visible = true;
                //speedScreen4CheckBox2.Visible = true;
            }
            else
            {
                if (speedScreen5CheckBoxGroupCreated == true)
                {

                    for (int i = 0; i < size; i++)
                    {
                        speedScreen5CheckBoxGroup[i].Visible = false;
                    }
                    for (int i = 0; i < size; i++)
                    {
                        speedScreen5LabelGroup[i].Visible = false;
                        speedScreen5TextBoxGroup[i].Visible = false;
                    }
                    speedScreen5Label1.Visible = false;
                    speedScreen5Label3.Visible = false;
                    speedScreen5Label4.Visible = false;
                    speedScreen5Button1.Visible = false;
                    speedScreen5Label9.Visible = false;
                    speedScreen5Label10.Visible = false;
                    speedScreen5Label11.Visible = false;
                    speedScreen5Label8.Visible = false;
                    //speedScreen4CheckBox1.Visible = false;
                    //speedScreen4CheckBox2.Visible = false;
                }
            }
        }
        private void SpeedScreen6(bool show)
        {
            if(show==true)
            {
                CreateBackgroundPictureBox(600, 800, win_x / 3 - 50, win_y / 3 - 150);
                backgroundBox.Visible = true;

                speedScreen6Button1.Visible = true;
                speedScreen6Button2.Visible = true;
                speedScreen6Button3.Visible = true;
                speedScreen6Button4.Visible = true;
                speedScreen6Button5.Visible = true;
                speedScreen6Button6.Visible = true;
                speedScreen6Button7.Visible = true;
            }
            else
            {
                if (speedScreen6LabelGroupCreated == true)
                {
                    speedScreen6Button1.Visible = false;
                    speedScreen6Button2.Visible = false;
                    speedScreen6Button3.Visible = false;
                    speedScreen6Button4.Visible = false;
                    speedScreen6Button5.Visible = false;
                    speedScreen6Button6.Visible = false;
                    speedScreen6Button7.Visible = false;

                    for (int i = 0; i < size; i++)
                    {
                        speedScreen6LabelGroup1[i].Visible = false;
                        speedScreen6LabelGroup3[i].Visible = false;
                    }
                    for (int i = 0; i < (size + 1) * 2; i++)
                    {
                        speedScreen6LabelGroup[i].Visible = false;
                    }
                    for (int i = 0; i < size + 1; i++)
                    {
                        speedScreen6LabelGroup4[i].Visible = false;
                        speedScreen6LabelGroup5[i].Visible = false;
                        speedScreen6LabelGroup2[i].Visible = false;
                    }

                    speedScreen6Label1.Visible = false;
                    speedScreen6Label2.Visible = false;
                    speedScreen6Label3.Visible = false;
                }
            }

        }
        private void SDTScreen1(bool show)
        {
            if(show==true)
            {
                CreateBackgroundPictureBox(600, 600, win_x / 3 - 50, win_y / 3 - 150);
                backgroundBox.Visible = true;
                sdtScreen1Button1.Visible = true;
                sdtScreen1Label1.Visible = true;
                sdtScreen1Label2.Visible = true;
                speedScreen2Label2.Visible = true;
                speedScreen2Label3.Text = "masa: kg";
                speedScreen2Label3.Visible = true;
                sdtScreen1Label3.Visible = true;


                for (int i = 0; i < size; i++)
                {
                    sdtScreen1LabelGroup1[i].Visible = true;
                    sdtScreen1TextBoxGroup1[i].Visible = true;
                }
                
            }
            else
            {
                sdtScreen1Button1.Visible = false;
                sdtScreen1Label1.Visible = false;
                sdtScreen1Label2.Visible = false;
                speedScreen2Label2.Visible = false;
                speedScreen2Label3.Visible = false;
                sdtScreen1Label3.Visible = false;
                for (int i = 0; i < size; i++)
                {
                    sdtScreen1LabelGroup1[i].Visible = false;
                    sdtScreen1TextBoxGroup1[i].Visible = false;
                }
            }
        }
        private void SDTScreen2(bool show)
        {
            if (show == true)
            {
                CreateBackgroundPictureBox(600, 800, win_x / 3 - 50, 100);
                backgroundBox.Visible = true;

                for (int i = 0; i < 10; i++)
                {
                    sdtScreen3ButtonGroup[i].Visible=true;
                }
                
            }
            else
            {
                if(sdtScreen2Created == true)
                {
                    for (int i = 0; i < size + 1; i++)
                    {
                        sdtScreen3LabelGroup[i].Visible = false;
                        sdtScreen3LabelGroup2[i].Visible = false;
                        sdtScreen3LabelGroup6[i].Visible = false;
                        sdtScreen3LabelGroup7[i].Visible = false;
                        sdtScreen3LabelGroup8[i].Visible = false;
                        sdtScreen3LabelGroup9[i].Visible = false;
                    }
                    for (int i = 0; i < size; i++)
                    {
                        sdtScreen3LabelGroup1[i].Visible = false;
                        sdtScreen3LabelGroup3[i].Visible = false;
                        sdtScreen3LabelGroup4[i].Visible = false;
                        sdtScreen3LabelGroup5[i].Visible = false;
                    }
                    for (int i = 0; i < 10; i++)
                    {
                        sdtScreen3ButtonGroup[i].Visible = false;
                    }
                }

            }
        }
        private void SDTScreen3(bool show)
        {
            if(show==true)
            {

            }
            else
            {

            }
        }
        // calculating functions
        private int CountMobility()
        {
            List<int> classes = new List<int>(); //lista zmiennych przechowujaca klasy poszczegolnych czlonow 
            int w = 0;

            for (int i = 0; i < size; i++) //sprawdzanie kazdej pary checkboxow
            {
                if (mobilityScreenCheckBoxGroup[i].Checked==true ) //jezeli checkbox jest zaznaczony
                {
                    classes.Add(3); //dodaj wartosc klasy do listy
                }
                else if (mobilityScreenCheckBoxGroup[i + size].Checked == true)
                {
                    classes.Add(4);
                }
                else if (mobilityScreenCheckBoxGroup[i + size * 2].Checked == true)
                {
                    classes.Add(5);
                }
            }

           
            if (newScreenCheckBox1.Checked == true && newScreenCheckBox2.Checked == false)  //jezeli manipulator jest przestrzenny
            {
                w = 6 * size; //size = n

                foreach (var i in classes)
                {
                    w -= i; //odejmowanie wartosci kazdej klasy z listy
                }
                classes.Clear(); //czyszczenie listy
                return w; //zwrocenie obliczonej wartosci ruchliwosci
            }
            else if (newScreenCheckBox2.Checked = true && newScreenCheckBox1.Checked == false)
            {
                int class4 = 0; //ilosc par klasy 4
                int class5 = 0; //ilosc par klasy 5

                foreach (var i in classes)
                {
                    if(i==5) 
                    {
                        class5++;
                    }
                    else if(i==4)
                    {
                        class4++;
                    }
                }

                w = 3 * size - class4 - 2 * class5; //ostateczny wzor

                classes.Clear();
                return w;
            }
            else
            {
                classes.Clear();
                return w;
            }

            
        }
        //zamiana seperatora liczby dziesiętnej
        private string ChangeSep(string s)
        {
            string new_s = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '.')
                {
                    new_s += ',';
                }
                else
                {
                    new_s += s[i];
                }
            }

            return new_s;
        }
        private void CountManPos() //count end of manipulator positon
        {
            speedScreen3Label1.Text = ""; //czyszczenie tekstu pola wyswietlajacego wynik

            //tworzenie macierzy rotacji na podstawie tabeli D-H
            for (int i = 0; i < size; i++)
            {
                //dodawanie do listy utworzonych macierzy
                matrixList.Add(CreateMatrixT(Rad(ToDouble(ChangeSep(speedScreenTextBoxGroup[0 + i * 4].Text))),
                    ToDouble(ChangeSep(speedScreenTextBoxGroup[1 + i * 4].Text)),
                    ToDouble(ChangeSep(speedScreenTextBoxGroup[2 + i * 4].Text)),
                    Rad(ToDouble(ChangeSep(speedScreenTextBoxGroup[3 + i * 4].Text)))));
            }

            //opcjonalne pokazywanie kazdej macierzy
            if (speedScreen2CheckBox.Checked == true)
            {
                double[,] a = new double[4, 4]; //zmienna pomocnicza
                for (int i = 0; i < matrixList.Count; i++) 
                {
                    a = matrixList[i]; //przypisanie macierzy z listy do zmiennej pomocniczej
                    string s = "";
                    for (int x = 0; x < 4; x++) 
                    {
                        for (int y = 0; y < 4; y++)
                        {
                            if (y == 3) 
                            {
                                s += a[y, x].ToString();
                            }
                            else
                            {
                                s += a[y, x].ToString() + "\t";
                            }
                        }
                        s += "\n";
                    }
                    MessageBox.Show(s);
                }
            }
            
            //wymnazanie macierzy
            double[,] final_matrix = new double[4, 4]; 

            for (int i = 0; i < matrixList.Count; i++)
            {
                //mnożenie każdej macierzy ze sobą
                if (i == 0)
                {
                    final_matrix = matrixList[i];
                }
                else
                {
                    final_matrix = MatrixMulti(final_matrix, matrixList[i]); 
                }
            }


            //wyświetlanie 4 miejsc po przecinku
            for (int i = 0; i < 3; i++) //3 wyniki x,y,z
            {
                string s = final_matrix[3, i].ToString(); 
                string new_s = "";
                bool sep = false;
                int var1 = 0;
                for (int x = 0; x < s.Length; x++) //przez wszystkie znaki w liczbie(napisie)
                {
                    //jeżeli wykryty zostanie ',' odliczanie do 4 
                    if (s[x]==',') 
                    {
                        sep = true;
                    }

                    if(sep==true) 
                    {
                        var1++;
                    }

                    if (var1 <= 5 || sep == false) 
                    {
                        new_s += s[x];
                    }
                }
                
                //wyświetlanie wyniku
                if(i==0)
                {
                    speedScreen3Label1.Text += "Wynik: X=" + new_s + "m    ";
                }
                else if (i == 1)
                {
                    speedScreen3Label1.Text += "Y=" + new_s + "m    ";
                }
                else if (i == 2)
                {
                    speedScreen3Label1.Text += "Z=" + new_s + "m    ";
                }
            }


            //pokazywanie macierzy końcowej
            finalMatrixString = "";
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    string str = final_matrix[i, j].ToString();
                    string new_s = "";
                    bool sep = false;
                    int var1 = 0;
                    for (int x = 0; x < str.Length; x++) //przez wszystkie znaki w liczbie(napisie)
                    {
                        //jeżeli wykryty zostanie ',' odliczanie do 4 
                        if (str[x] == ',')
                        {
                            sep = true;
                        }

                        if (sep == true)
                        {
                            var1++;
                        }

                        if (var1 <= 5 || sep == false)
                        {
                            new_s += str[x];
                        }
                        

                    }
                    finalMatrixString += new_s;
                    finalMatrixString += "\t";
                }
                finalMatrixString += "\n";
            }

        }
        private void CountFKT() //count first kinematics task
        {
            //czytanie macierzy rotacji oraz wektorów translacji z macierzy T
            for (int i = 0; i < size; i++)
            {
                double[,] helpMatrix = new double[4, 4];
                double[,] helpMatrix1 = new double[3, 3];
                helpMatrix = matrixList[i];
                for (int x = 0; x < 3; x++)
                {
                    for (int y = 0; y < 3; y++)
                    {
                        //czytanie pierwszych trzech kolumn i wierszy
                        helpMatrix1[x, y] = helpMatrix[x, y]; 
                    }
                }

                double[] vect = new double[3];

                for (int x = 0; x < 3; x++)
                {
                    vect[0] = helpMatrix[3, 0];
                    vect[1] = helpMatrix[3, 1];
                    vect[2] = helpMatrix[3, 2];
                }
                //dodanie macierzy i wektorów do listy
                rotationMatrixList.Add(helpMatrix1); 
                pVectorList.Add(vect);   


            }
            //obliczanie wektorów prędkości i przyspieszenia kątowego
            bool ppd = false;

            for (int i = 0; i < size; i++)
            {
                //zmienne pomocnicze
                double[] vect = new double[3];
                double[] vector1 = new double[3];
                double[] vector2 = new double[3];
                double[] vector3 = new double[3];


                if (i == 0)
                {
                    //utworzenie wektora zerowego 
                    vect[0] = 0;
                    vect[1] = 0;
                    vect[2] = 0;

                    //dodanie pierwszego zerowego wektora 
                    omegaVectorList.Add(vect); 
                    epsilonVectorList.Add(vect);
                }
                else
                {
                    //jeżeli wykryta została para postępowa, wykonaj to samo dla pary następnej
                    //np:
                    //i = 4 -> para postępowa, brak uwzględnienia wektora omegi w równaniu
                    // i = 5 -> również brak uwzględnienia wektora omegi
                    if (ppd==true) 
                    {
                        //prędkość kątowa
                        vector1 = MatrixVectorMultipl(MatrixTransp(rotationMatrixList[i - 1]), omegaVectorList[i - 1]);
                        omegaVectorList.Add(vector1);

                        //przyspieszenie kątowe
                        vector1 = MatrixVectorMultipl(rotationMatrixList[i - 1], epsilonVectorList[i - 1]);
                        epsilonVectorList.Add(vector1);
                        ppd = false;
                    }
                    else
                    {
                        if (speedScreen4CheckBoxGroup[i].Checked == true) //wykrywanie pary postępowej
                        {
                            //prędkość kątowa
                            vector1 = MatrixVectorMultipl(MatrixTransp(rotationMatrixList[i - 1]), omegaVectorList[i - 1]);
                            omegaVectorList.Add(vector1);

                            //przyspieszenie kątowe
                            vector1 = MatrixVectorMultipl(rotationMatrixList[i - 1], epsilonVectorList[i - 1]);
                            epsilonVectorList.Add(vector1);

                            ppd = true;

                        }
                        else
                        {
                            //prędkość kątowa
                            vect[0] = 0;
                            vect[1] = 0;
                            vect[2] = ToDouble(ChangeSep(speedScreen4TextBoxGroup[i].Text)); //czytanie wartości prędkości kątowej

                            vector1 = MatrixVectorMultipl(MatrixTransp(rotationMatrixList[i - 1]), omegaVectorList[i - 1]);
                            omegaVectorList.Add(VectorAdd(vector1, vect));

                            //przyspieszenie kątowe

                            vector1[0] = 0;
                            vector1[1] = 0;
                            vector1[2] = ToDouble(ChangeSep(speedScreen5TextBoxGroup[i].Text)); //czytanie przyspieszenia kątowego

                            vector2 = VectorAdd(VectorAdd(MatrixVectorMultipl(rotationMatrixList[i - 1], epsilonVectorList[i - 1]),
                                MatrixVectorMultipl(rotationMatrixList[i - 1], VectorMultipl(omegaVectorList[i - 1], vect))),
                                vector1);

                            epsilonVectorList.Add(vector2);

                        }
                    }
                    
                }

            }
            /*
            if(epsilonVectorList.Count>=6)
            {
                double[] vectoo = new double[3];
                vectoo[0] = 0d;
                vectoo[1] = 1d;
                vectoo[2] = 0d;
                epsilonVectorList[4] = vectoo;
                double[] vectoo1 = new double[3];
                vectoo1[0] = 0d;
                vectoo1[1] = 0d;
                vectoo1[2] = 0.5d;
                epsilonVectorList[5] = vectoo1;
                double[] vectoo2 = new double[3];
                vectoo2[0] = 0d;
                vectoo2[1] = 0d;
                vectoo2[2] = 3d;
                epsilonVectorList[6] = vectoo2;
            }
            */

            //utworzenie i dodanie do listy wektora zerowego prędkości i przyspieszenia punktu 0
            double[] speedVect = new double[3];
            speedVect[0] = 0d;
            speedVect[1] = 0d;
            speedVect[2] = 0d;
            speedVectorList.Add(speedVect);

            double[] accVect = new double[3];
            accVect[0] = 0d;
            accVect[1] = 0d;
            accVect[2] = 0d;
            accelVectorList.Add(accVect);

            for (int i = 1; i < size + 1; i++) //1-n
            {
                //jeżeli jest to para postępowa, uwzględnij prędkość i przyspieszenie liniowe
                if (speedScreen4CheckBoxGroup[i-1].Checked == true)
                {
                    //prędkość punktu
                    double[] linearSpeed = new double[3];
                    double[] linearAccel = new double[3];

                    linearSpeed[0] = 0d;
                    linearSpeed[1] = 0d;
                    linearSpeed[2] = ToDouble(ChangeSep(speedScreen4TextBoxGroup[i - 1].Text)); //czytanie wartości prędkości liniowej

                    //wzór obliczeniowy
                    double[] mnozenieWektorowe = VectorMultipl(omegaVectorList[i - 1], pVectorList[i - 1]);
                    double[] sumaWektorow = VectorAdd(speedVectorList[i - 1], mnozenieWektorowe);
                    double[] mnozenie = MatrixVectorMultipl(MatrixTransp(rotationMatrixList[i - 1]), sumaWektorow);
                    speedVectorList.Add(VectorAdd(mnozenie, linearSpeed));

                    //przyspieszenie punktu
                    linearAccel[0] = 0d;
                    linearAccel[1] = 0d;
                    linearAccel[2] = ToDouble(ChangeSep(speedScreen5TextBoxGroup[i - 1].Text)); //czytanie wartości pryspieszenia liniowego

                    //wzór obliczeniowy
                    double[] jeden = VectorMultipl(omegaVectorList[i - 1], pVectorList[i - 1]);
                    double[] dwa = VectorMultipl(omegaVectorList[i - 1], jeden);
                    double[] trzy = VectorMultipl(epsilonVectorList[i - 1], pVectorList[i - 1]);
                    double[] cztery = VectorAdd(VectorAdd(accelVectorList[i - 1], dwa), trzy);
                    double[] piec = MatrixVectorMultipl(rotationMatrixList[i - 1], cztery);
                    double[] szesc = VectorMultipl(omegaVectorList[i], linearSpeed); 
                    double[] siedem = VectorNumberMultipl(szesc, 2d); 
                    double[] osiem = VectorAdd(VectorAdd(siedem, linearAccel), piec);
                    accelVectorList.Add(osiem); 

                }
                else
                {
                    //prędkość punktu
                    double[] mnozenieWektorowe = VectorMultipl(omegaVectorList[i -1], pVectorList[i-1]);
                    double[] sumaWektorow = VectorAdd(speedVectorList[i - 1], mnozenieWektorowe);      
                    speedVectorList.Add(MatrixVectorMultipl(MatrixTransp(rotationMatrixList[i-1]), sumaWektorow));

                    //przyspieszenie punktu
                    double[] jeden = VectorMultipl(omegaVectorList[i - 1], pVectorList[i - 1]);
                    double[] dwa = VectorMultipl(omegaVectorList[i - 1], jeden);
                    double[] trzy = VectorMultipl(epsilonVectorList[i - 1], pVectorList[i - 1]);
                    double[] cztery = VectorAdd(VectorAdd(accelVectorList[i - 1], dwa), trzy);
                    double[] piec = MatrixVectorMultipl(rotationMatrixList[i - 1], cztery);

                    accelVectorList.Add(piec);

                }
            }

            //wysyłyłanie wyników do napisów wyświetlających
            //4 miejsca po przecinku
            for (int i = 0; i < size + 1; i++)
            {
                string s = VectorValue(speedVectorList[i]).ToString();
                string new_s = "";
                bool sep = false;
                int var1 = 0;
                for (int x = 0; x < s.Length; x++)
                {
                    if (s[x] == ',')
                    {
                        sep = true;
                    }

                    if (sep == true)
                    {
                        var1++;
                    }

                    if (var1 <= 5 || sep == false)
                    {
                        new_s += s[x];
                    }

                }

                speedScreen6LabelGroup[i].Text = new_s + " m/s";
            }
            for (int i = 0; i < size + 1; i++)
            {
                string s = VectorValue(accelVectorList[i]).ToString();
                string new_s = "";
                bool sep = false;
                int var1 = 0;
                for (int x = 0; x < s.Length; x++)
                {
                    if (s[x] == ',')
                    {
                        sep = true;
                    }

                    if (sep == true)
                    {
                        var1++;
                    }

                    if (var1 <= 5 || sep == false)
                    {
                        new_s += s[x];
                    }

                }
                speedScreen6LabelGroup[(size + 1) + i].Text = new_s + " m/s^2";
            }
            for (int i = 0; i < size; i++)
            {
                double[] vect = omegaVectorList[i];
                for (int j = 0; j < 3; j++)
                {
                    string s = vect[j].ToString();
                    string new_s = "";
                    bool sep = false;
                    int var1 = 0;
                    for (int x = 0; x < s.Length; x++)
                    {
                        if (s[x] == ',')
                        {
                            sep = true;
                        }

                        if (sep == true)
                        {
                            var1++;
                        }

                        if (var1 <= 5 || sep == false)
                        {
                            new_s += s[x];
                        }

                    }

                    if(j==0)
                    {
                        speedScreen6LabelGroup1[i].Text += "[" + new_s;
                    }
                    else if (j == 1)
                    {
                        speedScreen6LabelGroup1[i].Text += " " + new_s;
                    }
                    else if (j == 2)
                    {
                        speedScreen6LabelGroup1[i].Text += " " + new_s + "]";
                    }


                }
                
            }
            for (int i = 0; i < size; i++)
            {
                double[] vect = epsilonVectorList[i];

                for (int j = 0; j < 3; j++)
                {
                    string s = vect[j].ToString();
                    string new_s = "";
                    bool sep = false;
                    int var1 = 0;
                    for (int x = 0; x < s.Length; x++)
                    {
                        if (s[x] == ',')
                        {
                            sep = true;
                        }

                        if (sep == true)
                        {
                            var1++;
                        }

                        if (var1 <= 5 || sep == false)
                        {
                            new_s += s[x];
                        }

                    }

                    if (j == 0)
                    {
                        speedScreen6LabelGroup3[i].Text += "[" + new_s;
                    }
                    else if (j == 1)
                    {
                        speedScreen6LabelGroup3[i].Text += " " + new_s;
                    }
                    else if (j == 2)
                    {
                        speedScreen6LabelGroup3[i].Text += " " + new_s + "]";
                    }


                }

            }
            for (int i = 0; i < size + 1; i++)
            {
                double[] vect = speedVectorList[i];

                for (int j = 0; j < 3; j++)
                {
                    string s = vect[j].ToString();
                    string new_s = "";
                    bool sep = false;
                    int var1 = 0;
                    for (int x = 0; x < s.Length; x++)
                    {
                        if (s[x] == ',')
                        {
                            sep = true;
                        }

                        if (sep == true)
                        {
                            var1++;
                        }

                        if (var1 <= 5 || sep == false)
                        {
                            new_s += s[x];
                        }

                    }

                    if (j == 0)
                    {
                        speedScreen6LabelGroup4[i].Text += "[" + new_s;
                    }
                    else if (j == 1)
                    {
                        speedScreen6LabelGroup4[i].Text += " " + new_s;
                    }
                    else if (j == 2)
                    {
                        speedScreen6LabelGroup4[i].Text += " " + new_s + "]";
                    }


                }

            }
            for (int i = 0; i < size + 1; i++)
            {
                double[] vect = accelVectorList[i];
                for (int j = 0; j < 3; j++)
                {
                    string s = vect[j].ToString();
                    string new_s = "";
                    bool sep = false;
                    int var1 = 0;
                    for (int x = 0; x < s.Length; x++)
                    {
                        if (s[x] == ',')
                        {
                            sep = true;
                        }

                        if (sep == true)
                        {
                            var1++;
                        }

                        if (var1 <= 5 || sep == false)
                        {
                            new_s += s[x];
                        }

                    }

                    if (j == 0)
                    {
                        speedScreen6LabelGroup5[i].Text += "[" + new_s;
                    }
                    else if (j == 1)
                    {
                        speedScreen6LabelGroup5[i].Text += " " + new_s;
                    }
                    else if (j == 2)
                    {
                        speedScreen6LabelGroup5[i].Text += " " + new_s + "]";
                    }


                }

            }
        }
        private void CountFDT()
        {
            //masy czlonow
            for (int i = 0; i < size; i++)
            {
                massList.Add(ToDouble(ChangeSep(sdtScreen1TextBoxGroup1[i].Text))); //czytanie masy członów
            }

            //wektory przemieszczenia srodkow masy i Tensory bezwładności
            for (int i = 0; i < size; i++)
            {
                double[] vector = new double[3];
                if (i == 0)//wartosci na z
                {
                    //sprawdzanie w ktorej kolumnie w tabeli D-H występuje wartość
                    if (ToDouble(ChangeSep(speedScreenTextBoxGroup[1 + i * 4].Text)) != 0d &&
                        ToDouble(ChangeSep(speedScreenTextBoxGroup[2 + i * 4].Text)) == 0d) 
                    {
                        //utworzenie i dodanie wektora do listy
                        vector[0] = 0;
                        vector[1] = 0;
                        vector[2] = ToDouble(ChangeSep(speedScreenTextBoxGroup[1 + i * 4].Text)) / 2d;
                        massCenterPvect.Add(vector);

                        //utworzenie i dodanie do listy macierzy 
                        MassCenterMatrixList.Add(CreateMatrixI('z', massList[i], ToDouble(ChangeSep(speedScreenTextBoxGroup[1 + i * 4].Text))));
                    }
                    else if (ToDouble(ChangeSep(speedScreenTextBoxGroup[1 + i * 4].Text)) == 0d &&
                        ToDouble(ChangeSep(speedScreenTextBoxGroup[2 + i * 4].Text)) != 0d)
                    {
                        vector[0] = 0;
                        vector[1] = 0;
                        vector[2] = ToDouble(ChangeSep(speedScreenTextBoxGroup[2 + i * 4].Text)) / 2d;
                        massCenterPvect.Add(vector);

                        MassCenterMatrixList.Add(CreateMatrixI('z', massList[i], ToDouble(ChangeSep(speedScreenTextBoxGroup[2 + i * 4].Text))));
                    }
                }
                else
                {
                    //wartosc na y jezeli wartosc od przesuwu
                    if (speedScreen4CheckBoxGroup[i].Checked == true)
                    {
                        vector[0] = 0;
                        vector[1] = ToDouble(ChangeSep(speedScreenTextBoxGroup[2 + i * 4].Text)) / 2d;
                        vector[2] = 0;
                        massCenterPvect.Add(vector);

                        MassCenterMatrixList.Add(CreateMatrixI('y', massList[i], ToDouble(ChangeSep(speedScreenTextBoxGroup[2 + i * 4].Text))));
                    }
                    else
                    {
                        //wartosc na x jezeli w kolumnie ai
                        if (ToDouble(ChangeSep(speedScreenTextBoxGroup[1 + i * 4].Text)) != 0 &&
                        ToDouble(ChangeSep(speedScreenTextBoxGroup[2 + i * 4].Text)) == 0)
                        {
                            vector[0] = ToDouble(ChangeSep(speedScreenTextBoxGroup[1 + i * 4].Text)) / 2d;
                            vector[1] = 0;
                            vector[2] = 0;
                            massCenterPvect.Add(vector);

                            MassCenterMatrixList.Add(CreateMatrixI('x', massList[i], ToDouble(ChangeSep(speedScreenTextBoxGroup[1 + i * 4].Text))));
                        }
                        else //wektor i macierz zerowa
                        {
                            vector[0] = 0;
                            vector[1] = 0;
                            vector[2] = 0;
                            massCenterPvect.Add(vector);

                            MassCenterMatrixList.Add(CreateMatrixI('x', 0, 0));
                        }
                    }
                }
            }

            SendToLabel(massCenterPvect, sdtScreen3LabelGroup1); //wysyłanie wyniku do wyświetlania

            //przyspieszenia liniowe z uwzglednieniem przyspieszenia ziemskiego
            LinearAccelWithG.Clear();
            for (int i = 0; i <= size; i++)
            {
                double[] vector1 = new double[3];
                if (i==0)
                {
                    vector1[0] = 0d;
                    vector1[1] = 0d;
                    vector1[2] = 9.81d; //przyspieszenie ziemskie
                    LinearAccelWithG.Add(vector1);
                }
                else
                {
                    if (speedScreen4CheckBoxGroup[i - 1].Checked == true) //wykrywanie pary postępowej
                    {
                        double[] v = new double[3];
                        double[] a = new double[3];
                        v[0] = 0d;
                        v[1] = 0d;
                        v[2] = ToDouble(ChangeSep(speedScreen4TextBoxGroup[i - 1].Text)); //czytanie wartości prędkości liniowej
                        a[0] = 0d;
                        a[1] = 0d;
                        a[2] = ToDouble(ChangeSep(speedScreen5TextBoxGroup[i - 1].Text)); //czytanie wartości przyspieszenia liniowego

                        double[] one = VectorMultipl(omegaVectorList[i - 1], VectorMultipl(omegaVectorList[i - 1], pVectorList[i - 1]));
                        double[] two = VectorMultipl(epsilonVectorList[i - 1], pVectorList[i - 1]);
                        double[] three = VectorAdd(LinearAccelWithG[i - 1], VectorAdd(one, two));
                        double[] four = VectorAdd(VectorNumberMultipl(VectorMultipl(omegaVectorList[i], v), 2d), a);
                        double[] five = VectorAdd(MatrixVectorMultipl(MatrixTransp(rotationMatrixList[i - 1]), three), four);
                        LinearAccelWithG.Add(five);
                    }
                    else
                    {
                        double[] one = VectorMultipl(omegaVectorList[i - 1], VectorMultipl(omegaVectorList[i - 1], pVectorList[i - 1]));
                        double[] two = VectorMultipl(epsilonVectorList[i - 1], pVectorList[i - 1]);
                        double[] three = VectorAdd(LinearAccelWithG[i - 1], VectorAdd(one, two));
                        LinearAccelWithG.Add(MatrixVectorMultipl(MatrixTransp(rotationMatrixList[i - 1]), three));
                    }
                }
                
            }

            SendToLabel(LinearAccelWithG, sdtScreen3LabelGroup2);

            //Przyspieszenia liniowe środków ciężkości  
            for (int i = 0; i <= size - 1; i++)
            {
                if (speedScreen4CheckBoxGroup[i].Checked == true) //wykrywanie pary postępowej
                {
                    double[] lspeed = new double[3];
                    double[] laccel = new double[3];
                    lspeed[0] = 0d;
                    lspeed[1] = 0d;
                    lspeed[2] = ToDouble(ChangeSep(speedScreen4TextBoxGroup[i].Text)); //czytanie wartości prędkości liniowej

                    laccel[0] = 0d;
                    laccel[1] = 0d;
                    laccel[2] = ToDouble(ChangeSep(speedScreen5TextBoxGroup[i].Text)); //czytanie wartości przyspieszenia liniowego

                    //usunac
                    double[] oi = omegaVectorList[i];
                    double[] Pi = massCenterPvect[i];
                    double[] ei = epsilonVectorList[i];
                    double[] lawGi = LinearAccelWithG[i];
                    double[] oi1 = omegaVectorList[i + 1];
                    double[,] mi1 = rotationMatrixList[i + 1];
                    double[] lsp = lspeed;
                    double[] lacc = laccel;
                    //

                    double[] one = VectorMultipl(omegaVectorList[i], VectorMultipl(omegaVectorList[i], massCenterPvect[i]));
                    double[] two = VectorMultipl(epsilonVectorList[i], massCenterPvect[i]);
                    double[] three = VectorAdd(LinearAccelWithG[i], VectorAdd(one, two));
                    double[] four = VectorNumberMultipl(MatrixVectorMultipl(rotationMatrixList[i], omegaVectorList[i+1]), 2d);
                    double[] five = VectorMultipl(MatrixVectorMultipl(rotationMatrixList[i], lspeed), four);
                    double[] six = VectorAdd(five, MatrixVectorMultipl(rotationMatrixList[i], laccel));
                    double[] seven = VectorAdd(three, six);

                    massCenterLinearAccel.Add(seven);

                }
                else
                {
                    double[] one = VectorMultipl(omegaVectorList[i], VectorMultipl(omegaVectorList[i], massCenterPvect[i]));
                    double[] two = VectorMultipl(epsilonVectorList[i], massCenterPvect[i]);
                    double[] three = VectorAdd(LinearAccelWithG[i], VectorAdd(one, two));
                    massCenterLinearAccel.Add(three);
                }
                
            }

            SendToLabel(massCenterLinearAccel, sdtScreen3LabelGroup3);

            //Siła bezwładności 
            for (int i = 0; i < size; i++)
            {
                Fvect.Add(VectorNumberMultipl(massCenterLinearAccel[i], massList[i]));
            }

            SendToLabel(Fvect, sdtScreen3LabelGroup4);

            //Momenty sił względem środa masy członu 
            for (int i = 0; i < size; i++)
            {
                double[] one = MatrixVectorMultipl(MassCenterMatrixList[i], omegaVectorList[i]);
                double[] two = VectorMultipl(omegaVectorList[i], one);
                double[] three = MatrixVectorMultipl(MassCenterMatrixList[i], epsilonVectorList[i]);
                Nvect.Add(VectorAdd(three, two));
            }

            SendToLabel(Nvect, sdtScreen3LabelGroup5);

            //siły oddziaływania członu
            double[] vector2 = new double[3];
            vector2[0] = 0d;
            vector2[1] = 0d;
            vector2[2] = 0d;
            maleFvect.Add(vector2);
            for (int i = size - 1; i >= 0; i--)
            {
                maleFvect.Add(VectorAdd(MatrixVectorMultipl(rotationMatrixList[i], maleFvect[size - (i + 1)]), Fvect[i]));
            }
            maleFvect.Reverse(); //odwracanie listy

            SendToLabel(maleFvect, sdtScreen3LabelGroup6);

            //Momenty sił oddziaływania członu
            nVectList.Add(vector2);
            for (int i = size - 1; i >= 0; i--)
            {
                double[] one = VectorMultipl(pVectorList[i], MatrixVectorMultipl(rotationMatrixList[i], maleFvect[i + 1]));
                double[] two = VectorMultipl(massCenterPvect[i], Fvect[i]);
                double[] three = VectorAdd(Nvect[i], MatrixVectorMultipl(rotationMatrixList[i], nVectList[size - (i + 1)]));
                double[] four = VectorAdd(three, VectorAdd(two, one));
                nVectList.Add(four);
            }
            nVectList.Reverse();
            SendToLabel(nVectList, sdtScreen3LabelGroup7);

            SendToLabel(maleFvect, sdtScreen3LabelGroup8);
            SendToLabel(nVectList, sdtScreen3LabelGroup9);

        }//count first dinamics task
        private double[,] CreateMatrixI(char sign, double mass, double len)
        {
            //tworzenie macerzy bezwładności, wpisywanie watości w odpowiednie miejsca
            double[,] m = new double[3, 3];
            if(sign=='x')
            {
                //wiersz, kolumna
                m[0, 0] = 0d;
                m[1, 0] = 0d;
                m[2, 0] = 0d;
                m[0, 1] = 0d;
                m[1, 1] = 1d / 12d * mass * Math.Pow(len, 2d);
                m[2, 1] = 0d;
                m[0, 2] = 0d;
                m[1, 2] = 0d;
                m[2, 2] = 1d / 12d * mass * Math.Pow(len, 2d);

                return m;
            }
            else if (sign == 'y')
            {
                //wiersz, kolumna
                m[0, 0] = 1d / 12d * mass * Math.Pow(len, 2d);
                m[1, 0] = 0d;
                m[2, 0] = 0d;
                m[0, 1] = 0d;
                m[1, 1] = 0d;
                m[2, 1] = 0d;
                m[0, 2] = 0d;
                m[1, 2] = 0d;
                m[2, 2] = 1d / 12d * mass * Math.Pow(len, 2d);

                return m;
            }
            else if (sign == 'z')
            {
                //wiersz, kolumna
                m[0, 0] = 1d / 12d * mass * Math.Pow(len, 2d);
                m[1, 0] = 0d;
                m[2, 0] = 0d;
                m[0, 1] = 0d;
                m[1, 1] = 1d / 12d * mass * Math.Pow(len, 2d);
                m[2, 1] = 0d;
                m[0, 2] = 0d;
                m[1, 2] = 0d;
                m[2, 2] = 0d;

                return m;
            }
            else
            {
                return null;
            }
        }
        //funkcja zamieniająca stopnie na radiany
        private double Rad(double ang)
        {
            
            return (ang * 2 * Math.PI) / 360;
        }
        //funkcja zamieniająca napis na liczbę zmiennoprzecinkową
        private double ToDouble(string s)
        {
            var num = 0d;
            Double.TryParse(s, out num);

            return num;
        }
        private double[,] MatrixMulti(double[,] matrix1, double[,] matrix2)
        {
            //mnożenie macierzy
            int Asize_x = matrix1.GetLength(0);
            int Asize_y = matrix1.GetLength(1);
            int Bsize_x = matrix2.GetLength(0);
            int Bsize_y = matrix2.GetLength(1);

            //sprawdzenie warunku mnożenia macierzy
            if (Asize_x == Bsize_y)
            {
                double[,] finalMatrix = new double[Bsize_x, Asize_y];
                int size = Asize_x;
                double record = 0f;

                for (int y = 0; y < Asize_y; y++)
                {
                    for (int x = 0; x < Bsize_x; x++)
                    {
                        for (int i = 0; i < size; i++)
                        {
                            record += matrix1[i, y] * matrix2[x, i];
                        }
                        finalMatrix[x, y] = record;
                        record = 0;
                    }
                }

                return finalMatrix;
            }
            else
            {
                return null;
            }


        }
        private double[,] MatrixTransp(double[,] matrix1)
        {
            //transponowanie macierzy
            int size_x = matrix1.GetLength(0);
            int size_y = matrix1.GetLength(1);
            double[,] finalMatrix = new double[size_x, size_y];

            for (int j = 0; j < size_y; j++)
            {
                for (int i = 0; i < size_x; i++)
                {
                    finalMatrix[i, j] = matrix1[j, i];
                }
            }

            return finalMatrix;
        }
        private double[] VectorMultipl(double[] a, double[] b)
        {
            //mnożenie wektorowe
            double[] c = new double[3];

            c[0] = (a[1] * b[2]) - (a[2] * b[1]);
            c[1] = (a[2] * b[0]) - (a[0] * b[2]);
            c[2] = (a[0] * b[1]) - (a[1] * b[0]);

            return c;
        }
        private double[] MatrixVectorMultipl(double[,] M, double[] v)
        {
            //mnożenie macierzy i wektora
            double[] final = new double[3];

            for (int j = 0; j < 3; j++)
            {
                for (int i = 0; i < 3; i++)
                {
                    final[j] += M[i, j] * v[i];
                }
            }


            return final;
        }
        private double[] VectorAdd(double[] a, double[] b)
        {
            //dodawanie wektorów
            double[] c = new double[3];

            c[0] = a[0] + b[0];
            c[1] = a[1] + b[1];
            c[2] = a[2] + b[2];

            return c;
        }
        private double[] VectorNumberMultipl(double[] v, double n)
        {
            //mnożenie wektora przez liczbę
            for (int i = 0; i < v.Length; i++)
            {
                v[i] = v[i] * n;
            }

            return v;
        }
        private double VectorValue(double[] a)
        {
            //długość wektora
            return Math.Sqrt(Math.Pow(a[0], 2) + Math.Pow(a[1], 2) + Math.Pow(a[2], 2)); 
        }
        private void DrawRobot(object sender, PaintEventArgs e)//List<int> robotClasses, 
        {
            Color black = Color.FromArgb(255, 0, 0, 0);
            Pen blackPen = new Pen(black);

            e.Graphics.DrawLine(blackPen, 0, 0, 800, 200);

        }
    }
}

      