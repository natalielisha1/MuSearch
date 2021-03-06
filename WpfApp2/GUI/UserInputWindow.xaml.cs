﻿namespace WpfApp2.GUI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Collections.ObjectModel;
    using WpfApp2.BusinessLayer;
    using WpfApp2.BusinessLayer.Interfaces;
    using Musearch;

    /// <summary>
    /// Interaction logic for UserInput.xaml
    /// </summary>
    public partial class UserInputWindow : Window
    {
        public class BoolStringClass
        {
            public string TheText { get; set; }
            public int TheValue { get; set; }
        }
        

        public ObservableCollection<BoolStringClass> TheList { get; set; }
        public string categoryInput { get; set; }
        private int userId;

        private ISongs songsBL;
        private ICategories categoriesBL;
        List<CheckBox> CategoryBoxes;
        private List<Category> categoryOptions;
        private List<Category> categories;

        /// <summary>
        /// Constructor for the UserInputWindow object
        /// </summary>
        /// <param name="userId">the current user's ID</param>
        public UserInputWindow(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            this.categories = new List<Category>();
            this.CategoryBoxes = new List<CheckBox>();
            this.categoryOptions = new List<Category>();
            this.TheList = new ObservableCollection<BoolStringClass>();
            this.categoriesBL = Container.Instance.categoriesBL;
            this.songsBL = Container.Instance.songsBL;
        }
        
        /// <summary>
        /// one of the radio buttons is checked
        /// </summary>
        /// <param name="sender">the object that send the event</param>
        /// <param name="e">arguments</param>
        private void CheckBoxZone_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox chkZone = (CheckBox)sender;
            int i = Int32.Parse(chkZone.Tag.ToString());
            this.categories.Add(this.categoryOptions[i]);
        }

        /// <summary>
        /// one of the radio buttons is Unchecked
        /// </summary>
        /// <param name="sender">the object that send the event</param>
        /// <param name="e">arguments</param>
        private void CheckBoxZone_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox chkZone = (CheckBox)sender;
            int i = Int32.Parse(chkZone.Tag.ToString());
            this.categories.Remove(this.categoryOptions[i]);
        }

        /// <summary>
        /// creating the list for the user to see on the option for categories
        /// </summary>
        public void CreateCheckBoxList()
        {
            try
            {
                TheList.Clear();
                categoryOptions = this.categoriesBL.checkCategories(this.txtUserInput.Text);
                if (this.categoryOptions.Count != 0)
                {
                    for (int i = 0; i < categoryOptions.Count; i++)
                    {
                        TheList.Add(new BoolStringClass
                        {
                            TheText =
                            categoryOptions[i].Categories + " " + categoryOptions[i].CategoryName + " (from " + categoryOptions[i].Input + " " + this.txtUserInput.Text + "), amount: " + categoryOptions[i].Count,
                            TheValue = i
                        });
                    }
                    this.DataContext = this;
                }
                else
                {
                    // pop up error
                    MessageBox.Show("Sorry, this name doesn't exist in our database!");
                }
            }catch(Exception exe)
            {
                MessageBox.Show("System Error. \r\nTry again later.");
                this.Close();
            }
        }

        /// <summary>
        /// once the user typed his word we create the options for him
        /// </summary>
        /// <param name="sender">the object that send the event</param>
        /// <param name="e">arguments</param>
        private void btnSubmitClick(object sender, RoutedEventArgs e)
        {
            this.CreateCheckBoxList();
        }

        /// <summary>
        /// after the user choose all his categories he can start the game
        /// </summary>
        /// <param name="sender">the object that send the event</param>
        /// <param name="e">arguments</param>
        private void btnGenerateClick(object sender, RoutedEventArgs e)
        {
            if (this.categories.Count == 0)
                MessageBox.Show("You have to choose at least one category for the game.");

            else
            {
                //go to next page
                MainWindow gameMainWindow = new MainWindow(this.userId, this.categories);
                gameMainWindow.Show();
                this.Close();
            }
        }

        /// <summary>
        /// clicking on the back button
        /// </summary>
        /// <param name="sender">the object that send the event</param>
        /// <param name="e">arguments</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //go to home page
            WpfApp2.GUI.Menu gameMainWindow = new WpfApp2.GUI.Menu(this.userId);
            gameMainWindow.Show();
            this.Close();
        }

        /// <summary>
        /// clicking the surprise me button
        /// </summary>
        /// <param name="sender">the object that send the event</param>
        /// <param name="e">arguments</param>
        private void supriseMe_click(object sender, RoutedEventArgs e)
        {
            // choosing randomly the catagory type. 1 for artists, 2 for albums
            int catType;
            Random rand = new Random();
            catType = rand.Next(1, 3);
            try
            {
                // do while the category get words. don't want a 0 words word search
                do
                {
                    this.categories.Clear();
                    switch (catType)
                    {
                        case 1:
                            this.categories.Add(this.categoriesBL.randomCategory("artists"));
                            break;
                        case 2:
                            this.categories.Add(this.categoriesBL.randomCategory("albums"));
                            break;
                        default:
                            break;
                    }
                } while (this.songsBL.GetWords(this.categories).Count() == 0);
                MainWindow gameMainWindow = new MainWindow(this.userId, this.categories);
                gameMainWindow.Show();
                this.Close();
            }catch(Exception ex)
            {
                MessageBox.Show("System Error. \r\nTry again later.");
                this.Close();
            }
        }
        
    }
}
