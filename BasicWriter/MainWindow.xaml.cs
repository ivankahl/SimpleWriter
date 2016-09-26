using Microsoft.Win32;
using System;
using System.Collections.Generic;
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

namespace SimpleWriter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Document doc;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void lblNew_MouseEnter(object sender, MouseEventArgs e)
        {
            (sender as TextBlock).Foreground = new SolidColorBrush(Color.FromRgb(214, 214, 214));
        }

        private void lblNew_MouseLeave(object sender, MouseEventArgs e)
        {
            (sender as TextBlock).Foreground = new SolidColorBrush(Color.FromRgb(93, 93, 93));
        }

        private void Save()
        {
            doc.Save();
            lblSave.Text = "Save";
        }

        private void lblNew_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SaveFileDialog sfdNew = new SaveFileDialog();
            sfdNew.Filter = "Text Document (*.txt)|*.txt|All Files (*.*)|*.*";
            
            if (sfdNew.ShowDialog() == true)
            {
                doc = new Document(sfdNew.FileName);
                txtContent.IsEnabled = true;
                txtTitle.IsEnabled = true;
                lblSave.IsEnabled = true;

                txtContent.Text = doc.Content;
                txtTitle.Text = doc.Title;
                lblSave.Text = "Save";
            }
        }

        private void lblOpen_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog ofdOpen = new OpenFileDialog();
            ofdOpen.Filter = "Text Document (*.txt)|*.txt|All Files (*.*)|*.*";

            if (ofdOpen.ShowDialog() == true)
            {
                doc = new Document(ofdOpen.FileName);
                txtContent.IsEnabled = true;
                txtTitle.IsEnabled = true;
                lblSave.IsEnabled = true;

                txtContent.Text = doc.Content;
                txtTitle.Text = doc.Title;
                lblSave.Text = "Save";
            }
        }

        private void lblSave_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Save();
        }

        private void txtContent_TextChanged(object sender, TextChangedEventArgs e)
        {
            doc.Content = txtContent.Text;
            lblSave.Text = "\u25CF Save";

            int wordCount = doc.CalculateWordCount();

            if (wordCount == 1)
                lblStats.Text = wordCount.ToString() + " word";
            else
                lblStats.Text = wordCount.ToString() + " words";
        }

        private void txtTitle_TextChanged(object sender, TextChangedEventArgs e)
        {
            doc.Title = txtTitle.Text;
            lblSave.Text = "\u25CF Save";
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Save();
        }
    }
}
