using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp2.GUI
{
    using System.Collections.ObjectModel;
    using System.Data;

    using MuSearch.BusinessLayer;

    using WpfApp2.General;

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
        private UserInput userInputBL;
        List<CheckBox> CategoryBoxes;

        private List<Category> categoryOptions;

        private List<Category> categories;

        public UserInputWindow(int userId)
        {
            InitializeComponent();
            this.userInputBL = new UserInput();
            this.userId = userId;
            this.categories = new List<Category>();
            CategoryBoxes = new List<CheckBox>();
            this.categoryOptions = new List<Category>();
            this.TheList = new ObservableCollection<BoolStringClass>();
        }
        
        private void CheckBoxZone_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox chkZone = (CheckBox)sender;
            int i = Int32.Parse(chkZone.Tag.ToString());
            this.categories.Add(this.categoryOptions[i]);
            ZoneText.Text = "Selected So Far= " + String.Join(", ", this.categoryOptions[i].CategoryName);
        }
        private void CheckBoxZone_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox chkZone = (CheckBox)sender;
            int i = Int32.Parse(chkZone.Tag.ToString());
            this.categories.Remove(this.categoryOptions[i]);
            ZoneText.Text = "Selected So Far= " + String.Join(", ", this.categoryOptions[i].CategoryName);
        }
        public void CreateCheckBoxList()
        {
            TheList.Clear();
            categoryOptions = this.userInputBL.generateCategories(this.txtUserInput.Text);
            if (this.categoryOptions.Count!= 0)
            {
                for (int i = 0; i < categoryOptions.Count; i++)
                {
                    TheList.Add(new BoolStringClass { TheText = categoryOptions[i].Categories + " " + categoryOptions[i].CategoryName+" (from " + categoryOptions[i].Input+ " "+ this.txtUserInput.Text + ")", TheValue = i });
                }
                this.DataContext = this;
            }
            else
            {
                // pop up error
                MessageBox.Show("Sorry, this name doesn't exist in our database!");
            }
        }
        private void btnSubmitClick(object sender, RoutedEventArgs e)
        {
            this.CreateCheckBoxList();
        }
        

        private void btnSubmitClick2(object sender, RoutedEventArgs e)
        {
            
            //go to next page

            MainWindow gameMainWindow = new MainWindow(this.userId, this.categories); //for compilation
            gameMainWindow.Show();
            this.Close();
        }
    }
}
