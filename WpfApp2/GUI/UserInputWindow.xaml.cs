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

        private List<string> categories;

        public UserInputWindow(int userId)
        {
            InitializeComponent();
            this.userInputBL = new UserInput();
            this.userId = userId;
            this.categories = new List<string>();
            CategoryBoxes = new List<CheckBox>();
        }
        
        private void CheckBoxZone_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox chkZone = (CheckBox)sender;
            this.categories.Add(chkZone.Content.ToString());
            ZoneText.Text = "Selected So Far= " + String.Join(", ", this.categories.ToArray());
        }
        private void CheckBoxZone_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox chkZone = (CheckBox)sender;
            this.categories.Remove(chkZone.Content.ToString());
            ZoneText.Text = "Selected So Far= " + String.Join(", ", this.categories.ToArray());
        }
        public void CreateCheckBoxList()
        {
            //string valid = this.userInputBL.generateCategories(this.txtUserInput.Text);

            TheList = new ObservableCollection<BoolStringClass>();
            List<string> ifatList = new List<string>();
            ifatList.Add("ifat");
            ifatList.Add("ifat2");
            ifatList.Add("ifat3");
            //if (valid != null)
            {
                for (int i = 0; i < ifatList.Count; i++)
                {
                    TheList.Add(new BoolStringClass { TheText = ifatList[i], TheValue = i });
                }
                this.DataContext = this;
            }
            //else
            {
                // pop up error
                //MessageBox.Show("Sorry, this song doesn't exist in our database!");
            }
        }
        private void btnSubmitClick(object sender, RoutedEventArgs e)
        {
            this.CreateCheckBoxList();
        }
        

        private void btnSubmitClick2(object sender, RoutedEventArgs e)
        {
            List<string> checkedCategories = new List<string>();
            //check which categories were checked and add them the list
            for (int i = 0; i < CategoryBoxes.Count; i++) {
                if (CategoryBoxes[i].IsChecked == true)
                {
                    //checkedCategories.Add(CategoryBoxes[i].Text);
                }
            }
            //TODO: do something with the checkedCategories
            //go to next page

            MainWindow gameMainWindow = new MainWindow(this.userId, ""); //for compilation
            gameMainWindow.Show();
            this.Close();
        }
    }
}
