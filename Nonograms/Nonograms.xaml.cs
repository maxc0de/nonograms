﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Nonograms
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Random random = new Random(42);
        static GameField game;
        static GameField empty;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreateGameField(string s)
        {
            List<string[]> nonogram = Regex.Split(s, "\r\n").Select(we => we.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)).ToList();

            game = new GameField(nonogram);
            empty = game.GetEmpty();

            Top.Children.Clear();
            Left.Children.Clear();
            Game.Children.Clear();

            Top.Children.Add(game.GetGameFieldRows());
            Left.Children.Add(game.GetGameFieldColumns());
            Game.Children.Add(empty);


            this.SizeToContent = SizeToContent.WidthAndHeight;
        }
        private void ReadFromFile(FileInfo file)
        {
            string s = "";

            using (StreamReader sr = new StreamReader(file.FullName))
            {
                s = sr.ReadToEnd();
            }

            List<string[]> nonogram = Regex.Split(s, "\r\n").Select(we => we.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)).ToList();

            game = new GameField(nonogram);
            empty = game.GetEmpty();

            Top.Children.Clear();
            Left.Children.Clear();
            Game.Children.Clear();

            Top.Children.Add(game.GetGameFieldRows());
            Left.Children.Add(game.GetGameFieldColumns());
            Game.Children.Add(empty);


            this.SizeToContent = SizeToContent.WidthAndHeight;
        }
        private void SaveToFile(GameField field)
        {
            using (StreamWriter sw = new StreamWriter($"{random.Next()}.txt", false))
            {

                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (field.cells[i, j].Marked == true)
                        {
                            sw.Write($"1 ");
                        }
                        else
                        {
                            sw.Write($"0 ");
                        }

                    }
                    sw.WriteLine();
                }
            }
        }

        public static void CheckEquals(object sender, EventArgs e)
        {
            if (game.Equals(empty))
            {
                empty.Win();
            }
        }
        private void MenuItem_Click_0(object sender, RoutedEventArgs e)
        {
            //ReadFromFile(new FileInfo("Resources\\1.txt"));
            CreateGameField("0 0 1 0 0 \r\n0 1 1 1 0 \r\n1 1 1 1 1 \r\n0 0 1 0 0 \r\n0 0 1 1 0 \r\n");
        }
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            //ReadFromFile(new FileInfo("Resources\\1.txt"));
            CreateGameField("0 0 1 0 1 0 0 0 0 0 \r\n0 1 1 0 1 1 0 0 0 0 \r\n0 1 1 1 1 1 0 0 0 0 \r\n1 1 0 1 0 1 1 0 0 1 \r\n0 1 1 1 1 1 0 0 1 1 \r\n0 0 1 1 1 0 0 0 1 0 \r\n1 1 1 1 1 1 0 0 1 1 \r\n1 0 1 1 1 1 1 0 0 1 \r\n0 0 1 1 1 1 1 1 1 1 \r\n0 1 1 0 1 1 1 1 0 0 \r\n");
        }
        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            //ReadFromFile(new FileInfo("Resources\\2.txt"));
            CreateGameField("0 0 0 1 1 1 1 0 0 0 \r\n0 1 1 1 1 1 1 1 1 0 \r\n1 1 0 1 1 1 1 0 1 1 \r\n1 0 0 0 1 1 0 0 0 1 \r\n1 0 1 0 1 1 0 1 0 1 \r\n1 0 0 0 1 1 0 0 0 1 \r\n1 1 1 1 1 1 1 1 1 1 \r\n0 1 1 1 1 1 1 1 1 0 \r\n0 0 1 1 0 0 1 1 0 0 \r\n0 0 1 1 0 0 1 1 0 0 \r\n");
        }
        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            //ReadFromFile(new FileInfo("Resources\\3.txt"));
            CreateGameField("0 0 0 1 1 0 0 0 0 0 1 1 0 0 0 \r\n0 0 1 1 1 1 0 0 0 1 1 1 1 0 0 \r\n0 1 1 1 1 1 1 0 1 1 1 1 1 1 0 \r\n1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 \r\n1 0 0 0 1 1 0 1 0 1 1 0 1 0 1 \r\n1 1 0 1 1 0 0 0 0 0 1 0 1 0 1 \r\n1 1 0 1 1 1 0 0 0 1 1 0 1 0 1 \r\n1 0 0 0 1 1 1 0 1 1 1 0 0 0 1 \r\n0 1 1 1 1 1 1 1 1 1 1 1 1 1 0 \r\n0 0 1 1 1 1 1 1 1 1 1 1 1 0 0 \r\n0 0 0 1 1 1 1 1 1 1 1 1 0 0 0 \r\n0 0 0 0 1 1 1 1 1 1 1 0 0 0 0 \r\n0 0 0 0 0 1 1 1 1 1 0 0 0 0 0 \r\n0 0 0 0 0 0 1 1 1 0 0 0 0 0 0 \r\n0 0 0 0 0 0 0 1 0 0 0 0 0 0 0 \r\n");
        }
        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            //ReadFromFile(new FileInfo("Resources\\4.txt"));
            CreateGameField("0 0 0 0 0 0 0 0 0 0 0 0 0 1 1 1 1 1 1 1 0 \r\n0 0 0 0 0 0 0 0 0 0 0 0 1 1 0 1 1 1 1 1 1 \r\n0 0 0 0 0 0 0 0 0 0 0 0 1 1 1 1 1 1 1 1 1 \r\n0 0 0 0 0 0 0 0 0 0 0 0 1 1 1 1 1 1 1 1 1 \r\n0 0 0 0 0 0 0 0 0 0 0 0 1 1 1 1 0 0 0 0 0 \r\n0 0 0 0 0 0 0 0 0 0 0 0 1 1 1 1 1 1 0 0 0 \r\n0 0 0 0 0 0 0 0 0 0 0 1 1 1 1 0 0 0 0 0 0 \r\n1 0 0 0 0 0 0 0 0 0 1 1 1 1 1 0 0 0 0 0 0 \r\n1 0 0 0 0 0 0 0 1 1 1 1 1 1 1 1 1 0 0 0 0 \r\n1 1 0 0 0 0 1 1 1 1 1 1 1 1 1 0 1 0 0 0 0 \r\n1 1 1 0 0 1 1 1 1 1 1 1 1 1 1 0 0 0 0 0 0 \r\n1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 0 0 0 0 0 0 \r\n1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 0 0 0 0 0 0 \r\n0 1 1 1 1 1 1 1 1 1 1 1 1 1 0 0 0 0 0 0 0 \r\n0 0 1 1 1 1 1 1 1 1 1 1 1 0 0 0 0 0 0 0 0 \r\n0 0 0 1 1 1 1 1 1 1 1 1 0 0 0 0 0 0 0 0 0 \r\n0 0 0 0 1 1 1 1 1 1 1 1 0 0 0 0 0 0 0 0 0 \r\n0 0 0 0 0 1 1 1 0 0 1 1 0 0 0 0 0 0 0 0 0 \r\n0 0 0 0 0 1 1 0 0 0 0 1 0 0 0 0 0 0 0 0 0 \r\n0 0 0 0 0 1 0 0 0 0 0 1 0 0 0 0 0 0 0 0 0 \r\n0 0 0 0 0 1 1 0 0 0 0 1 1 0 0 0 0 0 0 0 0 \r\n");
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            //Диалог сколько клеток


            game = new GameField(10);
            empty = game.GetEmpty();

            Top.Children.Clear();
            Left.Children.Clear();
            Game.Children.Clear();

            Game.Children.Add(empty);

            this.SizeToContent = SizeToContent.WidthAndHeight;
        }
        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            //Диалог куда сохранить
            SaveToFile(empty);
        }
    }
}
